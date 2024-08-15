using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp
{
    public partial class InputName : Form
    {

        public string name {  get; set; }
        public InputName()
        {
            InitializeComponent();
        }

        private void InputName_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0) 
            {
                this.name = txtName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
        }
    }
}
