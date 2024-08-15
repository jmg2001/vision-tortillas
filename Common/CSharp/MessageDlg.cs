using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp
{

    public static class MessageBox2
    {
        public static DialogResult Show(string text, string caption = "Mensaje", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            using (var form = new MessageDlg(text, caption, buttons, icon, defaultButton))
            {
                return form.ShowDialog();
            }
        }
    }

    public partial class MessageDlg : Form
    {

        private Label lblMessage;
        private Button btnOK;
        private Button btnCancel;
        private MessageBoxButtons buttons;

        public MessageDlg(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();

            this.Text = caption;
            this.buttons = buttons;

            lblMessage = new Label
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Arial", 16), // Ajusta el tamaño de la fuente aquí
                Location = new Point(20, 20)
            };

            this.Controls.Add(lblMessage);

            // Agregar botones basados en el parámetro buttons
            if (buttons.HasFlag(MessageBoxButtons.OK))
            {
                btnOK = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Size = new Size(50,30),
                    Location = new Point((int)((lblMessage.Left+lblMessage.Right)/2)-25, lblMessage.Bottom + 10)
                };
                this.Controls.Add(btnOK);
            }

            if (buttons.HasFlag(MessageBoxButtons.RetryCancel))
            {
                if (!(btnOK == null))
                {
                    btnOK.Left -= 35;
                }
                btnCancel = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Size = new Size(50, 30),
                    Location = new Point(btnOK == null ? (int)((lblMessage.Left + lblMessage.Right) / 2) - 25 : btnOK.Right + 10, lblMessage.Bottom + 10)
                };
                this.Controls.Add(btnCancel);
            }


            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
            this.ClientSize = new Size(Math.Max(lblMessage.Width + 40, btnOK?.Right + 30 ?? 200), btnOK?.Bottom + 30 ?? 100);
            this.StartPosition = FormStartPosition.CenterParent;
        }


        private void MessageDlg_Load(object sender, EventArgs e)
        {

        }
    }
    
}
