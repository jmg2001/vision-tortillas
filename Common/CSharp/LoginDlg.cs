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
    public partial class LoginDlg : Form
    {
        string user;
        string password;
        public LoginDlg(string user, string password)
        {
            this.user = user;
            this.password = password;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == user)
            {
                if (txtPassword.Text == password)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                    this .DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Wrong User");
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
