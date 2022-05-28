﻿namespace DotnetCourseDesign
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.userNameInputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userInputGameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserNameLabelBesideHexagon = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showRecommondGameTagsListBox = new System.Windows.Forms.ListBox();
            this.showRecommondPersonsListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.showRecommondGamesListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.showUsersListBox = new System.Windows.Forms.ListBox();
            this.showUserPlayedGames = new System.Windows.Forms.ListBox();
            this.recommondGameButton = new System.Windows.Forms.Button();
            this.recommondUserButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // userNameInputTextBox
            // 
            this.userNameInputTextBox.Location = new System.Drawing.Point(129, 57);
            this.userNameInputTextBox.Name = "userNameInputTextBox";
            this.userNameInputTextBox.Size = new System.Drawing.Size(191, 25);
            this.userNameInputTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "游戏列表";
            // 
            // userInputGameTextBox
            // 
            this.userInputGameTextBox.Location = new System.Drawing.Point(129, 102);
            this.userInputGameTextBox.Name = "userInputGameTextBox";
            this.userInputGameTextBox.Size = new System.Drawing.Size(191, 25);
            this.userInputGameTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(343, 105);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UserNameLabelBesideHexagon);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.showRecommondGameTagsListBox);
            this.panel1.Controls.Add(this.showRecommondPersonsListBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.showRecommondGamesListBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(424, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 400);
            this.panel1.TabIndex = 5;
            // 
            // UserNameLabelBesideHexagon
            // 
            this.UserNameLabelBesideHexagon.AutoSize = true;
            this.UserNameLabelBesideHexagon.Location = new System.Drawing.Point(368, 85);
            this.UserNameLabelBesideHexagon.Name = "UserNameLabelBesideHexagon";
            this.UserNameLabelBesideHexagon.Size = new System.Drawing.Size(55, 15);
            this.UserNameLabelBesideHexagon.TabIndex = 9;
            this.UserNameLabelBesideHexagon.Text = "label6";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(61, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(160, 160);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // showRecommondGameTagsListBox
            // 
            this.showRecommondGameTagsListBox.FormattingEnabled = true;
            this.showRecommondGameTagsListBox.ItemHeight = 15;
            this.showRecommondGameTagsListBox.Location = new System.Drawing.Point(137, 203);
            this.showRecommondGameTagsListBox.Name = "showRecommondGameTagsListBox";
            this.showRecommondGameTagsListBox.Size = new System.Drawing.Size(122, 169);
            this.showRecommondGameTagsListBox.TabIndex = 7;
            // 
            // showRecommondPersonsListBox
            // 
            this.showRecommondPersonsListBox.FormattingEnabled = true;
            this.showRecommondPersonsListBox.ItemHeight = 15;
            this.showRecommondPersonsListBox.Location = new System.Drawing.Point(291, 203);
            this.showRecommondPersonsListBox.Name = "showRecommondPersonsListBox";
            this.showRecommondPersonsListBox.Size = new System.Drawing.Size(176, 169);
            this.showRecommondPersonsListBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "可能想认识：";
            // 
            // showRecommondGamesListBox
            // 
            this.showRecommondGamesListBox.FormattingEnabled = true;
            this.showRecommondGamesListBox.ItemHeight = 15;
            this.showRecommondGamesListBox.Location = new System.Drawing.Point(20, 203);
            this.showRecommondGamesListBox.Name = "showRecommondGamesListBox";
            this.showRecommondGamesListBox.Size = new System.Drawing.Size(118, 169);
            this.showRecommondGamesListBox.TabIndex = 4;
            this.showRecommondGamesListBox.SelectedIndexChanged += new System.EventHandler(this.showRecommondGames_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "猜你喜欢：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "用户名:";
            // 
            // showUsersListBox
            // 
            this.showUsersListBox.FormattingEnabled = true;
            this.showUsersListBox.ItemHeight = 15;
            this.showUsersListBox.Location = new System.Drawing.Point(40, 168);
            this.showUsersListBox.Name = "showUsersListBox";
            this.showUsersListBox.Size = new System.Drawing.Size(158, 214);
            this.showUsersListBox.TabIndex = 6;
            this.showUsersListBox.SelectedIndexChanged += new System.EventHandler(this.showUsersListBox_SelectedIndexChanged);
            // 
            // showUserPlayedGames
            // 
            this.showUserPlayedGames.FormattingEnabled = true;
            this.showUserPlayedGames.ItemHeight = 15;
            this.showUserPlayedGames.Location = new System.Drawing.Point(193, 168);
            this.showUserPlayedGames.Name = "showUserPlayedGames";
            this.showUserPlayedGames.Size = new System.Drawing.Size(194, 214);
            this.showUserPlayedGames.TabIndex = 7;
            // 
            // recommondGameButton
            // 
            this.recommondGameButton.Location = new System.Drawing.Point(245, 402);
            this.recommondGameButton.Name = "recommondGameButton";
            this.recommondGameButton.Size = new System.Drawing.Size(75, 23);
            this.recommondGameButton.TabIndex = 8;
            this.recommondGameButton.Text = "推荐游戏";
            this.recommondGameButton.UseVisualStyleBackColor = true;
            this.recommondGameButton.Click += new System.EventHandler(this.recommondGameButton_Click);
            // 
            // recommondUserButton
            // 
            this.recommondUserButton.Location = new System.Drawing.Point(76, 402);
            this.recommondUserButton.Name = "recommondUserButton";
            this.recommondUserButton.Size = new System.Drawing.Size(75, 23);
            this.recommondUserButton.TabIndex = 9;
            this.recommondUserButton.Text = "推荐玩家";
            this.recommondUserButton.UseVisualStyleBackColor = true;
            this.recommondUserButton.Click += new System.EventHandler(this.recommondUserButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 450);
            this.Controls.Add(this.recommondUserButton);
            this.Controls.Add(this.recommondGameButton);
            this.Controls.Add(this.showUserPlayedGames);
            this.Controls.Add(this.showUsersListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.userInputGameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userNameInputTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox userNameInputTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox userInputGameTextBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox showUsersListBox;
		private System.Windows.Forms.ListBox showUserPlayedGames;
		private System.Windows.Forms.ListBox showRecommondGameTagsListBox;
		private System.Windows.Forms.ListBox showRecommondPersonsListBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox showRecommondGamesListBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button recommondGameButton;
		private System.Windows.Forms.Button recommondUserButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UserNameLabelBesideHexagon;
    }
}