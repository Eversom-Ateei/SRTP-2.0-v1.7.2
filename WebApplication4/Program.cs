using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;



namespace WebApplication4

{

    
    public class Program
    {



        
        //Publicar o projeto no iss
        // https://alexalvess.medium.com/publicando-aplica%C3%A7%C3%A3o-net-core-no-iss-f4079c2f312

        public static void Main(string[] args)
        {      
            
            CreateHostBuilder(args).Build().Run();

          

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                  
                  
                    webBuilder.UseStartup<Startup>();
                    
                });




    }
}
