using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Util
{

        public class ChatHub : Hub
        {
            public async Task SendMessage(string usuario, string mensagem)
            {
                await Clients.All.SendAsync("ReceiveMessage"+usuario, usuario, mensagem);     

          
            }
        }

    
}
