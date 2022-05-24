using ClassModel;
using DataBaseClass;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameModel gameModel = new GameModel();
            gameModel.GameName = "Test1";
            gameModel.GameTagsAndWeights.Add(("冒险", 5.3f));
            gameModel.GameTagsAndWeights.Add(("策略", 4.5f));
            gameModel.GameTagsAndWeights.Add(("开放世界", 5.6f));

            gameModel.Evaluation.Add(0.7f);
            gameModel.Evaluation.Add(0.8f);
            gameModel.Evaluation.Add(0.34f);
            gameModel.Evaluation.Add(0.56f);
            gameModel.Evaluation.Add(0.34f);
            gameModel.Evaluation.Add(0.43f);

            GameOperator gameOperator = new GameOperator();
            gameOperator.InsertSingleGame(gameModel);
            List<GameModel> gameModels = gameOperator.GetAllGameList();
            foreach(GameModel game in gameModels)
            {
                Console.WriteLine(game.GameId);
                Console.WriteLine(game.GameName);
                for(int i = 0; i < game.GameTagsAndWeights.Count; i++)
                {
                    Console.WriteLine(game.GameTagsAndWeights[i].ToString());
                }
                for(int i = 0; i < game.Evaluation.Count; i++)
                {
                    Console.WriteLine(game.Evaluation[i].ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
