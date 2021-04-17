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
    public partial class FrmLocking : Form
    {
		public List<string> selectedPrograms;

		public FrmLocking()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "Program files (*.exe)|*.exe";
			DialogResult result = openFile.ShowDialog();
			
			if (result == DialogResult.OK)
			{
				string filename = Path.GetFileName(openFile.FileName);
				MessageBox.Show(openFile.FileName);
				if (!selectedPrograms.Contains(filename))
					selectedPrograms.Add(filename);

				ListViewItem item = new ListViewItem()
				{
					Text = filename
				};

				lvProgram.Items.Add(item);
			}
		}

        private void btnLock_Click(object sender, EventArgs e)
        {
			this.DialogResult = DialogResult.OK;
		}
	}
}
