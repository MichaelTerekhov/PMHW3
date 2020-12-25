using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1
{
    public class Tags
    {
        public string GoodsId { get; private set; }
        public string TagsValue { get; private set; }
        public Tags(string id, string val)
        {
            GoodsId = id;
            TagsValue = val;
        }

        public override string ToString()
        {
            return $"{TagsValue}";
        }
    }
}
