using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ExampleSignalR.Hubs
{
    public class HighchartsConnection : PersistentConnection
    {
        protected override Task OnConnectedAsync(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Welcome!");
        }

        protected override Task OnReceivedAsync(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }
    }
}