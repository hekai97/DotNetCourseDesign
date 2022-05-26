using ClassModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseClass
{
    public class GameOperator
    {
        private MySqlConnection mySqlConnection = null;
        public GameOperator()
        {
            mySqlConnection=DBConnect.GetInstance().GetSqlConnection();
        }
        #region 添加单个游戏
        public void InsertSingleGame(GameModel gameModel)
        {
            string sql = $"insert into games(game_name,game_tags_with_weights,game_evaluation) values " +
                $"('{gameModel.GameName}','{ListToText.ToText(gameModel.GameTagsAndWeights)}','{ListToText.ToText(gameModel.Evaluation)}')";
            MySqlCommand mySqlCommand = new MySqlCommand(sql,mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
        }
        #endregion
        #region 添加游戏列表
        public void InsertGameList(List<GameModel> gameModels)
        {
            string baseSql = "insert into games(game_name,game_tags_with_weights,game_evaluation) values";
            MySqlCommand sqlCommand = new MySqlCommand();
            sqlCommand.Connection = mySqlConnection;
            foreach (GameModel gameModel in gameModels)
            {
                string valueSql = $"('{gameModel.GameName}','{ListToText.ToText(gameModel.GameTagsAndWeights)}','{ListToText.ToText(gameModel.Evaluation)}')";
                sqlCommand.CommandText = baseSql + valueSql;
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion
        #region 获取游戏列表
        public List<GameModel> GetAllGameList()
        {
            List<GameModel> list = new List<GameModel>();
            string sql = "select * from games";
            MySqlCommand sqlCommand = new MySqlCommand(sql,mySqlConnection);
            MySqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                GameModel gameModel = new GameModel();
                gameModel.GameId = dataReader.GetInt32(0);
                gameModel.GameName = dataReader.GetString(1);
                gameModel.GameTagsAndWeights=TextToList.TextToPairList(dataReader.GetString(2));
                gameModel.Evaluation=TextToList.TextToFloatList(dataReader.GetString(3));

                gameModel.ListToHash();

                list.Add(gameModel);
            }
            return list;
        }
        #endregion
        #region 获取游戏列表的长度
        public int GetListCount()
        {
            return GetAllGameList().Count;
        }
        #endregion
        #region 通过游戏名获取游戏
        public GameModel GetGameByName()
        {
            return null;
        }
        #endregion
        #region 删除单个游戏
        public bool DeleteSingleGame(GameModel gameModel)
        {
            string sql = $"delete from games where game_id={gameModel.GameId}";
            int result = -1;
            MySqlCommand sqlCommand = new MySqlCommand(sql, mySqlConnection);
            result=sqlCommand.ExecuteNonQuery();
            if(result == -1) { return false; }
            return true;
        }
        #endregion
        #region 删除整张表
        public bool DeleteAll()
        {
            return false;
        }
        #endregion
    }
}
