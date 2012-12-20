using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSignalR.Highcharts
{
    public class HighchartsBasic<T>
    {
        public string name { get; set; }
        public virtual IList<T> data { get; set; }
    }
}