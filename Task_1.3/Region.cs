using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    public class Region : IRegion
    {
        public string Brand { get; set; }
        public string Country { get; set; }
        public Region(string brand, string country)
        {
            Brand = brand;
            Country = country;
        }
        public override bool Equals(object obj)
        {
            var region = obj as Region;
            if (this == region)
                return true;
            return region != null && string.Equals(Brand,region.Brand) && string.Equals(Country, region.Country);
        }

        public override int GetHashCode()
        {
            return Brand.GetHashCode() ^ Country.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{Brand},{Country}]";
        }
    }
}
