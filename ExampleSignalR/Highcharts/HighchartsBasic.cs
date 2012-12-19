using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSignalR.Highcharts
{
    public class HighchartsBasic<T>
    {
        public string Name { get; set; }
        public virtual IList<T> Data { get; set; }
    }
}