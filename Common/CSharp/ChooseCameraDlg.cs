using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public partial class ChooseCameraDlg : Form
    {

        public int camera { get; private set; }
        public ChooseCameraDlg()
        {
            InitializeComponent();
            
        }

        private void btnCamera1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.camera = 1;
            this.Close();
        }

        private void btnCamera2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.camera = 2;
            this.Close();
        }

        private void ChooseCameraDlg_Load(object sender, EventArgs e)
        {

        }
    }
}
