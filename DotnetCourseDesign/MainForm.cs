using ClassModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotnetCourseDesign
{
    public partial class MainForm : Form
    {
        List<UsersWithGamesModel> userList = new List<UsersWithGamesModel>();
        public MainForm()
        {
            
            InitializeComponent();
        }

        private void showUsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex=showUsersListBox.SelectedIndex;
            showUserPlayedGames.DataSource = userList[selectIndex].Games;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (userNameInputTextBox.Text.Equals("") || userInputGameTextBox.Text.Equals(""))
            {
                return;
            }
            string userName = userNameInputTextBox.Text;
            string gameName = userInputGameTextBox.Text;
            if (isUserExist(userName))
            {
                if (isGameInUser(userName,gameName))
                {
                    return;
                }
                int index=FindUserIndexByName(userName);
                userList[index].Games.Add(gameName);
            }
            else
            {
                UsersWithGamesModel user = new UsersWithGamesModel();
                user.Name = userNameInputTextBox.Text;
                user.Games.Add(userInputGameTextBox.Text);
                userList.Add(user);
            }

            int selectIndex = FindUserIndexByName(userName);
            showUsersListBox.SelectedIndex = selectIndex;
        }

        private int FindUserIndexByName(string name)
        {
            for(int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }
        private bool isUserExist(string username)
        {
            return FindUserIndexByName(username) !=-1;
        }
        private bool isGameInUser(string username,string gamename)
        {
            foreach(UsersWithGamesModel user in userList)
            {
                if (user.Name.Equals(username))
                {
                    foreach(string game in user.Games)
                    {
                        if (gamename.Equals(game))
                        {
                            return true;
                        }
                    }
                    break;
                }
            }
            return false;
        }
    }
}
