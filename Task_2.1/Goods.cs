using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1
{
    public class Goods
    {
        public string Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal Cost { get; private set; }
        public List<Tags> tags = new List<Tags>();
        public Goods(string id, string brand, string model, decimal cost)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Cost = cost;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[Tags] = ");
            foreach (var m in tags)
                str.Append(m + ", ");
            return $"[GoodsID] = {Id} [Brand] = {Brand} [Model] = {Model} [Cost] = {Cost} " + str;
        }
    }
}
