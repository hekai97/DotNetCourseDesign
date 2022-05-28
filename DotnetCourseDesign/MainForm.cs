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
        const int LENGTH = 140;
        

        //游戏计算的类
        GameCaculator gameCaculator=new GameCaculator();
        //操作数据库的几个类
        GameOperator gameOperator = new GameOperator();
        UserOperator userOperator = new UserOperator();
        //当前选中的用户，就是在ListBox中点击的那个
        UsersWithGamesModel selectedUser = null;
        //所有游戏的合集
        List<GameModel> allGames;
        //推荐的游戏，这个列表只要按下推荐游戏就会把之前的数据清除掉
        List<GameModel> recommondedGames;

        //用户名字的列表，该列表作为Listbox的数据源使用
        List<string> userNameList = new List<string>();
        //用户的列表，该列表表示此时的输入的用户数和所有的属性值
        List<UsersWithGamesModel> userList = new List<UsersWithGamesModel>();
        public MainForm()
        {
            InitializeComponent();
            UserNameLabelBesideHexagon.Text = "";

            allGames=gameOperator.GetAllGameList();

            showUsersListBox.DataSource = userNameList;

            pictureBox1.Width = LENGTH + 10;
            pictureBox1.Width = LENGTH + 10;
            pictureBox1.Padding = new Padding(5, 5, 5, 5);
            pictureBox1.CreateGraphics().Clear(Color.White);
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
                selectedUser=userList[selectIndex];
                UserNameLabelBesideHexagon.Text = selectedUser.Name;
                DrawerUserHexagon();
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
                if (recommondedGames != null)
                {
                    recommondedGames.Clear();
                }
                recommondedGames = gameCaculator.RecommondGames(ref selectedUser, ref allGames);
                showRecommondGamesListBox.Items.Clear();
                foreach(GameModel game in recommondedGames)
                {
                    showRecommondGamesListBox.Items.Add(game.GameName);
                }
            }
            else
            {
                MessageBox.Show("请先添加用户","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            DrawerUserHexagon();
        }

        private void recommondUserButton_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("请先添加用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showRecommondPersonsListBox.Items.Clear();
            try
            {
                List<(UsersWithGamesModel, float)> recommondPerson = gameCaculator.Similarity(selectedUser, ref userList);
                if(recommondPerson == null)
                {
                    MessageBox.Show("请先添加更多用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var person in recommondPerson)
                {
                    showRecommondPersonsListBox.Items.Add($"{person.Item1.Name}---相似度---{person.Item2 * 100}%");
                }
            }catch(IndexOutOfRangeException)
            {
                MessageBox.Show("请先添加用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showRecommondGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = showRecommondGamesListBox.SelectedIndex;
            List<string> selectedGameTags = new List<string>();
            GameModel selectedGame=recommondedGames[selectIndex];
            foreach(var t in selectedGame.GameTagsAndWeights)
            {
                selectedGameTags.Add(t.Item1.ToString());
            }
            showRecommondGameTagsListBox.Items.Clear();
            foreach(var t in selectedGameTags)
            {
                showRecommondGameTagsListBox.Items.Add(t);
            }

        }

        #region 绘图
        private void DrawerUserHexagon()
        {
            if (selectedUser == null||selectedUser.Evaluation.Count==0)
            {
                return;
            }
            Graphics e=pictureBox1.CreateGraphics();
            e.Clear(Color.White);
            Pen pen=new Pen(Color.Black);

            //首先绘制画板底部
            //这个是比值，ratio的意思是界面上画板的半长度与用户六边形最大值的比值，该值用来缩放绘制的六边形大小
            float ratio = (LENGTH / 2) / MyHexagon.hexagonMaxLength;
            //该值用来绘制画板底部的十个逐渐变小的六边形。
            float delta=MyHexagon.hexagonMaxLength;

            while (delta >= 0)
            {
                List<float> temp = new List<float>();
                for(int i = 0; i < 6; ++i)
                {
                    temp.Add(delta);
                }
                e.DrawPolygon(pen, GetPointsFromMyPoint(new MyHexagon(temp).hexagonPoints,ratio));
                delta -= 1;
            }

            //绘制用户的数据，采用另一种颜色的笔
            pen.Color = Color.Green;
            Brush brush=new SolidBrush(Color.Green);
            e.FillPolygon(brush, GetPointsFromMyPoint(new MyHexagon(selectedUser.Evaluation).hexagonPoints,ratio));
            //TODO 该处并未成功显示六边形
            e.Dispose();
            
        }

        private PointF[] GetPointsFromMyPoint(List<MyPoint> p,float rat)
        {
            List<PointF> tempResult = new List<PointF>();
            foreach(MyPoint pt in p)
            {
                tempResult.Add(new PointF(pt.x*rat, pt.y*rat));
            }
            return tempResult.ToArray();
        }
        #endregion
    }

}
