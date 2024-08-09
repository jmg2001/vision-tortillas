using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public partial class InputDlg2 : Form
    {
        public string units { get; set; }
        public double cameraHeight { get; set; }
        public double correctionFactor { get; set; }

        double originalSize;
        double desiredSize;

        public InputDlg2(string unit, double euFactor, double lastCalibrationHeight, double correctionFactor, string lastCalibrationHeightUnits, int camera = 1)
        {
            units = unit;
            string title = "";
            if (camera == 1) title = "LEFT";
            else title = "RIGHT";
            this.Text = $"Calibration Menu {title}";
            InitializeComponent();

            txtUnits.Text = units;
            lblDesiredSizeUnits.Text = units;
            lblOriginalSizeUnits.Text = units;

            lblEUFactorCal.Text = euFactor.ToString();
            lblLastCalibrationHeight.Text = lastCalibrationHeight.ToString();
            lblCorrectionFactor.Text = correctionFactor.ToString();
            lblLastCalibrationHeightUnits.Text = lastCalibrationHeightUnits;
        }

        public void InputDlg2_Load(object sender, EventArgs e)
        {
            
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            double height = 0;
            // Intentar convertir el texto del TextBox a un número entero
            if (double.TryParse(inputHeight.Text, out height))
            {
                height = validate(height);

                DialogResult result = MessageBox.Show($"You are going to perform a calibration with {inputHeight.Text} {units} height. Do you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                // Verificar la opción seleccionada por el usuario
                if (result == DialogResult.OK)
                {
                    cameraHeight = height;
                    // Si el usuario elige "Sí", continuar con la acción deseada
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    // Si el usuario elige "No", puedes hacer algo o simplemente salir
                    MessageBox.Show("Operation canceled");

                    this.Close();
                }
            }
            else
            {
                // Manejar el caso en que el texto no sea un número válido
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double validate(double height)
        {
            if (units == "mm")
            {
                return (int)height;
            }
            else
            {
                return height;
            }
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtOriginalSize.Text, out originalSize))
            {
                MessageBox.Show("Use a valid number");
                return;
            }

            if (!double.TryParse(txtDesiredSize.Text, out desiredSize))
            {
                MessageBox.Show("Use a valid number");
                return;
            }

            double correction = desiredSize / originalSize;

            if (Math.Abs(correction-1) > 0.1)
            {
                MessageBox.Show("Invalid correction, must be <= 10 %");
                return;
            }

            this.DialogResult = DialogResult.Yes;
            this.correctionFactor = correction;
            this.Close();

        }

        private void btnResetFactor_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.correctionFactor = 1;
            this.Close();
        }
    }
}
