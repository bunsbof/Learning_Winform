using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmSetIPRange : Form
    {
        //tạo prop lưu ip đầu
        public string IPBegin { get; private set; }
        //tạo prop lưu ip cuối
        public string IPEnd { get; private set; }
        //tạo prop lưu subnetmask
        public string SubnetMask { get; private set; }
        //tạo prop lưu tổng số lượng máy con
        public int ClientNum { get; private set; }

        public FrmSetIPRange()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //lấy text txtIPBegin lưu vào prop đã đc tạo
            IPBegin = txtIPBegin.Text;
            //lấy text txtIpEnd lưu vào prop đã đc tạo
            IPEnd = txtIpEnd.Text;
            //lấy text txtSubnetMask lưu vào prop đã đc tạo
            SubnetMask = txtSubnetMask.Text;
            //lưu dialog lại thành OK nếu như những cái trên đã được lưu lại và người dùng bấm nút btnSubmit_Click
            this.DialogResult = DialogResult.OK;
            //và đóng chương trình
            this.Close();
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            //lấy text txtSubnetMask lưu vào prop đã được tạo
            SubnetMask = txtSubnetMask.Text;//cái này để tạo subnet mask mặc định cho máy con ???
            //lấy string trong txtClientNumbers chuyển định dạng nó thành số rồi lưu vào prop ClientNum đã được tạo
            ClientNum = Convert.ToInt32(txtClientNumbers.Text);
            //lưu dialog lại thành OK nếu như những cái trên đã được lưu lại và người dùng bấm nút btnSubmit_Click
            this.DialogResult = DialogResult.OK;
            //và đóng chương trình
            this.Close();
        }
    }
}
