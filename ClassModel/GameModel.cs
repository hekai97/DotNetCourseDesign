﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class GameModel
    {
        int gameId;
        string gameName;
        List<(string, float)> gameTagsAndWeights = new List<(string, float)>();
        //添加一个六部图，六部分别为视觉，听觉，剧情，难度，游戏性，付费情况。
        List<float> evaluation=new List<float>();

        Hashtable gameTagsAndWeightsForHash = new Hashtable();
        public int GameId { get { return gameId; } set { gameId = value; } }

        public string GameName { get { return gameName; } set { gameName = value; } }
        public List<(string, float)> GameTagsAndWeights { get { return gameTagsAndWeights; } set { gameTagsAndWeights = value; } } 
        public List<float> Evaluation { get { return evaluation; } set { evaluation = value; } }

        #region
        public void ListToHash()
        {
            if (gameTagsAndWeightsForHash.Count <= 0)
                foreach ((string, float) i in this.gameTagsAndWeights)
                    gameTagsAndWeightsForHash.Add(i.Item1, i.Item2);
        }

        public Hashtable GetHashtable()
        {
            return this.gameTagsAndWeightsForHash;
        }
        #endregion
    }
}
