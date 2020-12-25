using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class SortByAge : IComparer<Player>
    {
        public int Compare(Player pl1, Player pl2) => pl1.Age.CompareTo(pl2.Age);
    }
    public class SortByRank : IComparer<Player>
    {
        public int Compare(Player pl1, Player pl2) => pl1.Rank.CompareTo(pl2.Rank);
    }
    public class SortByName : IComparer<Player>
    {
        public int Compare(Player pl1, Player pl2)
        {
            var fl1 = pl1.FirstName + pl1.LastName;
            var fl2 = pl2.FirstName + pl2.LastName;
            return fl1.CompareTo(fl2);
        }

    }
}
