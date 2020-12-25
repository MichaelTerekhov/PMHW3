using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    public interface IRegion
    {
        string Brand { get; }
        string Country { get; }
    }
    public interface IRegionSettings
    {
        string WebSite { get; }
    }
}
