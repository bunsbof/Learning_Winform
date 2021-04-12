using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        ServerProgram serverProgram;

        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            serverProgram = new ServerProgram();

            serverProgram.SetClientPath(txtClientPath.Text);
            serverProgram.SetServerPath(txtServerPath.Text);

            serverProgram.OnServerStarted += HandleOnServerStarted;
            serverProgram.OnClientListChanged += HandleOnClientListChanged;

            serverProgram.Start();
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
                MessageBox.Show("Vui long chon de thi");
                return;
			}                

            List<string> listOfDeThiURL = new List<string>();
            string clientPath = txtClientPath.Text;
            string serverPath = txtServerPath.Text;
            //xử lý hàm thông báo nếu đường dẫn của bài Client không hợp lệ
            if (string.IsNullOrWhiteSpace(clientPath))
			{
                MessageBox.Show("Vui long nhap duong dan phat bai thi hop le");
                return;
			}
            //xử lý hàm thông báo nếu đường dẫn của bài Server không hợp lệ
            if (string.IsNullOrWhiteSpace(serverPath))
			{
                MessageBox.Show("Vui long nhap duong dan luu bai hop le");
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
            //đoạn này được viết kỹ bên ServerProgram
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

		#endregion


	}
}
