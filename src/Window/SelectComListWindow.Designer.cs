namespace mi_lightstrip_controller.src.Window
{
    partial class SelectComListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectComListWindow));
            this.refreshBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comListDropdown = new System.Windows.Forms.ComboBox();
            this.comGroup = new System.Windows.Forms.GroupBox();
            this.saveConfigBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Location = new System.Drawing.Point(985, 57);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(100, 50);
            this.refreshBtn.TabIndex = 4;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择灯带串口：";
            // 
            // comListDropdown
            // 
            this.comListDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comListDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comListDropdown.FormattingEnabled = true;
            this.comListDropdown.Location = new System.Drawing.Point(235, 57);
            this.comListDropdown.Name = "comListDropdown";
            this.comListDropdown.Size = new System.Drawing.Size(744, 35);
            this.comListDropdown.TabIndex = 0;
            this.comListDropdown.SelectedIndexChanged += new System.EventHandler(this.ComListDropdown_SelectedIndexChanged);
            // 
            // comGroup
            // 
            this.comGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comGroup.Controls.Add(this.refreshBtn);
            this.comGroup.Controls.Add(this.label1);
            this.comGroup.Controls.Add(this.comListDropdown);
            this.comGroup.Location = new System.Drawing.Point(12, 12);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(1111, 128);
            this.comGroup.TabIndex = 2;
            this.comGroup.TabStop = false;
            this.comGroup.Text = "选择串口";
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveConfigBtn.Location = new System.Drawing.Point(12, 159);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Size = new System.Drawing.Size(200, 50);
            this.saveConfigBtn.TabIndex = 2;
            this.saveConfigBtn.Text = "确定";
            this.saveConfigBtn.UseVisualStyleBackColor = true;
            this.saveConfigBtn.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(218, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SelectComListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comGroup);
            this.Controls.Add(this.saveConfigBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectComListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择灯带串口";
            this.comGroup.ResumeLayout(false);
            this.comGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comListDropdown;
        private System.Windows.Forms.GroupBox comGroup;
        private System.Windows.Forms.Button saveConfigBtn;
        private System.Windows.Forms.Button button1;
    }
}