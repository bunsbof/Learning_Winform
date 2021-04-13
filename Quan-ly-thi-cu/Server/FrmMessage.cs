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
    public partial class FrmMessage : Form
    {
        public Action<string> onClickSendButton;

        public FrmMessage()
        {
            InitializeComponent();
        }

        private void btnMess_Click(object sender, EventArgs e)
        {
            onClickSendButton(txtMess.Text);

        }
    }
}
