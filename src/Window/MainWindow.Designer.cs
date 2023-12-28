namespace mi_lightstrip_controller
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.comGroup = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.normalModeToggle = new System.Windows.Forms.RadioButton();
            this.pureModeToggle = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openBtn = new System.Windows.Forms.RadioButton();
            this.closeBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.logText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.manualSelectBtn = new System.Windows.Forms.Button();
            this.currentComText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autoSelectBtn = new System.Windows.Forms.Button();
            this.purePanel = new System.Windows.Forms.GroupBox();
            this.intensityValue = new System.Windows.Forms.Label();
            this.selectColorBtn = new System.Windows.Forms.Button();
            this.intensityLabel = new System.Windows.Forms.Label();
            this.intensityTrackBar = new System.Windows.Forms.TrackBar();
            this.normalPanel = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.autoMinimize = new System.Windows.Forms.CheckBox();
            this.closeHideWindow = new System.Windows.Forms.CheckBox();
            this.autoCloseLightStrip = new System.Windows.Forms.CheckBox();
            this.autoOpenLightStrip = new System.Windows.Forms.CheckBox();
            this.isAutoStarup = new System.Windows.Forms.CheckBox();
            this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开启灯带ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭灯带ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.purePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensityTrackBar)).BeginInit();
            this.normalPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comGroup
            // 
            this.comGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comGroup.Controls.Add(this.panel2);
            this.comGroup.Controls.Add(this.panel1);
            this.comGroup.Controls.Add(this.logText);
            this.comGroup.Controls.Add(this.label3);
            this.comGroup.Controls.Add(this.manualSelectBtn);
            this.comGroup.Controls.Add(this.currentComText);
            this.comGroup.Controls.Add(this.label2);
            this.comGroup.Controls.Add(this.autoSelectBtn);
            this.comGroup.Controls.Add(this.purePanel);
            this.comGroup.Controls.Add(this.normalPanel);
            this.comGroup.Location = new System.Drawing.Point(13, 13);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(1190, 612);
            this.comGroup.TabIndex = 99;
            this.comGroup.TabStop = false;
            this.comGroup.Text = "灯带控制";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.normalModeToggle);
            this.panel2.Controls.Add(this.pureModeToggle);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(34, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 52);
            this.panel2.TabIndex = 13;
            // 
            // normalModeToggle
            // 
            this.normalModeToggle.AutoSize = true;
            this.normalModeToggle.Location = new System.Drawing.Point(208, 3);
            this.normalModeToggle.Name = "normalModeToggle";
            this.normalModeToggle.Size = new System.Drawing.Size(97, 31);
            this.normalModeToggle.TabIndex = 8;
            this.normalModeToggle.Text = "幻彩";
            this.normalModeToggle.UseVisualStyleBackColor = true;
            this.normalModeToggle.CheckedChanged += new System.EventHandler(this.NormalModeToggle_CheckedChanged);
            // 
            // pureModeToggle
            // 
            this.pureModeToggle.AutoSize = true;
            this.pureModeToggle.Location = new System.Drawing.Point(331, 3);
            this.pureModeToggle.Name = "pureModeToggle";
            this.pureModeToggle.Size = new System.Drawing.Size(97, 31);
            this.pureModeToggle.TabIndex = 9;
            this.pureModeToggle.Text = "纯色";
            this.pureModeToggle.UseVisualStyleBackColor = true;
            this.pureModeToggle.CheckedChanged += new System.EventHandler(this.PureModeToggle_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "工作模式：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openBtn);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(34, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 52);
            this.panel1.TabIndex = 12;
            // 
            // openBtn
            // 
            this.openBtn.AutoSize = true;
            this.openBtn.Location = new System.Drawing.Point(208, 3);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(97, 31);
            this.openBtn.TabIndex = 8;
            this.openBtn.Text = "开灯";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.CheckedChanged += new System.EventHandler(this.OpenBtn_CheckedChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = true;
            this.closeBtn.Location = new System.Drawing.Point(331, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(97, 31);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "关灯";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.CheckedChanged += new System.EventHandler(this.CloseBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "工作状态：";
            // 
            // logText
            // 
            this.logText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logText.Location = new System.Drawing.Point(115, 438);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(1051, 155);
            this.logText.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "日志：";
            // 
            // manualSelectBtn
            // 
            this.manualSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manualSelectBtn.Location = new System.Drawing.Point(984, 37);
            this.manualSelectBtn.Name = "manualSelectBtn";
            this.manualSelectBtn.Size = new System.Drawing.Size(200, 50);
            this.manualSelectBtn.TabIndex = 3;
            this.manualSelectBtn.Text = "手动选择";
            this.manualSelectBtn.UseVisualStyleBackColor = true;
            this.manualSelectBtn.Click += new System.EventHandler(this.ManualSelectBtn_Click);
            // 
            // currentComText
            // 
            this.currentComText.AutoSize = true;
            this.currentComText.Location = new System.Drawing.Point(235, 38);
            this.currentComText.Name = "currentComText";
            this.currentComText.Size = new System.Drawing.Size(68, 27);
            this.currentComText.TabIndex = 6;
            this.currentComText.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前灯带串口：";
            // 
            // autoSelectBtn
            // 
            this.autoSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSelectBtn.Location = new System.Drawing.Point(778, 37);
            this.autoSelectBtn.Name = "autoSelectBtn";
            this.autoSelectBtn.Size = new System.Drawing.Size(200, 50);
            this.autoSelectBtn.TabIndex = 2;
            this.autoSelectBtn.Text = "自动识别";
            this.autoSelectBtn.UseVisualStyleBackColor = true;
            this.autoSelectBtn.Click += new System.EventHandler(this.AutoSelectBtn_Click);
            // 
            // purePanel
            // 
            this.purePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purePanel.Controls.Add(this.intensityValue);
            this.purePanel.Controls.Add(this.selectColorBtn);
            this.purePanel.Controls.Add(this.intensityLabel);
            this.purePanel.Controls.Add(this.intensityTrackBar);
            this.purePanel.Location = new System.Drawing.Point(34, 201);
            this.purePanel.Name = "purePanel";
            this.purePanel.Size = new System.Drawing.Size(1132, 231);
            this.purePanel.TabIndex = 15;
            this.purePanel.TabStop = false;
            this.purePanel.Text = "纯色设置";
            this.purePanel.Visible = false;
            // 
            // intensityValue
            // 
            this.intensityValue.AutoSize = true;
            this.intensityValue.Location = new System.Drawing.Point(513, 51);
            this.intensityValue.Name = "intensityValue";
            this.intensityValue.Size = new System.Drawing.Size(54, 27);
            this.intensityValue.TabIndex = 3;
            this.intensityValue.Text = "100";
            // 
            // selectColorBtn
            // 
            this.selectColorBtn.Location = new System.Drawing.Point(108, 116);
            this.selectColorBtn.Name = "selectColorBtn";
            this.selectColorBtn.Size = new System.Drawing.Size(459, 85);
            this.selectColorBtn.TabIndex = 0;
            this.selectColorBtn.UseVisualStyleBackColor = true;
            this.selectColorBtn.Click += new System.EventHandler(this.SelectColorBtn_Click);
            // 
            // intensityLabel
            // 
            this.intensityLabel.AutoSize = true;
            this.intensityLabel.Location = new System.Drawing.Point(103, 51);
            this.intensityLabel.Name = "intensityLabel";
            this.intensityLabel.Size = new System.Drawing.Size(93, 27);
            this.intensityLabel.TabIndex = 2;
            this.intensityLabel.Text = "亮度：";
            // 
            // intensityTrackBar
            // 
            this.intensityTrackBar.LargeChange = 10;
            this.intensityTrackBar.Location = new System.Drawing.Point(190, 43);
            this.intensityTrackBar.Maximum = 100;
            this.intensityTrackBar.Name = "intensityTrackBar";
            this.intensityTrackBar.Size = new System.Drawing.Size(317, 101);
            this.intensityTrackBar.TabIndex = 1;
            this.intensityTrackBar.TickFrequency = 10;
            this.intensityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.intensityTrackBar.Value = 100;
            this.intensityTrackBar.Scroll += new System.EventHandler(this.IntensityTrackBar_Scroll);
            // 
            // normalPanel
            // 
            this.normalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.normalPanel.Controls.Add(this.label5);
            this.normalPanel.Location = new System.Drawing.Point(34, 201);
            this.normalPanel.Name = "normalPanel";
            this.normalPanel.Size = new System.Drawing.Size(1132, 231);
            this.normalPanel.TabIndex = 14;
            this.normalPanel.TabStop = false;
            this.normalPanel.Text = "幻彩设置";
            this.normalPanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "无需配置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.autoMinimize);
            this.groupBox1.Controls.Add(this.closeHideWindow);
            this.groupBox1.Controls.Add(this.autoCloseLightStrip);
            this.groupBox1.Controls.Add(this.autoOpenLightStrip);
            this.groupBox1.Controls.Add(this.isAutoStarup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 690);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 319);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // autoMinimize
            // 
            this.autoMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoMinimize.AutoSize = true;
            this.autoMinimize.Location = new System.Drawing.Point(34, 258);
            this.autoMinimize.Name = "autoMinimize";
            this.autoMinimize.Size = new System.Drawing.Size(287, 31);
            this.autoMinimize.TabIndex = 8;
            this.autoMinimize.Text = "启动时最小化到托盘";
            this.autoMinimize.UseVisualStyleBackColor = true;
            this.autoMinimize.CheckedChanged += new System.EventHandler(this.AutoMinimize_CheckedChanged);
            // 
            // closeHideWindow
            // 
            this.closeHideWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.closeHideWindow.AutoSize = true;
            this.closeHideWindow.Location = new System.Drawing.Point(34, 209);
            this.closeHideWindow.Name = "closeHideWindow";
            this.closeHideWindow.Size = new System.Drawing.Size(341, 31);
            this.closeHideWindow.TabIndex = 7;
            this.closeHideWindow.Text = "点击关闭时最小化到托盘";
            this.closeHideWindow.UseVisualStyleBackColor = true;
            this.closeHideWindow.CheckedChanged += new System.EventHandler(this.CloseHideWindow_CheckedChanged);
            // 
            // autoCloseLightStrip
            // 
            this.autoCloseLightStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoCloseLightStrip.AutoSize = true;
            this.autoCloseLightStrip.Location = new System.Drawing.Point(34, 156);
            this.autoCloseLightStrip.Name = "autoCloseLightStrip";
            this.autoCloseLightStrip.Size = new System.Drawing.Size(341, 31);
            this.autoCloseLightStrip.TabIndex = 6;
            this.autoCloseLightStrip.Text = "程序关闭时自动关闭灯带";
            this.autoCloseLightStrip.UseVisualStyleBackColor = true;
            this.autoCloseLightStrip.CheckedChanged += new System.EventHandler(this.AutoCloseLightStrip_CheckedChanged);
            // 
            // autoOpenLightStrip
            // 
            this.autoOpenLightStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoOpenLightStrip.AutoSize = true;
            this.autoOpenLightStrip.Location = new System.Drawing.Point(34, 102);
            this.autoOpenLightStrip.Name = "autoOpenLightStrip";
            this.autoOpenLightStrip.Size = new System.Drawing.Size(341, 31);
            this.autoOpenLightStrip.TabIndex = 5;
            this.autoOpenLightStrip.Text = "程序启动时自动打开灯带";
            this.autoOpenLightStrip.UseVisualStyleBackColor = true;
            this.autoOpenLightStrip.CheckedChanged += new System.EventHandler(this.AutoOpenLightStrip_CheckedChanged);
            // 
            // isAutoStarup
            // 
            this.isAutoStarup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.isAutoStarup.AutoSize = true;
            this.isAutoStarup.Location = new System.Drawing.Point(34, 52);
            this.isAutoStarup.Name = "isAutoStarup";
            this.isAutoStarup.Size = new System.Drawing.Size(206, 31);
            this.isAutoStarup.TabIndex = 4;
            this.isAutoStarup.Text = "是否开机自启";
            this.isAutoStarup.UseVisualStyleBackColor = true;
            this.isAutoStarup.CheckedChanged += new System.EventHandler(this.IsAutoStarup_CheckedChanged);
            // 
            // mainNotifyIcon
            // 
            this.mainNotifyIcon.ContextMenuStrip = this.mainContextMenuStrip;
            this.mainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainNotifyIcon.Icon")));
            this.mainNotifyIcon.Text = "米家灯带控制器";
            this.mainNotifyIcon.Visible = true;
            this.mainNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseClick);
            this.mainNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseDoubleClick);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启灯带ToolStripMenuItem,
            this.关闭灯带ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(199, 130);
            // 
            // 开启灯带ToolStripMenuItem
            // 
            this.开启灯带ToolStripMenuItem.Name = "开启灯带ToolStripMenuItem";
            this.开启灯带ToolStripMenuItem.Size = new System.Drawing.Size(198, 42);
            this.开启灯带ToolStripMenuItem.Text = "开启灯带";
            this.开启灯带ToolStripMenuItem.Click += new System.EventHandler(this.OpenLightStripToolStripMenuItem_Click);
            // 
            // 关闭灯带ToolStripMenuItem
            // 
            this.关闭灯带ToolStripMenuItem.Name = "关闭灯带ToolStripMenuItem";
            this.关闭灯带ToolStripMenuItem.Size = new System.Drawing.Size(198, 42);
            this.关闭灯带ToolStripMenuItem.Text = "关闭灯带";
            this.关闭灯带ToolStripMenuItem.Click += new System.EventHandler(this.CloseLightStripToolStripMenuItem_Click);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(198, 42);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.QuitProgramToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1214, 1009);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "米家灯带控制器";
            this.comGroup.ResumeLayout(false);
            this.comGroup.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.purePanel.ResumeLayout(false);
            this.purePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensityTrackBar)).EndInit();
            this.normalPanel.ResumeLayout(false);
            this.normalPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox comGroup;
        private System.Windows.Forms.Button autoSelectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentComText;
        private System.Windows.Forms.Button manualSelectBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox isAutoStarup;
        private System.Windows.Forms.CheckBox autoOpenLightStrip;
        private System.Windows.Forms.CheckBox autoCloseLightStrip;
        private System.Windows.Forms.CheckBox closeHideWindow;
        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 开启灯带ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭灯带ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoMinimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton closeBtn;
        private System.Windows.Forms.RadioButton openBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton normalModeToggle;
        private System.Windows.Forms.RadioButton pureModeToggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox normalPanel;
        private System.Windows.Forms.GroupBox purePanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectColorBtn;
        private System.Windows.Forms.Label intensityLabel;
        private System.Windows.Forms.TrackBar intensityTrackBar;
        private System.Windows.Forms.Label intensityValue;
    }
}

