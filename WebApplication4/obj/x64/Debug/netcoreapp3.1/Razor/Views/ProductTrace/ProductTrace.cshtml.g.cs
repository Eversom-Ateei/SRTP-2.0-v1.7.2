#pragma checksum "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a9dafcab76d89baf13d78d54e671d49c01291e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductTrace_ProductTrace), @"mvc.1.0.view", @"/Views/ProductTrace/ProductTrace.cshtml")]
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
#line 1 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9dafcab76d89baf13d78d54e671d49c01291e2", @"/Views/ProductTrace/ProductTrace.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductTrace_ProductTrace : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
  
    ViewBag.Title = "Rastreabilidade";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
 try
{
    if (ViewBag.userSession == "false")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n\r\n          \r\n        </script>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a9dafcab76d89baf13d78d54e671d49c01291e24353", async() => {
                WriteLiteral(@"

            <h6 style=""font-family:Calibri;text-align:center;"">Registro de Tempo</h6>
            <div class=""container"">
                <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."" />
                <br />
                <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                    <thead>
                        <tr>
                            <th scope=""col"">Posição</th>
                            <th scope=""col"">Item</th>
                            <th scope=""col"">Nome</th>
                            <th scope=""col"">Quantidade</th>
                        </tr>
                    </thead>
                    <tbody id=""data"">
");
#nullable restore
#line 35 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                         while (ViewBag.data.Read())
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td><label class=\"form-control\"> ");
#nullable restore
#line 38 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                            Write(ViewBag.data["PosId"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td>\r\n                                    <select class=\"form-control\">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a9dafcab76d89baf13d78d54e671d49c01291e26298", async() => {
#nullable restore
#line 41 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                    Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 43 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                         foreach (ItemMasterData m in ViewBag.optionItems)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a9dafcab76d89baf13d78d54e671d49c01291e28278", async() => {
#nullable restore
#line 45 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                               Write(m.ItemCode);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 46 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"


                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </select>\r\n\r\n\r\n                                </td>\r\n                                <td><label class=\"form-control\">");
#nullable restore
#line 54 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                           Write(ViewBag.data["ItemName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td><label class=\"form-control\">");
#nullable restore
#line 55 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                           Write(ViewBag.data["Quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td><div style=\"margin-top:10px \"></div><div style=\"background-image: url(\'../img/IconDecider.png\');\" class=\"icon20x20\" style=\"color: black ; font-size: 15px; margin-top: 40%; \"");
                BeginWriteAttribute("onclick", " onclick=\"", 2292, "\"", 2423, 9);
                WriteAttributeValue("", 2302, "ProductTraceSerialBatch(", 2302, 24, true);
#nullable restore
#line 56 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2326, ViewBag.data["Id"], 2326, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2345, ",", 2345, 1, true);
#nullable restore
#line 56 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2346, ViewBag.data["DocEntry"], 2346, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2371, ",\'", 2371, 2, true);
#nullable restore
#line 56 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2373, ViewBag.data["ItemCode"], 2373, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2398, "\',", 2398, 2, true);
#nullable restore
#line 56 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2400, ViewBag.data["PosId"], 2400, 22, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2422, ")", 2422, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div></td>\r\n                            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                    </tbody>\r\n                </table>\r\n                <div style=\"background-image: url(\'../img/IconAdd.png\');\" class=\"icon40x40\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px;\"></div>\r\n            </div>\r\n        ");
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
            WriteLiteral("\r\n");
#nullable restore
#line 66 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
    }
}
catch (Exception e)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 71 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
   Write(e.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 72 "C:\Users\gabriel.castro\Desktop\SRTP 2.0 v1.2- editando\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"


}

#line default
#line hidden
#nullable disable
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