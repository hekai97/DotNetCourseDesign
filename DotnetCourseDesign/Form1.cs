using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DotnetCourseDesign
{
    public partial class Form1 : Form
    {
        BindingList<string> userName = new BindingList<string>();
        Dictionary<string, BindingList<string>> gameNames = new Dictionary<string, BindingList<string>>();
        public Form1()
        {
            InitializeComponent();
            showUserNameListBox.DataSource = userName;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (!userNameTextBox.Text.Equals("") && !playedGameTextBox.Text.Equals(""))
            {
                if (!userName.Contains(userNameTextBox.Text))
                {
                    userName.Add(userNameTextBox.Text);
                    BindingList<string> gameNameList = new BindingList<string>();
                    gameNames.Add(userNameTextBox.Text, gameNameList);
                }
                if (!gameNames[userNameTextBox.Text].Contains(playedGameTextBox.Text))
                {
                    gameNames[userNameTextBox.Text].Add(playedGameTextBox.Text);
                    int t1 = showUserNameListBox.SelectedIndex;
                    int temp = showUserNameListBox.Items.IndexOf(userNameTextBox.Text);
                    showUserNameListBox.SelectedIndex=showUserNameListBox.Items.IndexOf(userNameTextBox.Text);
                }
            }
        }

        private void showUserNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.showUserNameListBox.SelectedIndex;
            string tempUserName = this.showUserNameListBox.Items[index].ToString();
            //this.showUserGameListBox.Items.Clear();
            //foreach (string s in gameNames[userName])
            //{
            //    this.showUserGameListBox.Items.Add(s);
            //}
            showUserGameListBox.DataSource = gameNames[tempUserName];
        }
    }
}
