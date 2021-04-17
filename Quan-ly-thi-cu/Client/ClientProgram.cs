using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;
using Core;
using System.Threading;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Client
{
	public class ClientProgram
	{
		IPEndPoint IP;
		Socket client;
		string serverPath = null; // Đường dẫn lưu trữ bài làm ở phía server


		public Action<string> onNhanThongBao;
		public Action<List<Student>> onNhanDanhSachSVTuExcel;

		string savePath = null; // Thu muc luu de thi

		public Action<int> onNhanSoPhut;

		event Action<List<string>> _onCamChuongTrinh;
		public event Action<List<string>> OnCamChuongTrinh
		{
			add { _onCamChuongTrinh += value; }
			remove { _onCamChuongTrinh -= value; }
		}
		event Action<string> _onSuccessNotification;
		public event Action<string> OnSuccessNotification
		{
			add
			{
				_onSuccessNotification += value;
			}
			remove
			{
				_onSuccessNotification -= value;
			}
		}

		event Action<string, Exception> _onErrorNotification;
		public event Action<string, Exception> OnErrorNotification
		{
			add
			{
				_onErrorNotification += value;
			}
			remove
			{
				_onErrorNotification -= value;
			}
		}

		event Action<string> _onReceivedExam;
		public event Action<string> OnReceivedExam
		{
			add
			{
				_onReceivedExam += value;
			}
			remove
			{
				_onReceivedExam -= value;
			}
		}

		public void SendStudent(Student student)
		{
			DataContainer container = new DataContainer(DataContainerType.SendStudent, student);

			SendDataToServer(container);
			if (_onSuccessNotification != null)
				_onSuccessNotification("Student information is sent");
		}

		public void SetClientPath(string serverPath)
		{
			//lưu đường dẫn thu bài ở phía Server
			this.serverPath = @"D:\serverPath";
		}
		//
		public void Connect(string hostname, int port)
		{
			IP = new IPEndPoint(IPAddress.Parse(hostname), port);
			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			string computerName = System.Environment.MachineName;

			try
			{
				client.Connect(IP);

				if (_onSuccessNotification != null)
					_onSuccessNotification("Connected");

				DataContainer container = new DataContainer(DataContainerType.SendPcName, computerName);
				SendDataToServer(container);

				Thread listen = new Thread(Receive);
				listen.IsBackground = true;
				listen.Start();
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("Cant connect to Server", ex);
			}
		}

		void SendDataToServer(DataContainer container)
		{
			try
			{
				if (container == null)
					throw new ArgumentException("Empty Data");

				client.Send(container.Serialize());
			}
			catch (ArgumentException ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("The submitted data is invalid", ex);
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("An error occur while trying to sent data to server", ex);
			}
		}


		public void CloseConnection()
		{
			if (client != null)
				client.Close();
		}

		public void NopBaiThi(List<string> danhSachDeThi)
		{
			List<Socket> clientList = new List<Socket>();

			if (danhSachDeThi.Count == 0)
				return;
			List<FileContainer> listOfFiles = new List<FileContainer>();
			foreach (string deThiURL in danhSachDeThi)
			{
				listOfFiles.Add(new FileContainer(deThiURL, this.serverPath));
			}
			if (danhSachDeThi.Count == 1)
			{
				FileContainer fileDeThi = listOfFiles[0];
				foreach (Socket client in clientList)
				{
					DataContainer container = new DataContainer(DataContainerType.NopBai, fileDeThi);
					client.Send(container.Serialize());
				}
			}

			if (danhSachDeThi.Count > 1)
			{
				int soLuongDeThi = danhSachDeThi.Count;

				int counter = 0;

				foreach (Socket client in clientList)
				{
					DataContainer container = new DataContainer(DataContainerType.PhatDe, listOfFiles[counter]);
					client.Send(container.Serialize());

					counter++;

					if (counter == soLuongDeThi)
						counter = 0;
				}
			}
		}

		void Receive()
		{
			try
			{
				while (true)
				{
					byte[] buffer = new byte[1024 * 1024 * 20];
					client.Receive(buffer);

					DataContainer dataContainer = DataContainer.Deserialize(buffer);

					switch (dataContainer.Type)
					{
						case DataContainerType.PhatDe:

							FileContainer fileContainer = dataContainer.Data as FileContainer;

							string savePath = fileContainer.SavePath;
							this.savePath = fileContainer.SavePath;

							if (Directory.Exists(savePath))
								Core.DirectoryHelper.DeleteAllFileInDirectory(savePath);

							Directory.CreateDirectory(savePath);

							string fileName = fileContainer.FileInfo.Name;

							string fullPath = Path.Combine(savePath, fileName);
							byte[] fileContent = fileContainer.FileContent;

							using (var fileStream = File.Create(fullPath))
							{
								fileStream.Write(fileContent, 0, fileContent.Length);
							}

							if (_onReceivedExam != null)
								_onReceivedExam(fullPath);

							if (_onSuccessNotification != null)
								_onSuccessNotification("Recieved");

							break;

						case DataContainerType.ThuBai:

							// Khong co duong dan chua de thi
							if (string.IsNullOrWhiteSpace(this.savePath))
							{
								// Handle error
								break;
							}

							// Khong co thu muc luu bai thi
							if (!Directory.Exists(this.savePath))
							{
								// Handle error
								if (_onErrorNotification != null)
								{
									string msg = "Cant find exam folder at: " + this.savePath;

									_onErrorNotification(msg, null);
								}

								break;
							}

							List<string> allowFileExtensions = new List<string>()
							{
								".zip",
								".7z",
								".rar"
							};

							// Tim file .zip trong thu muc luu bai thi
							DirectoryInfo d = new DirectoryInfo(this.savePath);
							FileInfo[] Files = d.GetFiles("*.*");

							string fileNopBai = null;
							foreach (FileInfo file in Files)
							{
								string filename = file.Name;
								string extension = Path.GetExtension(filename);

								if (allowFileExtensions.Contains(extension))
								{
									fileNopBai = file.FullName;
									break;
								}
							}

							if (string.IsNullOrWhiteSpace(fileNopBai))
							{
								if (_onErrorNotification != null)
									_onErrorNotification("Cant find folder", null);

								break;
							}

							// Gui file .zip len server
							FileContainer fileNopBaiContainer = new FileContainer(fileNopBai, null);

							DataContainer dataContainerNopBai = new DataContainer(DataContainerType.ThuBai, fileNopBaiContainer);

							SendDataToServer(dataContainerNopBai);

							break;

						case DataContainerType.SendList:
							break;
						case DataContainerType.GuiDanhSachSV:

							List<Student> students = dataContainer.Data as List<Student>;
							onNhanDanhSachSVTuExcel(students);
							break;

						case DataContainerType.GuiThongBaoAll:

							string message = dataContainer.Data.ToString();

							onNhanThongBao(message);

							break;
						case DataContainerType.SendPcName:
							break;

						case DataContainerType.DisconnectAll:

							if (_onSuccessNotification != null)
								_onSuccessNotification("Server is not responding");

							CloseConnection();
							break;

						case DataContainerType.BeginExam:
							int minnute = Convert.ToInt32(dataContainer.Data);

							if (onNhanSoPhut != null)
								onNhanSoPhut(minnute);
							break;
						case DataContainerType.BlockProgram:
							List<string> programs = dataContainer.Data as List<string>;

							if (_onCamChuongTrinh != null)
								_onCamChuongTrinh(programs);
							break;

						case DataContainerType.FinishExam:
							break;

						case DataContainerType.LockClient:
							break;
						case DataContainerType.Undefined:
							break;
						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
				{
					string msg = "Cant contact to Server. Disconnected";
					_onErrorNotification(msg, ex);
				}

                CloseConnection();
            }
		}	
	}
}
