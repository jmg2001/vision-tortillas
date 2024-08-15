using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp
{
    public partial class MenuParameters : Form
    {
        public List<GigECameraDemoDlg.User> usersList = new List<GigECameraDemoDlg.User>();
        public MenuParameters(List<GigECameraDemoDlg.User> usersList)
        {
            InitializeComponent();

            this.usersList = usersList;
        }

        private void MenuParameters_Load(object sender, System.EventArgs e)
        {
            foreach (var user in usersList)
            {
                if (user != null)
                {
                    string pass = new string('*', user.Password.Length);
                    tableUsers.Rows.Add(user.Name, pass,user.Level);
                }
            }

            //tableUsers.DataSource = usersList;
        }

        private void tableUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //// Verificar si la columna es la de contraseñas
            //if (tableUsers.Columns[e.ColumnIndex].DataPropertyName == "PASSWORDS")
            //{
            //    // Enmascarar la contraseña con asteriscos
            //    if (e.Value != null)
            //    {
            //        e.Value = new string('*', e.Value.ToString().Length);
            //    }
            //}
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            InputName input = new InputName();
            var result = input.ShowDialog();

            if (result == DialogResult.OK) 
            {
                tableUsers.Rows.Add(input.name,"CHANGE","CHANGE");
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in tableUsers.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        if (cell.Value.ToString() != "" && !usersList.Select(u => u.Name).ToList().Contains(cell.Value))
                        {
                            if (!AddUser(row))
                            {
                                tableUsers.Rows.Remove(row);
                            }

                            break;
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool AddUser(DataGridViewRow row)
        {
            string name = "";
            int password = 0;
            int level = 1;

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ColumnIndex == 0)
                {
                    name = cell.Value.ToString();
                }
                else if (cell.ColumnIndex == 1)
                {
                    if (!int.TryParse(cell.Value.ToString(), out password))
                    {
                        MessageBox2.Show("Only Numeric Passwords");
                        return false;
                    }
                }
                else
                {
                    if (int.TryParse(cell.Value.ToString(), out level))
                    {
                        if (!(level >= 1 &&  level <= 3))
                        {
                            MessageBox2.Show("Wrong Category");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox2.Show("Wrong Category");
                        return false;
                    }

                }
            }

            GigECameraDemoDlg.User user = new GigECameraDemoDlg.User(name, password.ToString(), level);
            usersList.Add(user);

            return true;
        }
    }
}
