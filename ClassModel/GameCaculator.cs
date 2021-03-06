using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassModel
{
    public class GameCaculator
    {
        #region 给单个用户推荐游戏
        /// <summary>
        /// 该方法的作用是返回一个推荐给用户的游戏列表
        /// </summary>
        /// <param name="usersWithGames">用户的模型，包含用户的用户名和其最近玩的游戏列表</param>
        /// <param name="allGames">从数据库中读出的所有游戏模型</param>
        /// <param name="values">控制参数，用于控制返回数据的长度，比如给用户返回5个推荐的游戏，则value=5,默认值是5</param>
        /// <returns></returns>
        public List<GameModel> RecommondGames(ref UsersWithGamesModel usersWithGames,ref List<GameModel> allGames, int values=5)
        {
            ///算法详解
            ///1.首先拿到用户的游戏列表，然后去遍历总的游戏列表中找到这些游戏
            ///2.将找到的游戏的各个相同标签的权重加起来求加权均值
            ///假如某个游戏的标签只出现过一次，就将其作为均值，最后得到一个标签权重键值对列表
            ///3.将用户的六部图算出来，计算方法（各个游戏六部图数据的平均值，然后得到六部分的百分比
            ///4.将用户游戏中存在的标签与不存在的标签进行8  2分
            ///5.将上述获得的键值对列表进行求和操作，然后算出各个的百分比。
            ///6.将上述得到的百分比列表中的数据都乘0.8，得到新的列表
            ///7.将该数据和数据库中的数据进行对比，计算，具体方式是：
            ///     (1).使用数据库中出现过的标签对应的权重去乘用户数据中该游戏对应标签的百分比，然后将其加起来。
            ///     (2),如果标签没有出现过，那么剩下多少标签没出现过，就把0.2平均分为几份，然后使用游戏对应标签的
            ///     权重去乘刚刚分好的那个数。
            ///     (3).将用户的六部图的百分比与游戏的六部图百分比相乘，算出结果
            ///     (3).将整个游戏的总体评分算出来，即将上述标签算的数据加起来*0.5，再加上六部图的数据乘以0.5，得到综合评分
            ///     (4).如果推荐列表不满，就将这个数据加进来。
            ///     (5).如果列表满了，就选择列表中综合评价分数最低的一个，将其置换
            ///8.返回这个游戏列表
            ///

            if (allGames.Count <= values)
            {
                return allGames;
            }
            //六部图数据
            List<List<float>> evaluationList;
            //找到的游戏标签和权重结果
            List<GameModel> findedGamesTagsWithWeight = FindGamesOfUserInAllGames(ref usersWithGames,ref allGames,out evaluationList);
            //找到的每个标签对应的权重值
            List<(string,float)> findedGamesTagsWithAverageWeight=GetFindedGamesAverageWeight(ref findedGamesTagsWithWeight);
            //六部图的结果
            usersWithGames.Evaluation = GetAverageEvaluation(evaluationList);
            //Tag权重平均值的百分比
            List<(string, float)> findedGameTagsWithAverageWeightPercent = GetFindedGamesAverageWeightPercent(findedGamesTagsWithAverageWeight);
            //六部图的每个数值的百分比
            List<float> gameEvaluationPercent = GetEvaluationPercent(usersWithGames.Evaluation);


            //开始对比
            //程序结果
            List<GameModel> result = GetRecommond(ref findedGamesTagsWithWeight, ref allGames, ref findedGameTagsWithAverageWeightPercent, ref gameEvaluationPercent,values);

            return result;
        }
        #endregion

        #region 计算用户与列表中存在的用户相似度，返回用户列表和用户与用户列表中各个人的相似度
        /// <summary>
        /// 该方法的作用是计算一个用户与另一个用户的相似度
        /// </summary>
        /// <param name="usersWithGames">待计算的用户</param>
        /// <param name="usersWithGamesModels">用来对比的用户列表</param>
        /// <param name="value">控制参数，用于控制返回数据的长度，比如给该用户返回5个相似的人，则value=5</param>
        /// <returns>返回一个列表，该列表中存在两个item，第一个item是相似的人，第二个item是相似度，float类型</returns>
        /// <exception cref="IndexOutOfRangeException">当输入的value大于用户列表长度的时候会抛出该异常</exception>
        public List<(UsersWithGamesModel, float)> Similarity(UsersWithGamesModel usersWithGames,ref List<UsersWithGamesModel> usersWithGamesModels, int value=1)
        {
            if (value > usersWithGames.Games.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return null;
        }
        #endregion

        #region 计算用户与用户之间的相似度，返回两个用户之间的相似度
        /// <summary>
        /// 计算两个用户之间的相似度
        /// </summary>
        /// <param name="usersWithGames1">用户1</param>
        /// <param name="usersWithGames2">用户2</param>
        /// <returns>两个用户之间的相似度</returns>
        private float SimilarityInSingleUser(UsersWithGamesModel usersWithGames1, UsersWithGamesModel usersWithGames2)
        {
            return 0.0f;
        }
        #endregion

        //#region 使用游戏名找到该游戏的各种标签和属性
        //public void FindGameByName(string gameName,List<GameModel> allGames,List<GameModel> findedGame)
        //{
        //    lock (findedGame)
        //    {
        //        foreach(GameModel game in allGames)
        //        {
        //            if (game.GameName.Equals(gameName))
        //            {
        //                findedGame.Add(game);
        //                break;
        //            }
        //        }
        //    }
        //}
        //#endregion

        #region 获取从用户输入的游戏名字中的游戏,同时输出参数中输出游戏的六部图
        private List<GameModel> FindGamesOfUserInAllGames(ref UsersWithGamesModel usersWithGames,ref List<GameModel> allGames,out List<List<float>> evaluationList)
        {
            evaluationList = new List<List<float>>();
            List<GameModel> findedGamesTagsWithWeight = new List<GameModel>();
            //找到这些游戏
            foreach (GameModel gameModel in allGames)
            {
                for (int i = 0; i < usersWithGames.Games.Count; ++i)
                {
                    if (usersWithGames.Games[i].Equals(gameModel.GameName))
                    {
                        findedGamesTagsWithWeight.Add(gameModel);
                        evaluationList.Add(gameModel.Evaluation);
                        break;
                    }
                }
            }
            return findedGamesTagsWithWeight;
        }
        #endregion

        #region 计算找出来的游戏标签权重的均值
        private List<(string,float)> GetFindedGamesAverageWeight(ref List<GameModel> findedGamesTagsWithWeight)
        {
            //算均值,先将数据拆分，方便后面计算
            //找到的游戏标签数目
            int length = findedGamesTagsWithWeight.Count;
            //找到的所有游戏标签，包含重复值
            List<string> gameTagsList = new List<string>();
            //上述游戏标签对应的权重值
            List<float> gameTagsWeight = new List<float>();
            foreach (GameModel gameModel in findedGamesTagsWithWeight)
            {
                foreach (var item in gameModel.GameTagsAndWeights)
                {
                    gameTagsList.Add(item.Item1);
                    gameTagsWeight.Add(item.Item2);
                }
            }
            //即将生成的游戏标签，不重复
            List<string> uniqueGameTagsList = new List<string>();
            //上述标签唯一值的和
            List<float> gameTagsWeightSum = new List<float>();
            //上述标签出现的次数
            List<int> tagsTime = new List<int>();

            for (int i = 0; i < gameTagsList.Count; ++i)
            {
                if (!uniqueGameTagsList.Contains(gameTagsList[i]))
                {
                    uniqueGameTagsList.Add(gameTagsList[i]);
                    gameTagsWeightSum.Add(gameTagsWeight[i]);
                    tagsTime.Add(1);
                }
                else
                {
                    gameTagsWeightSum[uniqueGameTagsList.IndexOf(gameTagsList[i])] += gameTagsWeight[i];
                    tagsTime[uniqueGameTagsList.IndexOf(gameTagsList[i])]++;
                }
            }
            //for (int i = 0; i < uniqueGameTagsList.Count; ++i)
            //{
            //    Console.WriteLine(uniqueGameTagsList[i]);
            //    Console.WriteLine(gameTagsWeightSum[i]);
            //    Console.WriteLine(tagsTime[i]);
            //}

            //用户玩的游戏标签的键值对,二八分之后
            List<(string, float)> tagAverageWeight = new List<(string, float)>();

            for (int i = 0; i < uniqueGameTagsList.Count; ++i)
            {
                float averageOfWeight = gameTagsWeightSum[i] / tagsTime[i];
                tagAverageWeight.Add((uniqueGameTagsList[i], averageOfWeight));
            }
            return tagAverageWeight;
        }
        #endregion

        #region 从游戏权重均值中获得每个权重对应的百分比
        private List<(string, float)> GetFindedGamesAverageWeightPercent(List<(string, float)> values)
        {
            List<(string, float)> result = new List<(string, float)>();
            float sum = 0.0f;
            foreach (var value in values)
            {
                sum += value.Item2;
            }
            for (int i = 0; i < values.Count; ++i)
            {
                result.Add((values[i].Item1, values[i].Item2 / sum));
            }
            return result;
        }

        #endregion

        #region 从多个六部图中获取平均值
        private List<float> GetAverageEvaluation(List<List<float>> evaluations)
        {
            int length = evaluations[0].Count;
            List<float> result = new List<float>(length);

            for(int i = 0; i < evaluations.Count; ++i)
            {
                for(int j = 0; j < length; ++j)
                {
                    result[j] += evaluations[i][j];
                }
            }
            for(int i = 0; i < length; ++i)
            {
                result[i] /= length;
            }

            return result;
        }
        #endregion

        #region 获取六部图每部分的百分比
        private List<float> GetEvaluationPercent(List<float> evaluation)
        {
            float sum = evaluation.Sum();
            List<float> result = new List<float>();
            foreach(float f in evaluation)
            {
                result.Add(f / sum);
            }
            return result;
        }
        #endregion

        #region 获取推荐的游戏列表

        /// <summary>
        /// 
        /// </summary>
        /// <param name="existGamesModel">存在的游戏目录，也就是此时用户输入的，在数据库中存在游戏</param>
        /// <param name="allGames">所有的游戏目录</param>
        /// <param name="tagsWeightList">标签对应的权重百分比列表</param>
        /// <param name="evaluationList">六部图对应的百分比列表</param>
        /// <param name="value">需要生成推荐的数目</param>
        /// <param name="existTagsWeight">这个值的意思是说，在进行比较的时候，有些标签是没有出现过的，那么出现过的标签所占的比重，默认是0.8</param>
        /// <param name="tagsWeight">这个值的意思是，在进行对比的时候，标签所占的比重，则1-tagWeight就是六部图所占的比重</param>
        /// <returns></returns>
        private List<GameModel> GetRecommond(ref List<GameModel> existGamesModel,
            ref List<GameModel> allGames,
            ref List<(string,float)> tagsWeightListPercent,
            ref List<float> evaluationListPercent,
            int value,
            float existTagsWeight=0.8f,
            float tagsWeight=0.5f
            )
        {
            List<(GameModel, float)> gameWithOverview = new List<(GameModel, float)>();
            List<GameModel> result = new List<GameModel>();
            foreach(GameModel games in allGames)
            {
                if (existGamesModel.Contains(games))
                {
                    continue;
                }
                //算出存在标签的权值之和

                //算出不存在标签的权值之和

                //算出六部图的比例和

                //上面三个相加，得到总体评价

            }

            return result;
        }

        #endregion
    }
}
