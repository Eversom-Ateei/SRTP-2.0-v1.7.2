#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\Shared\Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7aeb28f3686ffb6446f1b54b824305e80d7f58a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Chat), @"mvc.1.0.view", @"/Views/Shared/Chat.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7aeb28f3686ffb6446f1b54b824305e80d7f58a9", @"/Views/Shared/Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\Shared\Chat.cshtml"
  
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<html>
<script>
    $(document).ready(function () {

        function getHostSite() {
            //identificar inicio do path
            //usada nas chamadas Ajax / jSON
            var Path = location.host;
            var VirtualDirectory;
            if (Path.indexOf(""localhost"") >= 0 && Path.indexOf("":"") >= 0) {
                VirtualDirectory = """";
            }
            else {
                var pathname = window.location.pathname;
                var VirtualDir = pathname.split('/');
                VirtualDirectory = VirtualDir[1];
                VirtualDirectory = '/' + VirtualDirectory;
            }
            return location.protocol + ""//"" + location.host + VirtualDirectory + ""/""
        }

        var connection = new signalR.HubConnectionBuilder().withUrl(getHostSite() + ""chat"").build();

        $(""#send"").disabled = true;

        var to = $(""#to"").val();

        connection.on(""ReceiveMessage"" + to, function (user, message) {

         /*   var audio = n");
            WriteLiteral(@"ew Audio(getHostSite() + 'sons/AlarmNotify.mp3');
            audio.addEventListener('canplaythrough', function () {
                audio.play();

            });*/
            var msg = message.replace(/&/g, ""&amp;"").replace(/</g, ""&lt;"").replace(/>/g, ""&gt;"");

            var li = $(""#messagesList"").val() + (user + "": "" + msg);

            $(""#messagesList"").val(li);

        });

        connection.start().then(function () {

            $(""#send"").disabled = false;

        }).catch(function (err) {

            return console.error(err.toString());

        });

        $(""#send"").on(""click"", function (event) {

            var user = $(""#from"").val();
            var message = $(""#mensagem"").val();
            connection.invoke(""SendMessage"", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            event.preventDefault();
        });
    });
</script>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aeb28f3686ffb6446f1b54b824305e80d7f58a95519", async() => {
                WriteLiteral(@"

    <div class=""container col-6"">
        <!--<ul class=""list-group"" id=""messagesList""></ul>-->
        <input type=""text"" class=""list-group"" id=""messagesList"" />
    </div>
    <div class=""container col-6"">
        <div class=""form-group"">
            <label for=""usuario"">Usuário</label>
            <input type=""hidden"" id=""to"" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 2419, "\"", 2438, 1);
#nullable restore
#line 79 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\Shared\Chat.cshtml"
WriteAttributeValue("", 2427, ViewBag.to, 2427, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <input type=\"hidden\" id=\"from\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 2507, "\"", 2528, 1);
#nullable restore
#line 80 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\Shared\Chat.cshtml"
WriteAttributeValue("", 2515, ViewBag.from, 2515, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
        </div>
        <div class=""form-group"">
            <label for=""mensagem"">Mensagem</label>
            <textarea class=""form-control"" id=""mensagem"" rows=""2""></textarea>
        </div>
        <input type=""button"" class=""btn btn-primary"" id=""send"" value=""Enviar"" />
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <hr />
        </div>
    </div>


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591