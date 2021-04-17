using Core;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Server
{
    public partial class Server : Form
    {
        ServerProgram serverProgram;

        PopupNotifier popup;

        int counter = 0; // Dem nguoc theo tung giay


        System.Timers.Timer countdown;

        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            serverProgram = new ServerProgram();

            serverProgram.SetClientPath(txtClientPath.Text);
            serverProgram.SetServerPath(txtServerPath.Text);

            serverProgram.OnServerStarted += HandleOnServerStarted;
            serverProgram.OnClientListChanged += HandleOnClientListChanged;

            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed;
            countdown.Interval = 1000;

            serverProgram.Start();

            InitPopupNotifier();

        }

        byte[] Serialize(object data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);

            return stream.ToArray();
        }

        void InitPopupNotifier()
        {
            popup = new PopupNotifier();
            popup.ShowOptionsButton = false;
            popup.ContentPadding = new Padding(10, 3, 50, 3);
            popup.HeaderColor = Color.Black;
            popup.BodyColor = Color.White;
            popup.TitlePadding = new Padding(10, 3, 10, 3);
        }

        List<Student> DocNoiDungFileExcel(string duongDanFileExcel)
        {
            // Doc file excel
            List<Student> students = new List<Student>();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                //mở file excel
                var package = new ExcelPackage(new FileInfo(duongDanFileExcel));

                //lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                //duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. Lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        // biến j biểu thị cho một column trong file
                        int j = 1;

                        // lấy ra cột mã số sinh viên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
                        //tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        string mssv = worksheet.Cells[i, j++].Value.ToString();

                        // lấy ra cột họ và tên đệm tương ứng giá trị tại vị trí [i, 2]. i lần đầu là 2
                        //tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        string hoDem = worksheet.Cells[i, j++].Value.ToString();

                        // lấy ra cột tên tương ứng giá trị tại vị trí [i, 3]. i lần đầu là 2
                        //tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        string ten = worksheet.Cells[i, j++].Value.ToString();

                        // tạo student từ dữ liệu đã lấy được 
                        Student student = new Student()
                        {
                            MSSV = mssv,
                            LastName = hoDem,
                            FirstName = ten
                        };

                        // add student vào danh sách students
                        students.Add(student);
                    }
                    catch (Exception exe)
                    {


                    }

                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Error!" + ee.Message);
            }


            return students;
        }
        #region Server Program Events

        private void HandleOnClientListChanged(List<ClientInfo> clientList)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderClientList(clientList);
                });
            }
            else
            {
                RenderClientList(clientList);
            }
        }

        private void HandleOnServerStarted(System.Net.IPEndPoint serverIPendpoint)
        {
            this.Text = "Server is running at: " + serverIPendpoint.ToString();
        }

        #endregion

        #region Methods

        void RenderNotificationPopup(string title, string content)
        {
            popup.TitleText = title;
            popup.ContentText = content;

            popup.Popup();
        }

        private void HandleOnNotification(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("New notification", message);
                });
            }
            else
            {
                RenderNotificationPopup("New notification", message);
            }
        }

        void HandleOnClickSendButton(string tinnhan)
        {
            // gui tin nhan toi client
            serverProgram.GuiTinNhanChoTatCaMayCon(tinnhan);
        }

        void RenderClientList(List<ClientInfo> clientList)
        {
            if (flpMain.Controls.Count == 0)
			{
                foreach (ClientInfo clientInfo in clientList)
                {
                    UFrmClient frm = new UFrmClient(clientInfo);
                    flpMain.Controls.Add(frm);
                }

                return;
            }

            int clientControlLength = flpMain.Controls.Count;
            int i = 0;
            for (i = 0; i < clientList.Count; i++)
			{
                ClientInfo clientInfoInList = clientList[i];

                if (i < clientControlLength)
				{
                    UFrmClient frm = flpMain.Controls[i] as UFrmClient;
                    ClientInfo clientInfoInControl = frm.Client;

                    frm.SetClient(clientInfoInList);
				}
				else
				{
                    UFrmClient frm = new UFrmClient(clientInfoInList);
                    flpMain.Controls.Add(frm);
                }
			}

            if (i < flpMain.Controls.Count)
                for (int j = flpMain.Controls.Count - 1; j >= i; j--)
                    flpMain.Controls.RemoveAt(j);
        }

		#endregion

		#region Handle events on UI

		private void cmdNhapVungIP_Click(object sender, EventArgs e)
        {
            FrmSetIPRange frm = new FrmSetIPRange();
            DialogResult result = frm.ShowDialog();

            if (result != DialogResult.OK) return;

            string FirstIP = frm.IPBegin;
            string LastIP = frm.IPEnd;
            string SubnetMask = frm.SubnetMask;
            int clientNum = frm.ClientNum;

            if (clientNum == 0)//nếu số lượng client mà bằng 0
            {

                serverProgram.SetClientInfoList(FirstIP, LastIP, SubnetMask);
            }
            else
            {
                serverProgram.SetClientInfoList(clientNum);
            }

        }

		private void btnDisconnectAll_Click(object sender, EventArgs e)
		{
            serverProgram.DisconnectAll();
		}

		private void btnThemDe_Click(object sender, EventArgs e)
		{
            //tạo đối tượng mở explorer
            OpenFileDialog openFile = new OpenFileDialog();
            //set định dạng mở là tất cả dạng file
            openFile.Filter = "All files (*.*)|*.*";
            //cho phép chọn nhiều file
            openFile.Multiselect = true;
            //nếu dialog trả về OK(== 1) thì sẽ đóng nó
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

			foreach (string filename in openFile.FileNames)
			{
                //tạo phần tử listview để chứa file đc select
                ListViewItem row = new ListViewItem();
                //lấy đường dẫn của file
                row.Text = Path.GetFileName(filename);
                //hiển thị tên file
                row.Tag = filename;
                //cho vào lsvDeThi để hiển thị
                lsvDeThi.Items.Add(row);
            }
        }

        private void btnXoaDe_Click(object sender, EventArgs e)
        {
            //nếu đề thi không có phần tử nào thì không có gì xảy ra
            if (lsvDeThi.SelectedItems.Count == 0)
                return;
            //mặc định sẽ lấy đề thi thứ nhất để xóa
            lsvDeThi.Items.Remove(lsvDeThi.SelectedItems[0]);
        }

        private void btnPhatDe_Click(object sender, EventArgs e)
		{
            //nếu đề thi không có phần tử nào thì không có gì xảy ra
            if (lsvDeThi.Items.Count == 0)
			{
                MessageBox.Show("Choose file...");
                return;
			}                

            List<string> listOfDeThiURL = new List<string>();
            string clientPath = txtClientPath.Text;
            string serverPath = txtServerPath.Text;
            //xử lý hàm thông báo nếu đường dẫn của bài Client không hợp lệ
            if (string.IsNullOrWhiteSpace(clientPath))
			{
                MessageBox.Show("Choose Client path to save");
                return;
			}
            //xử lý hàm thông báo nếu đường dẫn của bài Server không hợp lệ
            if (string.IsNullOrWhiteSpace(serverPath))
			{
                MessageBox.Show("Choose valid path");
                return;
			}
            //đưa path của file bài thi hiện vào listOfDeThiURL
            foreach (ListViewItem row in lsvDeThi.Items)
			{
                string deThiURL = row.Tag as string;
                listOfDeThiURL.Add(deThiURL);
			}

            serverProgram.PhatDeThi(listOfDeThiURL);
		}

		private void btnThuBai_Click(object sender, EventArgs e)
		{
            serverProgram.ThuBai();
		}

		private void btnChonServerPath_Click(object sender, EventArgs e)
		{

            using (var fbd = new FolderBrowserDialog())// tạo instance của FolderBrowserDialog
            {
                DialogResult result = fbd.ShowDialog();// truyền biến fbd vào DialogResult
                //nếu kết quả trả về Ok và đường dẫn hiển thị không bị trống 
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //thì sẽ truyền đoạn path vào txtServerPath trong FrmServer
                    txtServerPath.Text = fbd.SelectedPath;
                    //lưu đường dẫn thu bài ở phía Server
                    serverProgram.SetServerPath(fbd.SelectedPath);
                }
            }
        }
        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            FrmMessage message = new FrmMessage();
            message.onClickSendButton = HandleOnClickSendButton;

            message.ShowDialog();
        }
        private void btnChonClientPath_Click(object sender, EventArgs e)
		{
            //y như btnChonServerPath_Click
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtClientPath.Text = fbd.SelectedPath;
                    serverProgram.SetClientPath(fbd.SelectedPath);
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            //Doc file excel
            List<Student> danhSachSV = DocNoiDungFileExcel(@"D:\dev\Socket\Quan-ly-thi-cu\CSDL.xlsx");

            //Goi ham gui
            serverProgram.GuiDanhSachSinhVien(danhSachSV);
        }





        #endregion

        private void cmdBatDauLamBai_Click(object sender, EventArgs e)
        {
            int minute = Convert.ToInt32(txtSetTime.Text);
            counter = minute * 60;
            countdown.Enabled = true;

            serverProgram.batDauLamBai(minute);
        }

        private void AddMessage(string v)
        {
            throw new NotImplementedException();
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;

            int minute = counter / 60;
            int second = counter % 60;

            lblTimeLeft.Text = minute + ":" + second;
            if (counter == 0)
            {
                countdown.Stop();

                serverProgram.GuiTinNhanChoTatCaMayCon("Time up");
            }
        }

        private void cmdKichHoatAllClient_Click(object sender, EventArgs e)
        {

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            FrmLocking frm = new FrmLocking();
            frm.ShowDialog();

            List<string> selectedPrograms = frm.selectedPrograms;
            serverProgram.CamChuongTrinh(selectedPrograms);
        }
    }
}
