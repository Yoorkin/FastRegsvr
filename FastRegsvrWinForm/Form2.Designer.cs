namespace FastRegsvrWinForm
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.Cmd = new System.Windows.Forms.ComboBox();
            this.RegList = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RegBtn = new System.Windows.Forms.Button();
            this.UnRegList = new System.Windows.Forms.CheckedListBox();
            this.Copy = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 375);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.RegList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "已注册的文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button);
            this.panel1.Controls.Add(this.Cmd);
            this.panel1.Location = new System.Drawing.Point(-19, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 42);
            this.panel1.TabIndex = 9;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(353, 4);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(97, 28);
            this.button.TabIndex = 8;
            this.button.Text = "执行";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click_1);
            // 
            // Cmd
            // 
            this.Cmd.DisplayMember = "0";
            this.Cmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cmd.FormattingEnabled = true;
            this.Cmd.Items.AddRange(new object[] {
            "反注册",
            "反注册并删除文件"});
            this.Cmd.Location = new System.Drawing.Point(226, 5);
            this.Cmd.Name = "Cmd";
            this.Cmd.Size = new System.Drawing.Size(121, 25);
            this.Cmd.TabIndex = 7;
            // 
            // RegList
            // 
            this.RegList.AllowDrop = true;
            this.RegList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RegList.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegList.FormattingEnabled = true;
            this.RegList.Location = new System.Drawing.Point(3, 3);
            this.RegList.Name = "RegList";
            this.RegList.Size = new System.Drawing.Size(433, 320);
            this.RegList.TabIndex = 1;
            this.RegList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegList_MouseClick);
            this.RegList.SelectedIndexChanged += new System.EventHandler(this.RegList_SelectedIndexChanged);
            this.RegList.DragDrop += new System.Windows.Forms.DragEventHandler(this.RegList_DragDrop);
            this.RegList.DragEnter += new System.Windows.Forms.DragEventHandler(this.RegList_DragEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RegBtn);
            this.tabPage2.Controls.Add(this.UnRegList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "反注册的文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RegBtn
            // 
            this.RegBtn.BackColor = System.Drawing.Color.Transparent;
            this.RegBtn.Location = new System.Drawing.Point(334, 317);
            this.RegBtn.Name = "RegBtn";
            this.RegBtn.Size = new System.Drawing.Size(97, 28);
            this.RegBtn.TabIndex = 9;
            this.RegBtn.Text = "注册";
            this.RegBtn.UseVisualStyleBackColor = false;
            this.RegBtn.Click += new System.EventHandler(this.RegBtn_Click);
            // 
            // UnRegList
            // 
            this.UnRegList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UnRegList.Dock = System.Windows.Forms.DockStyle.Top;
            this.UnRegList.FormattingEnabled = true;
            this.UnRegList.Location = new System.Drawing.Point(3, 3);
            this.UnRegList.Name = "UnRegList";
            this.UnRegList.Size = new System.Drawing.Size(433, 304);
            this.UnRegList.TabIndex = 2;
            this.UnRegList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UnRegList_MouseClick);
            this.UnRegList.SelectedIndexChanged += new System.EventHandler(this.UnRegList_SelectedIndexChanged);
            // 
            // Copy
            // 
            this.Copy.AutoSize = true;
            this.Copy.Checked = true;
            this.Copy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Copy.Location = new System.Drawing.Point(11, 386);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(168, 16);
            this.Copy.TabIndex = 8;
            this.Copy.Text = "复制到System文件夹再注册";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.CheckedChanged += new System.EventHandler(this.Copy_CheckedChanged_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(456, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // Label
            // 
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(184, 17);
            this.Label.Text = "                                            ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 427);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "FastRegsvr 已注册组件管理";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox RegList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox UnRegList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox Cmd;
        private System.Windows.Forms.CheckBox Copy;
        private System.Windows.Forms.Button RegBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label;
    }
}