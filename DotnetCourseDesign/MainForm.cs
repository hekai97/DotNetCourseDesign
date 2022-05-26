using ClassModel;
using DataBaseClass;
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
        GameCaculator gameCaculator=new GameCaculator();
        GameOperator gameOperator = new GameOperator();
        UserOperator userOperator = new UserOperator();
        UsersWithGamesModel selectedUser = null;
        List<GameModel> allGames;

        List<string> userNameList = new List<string>();
        List<UsersWithGamesModel> userList = new List<UsersWithGamesModel>();
        public MainForm()
        {
            InitializeComponent();

            allGames=gameOperator.GetAllGameList();

            showUsersListBox.DataSource = userNameList;
        }
        private void showUsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showUserPlayedGames.DataSource = null;
            int selectIndex=showUsersListBox.SelectedIndex;
            //这里之所以判断，是因为当把显示用户名的listbox的数据源设置为null之后，会执行这个方法
            //此时listbox失去了数据源，索引值会变为-1
            if (selectIndex >= 0)
            {
                showUserPlayedGames.DataSource = userList[selectIndex].Games;
            }
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
                showUserPlayedGames.DataSource = null;
                showUserPlayedGames.DataSource = userList[index].Games;
            }
            else
            {
                userNameList.Add(userName);
                UsersWithGamesModel user = new UsersWithGamesModel();
                user.Name = userNameInputTextBox.Text;
                user.Games.Add(userInputGameTextBox.Text);
                userList.Add(user);
            }

            showUsersListBox.DataSource = null;
            showUsersListBox.DataSource = userNameList;
            int selectIndex = FindUserIndexByName(userName);
            showUsersListBox.SelectedIndex = selectIndex;

            selectedUser=userList[selectIndex];
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

        private void recommondGameButton_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                List<GameModel> recommondedGames = gameCaculator.RecommondGames(ref selectedUser, ref allGames);
            }
            else
            {
                MessageBox.Show("请先添加用户","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void recommondUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}
