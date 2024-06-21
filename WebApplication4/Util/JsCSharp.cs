using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Util
{
    public class JsCSharp
    {

        private readonly IJSRuntime js;

        public JsCSharp(IJSRuntime js)
        {
            this.js = js;
        }
        public async ValueTask TickerChanged()
        {
            await js.InvokeVoidAsync("alert('1')");
        }
        public void Dispose()
        {
        }



    }
}
