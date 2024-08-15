namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp
{
    partial class MenuParameters
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
            this.tableUsers = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.columUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPasswords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tableUsers
            // 
            this.tableUsers.AllowUserToDeleteRows = false;
            this.tableUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columUsers,
            this.columnPasswords,
            this.columnLevel});
            this.tableUsers.Location = new System.Drawing.Point(2, 1);
            this.tableUsers.Name = "tableUsers";
            this.tableUsers.Size = new System.Drawing.Size(347, 222);
            this.tableUsers.TabIndex = 1;
            this.tableUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tableUsers_CellFormatting);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.Location = new System.Drawing.Point(206, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.Location = new System.Drawing.Point(46, 245);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 40);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // columUsers
            // 
            this.columUsers.HeaderText = "USER";
            this.columUsers.MaxInputLength = 6;
            this.columUsers.Name = "columUsers";
            this.columUsers.ReadOnly = true;
            // 
            // columnPasswords
            // 
            this.columnPasswords.HeaderText = "PASSWORD";
            this.columnPasswords.MaxInputLength = 10;
            this.columnPasswords.Name = "columnPasswords";
            // 
            // columnLevel
            // 
            this.columnLevel.HeaderText = "CATEGORY";
            this.columnLevel.Name = "columnLevel";
            // 
            // MenuParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 308);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableUsers);
            this.Name = "MenuParameters";
            this.Text = "SYSTEM CONFIGURATION";
            this.Load += new System.EventHandler(this.MenuParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView tableUsers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn columUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPasswords;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLevel;
    }
}