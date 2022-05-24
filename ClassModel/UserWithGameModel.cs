using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class UsersWithGamesModel
    {
        int userId;
        string name;
        List<string> games=new List<string>();
        List<float> evaluation = new List<float>();
        public int UserId{ get { return userId; }set { userId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public List<string> Games { get { return games; } set {games = value; } }
        public List<float> Evaluation { get { return evaluation; } set { evaluation = value; } }

    }
}
