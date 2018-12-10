using System;
using System.Net;
using System.Reflection;
using System.Net.Http;
using System.Collections.Generic;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace GameStore.Test.Controllers
{
  public  class BaseController : IDisposable
    {
        public string BASE_URL { get; private set; }
        public Uri BASE_URI { get; private set; }

        public IWebHost _webhost { get; private set; }

        public BaseController(int NoInit)
        {
            _webhost = null;
        }

        public BaseController()
        {
            Init(49911);
        }

        protected void Init(int port)
        {
            BASE_URL = $"http://gamestorecrosplatform.azurewebsites.net";
            BASE_URI = new Uri(BASE_URL);

            //var assemblyName = typeof(GameStore.Startup).GetTypeInfo().Assembly.FullName;

            //_webhost = WebHost.CreateDefaultBuilder(null)
            //                  .UseStartup(assemblyName)
            //                  .UseEnvironment("Development")
            //                  .UseKestrel()
            //                  .UseUrls(BASE_URL)
            //                  .Build();

            //_webhost.Start();
        }

        public void Dispose()
        {
            _webhost?.Dispose();
        }
    }
}
