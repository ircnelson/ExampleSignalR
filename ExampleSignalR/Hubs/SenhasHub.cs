using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace ExampleSignalR.Hubs
{
    public class SenhasHub : Hub
    {
        public static long Senha = 0;

        public void ProximaSenha()
        {
            Clients.All.senhaAtual(Senha += 1);
        }

        public void ObterSenhaAtual()
        {
            Clients.Caller.senhaAtual(Senha);
        }
    }
}