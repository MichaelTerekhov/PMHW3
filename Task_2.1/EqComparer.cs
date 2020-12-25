using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1
{
    public class GoodsEqualityComparer : IEqualityComparer<Goods>
    {
     public bool Equals(Goods b1, Goods b2)
    {
        if (b2 == null && b1 == null)
            return true;
        else if (b1 == null || b2 == null)
            return false;
        else if (b1.Id == b2.Id && b1.Brand == b2.Brand
                            && b1.Model == b2.Model && b1.Cost == b2.Cost && b1.tags ==b2.tags)
            return true;
        else
            return false;
    }

    public int GetHashCode(Goods pl)
    {
        if (pl == null)
            return 0;
        return pl.Id.GetHashCode() ^ pl.Brand.GetHashCode() ^ pl.Model.GetHashCode() ^ pl.Cost.GetHashCode() ^ pl.tags.GetHashCode();
    }
}
}
