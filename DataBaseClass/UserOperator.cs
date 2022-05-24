using ClassModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseClass
{
    public class UserOperator
    {
        private MySqlConnection mySqlConnection = null;
        public UserOperator()
        {
            mySqlConnection = DBConnect.GetInstance().GetSqlConnection();
        }
        #region 增加一个用户
        public void InsertSingleUserWithGame(UsersWithGamesModel userWithGameModel)
        {
            string sql = $"insert into users(username,user_played_games,user_evaluation) values " +
                $"('{userWithGameModel.Name}','{ListToText.ToText(userWithGameModel.Games)}','{ListToText.ToText(userWithGameModel.Evaluation)}')";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
        }
        #endregion 增加多个用户
        public void InsertUserWithGames(List<UsersWithGamesModel> usersWithGamesModels)
        {
            string baseSql = "insert into users(username,user_played_games,user_evaluation) values";
            MySqlCommand sqlCommand = new MySqlCommand();
            foreach (UsersWithGamesModel usersWithGames in usersWithGamesModels)
            {
                string valueSql = $"('{usersWithGames.Name}','{ListToText.ToText(usersWithGames.Games)}','{ListToText.ToText(usersWithGames.Evaluation)}')";
                sqlCommand.CommandText = baseSql + valueSql;
                sqlCommand.Connection = mySqlConnection;
                sqlCommand.ExecuteNonQuery();
            }
        }
        #region 获取数据库中的所有用户
        public List<UsersWithGamesModel> GetAll()
        {
            List<UsersWithGamesModel> list = new List<UsersWithGamesModel>();
            string sql = "select * from users";
            MySqlCommand sqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                UsersWithGamesModel user = new UsersWithGamesModel();
                user.UserId = dataReader.GetInt32(1);
                user.Name = dataReader.GetString(2);
                user.Games=TextToList.TextToStringList(dataReader.GetString(3));
                user.Evaluation=TextToList.TextToFloatList(dataReader.GetString(4));
                list.Add(user);
            }
            return list;
        }
        #endregion
        #region 按照id获取用户
        public UsersWithGamesModel GetUsersWithGamesModelById(int id)
        {

            return null;
        }
        #endregion
        #region 删除一个用户
        public bool DeleteUserById(UsersWithGamesModel usersWithGamesModel)
        {
            string sql = $"delete from games where game_id={usersWithGamesModel.UserId}";
            int result = -1;
            MySqlCommand sqlCommand = new MySqlCommand(sql, mySqlConnection);
            result = sqlCommand.ExecuteNonQuery();
            if (result == -1) { return false; }
            return true;
        }
        #endregion
        #region 删除所有用户
        public bool DeleteAll()
        {
            return false;
        }
        #endregion
    }
}
