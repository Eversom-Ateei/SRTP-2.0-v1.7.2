#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\Shared\Routers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52d3c9e8ba0d6004084536720bf77a2da5c87b38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Routers), @"mvc.1.0.view", @"/Views/Shared/Routers.cshtml")]
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
#line 1 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52d3c9e8ba0d6004084536720bf77a2da5c87b38", @"/Views/Shared/Routers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Routers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("RoutersView()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\Shared\Routers.cshtml"
  
    ViewBag.Title = "Rotas";
    Layout = "~/Views/Shared/Home.cshtml";
    int c = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\Shared\Routers.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\Shared\Routers.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n     \r\n    </script>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52d3c9e8ba0d6004084536720bf77a2da5c87b384625", async() => {
                WriteLiteral(@"
               



        <h6 style=""font-family:Calibri;text-align:center;"" class=""form-control"">Rotas de Produção</h6>
        <div class=""container"">
            <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">
            <br>
            <table class=""table table-sm table-hover tablesorter"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Ordem</th>
                        <th scope=""col"">Código</th>
                        <th scope=""col"">Recurso</th>
                        <th scope=""col"">Apontados</th>
                        <th scope=""col"">Planejado</th>
                    </tr>
                </thead>
                <tbody id=""data"">
                </tbody>
            </table>

            <h4 id=""linkTimeReg"" style=""color: black ; font-size: 15px; "" data-toggle=""modal"" data-target=""");
                WriteLiteral(@"#ModalTimeReg"" hidden>time</h4>


            <div class=""modal fade bd-example-modal-lg"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"" id=""ModalTimeReg"">
                <div class=""modal-dialog modal-lg"">
                  
                    <div class=""modal-content"">

                        <table id=""timeReg"" class=""table table-bordered tablesorter"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                            <!--Load by jquery-->
                        </table>
                    </div>
                </div>
            </div>

            <div class=""modal fade bg-dark"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"" id=""ModalSerial"">
                <div class=""modal-dialog modal-lg"">
                    <div class=""modal-content"">
                        <table id=""serials"" class=""table table-bordered"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
     ");
                WriteLiteral("                       <!--Load by jquery-->\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.7.2 (Postada)\WebApplication4\Views\Shared\Routers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
