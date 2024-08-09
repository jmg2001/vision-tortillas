namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    partial class ChooseCameraDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCamera1 = new System.Windows.Forms.Button();
            this.btnCamera2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCamera1
            // 
            this.btnCamera1.BackColor = System.Drawing.Color.Silver;
            this.btnCamera1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnCamera1.Location = new System.Drawing.Point(37, 43);
            this.btnCamera1.Name = "btnCamera1";
            this.btnCamera1.Size = new System.Drawing.Size(140, 62);
            this.btnCamera1.TabIndex = 0;
            this.btnCamera1.Text = "LEFT";
            this.btnCamera1.UseVisualStyleBackColor = false;
            this.btnCamera1.Click += new System.EventHandler(this.btnCamera1_Click);
            // 
            // btnCamera2
            // 
            this.btnCamera2.BackColor = System.Drawing.Color.Silver;
            this.btnCamera2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnCamera2.Location = new System.Drawing.Point(227, 43);
            this.btnCamera2.Name = "btnCamera2";
            this.btnCamera2.Size = new System.Drawing.Size(140, 62);
            this.btnCamera2.TabIndex = 1;
            this.btnCamera2.Text = "RIGHT";
            this.btnCamera2.UseVisualStyleBackColor = false;
            this.btnCamera2.Visible = false;
            this.btnCamera2.Click += new System.EventHandler(this.btnCamera2_Click);
            // 
            // ChooseCameraDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(414, 138);
            this.Controls.Add(this.btnCamera2);
            this.Controls.Add(this.btnCamera1);
            this.Name = "ChooseCameraDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Camera";
            this.Load += new System.EventHandler(this.ChooseCameraDlg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCamera1;
        private System.Windows.Forms.Button btnCamera2;
    }
}