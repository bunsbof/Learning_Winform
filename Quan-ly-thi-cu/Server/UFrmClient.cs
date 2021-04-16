using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Server
{
    public partial class UFrmClient : UserControl
    {
        //tạo ra một prop của ClientInfo
        public ClientInfo Client { get; private set; }

        public UFrmClient(ClientInfo client)
        {
            InitializeComponent();
            
            Client = new ClientInfo(client);

            SetContent(client);
            SetTooltip(client);
        }

        private void UFrmClient_Load(object sender, EventArgs e)
        {
            //cái này để edit nó cho nó ko có border 
            txtStudentId.BorderStyle = BorderStyle.None;
            txtPCName.BorderStyle = BorderStyle.None;
            txtClientIP.BorderStyle = BorderStyle.None;
        }

        public void SetClient(ClientInfo client)//dùng dependency injection của ClientInfo
        {

            Client = client;

            SetContent(client);
            SetTooltip(client);
        }

		#region Private methods
        //đây là method dùng để hiển thị tên máy con, mã số sinh viên, id của máy, và hiển thị hình ảnh máy tính cho đẹp :))
		void SetContent(ClientInfo client)
		{
            //kiểm tra xem dữ liệu được truyền từ nơi khác có rỗng không
            if (!string.IsNullOrWhiteSpace(client.ClientIP))
                //nếu đúng thì cho IP của Client hiển thị trên txtClientIP
                txtClientIP.Text = client.ClientIP;
            else
                //còn không thì hiển thị là No IP
                txtClientIP.Text = "No IP";
            //Ở dưới này cx giống vậy

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.MSSV))
            {
                txtStudentId.Text = client.StudentInfo.MSSV;
            }
            else
                txtStudentId.Text = "N/A";

            if (!string.IsNullOrWhiteSpace(client.PCName))
                txtPCName.Text = client.PCName;
            else
                txtPCName.Text = "N/A";


            string imageName;//lưu biến chứa hình ảnh để định dạng máy này còn kết nối, mất kết nối, hay bị lỗi

            switch (client.Status)
            {
                case ClientInfoStatus.Undefined:
                    imageName = "desktop-undefined.png";
                    break;

                case ClientInfoStatus.ClientConnected:
                    imageName = "desktop-normal.png";
                    break;

                case ClientInfoStatus.StudentConnected:
                    imageName = "desktop-success.png";
                    break;

                case ClientInfoStatus.Disconnected:
                    imageName = "desktop-error.png";
                    break;

                default:
                    imageName = "desktop-undefined.png";
                    break;
            }
            //Bitmap này là để làm gì??
            //dùng để hiển thị cái hình ảnh này lên nguyên cái form
            //giải thích : tạo biến bitmap truyền qua GetPathTo đc viết trong PathUtils của Common
            //                 + đưa file hình ảnh vào lưu trong đó
            Bitmap bitmap = new Bitmap(Common.PathUtils.GetPathTo("Assets", imageName));
            //                 + hiển thị hình ảnh đó trên pbClient(PictureBox)
            pbClient.BackgroundImage = bitmap;
        }

        void SetTooltip(ClientInfo client)
		{
            string message = "";//tạo chuỗi thông báo
            //nếu ClientInfoStatus được trả về là ClientConnected thì sẽ trả về string bên dưới
            if (client.Status == ClientInfoStatus.ClientConnected)
                message += "Máy con đã kết nối";
            //nếu ClientInfoStatus được trả về là StudentConnected thì sẽ trả về string bên dưới
            else if (client.Status == ClientInfoStatus.StudentConnected)
                message += "Sinh viên đã kết nối";
            //nếu ClientInfoStatus được trả về là Disconnected thì sẽ trả về string bên dưới
            else if (client.Status == ClientInfoStatus.Disconnected)
                message += "Máy con mất kết nối";
            else
                message += "Máy con chưa kết nối";
            //     Gets the newline string defined for this environment.
            message += Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.PCName))
                message += client.PCName + Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.MSSV))
                message += client.StudentInfo.MSSV + Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.FullName))
                message += client.StudentInfo.FullName + Environment.NewLine;
            //cho cái tooltip đệ quy SetToolTip truyền PictureBox vào với message 
            tltInfo.SetToolTip(pbClient, message);
		}

        #endregion

        
    }
}
