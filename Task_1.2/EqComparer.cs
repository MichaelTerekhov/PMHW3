using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class PlayerEqualityComparer : IEqualityComparer<Player>
    {
        public bool Equals(Player b1, Player b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;
            else if (b1.Age == b2.Age && b1.FirstName == b2.FirstName
                                && b1.LastName == b2.LastName && b1.Rank == b2.Rank)
                return true;
            else
                return false;
        }

        public int GetHashCode(Player pl)
        {
            if (pl == null)
                return 0;
            return pl.Age.GetHashCode() ^ pl.FirstName.GetHashCode() ^ pl.LastName.GetHashCode() ^ pl.Rank.GetHashCode();
        }
    }
}
