using ClassModel;
using DataBaseClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string basePath = @"E:\Codes\VS2022\DotNetCourseDesign\DataGenerationConsole";
            //WriteToFile writeToFile = new WriteToFile();
            //writeToFile.initGameName(basePath, 10000);
            #region 暂时无用的代码
            //string gamePath = basePath + @"\games";
            //string gameTagsPath = basePath + @"\gameTags";
            //DirectoryInfo gameTagsDirectory = new DirectoryInfo(gameTagsPath);
            //FileInfo[] gameTagsFiles = gameTagsDirectory.GetFiles();
            //List<string> games = new List<string>(File.ReadAllLines(gamePath + @"\gameList.txt"));
            //List<string[]> tags = new List<string[]>();
            //foreach (FileInfo gameTagFile in gameTagsFiles)
            //{
            //    Console.WriteLine(gameTagFile.FullName);
            //    string[] tempTags = File.ReadAllLines(gameTagFile.FullName);
            //    tags.Add(tempTags);
            //}
            //GenerateGameTags generateGameTags = new GenerateGameTags();
            ////List<string> result = generateGameTags.GenerateToStringList(games, tags);
            ////for (int i = 0; i < result.Count; i++)
            ////{
            ////    Console.WriteLine(result[i]);
            ////}
            ////Console.ReadLine();

            //List<GameModel> result = generateGameTags.GenerateToGameModelList(games, tags);

            ////TestReadSpeed();
            //GameOperator gameOperator = new GameOperator();
            //gameOperator.InsertGameList(result);
            #endregion

            //WriteToFile wr = new WriteToFile();
            //wr.GenerationGamesToDataBases(basePath);

            TestReadSpeed();
            Console.ReadLine();
        }
        static void GenerationGames()
        {
            string basePath = @"E:\Codes\VS2022\DotNetCourseDesign\DataGenerationConsole";
            WriteToFile writeToFile = new WriteToFile();
            writeToFile.initGameName(basePath, 10000);
            writeToFile.GenerationGamesToDataBases(basePath);

        }

        public static void TestReadSpeed()
        {
            GameOperator gameOperator = new GameOperator();
            List<GameModel> result = gameOperator.GetAllGameList();
            UsersWithGamesModel usersWithGamesModel = new UsersWithGamesModel();
            usersWithGamesModel.Games.Add("游戏10000");
            usersWithGamesModel.Games.Add("游戏9999");
            usersWithGamesModel.Games.Add("游戏9998");
            usersWithGamesModel.Games.Add("游戏9997");
            usersWithGamesModel.Games.Add("游戏9996");
            usersWithGamesModel.Games.Add("游戏9995");
            usersWithGamesModel.Games.Add("游戏9994");
            GameCaculator gameCaculator = new GameCaculator();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<GameModel> res=gameCaculator.RecommondGames(ref usersWithGamesModel,ref result, 100);
            foreach (GameModel gameModel in res)
            {
                Console.WriteLine(gameModel.GameId);
                Console.WriteLine(gameModel.GameName);
                Console.WriteLine(ListToText.ToText(gameModel.GameTagsAndWeights));
                Console.WriteLine(ListToText.ToText(gameModel.Evaluation));
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
    class WriteToFile
    {
        public void initGameName(string basePath,int number)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < number; ++i)
            {
                list.Add($"游戏{i+1}");
            }
            File.WriteAllLines(basePath+@"\games\gameList.txt", list);
        }
        public void GenerationGamesToDataBases(string basePath)
        {
            string gamePath = basePath + @"\games";
            string gameTagsPath = basePath + @"\gameTags";
            DirectoryInfo gameTagsDirectory = new DirectoryInfo(gameTagsPath);
            FileInfo[] gameTagsFiles = gameTagsDirectory.GetFiles();
            List<string> games = new List<string>(File.ReadAllLines(gamePath + @"\gameList.txt"));
            List<string[]> tags = new List<string[]>();
            foreach (FileInfo gameTagFile in gameTagsFiles)
            {
                Console.WriteLine(gameTagFile.FullName);
                string[] tempTags = File.ReadAllLines(gameTagFile.FullName);
                tags.Add(tempTags);
            }
            GenerateGameTags generateGameTags = new GenerateGameTags();
            List<GameModel> result = generateGameTags.GenerateToGameModelList(games, tags);

            //TestReadSpeed();
            GameOperator gameOperator = new GameOperator();
            gameOperator.InsertGameList(result);


            Console.ReadLine();
        }
    }
}
