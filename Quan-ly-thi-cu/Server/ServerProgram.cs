using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using Core;

namespace Server
{
	public class ServerProgram
	{
		private const int PORT = 2010;
		private const int BUFFER_SIZE = 1 * 1024 * 1024 * 20; // 20Mb

		IPEndPoint IP;
		Socket server;
		List<Socket> clientList;

		string clientPath = null; // Đường dẫn lưu trữ đề thi ở phía client
		string serverPath = null; // Đường dẫn lưu trữ bài làm ở phía server

		ClientInfoManager clientInfoManager;

		public ServerProgram()
		{
			//tại sao phải tạo 1 list Socket
			clientList = new List<Socket>();
			clientInfoManager = new ClientInfoManager();
		}
		//chưa hiểu action
		#region Events
		event Action<string> _onNotification;
		public event Action<string> OnNotification
		{
			add { _onNotification += value; }
			remove { _onNotification -= value; }
		}

		event Action<List<ClientInfo>> _onClientListChanged;
		public event Action<List<ClientInfo>> OnClientListChanged
		{
			add
			{
				_onClientListChanged += value;
			}
			remove
			{
				_onClientListChanged -= value;
			}
		}

		event Action<IPEndPoint> _onServerStarted;
		public event Action<IPEndPoint> OnServerStarted
		{
			add
			{
				_onServerStarted += value;
			}
			remove
			{
				_onServerStarted -= value;
			}
		}

		public Action<Student> onNhanSinhVien;

		#endregion

		#region Init client info list
		//tất cả thông tin của client mà FrmSetIPRange đã tạo ra
		public void SetClientInfoList(string FirstIP, string LastIP, string SubnetMask)
		{
			clientInfoManager = new ClientInfoManager(FirstIP, LastIP, SubnetMask);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);
		}
		//override SetClientInfoList bằng số tổng các máy con
		public void SetClientInfoList(int numberOfClients)
		{
			clientInfoManager = new ClientInfoManager(numberOfClients);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);
		}

		#endregion

		#region Start server

		public void Start()
		{
			//này đã học rồi
			IP = new IPEndPoint(IPAddress.Any, PORT);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			server.Bind(IP);//vì cái Bind này là chạy trên nền socket (Endpoint) nên phải tạo IP này là IPEndPoint
			//cần tìm hiểu cái thread này thêm
			Thread listen = new Thread(StartServer)
			{
				IsBackground = true
			};

			listen.Start();

			IPEndPoint serverIP = null;

			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					serverIP = new IPEndPoint(ip, PORT);
					break;
				}
			}

			if (_onServerStarted != null && serverIP != null)
				_onServerStarted(serverIP);
		}

		void StartServer()
		{
			try
			{
				while (true)
				{
					server.Listen(100);

					Socket clientSocket = server.Accept();

					clientList.Add(clientSocket);

					string clientIP = clientSocket.RemoteEndPoint.ToString().Split(':')[0];

					ClientInfo newClient = new ClientInfo()
					{
						Endpoint = clientSocket.RemoteEndPoint as IPEndPoint,
						ClientIP = clientIP,
						Status = ClientInfoStatus.ClientConnected
					};

					// Thêm mới nếu chưa có, tự cập nhật nếu đã có
					clientInfoManager.Add(newClient);

					if (_onClientListChanged != null)
						_onClientListChanged(clientInfoManager.Clients);

					Thread receive = new Thread(Receive);
					receive.IsBackground = true;
					receive.Start(clientSocket);
				}
			}
			catch (Exception ex)
			{
				IP = new IPEndPoint(IPAddress.Any, PORT);
				server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			}
		}

		#endregion

		#region Receive and close server connection

		public void CloseConnection()
		{
			server.Close();
		}

		void Receive(object obj)
		{
			Socket client = obj as Socket;
			string clientIP = client.RemoteEndPoint.ToString().Split(':')[0];
			ClientInfo clientInfo = clientInfoManager.Find(clientIP);

			try
			{
				while (true)
				{
					byte[] buffer = new byte[BUFFER_SIZE];
					client.Receive(buffer);

					DataContainer dataContainer = DataContainer.Deserialize(buffer);

					switch (dataContainer.Type)
					{
						case DataContainerType.SendPcName:

							string pcName = dataContainer.Data as string;
							clientInfo.PCName = pcName;
							clientInfo.Status = ClientInfoStatus.ClientConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.SendStudent:
							Student student1 = dataContainer.Data as Student;

							clientInfo.StudentInfo = student1;
							clientInfo.Status = ClientInfoStatus.StudentConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.ThuBai:

							FileContainer fileNopBaiContainer = dataContainer.Data as FileContainer;

							string savePath = this.serverPath;

							if (!Directory.Exists(savePath))
								Directory.CreateDirectory(savePath);

							string fileName = fileNopBaiContainer.FileInfo.Name;
							string fullPath = Path.Combine(savePath, fileName);

							byte[] fileContent = fileNopBaiContainer.FileContent;

							using (var fileStream = File.Create(fullPath))
								fileStream.Write(fileContent, 0, fileContent.Length);

							break;

						case DataContainerType.SendList:
							break;

						case DataContainerType.SendString:
							break;

						case DataContainerType.BeginExam:
							break;

						case DataContainerType.FinishExam:
							break;

						case DataContainerType.LockClient:
							break;

						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				clientInfo.Status = ClientInfoStatus.Disconnected;

				if (_onClientListChanged != null)
					_onClientListChanged(clientInfoManager.Clients);

				clientList.Remove(client);
				client.Close();
			}
		}

		#endregion

		#region Methods

		public void CamChuongTrinh(List<string> programs)
		{
			DataContainer container = new DataContainer(DataContainerType.BlockProgram, programs);

			foreach (Socket item in clientList)
			{
				item.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("List of locking program have send");
		}

		public void batDauLamBai(int sophut)
		{
			DataContainer container = new DataContainer(DataContainerType.BeginExam, sophut);
			foreach (Socket item in clientList)
			{
				item.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("Begin examination");
		}

		public void GuiTinNhanChoTatCaMayCon(string tinNhan)
		{
			DataContainer dataContainer = new DataContainer(DataContainerType.GuiThongBaoAll, tinNhan);

			byte[] buffer = dataContainer.Serialize();

			foreach (Socket item in clientList)
			{
				item.Send(buffer);
			}
		}
		public void GuiDanhSachSinhVien(List<Student> students)
		{
			DataContainer dataContainer = new DataContainer(DataContainerType.GuiDanhSachSV, students);

			byte[] buffer = dataContainer.Serialize();

			foreach (Socket item in clientList)
			{
				item.Send(buffer);
			}
		}
		public void SetClientPath(string clientPath)
		{
			this.clientPath = clientPath;
		}

		public void SetServerPath(string serverPath)
		{
			//lưu đường dẫn thu bài ở phía Server
			this.serverPath = serverPath;
		}
		

		public void PhatDeThi(List<string> danhSachDeThi)
		{
			//nếu danh sách đề thi mà không có gì cả thì ngắt kết nối
			if (danhSachDeThi.Count == 0)
				return;
			//tạo danh sách của FileContainer để lưu 
			List<FileContainer> listOfFiles = new List<FileContainer>();
			//với mỗi phần tử của danhSachDeThi
			foreach (string deThiURL in danhSachDeThi)
			{
				//sẽ gửi các phần tử của listOfFiles vào danhSachDeThi và lưu ngay trên constructor của FileContainer
				listOfFiles.Add(new FileContainer(deThiURL, this.clientPath));
			}
			//neeus chi cos 1 de
			if (danhSachDeThi.Count == 1)
			{
				//lấy phần tử đầu tiên của FileContainer
				FileContainer fileDeThi = listOfFiles[0];
				//này hiểu nhưng chẳng biết cách viết ra sao, chắc phải lươn
				foreach (Socket client in clientList)
				{
					//lấy file đề thi bỏ vào constructor của DataContainer với định dạng là Phát đề
					DataContainer container = new DataContainer(DataContainerType.PhatDe, fileDeThi);
					//mã hóa và gửi cho client
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

		public void ThuBai()
		{

			//DataContainer container = new DataContainer(DataContainerType.ThuBai, null);

			//foreach (Socket socket in clientList)
			//{
			//	socket.Send(container.Serialize());
			//}
			DataContainer container = new DataContainer(DataContainerType.ThuBai, null);

			foreach (Socket socket in clientList)
			{
				socket.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("Sent notification to All Client");
		}

		public void DisconnectAll()
		{
			//tạo một luồng Socket
			foreach (Socket socket in clientList)
			{
				//obj ở đây sẽ cho thành null
				DataContainer response = new DataContainer(DataContainerType.DisconnectAll, null);
				//mã hóa lại ...
				socket.Send(response.Serialize());
			}
			//Xóa danh sách client
			clientList.Clear();
			//chuyển định dạng của các máy con thành DisconnectAll(được viết kỹ bên ClientInfoManager)
			clientInfoManager.DisconnectAll();
		}

		#endregion
	}
}
