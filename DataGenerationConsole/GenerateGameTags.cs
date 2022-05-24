using ClassModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationConsole
{
    internal class GenerateGameTags
    {
        public List<string> GenerateToStringList(List<string> gameName, List<string[]> tags)
        {
            List<string> result = new List<string>();
            Random random = new Random();
            foreach (string game in gameName)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(game);
                sb.Append("\t");
                //一个游戏需要生成的标签数目，暂定为5-tag的最大数量
                int numberOfTagsToGenerate = random.Next(5, tags.Count);
                Hashtable hashtable = new Hashtable();
                List<int> tagNumber = new List<int>();
                for (int i = 0; i < numberOfTagsToGenerate; i++)
                {
                    int temp = random.Next(0, tags.Count);
                    if (!hashtable.ContainsValue(temp))
                    {
                        hashtable.Add(temp, temp);
                        tagNumber.Add(temp);
                    }
                    else
                    {
                        i--;
                    }
                }
                for (int i = 0; i < tagNumber.Count; i++)
                {
                    int index = random.Next(0, tags[tagNumber[i]].Length);
                    sb.Append(tags[tagNumber[i]][index]);
                    sb.Append("\t");
                }
                result.Add(sb.ToString());
            }
            return result;
        }
        public List<GameModel> GenerateToGameModelList(List<string> gameName, List<string[]> tags)
        {
            List<GameModel> result = new List<GameModel>();
            Random random = new Random();
            foreach (string game in gameName)
            {
                GameModel model = new GameModel();
                model.GameName=game;

                int numberOfTagsToGenerate = random.Next(5, tags.Count);
                Hashtable hashtable = new Hashtable();
                List<int> tagNumber = new List<int>();
                for (int i = 0; i < numberOfTagsToGenerate; i++)
                {
                    int temp = random.Next(0, tags.Count);
                    if (!hashtable.ContainsValue(temp))
                    {
                        hashtable.Add(temp, temp);
                        tagNumber.Add(temp);
                    }
                    else
                    {
                        i--;
                    }
                }
                //生成Tag和权重
                for (int i = 0; i < tagNumber.Count; i++)
                {
                    int index = random.Next(0, tags[tagNumber[i]].Length);
                    double temp=random.NextDouble();
                    float weight = (float)temp*10;
                    model.GameTagsAndWeights.Add((tags[tagNumber[i]][index],weight));
                }
                //生成评价的权重
                for(int i = 0; i < 6; i++)
                {
                    model.Evaluation.Add((float)(random.NextDouble() * 10));
                }
                result.Add(model);
            }
            
            return result;
        }
    }
}
