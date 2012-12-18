using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace ExampleSignalR.SignalR
{
    public class HighchartsHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}