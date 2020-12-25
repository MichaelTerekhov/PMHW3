using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1
{
    public class Inventory
    {
        public string GoodsId { get; private set; }
        public string Location { get; private set; }
        public int Count { get; private set; }
        public Inventory(string id, string loc, int c)
        {
            GoodsId = id;
            Location = loc;
            Count = c;
        }

        public override string ToString()
        {
            return $"[GoodsId] = {GoodsId} [Location] = {Location} 'Count' = {Count}";
        }
    }
}
