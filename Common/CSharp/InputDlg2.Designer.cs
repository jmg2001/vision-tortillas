namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    partial class InputDlg2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be
        ///     disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of
        /// this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtUnits = new System.Windows.Forms.Label();
            this.inputHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.lblOriginalSizeUnits = new System.Windows.Forms.Label();
            this.txtOriginalSize = new System.Windows.Forms.TextBox();
            this.lblDesiredSizeUnits = new System.Windows.Forms.Label();
            this.txtDesiredSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastCalibrationHeight = new System.Windows.Forms.Label();
            this.lblCorrectionFactor = new System.Windows.Forms.Label();
            this.lblLastCalibrationHeightUnits = new System.Windows.Forms.Label();
            this.lblEUFactorCal = new System.Windows.Forms.Label();
            this.btnResetFactor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Silver;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(171, 125);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(148, 38);
            this.btnContinue.TabIndex = 7;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // txtUnits
            // 
            this.txtUnits.AutoSize = true;
            this.txtUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnits.Location = new System.Drawing.Point(341, 96);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(35, 20);
            this.txtUnits.TabIndex = 6;
            this.txtUnits.Text = "mm";
            // 
            // inputHeight
            // 
            this.inputHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputHeight.Location = new System.Drawing.Point(171, 78);
            this.inputHeight.Name = "inputHeight";
            this.inputHeight.Size = new System.Drawing.Size(148, 38);
            this.inputHeight.TabIndex = 5;
            this.inputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter the new height of the camera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Calibration Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "EU Factor:";
            // 
            // btnCorrect
            // 
            this.btnCorrect.BackColor = System.Drawing.Color.Silver;
            this.btnCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrect.Location = new System.Drawing.Point(36, 267);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(189, 51);
            this.btnCorrect.TabIndex = 12;
            this.btnCorrect.Text = "Correct";
            this.btnCorrect.UseVisualStyleBackColor = false;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // lblOriginalSizeUnits
            // 
            this.lblOriginalSizeUnits.AutoSize = true;
            this.lblOriginalSizeUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalSizeUnits.Location = new System.Drawing.Point(322, 134);
            this.lblOriginalSizeUnits.Name = "lblOriginalSizeUnits";
            this.lblOriginalSizeUnits.Size = new System.Drawing.Size(35, 20);
            this.lblOriginalSizeUnits.TabIndex = 11;
            this.lblOriginalSizeUnits.Text = "mm";
            // 
            // txtOriginalSize
            // 
            this.txtOriginalSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalSize.Location = new System.Drawing.Point(167, 116);
            this.txtOriginalSize.Name = "txtOriginalSize";
            this.txtOriginalSize.Size = new System.Drawing.Size(148, 38);
            this.txtOriginalSize.TabIndex = 10;
            this.txtOriginalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDesiredSizeUnits
            // 
            this.lblDesiredSizeUnits.AutoSize = true;
            this.lblDesiredSizeUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesiredSizeUnits.Location = new System.Drawing.Point(322, 224);
            this.lblDesiredSizeUnits.Name = "lblDesiredSizeUnits";
            this.lblDesiredSizeUnits.Size = new System.Drawing.Size(35, 20);
            this.lblDesiredSizeUnits.TabIndex = 14;
            this.lblDesiredSizeUnits.Text = "mm";
            // 
            // txtDesiredSize
            // 
            this.txtDesiredSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesiredSize.Location = new System.Drawing.Point(167, 206);
            this.txtDesiredSize.Name = "txtDesiredSize";
            this.txtDesiredSize.Size = new System.Drawing.Size(148, 38);
            this.txtDesiredSize.TabIndex = 13;
            this.txtDesiredSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correction Factor:";
            // 
            // lblLastCalibrationHeight
            // 
            this.lblLastCalibrationHeight.AutoSize = true;
            this.lblLastCalibrationHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastCalibrationHeight.Location = new System.Drawing.Point(273, 72);
            this.lblLastCalibrationHeight.Name = "lblLastCalibrationHeight";
            this.lblLastCalibrationHeight.Size = new System.Drawing.Size(286, 25);
            this.lblLastCalibrationHeight.TabIndex = 17;
            this.lblLastCalibrationHeight.Text = "@lblLastCalibrationHeight";
            // 
            // lblCorrectionFactor
            // 
            this.lblCorrectionFactor.AutoSize = true;
            this.lblCorrectionFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectionFactor.Location = new System.Drawing.Point(220, 36);
            this.lblCorrectionFactor.Name = "lblCorrectionFactor";
            this.lblCorrectionFactor.Size = new System.Drawing.Size(235, 25);
            this.lblCorrectionFactor.TabIndex = 18;
            this.lblCorrectionFactor.Text = "@lblCorrectionFactor";
            // 
            // lblLastCalibrationHeightUnits
            // 
            this.lblLastCalibrationHeightUnits.AutoSize = true;
            this.lblLastCalibrationHeightUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastCalibrationHeightUnits.Location = new System.Drawing.Point(384, 72);
            this.lblLastCalibrationHeightUnits.Name = "lblLastCalibrationHeightUnits";
            this.lblLastCalibrationHeightUnits.Size = new System.Drawing.Size(340, 25);
            this.lblLastCalibrationHeightUnits.TabIndex = 19;
            this.lblLastCalibrationHeightUnits.Text = "@lblLastCalibrationHeightUnits";
            // 
            // lblEUFactorCal
            // 
            this.lblEUFactorCal.AutoSize = true;
            this.lblEUFactorCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEUFactorCal.Location = new System.Drawing.Point(151, 35);
            this.lblEUFactorCal.Name = "lblEUFactorCal";
            this.lblEUFactorCal.Size = new System.Drawing.Size(192, 25);
            this.lblEUFactorCal.TabIndex = 20;
            this.lblEUFactorCal.Text = "@lblEUFactorCal";
            // 
            // btnResetFactor
            // 
            this.btnResetFactor.BackColor = System.Drawing.Color.Silver;
            this.btnResetFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFactor.Location = new System.Drawing.Point(257, 267);
            this.btnResetFactor.Name = "btnResetFactor";
            this.btnResetFactor.Size = new System.Drawing.Size(189, 51);
            this.btnResetFactor.TabIndex = 21;
            this.btnResetFactor.Text = "Reset Factor";
            this.btnResetFactor.UseVisualStyleBackColor = false;
            this.btnResetFactor.Click += new System.EventHandler(this.btnResetFactor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputHeight);
            this.groupBox1.Controls.Add(this.txtUnits);
            this.groupBox1.Controls.Add(this.btnContinue);
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 178);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration by Height";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtOriginalSize);
            this.groupBox2.Controls.Add(this.lblOriginalSizeUnits);
            this.groupBox2.Controls.Add(this.btnResetFactor);
            this.groupBox2.Controls.Add(this.btnCorrect);
            this.groupBox2.Controls.Add(this.txtDesiredSize);
            this.groupBox2.Controls.Add(this.lblDesiredSizeUnits);
            this.groupBox2.Controls.Add(this.lblCorrectionFactor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 348);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Correction Factor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(92, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(299, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Physical Measured Diameter :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Software Measured Diameter:";
            // 
            // InputDlg2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(531, 676);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEUFactorCal);
            this.Controls.Add(this.lblLastCalibrationHeightUnits);
            this.Controls.Add(this.lblLastCalibrationHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "InputDlg2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calibration Menu";
            this.Load += new System.EventHandler(this.InputDlg2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label txtUnits;
        private System.Windows.Forms.TextBox inputHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCorrect;
        private System.Windows.Forms.Label lblOriginalSizeUnits;
        private System.Windows.Forms.TextBox txtOriginalSize;
        private System.Windows.Forms.Label lblDesiredSizeUnits;
        private System.Windows.Forms.TextBox txtDesiredSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEuFactor;
        private System.Windows.Forms.Label lblLastCalibrationHeight;
        private System.Windows.Forms.Label lblCorrectionFactor;
        private System.Windows.Forms.Label lblLastCalibrationHeightUnits;
        private System.Windows.Forms.Label lblEUFactorCal;
        private System.Windows.Forms.Button btnResetFactor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}