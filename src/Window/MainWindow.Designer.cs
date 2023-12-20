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
            this.closeBtn = new System.Windows.Forms.RadioButton();
            this.openBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.manualSelectBtn = new System.Windows.Forms.Button();
            this.currentComText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autoSelectBtn = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.mainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comGroup
            // 
            this.comGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comGroup.Controls.Add(this.closeBtn);
            this.comGroup.Controls.Add(this.openBtn);
            this.comGroup.Controls.Add(this.label1);
            this.comGroup.Controls.Add(this.manualSelectBtn);
            this.comGroup.Controls.Add(this.currentComText);
            this.comGroup.Controls.Add(this.label2);
            this.comGroup.Controls.Add(this.autoSelectBtn);
            this.comGroup.Location = new System.Drawing.Point(13, 13);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(1148, 438);
            this.comGroup.TabIndex = 99;
            this.comGroup.TabStop = false;
            this.comGroup.Text = "灯带控制";
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = true;
            this.closeBtn.Location = new System.Drawing.Point(192, 138);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(97, 31);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "关灯";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.CheckedChanged += new System.EventHandler(this.CloseBtn_CheckedChanged);
            // 
            // openBtn
            // 
            this.openBtn.AutoSize = true;
            this.openBtn.Location = new System.Drawing.Point(34, 138);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(97, 31);
            this.openBtn.TabIndex = 8;
            this.openBtn.Text = "开灯";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.CheckedChanged += new System.EventHandler(this.OpenBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "工作状态：";
            // 
            // manualSelectBtn
            // 
            this.manualSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manualSelectBtn.Location = new System.Drawing.Point(942, 37);
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
            this.autoSelectBtn.Location = new System.Drawing.Point(736, 37);
            this.autoSelectBtn.Name = "autoSelectBtn";
            this.autoSelectBtn.Size = new System.Drawing.Size(200, 50);
            this.autoSelectBtn.TabIndex = 2;
            this.autoSelectBtn.Text = "自动识别";
            this.autoSelectBtn.UseVisualStyleBackColor = true;
            this.autoSelectBtn.Click += new System.EventHandler(this.AutoSelectBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.autoMinimize);
            this.groupBox1.Controls.Add(this.closeHideWindow);
            this.groupBox1.Controls.Add(this.autoCloseLightStrip);
            this.groupBox1.Controls.Add(this.autoOpenLightStrip);
            this.groupBox1.Controls.Add(this.isAutoStarup);
            this.groupBox1.Location = new System.Drawing.Point(13, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 314);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // autoMinimize
            // 
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
            this.ClientSize = new System.Drawing.Size(1172, 783);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "米家灯带控制器";
            this.comGroup.ResumeLayout(false);
            this.comGroup.PerformLayout();
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
    }
}

