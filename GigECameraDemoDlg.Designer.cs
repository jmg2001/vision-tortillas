
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using System.Windows.Forms;


namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    partial class GigECameraDemoDlg
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabelInfo = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabelInfoTrash = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PixelLabel = new System.Windows.Forms.ToolStripLabel();
            this.PixelDataValue = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.videoSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.virtualTriggerBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processImageBtn = new System.Windows.Forms.Button();
            this.triggerModeBtn = new System.Windows.Forms.Button();
            this.viewModeBtn = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.Txt_mode = new System.Windows.Forms.Label();
            this.BtnLocalRemote = new System.Windows.Forms.Button();
            this.GroupBox17 = new System.Windows.Forms.GroupBox();
            this.Txt_MaxCompacity = new System.Windows.Forms.TextBox();
            this.Label50 = new System.Windows.Forms.Label();
            this.Txt_MaxOvality = new System.Windows.Forms.TextBox();
            this.Txt_MinDiameter = new System.Windows.Forms.TextBox();
            this.Label53 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.Label55 = new System.Windows.Forms.Label();
            this.Txt_MaxDiameter = new System.Windows.Forms.TextBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.grid_16 = new System.Windows.Forms.Button();
            this.grid_12 = new System.Windows.Forms.Button();
            this.grid_6 = new System.Windows.Forms.Button();
            this.grid_5 = new System.Windows.Forms.Button();
            this.grid_4 = new System.Windows.Forms.Button();
            this.grid_9 = new System.Windows.Forms.Button();
            this.GB_Threshold = new System.Windows.Forms.GroupBox();
            this.Chk_Threshold_Mode = new System.Windows.Forms.CheckBox();
            this.Txt_Threshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.controlsTabs = new System.Windows.Forms.TabControl();
            this.commandsPage = new System.Windows.Forms.TabPage();
            this.unitsTxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.diametersTxtCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.avg_diameter = new System.Windows.Forms.Label();
            this.cameraControlPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.targetUnitsTxt = new System.Windows.Forms.Label();
            this.calibrateBtn = new System.Windows.Forms.Button();
            this.txtCalibrationTarget = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.euListSelection = new System.Windows.Forms.ComboBox();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.imagePage = new System.Windows.Forms.TabPage();
            this.originalBox = new System.Windows.Forms.PictureBox();
            this.processROIBox = new System.Windows.Forms.PictureBox();
            this.tablePage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.GroupBox13 = new System.Windows.Forms.GroupBox();
            this.Label47 = new System.Windows.Forms.Label();
            this.Chk_Right_Side = new System.Windows.Forms.CheckBox();
            this.Txt_Tag = new System.Windows.Forms.TextBox();
            this.GroupBox12 = new System.Windows.Forms.GroupBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Txt_Line_Width = new System.Windows.Forms.TextBox();
            this.Label44 = new System.Windows.Forms.Label();
            this.Label45 = new System.Windows.Forms.Label();
            this.txt_under_size = new System.Windows.Forms.TextBox();
            this.txt_over_size = new System.Windows.Forms.TextBox();
            this.Label38 = new System.Windows.Forms.Label();
            this.Txt_Max_Threshold = new System.Windows.Forms.TextBox();
            this.Chk_Digital_Knife = new System.Windows.Forms.CheckBox();
            this.GroupBox11 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TXT_ROI_Bottom = new System.Windows.Forms.TextBox();
            this.TXT_ROI_Right = new System.Windows.Forms.TextBox();
            this.TXT_ROI_Top = new System.Windows.Forms.TextBox();
            this.TXT_ROI_Left = new System.Windows.Forms.TextBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.CmbProducts = new System.Windows.Forms.ComboBox();
            this.CmdDelete = new System.Windows.Forms.Button();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.Txt_Compacity = new System.Windows.Forms.TextBox();
            this.Label46 = new System.Windows.Forms.Label();
            this.Txt_Description = new System.Windows.Forms.TextBox();
            this.Txt_Code = new System.Windows.Forms.TextBox();
            this.Txt_Ovality = new System.Windows.Forms.TextBox();
            this.Txt_MinD = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.Txt_MaxD = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.Cmd_video = new System.Windows.Forms.Button();
            this.Cmd_Calibration = new System.Windows.Forms.Button();
            this.Cmd_Save = new System.Windows.Forms.Button();
            this.maxDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.minDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox17.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GB_Threshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.controlsTabs.SuspendLayout();
            this.commandsPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cameraControlPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.imagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processROIBox)).BeginInit();
            this.tablePage.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.StatusLabelInfo,
            this.StatusLabelInfoTrash,
            this.toolStripSeparator1,
            this.PixelLabel,
            this.PixelDataValue});
            this.toolStrip1.Location = new System.Drawing.Point(0, 618);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(45, 22);
            this.StatusLabel.Text = "Status :";
            // 
            // StatusLabelInfo
            // 
            this.StatusLabelInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLabelInfo.Name = "StatusLabelInfo";
            this.StatusLabelInfo.Size = new System.Drawing.Size(49, 22);
            this.StatusLabelInfo.Text = "nothing";
            // 
            // StatusLabelInfoTrash
            // 
            this.StatusLabelInfoTrash.Name = "StatusLabelInfoTrash";
            this.StatusLabelInfoTrash.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PixelLabel
            // 
            this.PixelLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PixelLabel.Name = "PixelLabel";
            this.PixelLabel.Size = new System.Drawing.Size(38, 22);
            this.PixelLabel.Text = "Pixel :";
            // 
            // PixelDataValue
            // 
            this.PixelDataValue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PixelDataValue.Name = "PixelDataValue";
            this.PixelDataValue.Size = new System.Drawing.Size(92, 22);
            this.PixelDataValue.Text = "Data not avaible";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoSettingsToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.logoffToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1123, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // videoSettingsToolStripMenuItem
            // 
            this.videoSettingsToolStripMenuItem.Name = "videoSettingsToolStripMenuItem";
            this.videoSettingsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.videoSettingsToolStripMenuItem.Text = "Video Settings";
            this.videoSettingsToolStripMenuItem.Click += new System.EventHandler(this.videoSettingsToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.logoffToolStripMenuItem.Text = "Logoff";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.virtualTriggerBtn);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.processImageBtn);
            this.GroupBox1.Controls.Add(this.triggerModeBtn);
            this.GroupBox1.Controls.Add(this.viewModeBtn);
            this.GroupBox1.Location = new System.Drawing.Point(3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(320, 102);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Manual Commands";
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // virtualTriggerBtn
            // 
            this.virtualTriggerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.virtualTriggerBtn.BackColor = System.Drawing.Color.Silver;
            this.virtualTriggerBtn.Location = new System.Drawing.Point(161, 31);
            this.virtualTriggerBtn.Name = "virtualTriggerBtn";
            this.virtualTriggerBtn.Size = new System.Drawing.Size(65, 55);
            this.virtualTriggerBtn.TabIndex = 74;
            this.virtualTriggerBtn.Text = "TRIGGER";
            this.virtualTriggerBtn.UseVisualStyleBackColor = false;
            this.virtualTriggerBtn.Click += new System.EventHandler(this.virtualTriggerBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "View Mode";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Trigger Source";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // processImageBtn
            // 
            this.processImageBtn.BackColor = System.Drawing.Color.Silver;
            this.processImageBtn.Location = new System.Drawing.Point(226, 31);
            this.processImageBtn.Name = "processImageBtn";
            this.processImageBtn.Size = new System.Drawing.Size(90, 55);
            this.processImageBtn.TabIndex = 73;
            this.processImageBtn.Text = "PROCESS FRAME";
            this.processImageBtn.UseVisualStyleBackColor = false;
            this.processImageBtn.Click += new System.EventHandler(this.processImageBtn_Click);
            // 
            // triggerModeBtn
            // 
            this.triggerModeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.triggerModeBtn.BackColor = System.Drawing.Color.Silver;
            this.triggerModeBtn.Location = new System.Drawing.Point(80, 32);
            this.triggerModeBtn.Name = "triggerModeBtn";
            this.triggerModeBtn.Size = new System.Drawing.Size(81, 55);
            this.triggerModeBtn.TabIndex = 72;
            this.triggerModeBtn.Text = "SOFTWARE";
            this.triggerModeBtn.UseVisualStyleBackColor = false;
            this.triggerModeBtn.Click += new System.EventHandler(this.triggerModeBtn_Click);
            // 
            // viewModeBtn
            // 
            this.viewModeBtn.BackColor = System.Drawing.Color.Silver;
            this.viewModeBtn.Location = new System.Drawing.Point(12, 34);
            this.viewModeBtn.Name = "viewModeBtn";
            this.viewModeBtn.Size = new System.Drawing.Size(69, 55);
            this.viewModeBtn.TabIndex = 69;
            this.viewModeBtn.Text = "FRAME";
            this.viewModeBtn.UseVisualStyleBackColor = false;
            this.viewModeBtn.Click += new System.EventHandler(this.Cmd_Trigger_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.Txt_mode);
            this.GroupBox8.Controls.Add(this.BtnLocalRemote);
            this.GroupBox8.Location = new System.Drawing.Point(15, 239);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(293, 49);
            this.GroupBox8.TabIndex = 112;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Operation Mode";
            // 
            // Txt_mode
            // 
            this.Txt_mode.AutoSize = true;
            this.Txt_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_mode.Location = new System.Drawing.Point(48, 19);
            this.Txt_mode.Name = "Txt_mode";
            this.Txt_mode.Size = new System.Drawing.Size(45, 16);
            this.Txt_mode.TabIndex = 94;
            this.Txt_mode.Text = "Local";
            // 
            // BtnLocalRemote
            // 
            this.BtnLocalRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnLocalRemote.BackColor = System.Drawing.Color.Silver;
            this.BtnLocalRemote.Location = new System.Drawing.Point(145, 3);
            this.BtnLocalRemote.Name = "BtnLocalRemote";
            this.BtnLocalRemote.Size = new System.Drawing.Size(84, 40);
            this.BtnLocalRemote.TabIndex = 75;
            this.BtnLocalRemote.Text = "Toggle Mode";
            this.BtnLocalRemote.UseVisualStyleBackColor = false;
            this.BtnLocalRemote.Click += new System.EventHandler(this.BtnLocalRemote_Click);
            // 
            // GroupBox17
            // 
            this.GroupBox17.Controls.Add(this.minDiameterUnitsTxt);
            this.GroupBox17.Controls.Add(this.maxDiameterUnitsTxt);
            this.GroupBox17.Controls.Add(this.Txt_MaxCompacity);
            this.GroupBox17.Controls.Add(this.Label50);
            this.GroupBox17.Controls.Add(this.Txt_MaxOvality);
            this.GroupBox17.Controls.Add(this.Txt_MinDiameter);
            this.GroupBox17.Controls.Add(this.Label53);
            this.GroupBox17.Controls.Add(this.Label54);
            this.GroupBox17.Controls.Add(this.Label55);
            this.GroupBox17.Controls.Add(this.Txt_MaxDiameter);
            this.GroupBox17.Location = new System.Drawing.Point(15, 303);
            this.GroupBox17.Name = "GroupBox17";
            this.GroupBox17.Size = new System.Drawing.Size(293, 108);
            this.GroupBox17.TabIndex = 111;
            this.GroupBox17.TabStop = false;
            this.GroupBox17.Text = "Actual Target Sizes";
            // 
            // Txt_MaxCompacity
            // 
            this.Txt_MaxCompacity.Location = new System.Drawing.Point(152, 79);
            this.Txt_MaxCompacity.Name = "Txt_MaxCompacity";
            this.Txt_MaxCompacity.Size = new System.Drawing.Size(63, 20);
            this.Txt_MaxCompacity.TabIndex = 94;
            this.Txt_MaxCompacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label50
            // 
            this.Label50.AutoSize = true;
            this.Label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label50.Location = new System.Drawing.Point(19, 81);
            this.Label50.Name = "Label50";
            this.Label50.Size = new System.Drawing.Size(116, 16);
            this.Label50.TabIndex = 93;
            this.Label50.Text = "Max Compacity:";
            // 
            // Txt_MaxOvality
            // 
            this.Txt_MaxOvality.Location = new System.Drawing.Point(152, 58);
            this.Txt_MaxOvality.Name = "Txt_MaxOvality";
            this.Txt_MaxOvality.Size = new System.Drawing.Size(63, 20);
            this.Txt_MaxOvality.TabIndex = 92;
            this.Txt_MaxOvality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_MinDiameter
            // 
            this.Txt_MinDiameter.Location = new System.Drawing.Point(152, 37);
            this.Txt_MinDiameter.Name = "Txt_MinDiameter";
            this.Txt_MinDiameter.Size = new System.Drawing.Size(63, 20);
            this.Txt_MinDiameter.TabIndex = 91;
            this.Txt_MinDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label53.Location = new System.Drawing.Point(19, 60);
            this.Label53.Name = "Label53";
            this.Label53.Size = new System.Drawing.Size(91, 16);
            this.Label53.TabIndex = 90;
            this.Label53.Text = "Max Ovality:";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label54.Location = new System.Drawing.Point(19, 39);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(102, 16);
            this.Label54.TabIndex = 89;
            this.Label54.Text = "Min Diameter:";
            // 
            // Label55
            // 
            this.Label55.AutoSize = true;
            this.Label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label55.Location = new System.Drawing.Point(19, 18);
            this.Label55.Name = "Label55";
            this.Label55.Size = new System.Drawing.Size(106, 16);
            this.Label55.TabIndex = 88;
            this.Label55.Text = "Max Diameter:";
            // 
            // Txt_MaxDiameter
            // 
            this.Txt_MaxDiameter.Location = new System.Drawing.Point(152, 16);
            this.Txt_MaxDiameter.Name = "Txt_MaxDiameter";
            this.Txt_MaxDiameter.Size = new System.Drawing.Size(63, 20);
            this.Txt_MaxDiameter.TabIndex = 87;
            this.Txt_MaxDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MaxDiameter.TextChanged += new System.EventHandler(this.Txt_MaxDiameter_TextChanged);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.grid_16);
            this.GroupBox5.Controls.Add(this.grid_12);
            this.GroupBox5.Controls.Add(this.grid_6);
            this.GroupBox5.Controls.Add(this.grid_5);
            this.GroupBox5.Controls.Add(this.grid_4);
            this.GroupBox5.Controls.Add(this.grid_9);
            this.GroupBox5.Location = new System.Drawing.Point(15, 417);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(297, 111);
            this.GroupBox5.TabIndex = 109;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Select Grid";
            // 
            // grid_16
            // 
            this.grid_16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_16.BackColor = System.Drawing.Color.Silver;
            this.grid_16.Location = new System.Drawing.Point(226, 63);
            this.grid_16.Name = "grid_16";
            this.grid_16.Size = new System.Drawing.Size(67, 42);
            this.grid_16.TabIndex = 75;
            this.grid_16.UseVisualStyleBackColor = false;
            this.grid_16.Click += new System.EventHandler(this.Cmd_Program_6_Click);
            // 
            // grid_12
            // 
            this.grid_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_12.BackColor = System.Drawing.Color.Silver;
            this.grid_12.Location = new System.Drawing.Point(120, 63);
            this.grid_12.Name = "grid_12";
            this.grid_12.Size = new System.Drawing.Size(67, 42);
            this.grid_12.TabIndex = 74;
            this.grid_12.UseVisualStyleBackColor = false;
            this.grid_12.Click += new System.EventHandler(this.Cmd_Program_5_Click);
            // 
            // grid_6
            // 
            this.grid_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_6.BackColor = System.Drawing.Color.Silver;
            this.grid_6.Location = new System.Drawing.Point(226, 19);
            this.grid_6.Name = "grid_6";
            this.grid_6.Size = new System.Drawing.Size(67, 42);
            this.grid_6.TabIndex = 73;
            this.grid_6.Text = "4x4";
            this.grid_6.UseVisualStyleBackColor = false;
            this.grid_6.Click += new System.EventHandler(this.grid_6_Click);
            // 
            // grid_5
            // 
            this.grid_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_5.BackColor = System.Drawing.Color.Silver;
            this.grid_5.Location = new System.Drawing.Point(119, 19);
            this.grid_5.Name = "grid_5";
            this.grid_5.Size = new System.Drawing.Size(67, 42);
            this.grid_5.TabIndex = 72;
            this.grid_5.Text = "5";
            this.grid_5.UseVisualStyleBackColor = false;
            this.grid_5.Click += new System.EventHandler(this.grid_5_Click);
            // 
            // grid_4
            // 
            this.grid_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_4.BackColor = System.Drawing.Color.Silver;
            this.grid_4.Location = new System.Drawing.Point(13, 19);
            this.grid_4.Name = "grid_4";
            this.grid_4.Size = new System.Drawing.Size(67, 42);
            this.grid_4.TabIndex = 71;
            this.grid_4.Text = "3x3";
            this.grid_4.UseVisualStyleBackColor = false;
            this.grid_4.Click += new System.EventHandler(this.grid_4_Click);
            // 
            // grid_9
            // 
            this.grid_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_9.BackColor = System.Drawing.Color.Silver;
            this.grid_9.Location = new System.Drawing.Point(13, 63);
            this.grid_9.Name = "grid_9";
            this.grid_9.Size = new System.Drawing.Size(67, 42);
            this.grid_9.TabIndex = 70;
            this.grid_9.Text = "2x2";
            this.grid_9.UseVisualStyleBackColor = false;
            this.grid_9.Click += new System.EventHandler(this.grid_9_Click);
            // 
            // GB_Threshold
            // 
            this.GB_Threshold.Controls.Add(this.Chk_Threshold_Mode);
            this.GB_Threshold.Controls.Add(this.Txt_Threshold);
            this.GB_Threshold.Location = new System.Drawing.Point(3, 112);
            this.GB_Threshold.Name = "GB_Threshold";
            this.GB_Threshold.Size = new System.Drawing.Size(158, 47);
            this.GB_Threshold.TabIndex = 108;
            this.GB_Threshold.TabStop = false;
            this.GB_Threshold.Text = "Binary Threshold";
            // 
            // Chk_Threshold_Mode
            // 
            this.Chk_Threshold_Mode.AutoSize = true;
            this.Chk_Threshold_Mode.Checked = true;
            this.Chk_Threshold_Mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Threshold_Mode.Location = new System.Drawing.Point(82, 23);
            this.Chk_Threshold_Mode.Name = "Chk_Threshold_Mode";
            this.Chk_Threshold_Mode.Size = new System.Drawing.Size(73, 17);
            this.Chk_Threshold_Mode.TabIndex = 13;
            this.Chk_Threshold_Mode.Text = "Automatic";
            this.Chk_Threshold_Mode.UseVisualStyleBackColor = true;
            this.Chk_Threshold_Mode.CheckedChanged += new System.EventHandler(this.Chk_Threshold_Mode_CheckedChanged);
            // 
            // Txt_Threshold
            // 
            this.Txt_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Threshold.Location = new System.Drawing.Point(22, 21);
            this.Txt_Threshold.Name = "Txt_Threshold";
            this.Txt_Threshold.Size = new System.Drawing.Size(38, 20);
            this.Txt_Threshold.TabIndex = 12;
            this.Txt_Threshold.Text = "0";
            this.Txt_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Threshold.TextChanged += new System.EventHandler(this.Txt_Threshold_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 114;
            // 
            // btnsave
            // 
            this.btnsave.AllowDrop = true;
            this.btnsave.Location = new System.Drawing.Point(69, 305);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(169, 23);
            this.btnsave.TabIndex = 116;
            this.btnsave.Text = "save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1109, 611);
            this.dataGridView1.TabIndex = 117;
            // 
            // controlsTabs
            // 
            this.controlsTabs.Controls.Add(this.commandsPage);
            this.controlsTabs.Controls.Add(this.cameraControlPage);
            this.controlsTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlsTabs.Location = new System.Drawing.Point(790, 0);
            this.controlsTabs.Name = "controlsTabs";
            this.controlsTabs.SelectedIndex = 0;
            this.controlsTabs.Size = new System.Drawing.Size(333, 643);
            this.controlsTabs.TabIndex = 118;
            // 
            // commandsPage
            // 
            this.commandsPage.Controls.Add(this.unitsTxt);
            this.commandsPage.Controls.Add(this.label6);
            this.commandsPage.Controls.Add(this.GroupBox5);
            this.commandsPage.Controls.Add(this.groupBox3);
            this.commandsPage.Controls.Add(this.groupBox2);
            this.commandsPage.Controls.Add(this.GroupBox1);
            this.commandsPage.Controls.Add(this.GB_Threshold);
            this.commandsPage.Controls.Add(this.GroupBox8);
            this.commandsPage.Controls.Add(this.GroupBox17);
            this.commandsPage.Location = new System.Drawing.Point(4, 22);
            this.commandsPage.Name = "commandsPage";
            this.commandsPage.Padding = new System.Windows.Forms.Padding(3);
            this.commandsPage.Size = new System.Drawing.Size(325, 617);
            this.commandsPage.TabIndex = 0;
            this.commandsPage.Text = " Main";
            this.commandsPage.UseVisualStyleBackColor = true;
            // 
            // unitsTxt
            // 
            this.unitsTxt.AutoSize = true;
            this.unitsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsTxt.Location = new System.Drawing.Point(155, 555);
            this.unitsTxt.Name = "unitsTxt";
            this.unitsTxt.Size = new System.Drawing.Size(53, 29);
            this.unitsTxt.TabIndex = 116;
            this.unitsTxt.Text = "mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 555);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 29);
            this.label6.TabIndex = 115;
            this.label6.Text = "Units:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.diametersTxtCheck);
            this.groupBox3.Location = new System.Drawing.Point(161, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 47);
            this.groupBox3.TabIndex = 109;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show Diameters Text";
            // 
            // diametersTxtCheck
            // 
            this.diametersTxtCheck.AutoSize = true;
            this.diametersTxtCheck.Checked = true;
            this.diametersTxtCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.diametersTxtCheck.Location = new System.Drawing.Point(56, 23);
            this.diametersTxtCheck.Name = "diametersTxtCheck";
            this.diametersTxtCheck.Size = new System.Drawing.Size(15, 14);
            this.diametersTxtCheck.TabIndex = 13;
            this.diametersTxtCheck.UseVisualStyleBackColor = true;
            this.diametersTxtCheck.CheckedChanged += new System.EventHandler(this.diametersTxtCheck_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.avg_diameter);
            this.groupBox2.Location = new System.Drawing.Point(15, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 58);
            this.groupBox2.TabIndex = 114;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equivalent Diameter";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // avg_diameter
            // 
            this.avg_diameter.AutoSize = true;
            this.avg_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_diameter.Location = new System.Drawing.Point(119, 19);
            this.avg_diameter.Name = "avg_diameter";
            this.avg_diameter.Size = new System.Drawing.Size(24, 25);
            this.avg_diameter.TabIndex = 0;
            this.avg_diameter.Text = "0";
            this.avg_diameter.Click += new System.EventHandler(this.avg_diameter_Click);
            // 
            // cameraControlPage
            // 
            this.cameraControlPage.Controls.Add(this.groupBox4);
            this.cameraControlPage.Controls.Add(this.btnsave);
            this.cameraControlPage.Location = new System.Drawing.Point(4, 22);
            this.cameraControlPage.Name = "cameraControlPage";
            this.cameraControlPage.Padding = new System.Windows.Forms.Padding(3);
            this.cameraControlPage.Size = new System.Drawing.Size(325, 617);
            this.cameraControlPage.TabIndex = 1;
            this.cameraControlPage.Text = "Configuration";
            this.cameraControlPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.targetUnitsTxt);
            this.groupBox4.Controls.Add(this.calibrateBtn);
            this.groupBox4.Controls.Add(this.txtCalibrationTarget);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.euListSelection);
            this.groupBox4.Location = new System.Drawing.Point(6, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 172);
            this.groupBox4.TabIndex = 117;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calibration";
            // 
            // targetUnitsTxt
            // 
            this.targetUnitsTxt.AutoSize = true;
            this.targetUnitsTxt.Location = new System.Drawing.Point(157, 63);
            this.targetUnitsTxt.Name = "targetUnitsTxt";
            this.targetUnitsTxt.Size = new System.Drawing.Size(23, 13);
            this.targetUnitsTxt.TabIndex = 5;
            this.targetUnitsTxt.Text = "mm";
            // 
            // calibrateBtn
            // 
            this.calibrateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrateBtn.Location = new System.Drawing.Point(44, 98);
            this.calibrateBtn.Name = "calibrateBtn";
            this.calibrateBtn.Size = new System.Drawing.Size(84, 27);
            this.calibrateBtn.TabIndex = 4;
            this.calibrateBtn.Text = "Calibrate";
            this.calibrateBtn.UseVisualStyleBackColor = true;
            this.calibrateBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCalibrationTarget
            // 
            this.txtCalibrationTarget.Location = new System.Drawing.Point(81, 56);
            this.txtCalibrationTarget.Name = "txtCalibrationTarget";
            this.txtCalibrationTarget.Size = new System.Drawing.Size(69, 20);
            this.txtCalibrationTarget.TabIndex = 3;
            this.txtCalibrationTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCalibrationTarget.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Target:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "EU:";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // euListSelection
            // 
            this.euListSelection.FormattingEnabled = true;
            this.euListSelection.Items.AddRange(new object[] {
            "mm",
            "inch"});
            this.euListSelection.Location = new System.Drawing.Point(82, 26);
            this.euListSelection.Name = "euListSelection";
            this.euListSelection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.euListSelection.Size = new System.Drawing.Size(68, 21);
            this.euListSelection.TabIndex = 0;
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.imagePage);
            this.mainTabs.Controls.Add(this.tablePage);
            this.mainTabs.Controls.Add(this.productsPage);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(1123, 643);
            this.mainTabs.TabIndex = 119;
            // 
            // imagePage
            // 
            this.imagePage.Controls.Add(this.originalBox);
            this.imagePage.Controls.Add(this.processROIBox);
            this.imagePage.Location = new System.Drawing.Point(4, 22);
            this.imagePage.Name = "imagePage";
            this.imagePage.Padding = new System.Windows.Forms.Padding(3);
            this.imagePage.Size = new System.Drawing.Size(1115, 617);
            this.imagePage.TabIndex = 0;
            this.imagePage.Text = "Image";
            this.imagePage.UseVisualStyleBackColor = true;
            this.imagePage.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // originalBox
            // 
            this.originalBox.Location = new System.Drawing.Point(0, 0);
            this.originalBox.Name = "originalBox";
            this.originalBox.Size = new System.Drawing.Size(716, 239);
            this.originalBox.TabIndex = 1;
            this.originalBox.TabStop = false;
            this.originalBox.Visible = false;
            // 
            // processROIBox
            // 
            this.processROIBox.Location = new System.Drawing.Point(0, 232);
            this.processROIBox.Name = "processROIBox";
            this.processROIBox.Size = new System.Drawing.Size(716, 263);
            this.processROIBox.TabIndex = 0;
            this.processROIBox.TabStop = false;
            this.processROIBox.Visible = false;
            // 
            // tablePage
            // 
            this.tablePage.Controls.Add(this.button1);
            this.tablePage.Controls.Add(this.textBox1);
            this.tablePage.Controls.Add(this.dataGridView1);
            this.tablePage.Location = new System.Drawing.Point(4, 22);
            this.tablePage.Name = "tablePage";
            this.tablePage.Padding = new System.Windows.Forms.Padding(3);
            this.tablePage.Size = new System.Drawing.Size(1115, 617);
            this.tablePage.TabIndex = 1;
            this.tablePage.Text = "Table";
            this.tablePage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 120;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 485);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(496, 20);
            this.textBox1.TabIndex = 118;
            // 
            // productsPage
            // 
            this.productsPage.Controls.Add(this.GroupBox13);
            this.productsPage.Controls.Add(this.GroupBox12);
            this.productsPage.Controls.Add(this.GroupBox11);
            this.productsPage.Controls.Add(this.CmdAdd);
            this.productsPage.Controls.Add(this.CmdUpdate);
            this.productsPage.Controls.Add(this.GroupBox10);
            this.productsPage.Controls.Add(this.CmdDelete);
            this.productsPage.Controls.Add(this.GroupBox9);
            this.productsPage.Controls.Add(this.Cmd_video);
            this.productsPage.Controls.Add(this.Cmd_Calibration);
            this.productsPage.Controls.Add(this.Cmd_Save);
            this.productsPage.Location = new System.Drawing.Point(4, 22);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(3);
            this.productsPage.Size = new System.Drawing.Size(1115, 617);
            this.productsPage.TabIndex = 2;
            this.productsPage.Text = "Products";
            this.productsPage.UseVisualStyleBackColor = true;
            // 
            // GroupBox13
            // 
            this.GroupBox13.Controls.Add(this.Label47);
            this.GroupBox13.Controls.Add(this.Chk_Right_Side);
            this.GroupBox13.Controls.Add(this.Txt_Tag);
            this.GroupBox13.Location = new System.Drawing.Point(210, 239);
            this.GroupBox13.Name = "GroupBox13";
            this.GroupBox13.Size = new System.Drawing.Size(205, 151);
            this.GroupBox13.TabIndex = 122;
            this.GroupBox13.TabStop = false;
            this.GroupBox13.Text = "Misc";
            // 
            // Label47
            // 
            this.Label47.AutoSize = true;
            this.Label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label47.Location = new System.Drawing.Point(6, 25);
            this.Label47.Name = "Label47";
            this.Label47.Size = new System.Drawing.Size(39, 16);
            this.Label47.TabIndex = 93;
            this.Label47.Text = "Tag:";
            // 
            // Chk_Right_Side
            // 
            this.Chk_Right_Side.AutoSize = true;
            this.Chk_Right_Side.Location = new System.Drawing.Point(49, 59);
            this.Chk_Right_Side.Name = "Chk_Right_Side";
            this.Chk_Right_Side.Size = new System.Drawing.Size(117, 17);
            this.Chk_Right_Side.TabIndex = 100;
            this.Chk_Right_Side.Text = "Installed Right Side";
            this.Chk_Right_Side.UseVisualStyleBackColor = true;
            // 
            // Txt_Tag
            // 
            this.Txt_Tag.Location = new System.Drawing.Point(49, 24);
            this.Txt_Tag.MaxLength = 20;
            this.Txt_Tag.Name = "Txt_Tag";
            this.Txt_Tag.Size = new System.Drawing.Size(150, 20);
            this.Txt_Tag.TabIndex = 94;
            this.Txt_Tag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox12
            // 
            this.GroupBox12.Controls.Add(this.Label19);
            this.GroupBox12.Controls.Add(this.Txt_Line_Width);
            this.GroupBox12.Controls.Add(this.Label44);
            this.GroupBox12.Controls.Add(this.Label45);
            this.GroupBox12.Controls.Add(this.txt_under_size);
            this.GroupBox12.Controls.Add(this.txt_over_size);
            this.GroupBox12.Controls.Add(this.Label38);
            this.GroupBox12.Controls.Add(this.Txt_Max_Threshold);
            this.GroupBox12.Controls.Add(this.Chk_Digital_Knife);
            this.GroupBox12.Location = new System.Drawing.Point(421, 243);
            this.GroupBox12.Name = "GroupBox12";
            this.GroupBox12.Size = new System.Drawing.Size(197, 157);
            this.GroupBox12.TabIndex = 121;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "Parameters";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(13, 21);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(83, 16);
            this.Label19.TabIndex = 82;
            this.Label19.Text = "Line Width:";
            // 
            // Txt_Line_Width
            // 
            this.Txt_Line_Width.Location = new System.Drawing.Point(128, 19);
            this.Txt_Line_Width.Name = "Txt_Line_Width";
            this.Txt_Line_Width.Size = new System.Drawing.Size(63, 20);
            this.Txt_Line_Width.TabIndex = 81;
            this.Txt_Line_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label44.Location = new System.Drawing.Point(13, 53);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(87, 16);
            this.Label44.TabIndex = 83;
            this.Label44.Text = "Under Size:";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label45.Location = new System.Drawing.Point(13, 80);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(78, 16);
            this.Label45.TabIndex = 84;
            this.Label45.Text = "Over Size:";
            // 
            // txt_under_size
            // 
            this.txt_under_size.Location = new System.Drawing.Point(128, 51);
            this.txt_under_size.Name = "txt_under_size";
            this.txt_under_size.Size = new System.Drawing.Size(63, 20);
            this.txt_under_size.TabIndex = 85;
            this.txt_under_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_over_size
            // 
            this.txt_over_size.Location = new System.Drawing.Point(128, 78);
            this.txt_over_size.Name = "txt_over_size";
            this.txt_over_size.Size = new System.Drawing.Size(63, 20);
            this.txt_over_size.TabIndex = 86;
            this.txt_over_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label38.Location = new System.Drawing.Point(14, 108);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(113, 16);
            this.Label38.TabIndex = 96;
            this.Label38.Text = "Max Threshold:";
            // 
            // Txt_Max_Threshold
            // 
            this.Txt_Max_Threshold.Location = new System.Drawing.Point(128, 106);
            this.Txt_Max_Threshold.Name = "Txt_Max_Threshold";
            this.Txt_Max_Threshold.Size = new System.Drawing.Size(63, 20);
            this.Txt_Max_Threshold.TabIndex = 97;
            this.Txt_Max_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Chk_Digital_Knife
            // 
            this.Chk_Digital_Knife.AutoSize = true;
            this.Chk_Digital_Knife.Checked = true;
            this.Chk_Digital_Knife.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Digital_Knife.Location = new System.Drawing.Point(59, 133);
            this.Chk_Digital_Knife.Name = "Chk_Digital_Knife";
            this.Chk_Digital_Knife.Size = new System.Drawing.Size(82, 17);
            this.Chk_Digital_Knife.TabIndex = 95;
            this.Chk_Digital_Knife.Text = "Digital Knife";
            this.Chk_Digital_Knife.UseVisualStyleBackColor = true;
            // 
            // GroupBox11
            // 
            this.GroupBox11.Controls.Add(this.TableLayoutPanel3);
            this.GroupBox11.Location = new System.Drawing.Point(2, 243);
            this.GroupBox11.Name = "GroupBox11";
            this.GroupBox11.Size = new System.Drawing.Size(197, 155);
            this.GroupBox11.TabIndex = 120;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "ROI Definition";
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Controls.Add(this.TXT_ROI_Bottom, 1, 3);
            this.TableLayoutPanel3.Controls.Add(this.TXT_ROI_Right, 1, 2);
            this.TableLayoutPanel3.Controls.Add(this.TXT_ROI_Top, 1, 1);
            this.TableLayoutPanel3.Controls.Add(this.TXT_ROI_Left, 1, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label34, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label35, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.Label36, 0, 2);
            this.TableLayoutPanel3.Controls.Add(this.Label37, 0, 3);
            this.TableLayoutPanel3.Location = new System.Drawing.Point(16, 23);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 4;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(168, 120);
            this.TableLayoutPanel3.TabIndex = 80;
            // 
            // TXT_ROI_Bottom
            // 
            this.TXT_ROI_Bottom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXT_ROI_Bottom.Location = new System.Drawing.Point(106, 97);
            this.TXT_ROI_Bottom.Name = "TXT_ROI_Bottom";
            this.TXT_ROI_Bottom.Size = new System.Drawing.Size(38, 20);
            this.TXT_ROI_Bottom.TabIndex = 87;
            this.TXT_ROI_Bottom.Text = "0";
            this.TXT_ROI_Bottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TXT_ROI_Right
            // 
            this.TXT_ROI_Right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXT_ROI_Right.Location = new System.Drawing.Point(106, 68);
            this.TXT_ROI_Right.Name = "TXT_ROI_Right";
            this.TXT_ROI_Right.Size = new System.Drawing.Size(38, 20);
            this.TXT_ROI_Right.TabIndex = 86;
            this.TXT_ROI_Right.Text = "0";
            this.TXT_ROI_Right.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TXT_ROI_Top
            // 
            this.TXT_ROI_Top.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXT_ROI_Top.Location = new System.Drawing.Point(106, 37);
            this.TXT_ROI_Top.Name = "TXT_ROI_Top";
            this.TXT_ROI_Top.Size = new System.Drawing.Size(38, 20);
            this.TXT_ROI_Top.TabIndex = 85;
            this.TXT_ROI_Top.Text = "0";
            this.TXT_ROI_Top.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TXT_ROI_Left
            // 
            this.TXT_ROI_Left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXT_ROI_Left.Location = new System.Drawing.Point(106, 6);
            this.TXT_ROI_Left.Name = "TXT_ROI_Left";
            this.TXT_ROI_Left.Size = new System.Drawing.Size(38, 20);
            this.TXT_ROI_Left.TabIndex = 81;
            this.TXT_ROI_Left.Text = "0";
            this.TXT_ROI_Left.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label34.Location = new System.Drawing.Point(4, 1);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(32, 16);
            this.Label34.TabIndex = 81;
            this.Label34.Text = "Left";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(4, 32);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(35, 16);
            this.Label35.TabIndex = 82;
            this.Label35.Text = "Top";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.Location = new System.Drawing.Point(4, 63);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(43, 16);
            this.Label36.TabIndex = 83;
            this.Label36.Text = "Right";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.Location = new System.Drawing.Point(4, 94);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(55, 16);
            this.Label37.TabIndex = 84;
            this.Label37.Text = "Bottom";
            // 
            // CmdAdd
            // 
            this.CmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdAdd.AutoSize = true;
            this.CmdAdd.BackColor = System.Drawing.Color.Silver;
            this.CmdAdd.Location = new System.Drawing.Point(506, 181);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(70, 55);
            this.CmdAdd.TabIndex = 119;
            this.CmdAdd.Text = "Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdUpdate.AutoSize = true;
            this.CmdUpdate.BackColor = System.Drawing.Color.Silver;
            this.CmdUpdate.Location = new System.Drawing.Point(581, 181);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(70, 55);
            this.CmdUpdate.TabIndex = 118;
            this.CmdUpdate.Text = "Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            // 
            // GroupBox10
            // 
            this.GroupBox10.Controls.Add(this.CmbProducts);
            this.GroupBox10.Location = new System.Drawing.Point(2, 2);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(774, 55);
            this.GroupBox10.TabIndex = 117;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Products";
            // 
            // CmbProducts
            // 
            this.CmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProducts.FormattingEnabled = true;
            this.CmbProducts.Location = new System.Drawing.Point(13, 21);
            this.CmbProducts.Name = "CmbProducts";
            this.CmbProducts.Size = new System.Drawing.Size(263, 21);
            this.CmbProducts.TabIndex = 106;
            // 
            // CmdDelete
            // 
            this.CmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdDelete.BackColor = System.Drawing.Color.Silver;
            this.CmdDelete.Location = new System.Drawing.Point(505, 243);
            this.CmdDelete.Name = "CmdDelete";
            this.CmdDelete.Size = new System.Drawing.Size(70, 55);
            this.CmdDelete.TabIndex = 116;
            this.CmdDelete.Text = "Delete";
            this.CmdDelete.UseVisualStyleBackColor = false;
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.Txt_Compacity);
            this.GroupBox9.Controls.Add(this.Label46);
            this.GroupBox9.Controls.Add(this.Txt_Description);
            this.GroupBox9.Controls.Add(this.Txt_Code);
            this.GroupBox9.Controls.Add(this.Txt_Ovality);
            this.GroupBox9.Controls.Add(this.Txt_MinD);
            this.GroupBox9.Controls.Add(this.Label30);
            this.GroupBox9.Controls.Add(this.Label31);
            this.GroupBox9.Controls.Add(this.Label32);
            this.GroupBox9.Controls.Add(this.Txt_MaxD);
            this.GroupBox9.Controls.Add(this.Label27);
            this.GroupBox9.Controls.Add(this.Label28);
            this.GroupBox9.Location = new System.Drawing.Point(2, 60);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(497, 173);
            this.GroupBox9.TabIndex = 115;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Products Database";
            // 
            // Txt_Compacity
            // 
            this.Txt_Compacity.Location = new System.Drawing.Point(160, 133);
            this.Txt_Compacity.Name = "Txt_Compacity";
            this.Txt_Compacity.Size = new System.Drawing.Size(63, 20);
            this.Txt_Compacity.TabIndex = 102;
            this.Txt_Compacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label46
            // 
            this.Label46.AutoSize = true;
            this.Label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label46.Location = new System.Drawing.Point(15, 135);
            this.Label46.Name = "Label46";
            this.Label46.Size = new System.Drawing.Size(116, 16);
            this.Label46.TabIndex = 101;
            this.Label46.Text = "Max Compacity:";
            // 
            // Txt_Description
            // 
            this.Txt_Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Description.Location = new System.Drawing.Point(160, 47);
            this.Txt_Description.MaxLength = 40;
            this.Txt_Description.Name = "Txt_Description";
            this.Txt_Description.Size = new System.Drawing.Size(324, 20);
            this.Txt_Description.TabIndex = 100;
            this.Txt_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Code
            // 
            this.Txt_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Code.Location = new System.Drawing.Point(160, 24);
            this.Txt_Code.MaxLength = 16;
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.Size = new System.Drawing.Size(197, 20);
            this.Txt_Code.TabIndex = 99;
            this.Txt_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Ovality
            // 
            this.Txt_Ovality.Location = new System.Drawing.Point(160, 112);
            this.Txt_Ovality.Name = "Txt_Ovality";
            this.Txt_Ovality.Size = new System.Drawing.Size(63, 20);
            this.Txt_Ovality.TabIndex = 98;
            this.Txt_Ovality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_MinD
            // 
            this.Txt_MinD.Location = new System.Drawing.Point(160, 91);
            this.Txt_MinD.Name = "Txt_MinD";
            this.Txt_MinD.Size = new System.Drawing.Size(63, 20);
            this.Txt_MinD.TabIndex = 97;
            this.Txt_MinD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label30.Location = new System.Drawing.Point(15, 114);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(87, 16);
            this.Label30.TabIndex = 96;
            this.Label30.Text = "Min Ovality:";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(15, 93);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(102, 16);
            this.Label31.TabIndex = 95;
            this.Label31.Text = "Min Diameter:";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(15, 72);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(106, 16);
            this.Label32.TabIndex = 94;
            this.Label32.Text = "Max Diameter:";
            // 
            // Txt_MaxD
            // 
            this.Txt_MaxD.Location = new System.Drawing.Point(160, 70);
            this.Txt_MaxD.Name = "Txt_MaxD";
            this.Txt_MaxD.Size = new System.Drawing.Size(63, 20);
            this.Txt_MaxD.TabIndex = 93;
            this.Txt_MaxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(15, 51);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(147, 16);
            this.Label27.TabIndex = 85;
            this.Label27.Text = "Product Description:";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label28.Location = new System.Drawing.Point(15, 30);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(105, 16);
            this.Label28.TabIndex = 84;
            this.Label28.Text = "Product Code:";
            // 
            // Cmd_video
            // 
            this.Cmd_video.BackColor = System.Drawing.Color.Silver;
            this.Cmd_video.Location = new System.Drawing.Point(582, 130);
            this.Cmd_video.Name = "Cmd_video";
            this.Cmd_video.Size = new System.Drawing.Size(69, 23);
            this.Cmd_video.TabIndex = 113;
            this.Cmd_video.Text = "Start Video";
            this.Cmd_video.UseVisualStyleBackColor = false;
            this.Cmd_video.Visible = false;
            // 
            // Cmd_Calibration
            // 
            this.Cmd_Calibration.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Calibration.Location = new System.Drawing.Point(582, 159);
            this.Cmd_Calibration.Name = "Cmd_Calibration";
            this.Cmd_Calibration.Size = new System.Drawing.Size(69, 23);
            this.Cmd_Calibration.TabIndex = 112;
            this.Cmd_Calibration.Text = "Center";
            this.Cmd_Calibration.UseVisualStyleBackColor = false;
            this.Cmd_Calibration.Visible = false;
            // 
            // Cmd_Save
            // 
            this.Cmd_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cmd_Save.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Save.Location = new System.Drawing.Point(259, 576);
            this.Cmd_Save.Name = "Cmd_Save";
            this.Cmd_Save.Size = new System.Drawing.Size(129, 40);
            this.Cmd_Save.TabIndex = 114;
            this.Cmd_Save.Text = "Save";
            this.Cmd_Save.UseVisualStyleBackColor = false;
            // 
            // maxDiameterUnitsTxt
            // 
            this.maxDiameterUnitsTxt.AutoSize = true;
            this.maxDiameterUnitsTxt.Location = new System.Drawing.Point(223, 23);
            this.maxDiameterUnitsTxt.Name = "maxDiameterUnitsTxt";
            this.maxDiameterUnitsTxt.Size = new System.Drawing.Size(23, 13);
            this.maxDiameterUnitsTxt.TabIndex = 95;
            this.maxDiameterUnitsTxt.Text = "mm";
            // 
            // minDiameterUnitsTxt
            // 
            this.minDiameterUnitsTxt.AutoSize = true;
            this.minDiameterUnitsTxt.Location = new System.Drawing.Point(223, 46);
            this.minDiameterUnitsTxt.Name = "minDiameterUnitsTxt";
            this.minDiameterUnitsTxt.Size = new System.Drawing.Size(23, 13);
            this.minDiameterUnitsTxt.TabIndex = 96;
            this.minDiameterUnitsTxt.Text = "mm";
            // 
            // GigECameraDemoDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1123, 643);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.controlsTabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GigECameraDemoDlg";
            this.Text = "VISION SYSTEM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GigECameraDemoDlg_FormClosed);
            this.Load += new System.EventHandler(this.GigECameraDemoDlg_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox17.ResumeLayout(false);
            this.GroupBox17.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GB_Threshold.ResumeLayout(false);
            this.GB_Threshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.controlsTabs.ResumeLayout(false);
            this.commandsPage.ResumeLayout(false);
            this.commandsPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cameraControlPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.imagePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processROIBox)).EndInit();
            this.tablePage.ResumeLayout(false);
            this.tablePage.PerformLayout();
            this.productsPage.ResumeLayout(false);
            this.productsPage.PerformLayout();
            this.GroupBox13.ResumeLayout(false);
            this.GroupBox13.PerformLayout();
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel StatusLabel;
        private System.Windows.Forms.ToolStripLabel StatusLabelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel PixelLabel;
        private System.Windows.Forms.ToolStripLabel PixelDataValue;
        private System.Windows.Forms.ToolStripLabel StatusLabelInfoTrash;
        private ImageBox m_ImageBox;

        private SapAcqDevice m_AcqDevice;
        private SapBuffer m_Buffers;
        private SapGraphic m_Graphic;
        private SapAcqDeviceToBuf m_Xfer;
        private SapView m_View;
        private SapLocation m_ServerLocation;
        private string m_ConfigFileName;

        //System menu
        private SystemMenu m_SystemMenu;
        //index for "about this.." item im system menu
        private const int m_AboutID = 0x100;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem videoSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button triggerModeBtn;
        internal System.Windows.Forms.Button viewModeBtn;
        internal System.Windows.Forms.Button processImageBtn;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Label Txt_mode;
        internal System.Windows.Forms.Button BtnLocalRemote;
        internal System.Windows.Forms.GroupBox GroupBox17;
        internal System.Windows.Forms.TextBox Txt_MaxCompacity;
        internal System.Windows.Forms.Label Label50;
        internal System.Windows.Forms.TextBox Txt_MaxOvality;
        internal System.Windows.Forms.TextBox Txt_MinDiameter;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.Label Label55;
        internal System.Windows.Forms.TextBox Txt_MaxDiameter;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button grid_16;
        internal System.Windows.Forms.Button grid_12;
        internal System.Windows.Forms.Button grid_6;
        internal System.Windows.Forms.Button grid_5;
        internal System.Windows.Forms.Button grid_4;
        internal System.Windows.Forms.Button grid_9;
        internal System.Windows.Forms.GroupBox GB_Threshold;
        internal System.Windows.Forms.CheckBox Chk_Threshold_Mode;
        internal System.Windows.Forms.TextBox Txt_Threshold;
        private Label label1;
        private Button btnsave;
        private DataGridView dataGridView1;
        private TabControl controlsTabs;
        private TabPage commandsPage;
        private TabPage cameraControlPage;
        private TabControl mainTabs;
        private TabPage imagePage;
        private TabPage tablePage;
        private TabPage productsPage;
        internal GroupBox GroupBox13;
        internal Label Label47;
        internal CheckBox Chk_Right_Side;
        internal TextBox Txt_Tag;
        internal GroupBox GroupBox12;
        internal Label Label19;
        internal TextBox Txt_Line_Width;
        internal Label Label44;
        internal Label Label45;
        internal TextBox txt_under_size;
        internal TextBox txt_over_size;
        internal Label Label38;
        internal TextBox Txt_Max_Threshold;
        internal CheckBox Chk_Digital_Knife;
        internal GroupBox GroupBox11;
        internal TableLayoutPanel TableLayoutPanel3;
        internal TextBox TXT_ROI_Bottom;
        internal TextBox TXT_ROI_Right;
        internal TextBox TXT_ROI_Top;
        internal TextBox TXT_ROI_Left;
        internal Label Label34;
        internal Label Label35;
        internal Label Label36;
        internal Label Label37;
        internal Button CmdAdd;
        internal Button CmdUpdate;
        internal GroupBox GroupBox10;
        internal ComboBox CmbProducts;
        internal Button CmdDelete;
        internal GroupBox GroupBox9;
        internal TextBox Txt_Compacity;
        internal Label Label46;
        internal TextBox Txt_Description;
        internal TextBox Txt_Code;
        internal TextBox Txt_Ovality;
        internal TextBox Txt_MinD;
        internal Label Label30;
        internal Label Label31;
        internal Label Label32;
        internal TextBox Txt_MaxD;
        internal Label Label27;
        internal Label Label28;
        internal Button Cmd_video;
        internal Button Cmd_Calibration;
        internal Button Cmd_Save;
        internal GroupBox groupBox2;
        private Label avg_diameter;
        private PictureBox processROIBox;
        private PictureBox originalBox;
        internal Button virtualTriggerBtn;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        internal GroupBox groupBox3;
        internal CheckBox diametersTxtCheck;
        private GroupBox groupBox4;
        private Label label4;
        private ComboBox euListSelection;
        private Label label5;
        private Button calibrateBtn;
        private TextBox txtCalibrationTarget;
        private Label targetUnitsTxt;
        private Label unitsTxt;
        private Label label6;
        private Label minDiameterUnitsTxt;
        private Label maxDiameterUnitsTxt;
    }
}

