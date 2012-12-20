using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSignalR.Highcharts
{
    public class HighchartsRender<TCategorie, TData> where TData : struct
    {
        public List<TCategorie> categories { get; set; }
        public Dictionary<String, List<TData>> series { get; set; }

        public HighchartsRender()
        {
            categories = new List<TCategorie>();
            series = new Dictionary<string, List<TData>>();
        }
    }
}