using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class TextToList
    {
        public static List<string> TextToStringList(string text)
        {
            string[] strings = text.Split('\n');
            List<string> list = new List<string>(strings);
            return list;
        } 
        public static List<float> TextToFloatList(string text)
        {
            string[] strings = text.Split('\n');
            float[] floats = new float[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                floats[i] = Convert.ToSingle(strings[i]);
            }
            List <float> list = new List<float>(floats);
            return list;
        }
        public static List<(string,float)> TextToPairList(string text)
        {
            List<(string, float)> list = new List<(string, float)>();
            string[] strings = text.Split('\n');
            string[] pairFirst = new string[strings.Length];
            float[] pairSecond = new float[strings.Length];
            for(int i = 0; i < strings.Length; i++)
            {
                string[] temp = strings[i].Split('\t');
                pairFirst[i] = temp[0];
                pairSecond[i] = Convert.ToSingle(temp[1]);
                list.Add((pairFirst[i],pairSecond[i]));
            }
            return list;
        }
    }
}
