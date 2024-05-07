using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    static class GrabDemo
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                GigECameraDemoDlg form = new GigECameraDemoDlg();
                if (!form.IsDisposed)
                    Application.Run(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}