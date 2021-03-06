using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Client
{
    public partial class FrmClient : Form
    {
        private const int SERVER_PORT = 2010;
        Thread DitecThread;

        int counter = 0; // Dem nguoc theo tung giay
        System.Timers.Timer countdown;

        ProcessKill processkill;

        ClientProgram clientProgram;
        PopupNotifier popup;

        public FrmClient()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            clientProgram = new ClientProgram();

			clientProgram.OnSuccessNotification += HandleOnSuccessNotification;
			clientProgram.OnErrorNotification += HandleOnErrorNotification;
			clientProgram.OnReceivedExam += HandleOnReceivedExam;
            clientProgram.OnCamChuongTrinh += HandleOnCamChuongTrinh;
            clientProgram.onNhanThongBao = HandleOnNhanThongBao;
            clientProgram.onNhanDanhSachSVTuExcel = HandleOnNhanDanhSachSVTuExcel;

            clientProgram.onNhanSoPhut = HandleOnNhanSoPhut;


            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed; ;
            countdown.Interval = 1000;

            InitPopupNotifier();
        }
        void InitProcessManager(List<string> processes)
        {
            processkill = new ProcessKill(processes);
            processkill.OnInvalidProcessKilled += HandleOnInvalidProcessKilled;
        }
        private void HandleOnCamChuongTrinh(List<string> programs)
        {
            if (processkill == null)
            {
                InitProcessManager(programs);
                return;
            }

            foreach (string program in programs)
            {
                processkill.AddProcess(program);
            }
        }

        private void HandleOnInvalidProcessKilled(string processName)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("Lỗi", "chương trình không được phép chạy: " + processName);
                });
            }
            else
            {
                RenderNotificationPopup("Lỗi", "chương trình không được phép chạy: " + processName);
            }
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;

            int minute = counter / 60;
            int second = counter % 60;

            if (counter % (30 * 60) == 0)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        string msg = "Time remain: " + minute + " minute - " + second + " second";
                        RenderNotificationPopup("Pay attention to examition time", msg);
                    });
                }
                else
                {
                    string msg = "Time remain: " + minute + " minute - " + second + " second";
                    RenderNotificationPopup("Pay attention to examition time", msg);
                }
            }
            else if (counter == (15 * 60))
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        string msg = "You have 15 minute left";
                        RenderNotificationPopup("Pay attention to examition time", msg);
                    });
                }
                else
                {
                    string msg = "You have 15 minute left";
                    RenderNotificationPopup("Pay attention to examition time", msg);
                }
            }
            else if (counter == (10 * 60))
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        string msg = "You have 10 minute left, pay attention to RAR your folder or files";
                        RenderNotificationPopup("Pay attention to examition time", msg);
                    });
                }
                else
                {
                    string msg = "You have 10 minute left, pay attention to RAR your folder or files";
                    RenderNotificationPopup("Pay attention to examition time", msg);
                }
            }
            else if (counter == (5 * 60))
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        string msg = "RAR your folder or files";
                        RenderNotificationPopup("Pay attention to examition time", msg);
                    });
                }
                else
                {
                    string msg = "RAR your folder or files";
                    RenderNotificationPopup("Pay attention to examition time", msg);
                }
            }

            lblThoiGianConLai.Text = minute + " minute - " + second + " second";

            if (counter == 0)
            {
                countdown.Stop();

                btnFinishExam.PerformClick();
            }
        }


        private void HandleOnNhanSoPhut(int minute)
        {
            counter = minute * 60;
            countdown.Enabled = true;
        }

        void HandleOnNhanThongBao(string message)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    popup.TitleText = "Server Message";
                    popup.ContentText = message;

                    popup.Popup();
                });
            }
            else
            {
                popup.TitleText = "Server Message";
                popup.ContentText = message;

                popup.Popup();
            }


        }

        void HandleOnNhanDanhSachSVTuExcel(List<Student> students)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    popup.TitleText = "Notification";
                    popup.ContentText = "Student list have revieced";

                    popup.Popup();

                    cbDSThi.DataSource = students;
                    cbDSThi.DisplayMember = "FullNameAndId";
                });
            }
            else
            {
                popup.TitleText = "Notification";
                popup.ContentText = "Student list have recieved";

                popup.Popup();

                cbDSThi.DataSource = students;
                cbDSThi.DisplayMember = "FullNameAndId";
            }

        }

        void InitPopupNotifier()
		{
            popup = new PopupNotifier();
            popup.ShowOptionsButton = false;
            popup.TitleColor = Color.Black;
            popup.TitleColor = Color.Black;
            popup.BodyColor = Color.White;
            popup.ContentPadding = new Padding(10, 3, 10, 3);
            popup.TitlePadding = new Padding(10, 3, 10, 3); 
        }

        void RenderNotificationPopup(string title, string content)
		{           
            popup.TitleText = title;
            popup.ContentText = content;

            popup.Popup();
        }

		private void HandleOnErrorNotification(string errorMessage, Exception ex)
		{

            string msg = errorMessage;

            if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
                msg += ". " + ex.Message;

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("Error Message", msg);
                });
            }
            else
            {
                RenderNotificationPopup("Error Message", msg);
            }
		}

		private void HandleOnSuccessNotification(string message)
		{
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("New Message", message);
                });
            }
            else
            {
                RenderNotificationPopup("New Message", message);
            }

        }

		private void HandleOnReceivedExam(string examFileUrl)
		{
            lblDeThi.Text = examFileUrl;
		}

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            clientProgram.Connect(txtServerIP.Text, SERVER_PORT);
            //btnConnectToServer.Enabled = false;
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            DitecThread = new Thread(new ThreadStart(Ditec_aplication_open));
            DitecThread.IsBackground = true;
            DitecThread.Start();
        }
        static void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string name = e.NewEvent.Properties["ProcessName"].Value.ToString();

            if (name == "chrome.exe")
            {
               
                Process[] p = Process.GetProcessesByName("chrome");
                foreach (Process item in p)
                {
                    if (item.ProcessName.ToUpper() == "CHROME")
                    {
                        item.Kill();
                    }
                }
                //MessageBox.Show(" cam chay chuong trinh nay");
            }
        }
        static void stopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //MessageBox.Show("Process stopped: {0}", e.NewEvent.Properties["ProcessName"].Value.ToString());
        }
        public void Ditec_aplication_open()
        {
            while (true)
            {
                ManagementEventWatcher startWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
                startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
                startWatch.Start();
                ManagementEventWatcher stopWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
                stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
                stopWatch.Start();
                Thread.Sleep(50);
                startWatch.Stop();
                stopWatch.Stop();
            }

        }

        //private void btnChonDe_Click(object sender, EventArgs e)
        //{
        //    //tạo đối tượng mở explorer
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    //set định dạng mở là tất cả dạng file
        //    openFile.Filter = "All files (*.*)|*.*";
        //    //cho phép chọn nhiều file
        //    openFile.Multiselect = true;
        //    //nếu dialog trả về OK(== 1) thì sẽ đóng nó
        //    if (openFile.ShowDialog() != DialogResult.OK)
        //        return;

        //    foreach (string filename in openFile.FileNames)
        //    {
        //        //tạo phần tử listview để chứa file đc select
        //        ListViewItem row = new ListViewItem();
        //        //lấy đường dẫn của file
        //        row.Text = Path.GetFileName(filename);
        //        //hiển thị tên file
        //        row.Tag = filename;
        //        //cho vào lsvDeThi để hiển thị
        //        lsvDeThi.Items.Add(row);
        //    }
        //}

        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem == null)
            {
                return;
            }

            Student student = cbDSThi.SelectedItem as Student;
            lblHoTen.Text = student.FullName;
            lblMaSo.Text = student.MSSV;
        }

        private void btnFinishExam_Click(object sender, EventArgs e)
        {

        }

        private void btnSendStudentInfo_Click(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem == null)
                return;
            Student student = cbDSThi.SelectedItem as Student;
            clientProgram.SendStudent(student);
            btnFinishExam.Enabled = true;
        }
    }
}
