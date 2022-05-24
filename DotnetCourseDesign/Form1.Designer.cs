namespace DotnetCourseDesign
{
    partial class Form1
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
            this.showUserNameListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUserGameListBox = new System.Windows.Forms.ListBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.playedGameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cleanAllUserButton = new System.Windows.Forms.Button();
            this.cleanAllGameButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showUserNameListBox
            // 
            this.showUserNameListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.showUserNameListBox.FormattingEnabled = true;
            this.showUserNameListBox.ItemHeight = 15;
            this.showUserNameListBox.Location = new System.Drawing.Point(86, 185);
            this.showUserNameListBox.Name = "showUserNameListBox";
            this.showUserNameListBox.Size = new System.Drawing.Size(120, 94);
            this.showUserNameListBox.TabIndex = 0;
            this.showUserNameListBox.SelectedIndexChanged += new System.EventHandler(this.showUserNameListBox_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // showUserGameListBox
            // 
            this.showUserGameListBox.FormattingEnabled = true;
            this.showUserGameListBox.ItemHeight = 15;
            this.showUserGameListBox.Location = new System.Drawing.Point(212, 185);
            this.showUserGameListBox.Name = "showUserGameListBox";
            this.showUserGameListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.showUserGameListBox.Size = new System.Drawing.Size(120, 94);
            this.showUserGameListBox.TabIndex = 1;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(86, 117);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 25);
            this.userNameTextBox.TabIndex = 2;
            // 
            // playedGameTextBox
            // 
            this.playedGameTextBox.Location = new System.Drawing.Point(280, 117);
            this.playedGameTextBox.Name = "playedGameTextBox";
            this.playedGameTextBox.Size = new System.Drawing.Size(100, 25);
            this.playedGameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "玩过的游戏";
            // 
            // cleanAllUserButton
            // 
            this.cleanAllUserButton.Location = new System.Drawing.Point(86, 336);
            this.cleanAllUserButton.Name = "cleanAllUserButton";
            this.cleanAllUserButton.Size = new System.Drawing.Size(120, 41);
            this.cleanAllUserButton.TabIndex = 6;
            this.cleanAllUserButton.Text = "清空所有用户";
            this.cleanAllUserButton.UseVisualStyleBackColor = true;
            // 
            // cleanAllGameButton
            // 
            this.cleanAllGameButton.Location = new System.Drawing.Point(212, 336);
            this.cleanAllGameButton.Name = "cleanAllGameButton";
            this.cleanAllGameButton.Size = new System.Drawing.Size(120, 41);
            this.cleanAllGameButton.TabIndex = 7;
            this.cleanAllGameButton.Text = "清空所有游戏";
            this.cleanAllGameButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(406, 118);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 34);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cleanAllGameButton);
            this.Controls.Add(this.cleanAllUserButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playedGameTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.showUserGameListBox);
            this.Controls.Add(this.showUserNameListBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox showUserNameListBox;
        private System.Windows.Forms.ListBox showUserGameListBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox playedGameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cleanAllUserButton;
        private System.Windows.Forms.Button cleanAllGameButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}

