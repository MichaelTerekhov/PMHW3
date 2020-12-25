using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    public class RegionSettings: IRegionSettings
    {
       public  string WebSite { get; set; }
        public RegionSettings(string web)
        {
            WebSite = web;
        }
        public override string ToString()
        {
            return $"[{WebSite}]";
        }
    }
}
