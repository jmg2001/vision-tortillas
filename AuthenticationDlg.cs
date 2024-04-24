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
    public partial class AuthenticationDlg : Form
    {
        public class Authenticator
        {
            private const string Username = "admin";
            private const string Password = "123456";

            public static bool Authenticate(string username, string password)
            {
                return username == Username && password == Password;
            }
        }

        public AuthenticationDlg()
        {
            InitializeComponent();
        }

        private void AuthenticationDlg_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text;
            string password = passwordTxt.Text;

            if (Authenticator.Authenticate(username, password))
            {
                MessageBox.Show("Inicio de sesión exitoso");
                // Aquí puedes hacer algo después de que el usuario haya iniciado sesión correctamente
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }
    }
}
