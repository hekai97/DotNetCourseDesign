using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class ListToText
    {
        public static string ToText(List<string> strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in strings)
            {
                sb.Append(s);
                sb.Append('\n');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        public static string ToText(List<float> floats)
        {
            StringBuilder sb = new StringBuilder();
            foreach(float f in floats)
            {
                sb.Append(f.ToString());
                sb.Append('\n');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        public static string ToText(List<(string,float)> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var v in values)
            {
                sb.Append(v.Item1.ToString() + '\t' + v.Item2.ToString());
                sb.Append('\n');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
