
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_File_Control = new System.Windows.Forms.GroupBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_New = new System.Windows.Forms.Button();
            this.groupBox_General_Options = new System.Windows.Forms.GroupBox();
            this.button_View = new System.Windows.Forms.Button();
            this.button_Buffer = new System.Windows.Forms.Button();
            this.groupBox_Acquisition_Options = new System.Windows.Forms.GroupBox();
            this.button_Load_Config = new System.Windows.Forms.Button();
            this.groupBox_Acquisition_Control = new System.Windows.Forms.GroupBox();
            this.button_Freeze = new System.Windows.Forms.Button();
            this.button_Grab = new System.Windows.Forms.Button();
            this.button_Snap = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.videoSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Cmd_Process_Data = new System.Windows.Forms.Button();
            this.Cmd_Update_Viewport = new System.Windows.Forms.Button();
            this.Cmd_Trigger = new System.Windows.Forms.Button();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.virtualTriggerBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.avg_diameter = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.originalBox = new System.Windows.Forms.PictureBox();
            this.processROIBox = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
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
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_File_Control.SuspendLayout();
            this.groupBox_General_Options.SuspendLayout();
            this.groupBox_Acquisition_Options.SuspendLayout();
            this.groupBox_Acquisition_Control.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox17.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GB_Threshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processROIBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1123, 25);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBox_File_Control);
            this.panel1.Controls.Add(this.groupBox_General_Options);
            this.panel1.Controls.Add(this.groupBox_Acquisition_Options);
            this.panel1.Controls.Add(this.groupBox_Acquisition_Control);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Location = new System.Drawing.Point(17, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 503);
            this.panel1.TabIndex = 11;
            // 
            // groupBox_File_Control
            // 
            this.groupBox_File_Control.Controls.Add(this.button_Save);
            this.groupBox_File_Control.Controls.Add(this.button_Load);
            this.groupBox_File_Control.Controls.Add(this.button_New);
            this.groupBox_File_Control.Location = new System.Drawing.Point(17, 203);
            this.groupBox_File_Control.Name = "groupBox_File_Control";
            this.groupBox_File_Control.Size = new System.Drawing.Size(142, 132);
            this.groupBox_File_Control.TabIndex = 11;
            this.groupBox_File_Control.TabStop = false;
            this.groupBox_File_Control.Text = "File Control";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(22, 97);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(104, 23);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(22, 60);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(104, 23);
            this.button_Load.TabIndex = 1;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // button_New
            // 
            this.button_New.Location = new System.Drawing.Point(22, 24);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(104, 23);
            this.button_New.TabIndex = 0;
            this.button_New.Text = "New";
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // groupBox_General_Options
            // 
            this.groupBox_General_Options.Controls.Add(this.button_View);
            this.groupBox_General_Options.Controls.Add(this.button_Buffer);
            this.groupBox_General_Options.Location = new System.Drawing.Point(17, 341);
            this.groupBox_General_Options.Name = "groupBox_General_Options";
            this.groupBox_General_Options.Size = new System.Drawing.Size(142, 88);
            this.groupBox_General_Options.TabIndex = 12;
            this.groupBox_General_Options.TabStop = false;
            this.groupBox_General_Options.Text = "General Options";
            // 
            // button_View
            // 
            this.button_View.Location = new System.Drawing.Point(22, 53);
            this.button_View.Name = "button_View";
            this.button_View.Size = new System.Drawing.Size(104, 23);
            this.button_View.TabIndex = 1;
            this.button_View.Text = "View";
            this.button_View.UseVisualStyleBackColor = true;
            this.button_View.Click += new System.EventHandler(this.button_View_Click);
            // 
            // button_Buffer
            // 
            this.button_Buffer.Location = new System.Drawing.Point(22, 20);
            this.button_Buffer.Name = "button_Buffer";
            this.button_Buffer.Size = new System.Drawing.Size(104, 23);
            this.button_Buffer.TabIndex = 0;
            this.button_Buffer.Text = "Buffer";
            this.button_Buffer.UseVisualStyleBackColor = true;
            this.button_Buffer.Click += new System.EventHandler(this.button_Buffer_Click);
            // 
            // groupBox_Acquisition_Options
            // 
            this.groupBox_Acquisition_Options.Controls.Add(this.button_Load_Config);
            this.groupBox_Acquisition_Options.Location = new System.Drawing.Point(17, 435);
            this.groupBox_Acquisition_Options.Name = "groupBox_Acquisition_Options";
            this.groupBox_Acquisition_Options.Size = new System.Drawing.Size(142, 54);
            this.groupBox_Acquisition_Options.TabIndex = 13;
            this.groupBox_Acquisition_Options.TabStop = false;
            this.groupBox_Acquisition_Options.Text = "Acquisition Options";
            // 
            // button_Load_Config
            // 
            this.button_Load_Config.Location = new System.Drawing.Point(22, 20);
            this.button_Load_Config.Name = "button_Load_Config";
            this.button_Load_Config.Size = new System.Drawing.Size(104, 23);
            this.button_Load_Config.TabIndex = 0;
            this.button_Load_Config.Text = "Load Config";
            this.button_Load_Config.UseVisualStyleBackColor = true;
            this.button_Load_Config.Click += new System.EventHandler(this.button_Load_Config_Click);
            // 
            // groupBox_Acquisition_Control
            // 
            this.groupBox_Acquisition_Control.Controls.Add(this.button_Freeze);
            this.groupBox_Acquisition_Control.Controls.Add(this.button_Grab);
            this.groupBox_Acquisition_Control.Controls.Add(this.button_Snap);
            this.groupBox_Acquisition_Control.Location = new System.Drawing.Point(17, 53);
            this.groupBox_Acquisition_Control.Name = "groupBox_Acquisition_Control";
            this.groupBox_Acquisition_Control.Size = new System.Drawing.Size(142, 144);
            this.groupBox_Acquisition_Control.TabIndex = 9;
            this.groupBox_Acquisition_Control.TabStop = false;
            this.groupBox_Acquisition_Control.Text = "Acquisition Control";
            // 
            // button_Freeze
            // 
            this.button_Freeze.Location = new System.Drawing.Point(22, 104);
            this.button_Freeze.Name = "button_Freeze";
            this.button_Freeze.Size = new System.Drawing.Size(104, 23);
            this.button_Freeze.TabIndex = 2;
            this.button_Freeze.Text = "Freeze";
            this.button_Freeze.UseVisualStyleBackColor = true;
            this.button_Freeze.Click += new System.EventHandler(this.button_Freeze_Click);
            // 
            // button_Grab
            // 
            this.button_Grab.Location = new System.Drawing.Point(22, 62);
            this.button_Grab.Name = "button_Grab";
            this.button_Grab.Size = new System.Drawing.Size(104, 23);
            this.button_Grab.TabIndex = 1;
            this.button_Grab.Text = "Grab";
            this.button_Grab.UseVisualStyleBackColor = true;
            this.button_Grab.Click += new System.EventHandler(this.button_Grab_Click);
            // 
            // button_Snap
            // 
            this.button_Snap.Location = new System.Drawing.Point(22, 23);
            this.button_Snap.Name = "button_Snap";
            this.button_Snap.Size = new System.Drawing.Size(104, 23);
            this.button_Snap.TabIndex = 0;
            this.button_Snap.Text = "Snap";
            this.button_Snap.UseVisualStyleBackColor = true;
            this.button_Snap.Click += new System.EventHandler(this.button_Snap_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.ForeColor = System.Drawing.Color.Black;
            this.button_Exit.Location = new System.Drawing.Point(39, 11);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(104, 35);
            this.button_Exit.TabIndex = 10;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
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
            this.GroupBox1.Controls.Add(this.Cmd_Process_Data);
            this.GroupBox1.Controls.Add(this.Cmd_Update_Viewport);
            this.GroupBox1.Controls.Add(this.Cmd_Trigger);
            this.GroupBox1.Location = new System.Drawing.Point(0, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(238, 74);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Manual Commands";
            // 
            // Cmd_Process_Data
            // 
            this.Cmd_Process_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cmd_Process_Data.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Process_Data.Location = new System.Drawing.Point(90, 10);
            this.Cmd_Process_Data.Name = "Cmd_Process_Data";
            this.Cmd_Process_Data.Size = new System.Drawing.Size(70, 55);
            this.Cmd_Process_Data.TabIndex = 73;
            this.Cmd_Process_Data.Text = "Process Image DISABLED";
            this.Cmd_Process_Data.UseVisualStyleBackColor = false;
            this.Cmd_Process_Data.Click += new System.EventHandler(this.Cmd_Process_Data_Click);
            // 
            // Cmd_Update_Viewport
            // 
            this.Cmd_Update_Viewport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cmd_Update_Viewport.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Update_Viewport.Location = new System.Drawing.Point(160, 10);
            this.Cmd_Update_Viewport.Name = "Cmd_Update_Viewport";
            this.Cmd_Update_Viewport.Size = new System.Drawing.Size(68, 55);
            this.Cmd_Update_Viewport.TabIndex = 72;
            this.Cmd_Update_Viewport.Text = "Trigger MANUAL";
            this.Cmd_Update_Viewport.UseVisualStyleBackColor = false;
            this.Cmd_Update_Viewport.Click += new System.EventHandler(this.Cmd_Update_Viewport_Click);
            // 
            // Cmd_Trigger
            // 
            this.Cmd_Trigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cmd_Trigger.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Trigger.Location = new System.Drawing.Point(12, 11);
            this.Cmd_Trigger.Name = "Cmd_Trigger";
            this.Cmd_Trigger.Size = new System.Drawing.Size(77, 55);
            this.Cmd_Trigger.TabIndex = 69;
            this.Cmd_Trigger.Text = "Run";
            this.Cmd_Trigger.UseVisualStyleBackColor = false;
            this.Cmd_Trigger.Click += new System.EventHandler(this.Cmd_Trigger_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.Txt_mode);
            this.GroupBox8.Controls.Add(this.BtnLocalRemote);
            this.GroupBox8.Location = new System.Drawing.Point(0, 360);
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
            this.GroupBox17.Controls.Add(this.Txt_MaxCompacity);
            this.GroupBox17.Controls.Add(this.Label50);
            this.GroupBox17.Controls.Add(this.Txt_MaxOvality);
            this.GroupBox17.Controls.Add(this.Txt_MinDiameter);
            this.GroupBox17.Controls.Add(this.Label53);
            this.GroupBox17.Controls.Add(this.Label54);
            this.GroupBox17.Controls.Add(this.Label55);
            this.GroupBox17.Controls.Add(this.Txt_MaxDiameter);
            this.GroupBox17.Location = new System.Drawing.Point(0, 415);
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
            this.Label53.Size = new System.Drawing.Size(87, 16);
            this.Label53.TabIndex = 90;
            this.Label53.Text = "Min Ovality:";
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
            this.GroupBox5.Location = new System.Drawing.Point(0, 121);
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
            this.grid_16.Text = "16 Grid";
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
            this.grid_12.Text = "12 Grid";
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
            this.grid_6.Text = "6 Grid";
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
            this.grid_5.Text = "5 Grid";
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
            this.grid_4.Text = "4 Grid";
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
            this.grid_9.Text = "9 Grid";
            this.grid_9.UseVisualStyleBackColor = false;
            this.grid_9.Click += new System.EventHandler(this.grid_9_Click);
            // 
            // GB_Threshold
            // 
            this.GB_Threshold.Controls.Add(this.Chk_Threshold_Mode);
            this.GB_Threshold.Controls.Add(this.Txt_Threshold);
            this.GB_Threshold.Location = new System.Drawing.Point(0, 78);
            this.GB_Threshold.Name = "GB_Threshold";
            this.GB_Threshold.Size = new System.Drawing.Size(238, 47);
            this.GB_Threshold.TabIndex = 108;
            this.GB_Threshold.TabStop = false;
            this.GB_Threshold.Text = "Binary Threshold";
            // 
            // Chk_Threshold_Mode
            // 
            this.Chk_Threshold_Mode.AutoSize = true;
            this.Chk_Threshold_Mode.Checked = true;
            this.Chk_Threshold_Mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Threshold_Mode.Location = new System.Drawing.Point(118, 23);
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
            this.Txt_Threshold.Location = new System.Drawing.Point(51, 21);
            this.Txt_Threshold.Name = "Txt_Threshold";
            this.Txt_Threshold.Size = new System.Drawing.Size(38, 20);
            this.Txt_Threshold.TabIndex = 12;
            this.Txt_Threshold.Text = "0";
            this.Txt_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnsave.Location = new System.Drawing.Point(17, 512);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 349);
            this.dataGridView1.TabIndex = 117;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(731, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(311, 622);
            this.tabControl1.TabIndex = 118;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.virtualTriggerBtn);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.GroupBox1);
            this.tabPage1.Controls.Add(this.GB_Threshold);
            this.tabPage1.Controls.Add(this.GroupBox5);
            this.tabPage1.Controls.Add(this.GroupBox8);
            this.tabPage1.Controls.Add(this.GroupBox17);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(303, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MainControl";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // virtualTriggerBtn
            // 
            this.virtualTriggerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.virtualTriggerBtn.BackColor = System.Drawing.Color.Silver;
            this.virtualTriggerBtn.Location = new System.Drawing.Point(231, 13);
            this.virtualTriggerBtn.Name = "virtualTriggerBtn";
            this.virtualTriggerBtn.Size = new System.Drawing.Size(69, 55);
            this.virtualTriggerBtn.TabIndex = 74;
            this.virtualTriggerBtn.Text = "Trigger";
            this.virtualTriggerBtn.UseVisualStyleBackColor = false;
            this.virtualTriggerBtn.Click += new System.EventHandler(this.virtualTriggerBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.avg_diameter);
            this.groupBox2.Location = new System.Drawing.Point(1, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 111);
            this.groupBox2.TabIndex = 114;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Promedio diametro triangulos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // avg_diameter
            // 
            this.avg_diameter.AutoSize = true;
            this.avg_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_diameter.Location = new System.Drawing.Point(152, 49);
            this.avg_diameter.Name = "avg_diameter";
            this.avg_diameter.Size = new System.Drawing.Size(24, 25);
            this.avg_diameter.TabIndex = 0;
            this.avg_diameter.Text = "0";
            this.avg_diameter.Click += new System.EventHandler(this.avg_diameter_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnsave);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(303, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CameraControl";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(0, 27);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(724, 527);
            this.tabControl2.TabIndex = 119;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.originalBox);
            this.tabPage3.Controls.Add(this.processROIBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(716, 501);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Image";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
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
            this.processROIBox.Location = new System.Drawing.Point(0, 235);
            this.processROIBox.Name = "processROIBox";
            this.processROIBox.Size = new System.Drawing.Size(716, 263);
            this.processROIBox.TabIndex = 0;
            this.processROIBox.TabStop = false;
            this.processROIBox.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(716, 501);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Table";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.GroupBox13);
            this.tabPage5.Controls.Add(this.GroupBox12);
            this.tabPage5.Controls.Add(this.GroupBox11);
            this.tabPage5.Controls.Add(this.CmdAdd);
            this.tabPage5.Controls.Add(this.CmdUpdate);
            this.tabPage5.Controls.Add(this.GroupBox10);
            this.tabPage5.Controls.Add(this.CmdDelete);
            this.tabPage5.Controls.Add(this.GroupBox9);
            this.tabPage5.Controls.Add(this.Cmd_video);
            this.tabPage5.Controls.Add(this.Cmd_Calibration);
            this.tabPage5.Controls.Add(this.Cmd_Save);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(716, 501);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Products";
            this.tabPage5.UseVisualStyleBackColor = true;
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
            this.CmdAdd.BackColor = System.Drawing.Color.Silver;
            this.CmdAdd.Location = new System.Drawing.Point(506, 65);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(70, 55);
            this.CmdAdd.TabIndex = 119;
            this.CmdAdd.Text = "Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdUpdate.BackColor = System.Drawing.Color.Silver;
            this.CmdUpdate.Location = new System.Drawing.Point(581, 65);
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
            this.GroupBox10.Size = new System.Drawing.Size(287, 55);
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
            this.CmdDelete.Location = new System.Drawing.Point(505, 127);
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
            this.Cmd_Save.Location = new System.Drawing.Point(259, 460);
            this.Cmd_Save.Name = "Cmd_Save";
            this.Cmd_Save.Size = new System.Drawing.Size(129, 40);
            this.Cmd_Save.TabIndex = 114;
            this.Cmd_Save.Text = "Save";
            this.Cmd_Save.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1048, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 120;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GigECameraDemoDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1123, 643);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GigECameraDemoDlg";
            this.Text = "Prueba 1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GigECameraDemoDlg_FormClosed);
            this.Load += new System.EventHandler(this.GigECameraDemoDlg_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_File_Control.ResumeLayout(false);
            this.groupBox_General_Options.ResumeLayout(false);
            this.groupBox_Acquisition_Options.ResumeLayout(false);
            this.groupBox_Acquisition_Control.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox17.ResumeLayout(false);
            this.GroupBox17.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GB_Threshold.ResumeLayout(false);
            this.GB_Threshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processROIBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_File_Control;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.GroupBox groupBox_General_Options;
        private System.Windows.Forms.Button button_View;
        private System.Windows.Forms.Button button_Buffer;
        private System.Windows.Forms.GroupBox groupBox_Acquisition_Options;
        private System.Windows.Forms.Button button_Load_Config;
        private System.Windows.Forms.GroupBox groupBox_Acquisition_Control;
        private System.Windows.Forms.Button button_Freeze;
        private System.Windows.Forms.Button button_Grab;
        private System.Windows.Forms.Button button_Snap;
        private System.Windows.Forms.Button button_Exit;
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
        internal System.Windows.Forms.Button Cmd_Update_Viewport;
        internal System.Windows.Forms.Button Cmd_Trigger;
        internal System.Windows.Forms.Button Cmd_Process_Data;
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
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
    }
}

