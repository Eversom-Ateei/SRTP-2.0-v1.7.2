#pragma checksum "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a144871581a9440f49e643aa25ec616392888e162739eb87d06a982b1ff9d8d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductTrace_ProductTrace), @"mvc.1.0.view", @"/Views/ProductTrace/ProductTrace.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a144871581a9440f49e643aa25ec616392888e162739eb87d06a982b1ff9d8d9", @"/Views/ProductTrace/ProductTrace.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b082b762a216bfff973b964f5a8b688262dc980e97b9ec47c5e410a5f2c61a8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ProductTrace_ProductTrace : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
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
#line 2 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
  
    ViewBag.Title = "Rastreabilidade";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
 try
{
    if (ViewBag.userSession == "false")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n             $(document).ready(function () {\r\n  $(\"#code\").keyup(function (event) {\r\n\r\n            if (event.which === 13)\r\n            {\r\n\r\n                LoadDetail(");
#nullable restore
#line 21 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                      Write(ViewBag.docEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'");
#nullable restore
#line 21 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                          Write(ViewBag.serial);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n\r\n            }\r\n        });\r\n\r\n        $(\"#quantity\").keyup(function (event) {\r\n\r\n            if (event.which === 13)\r\n            {\r\n\r\n                ScanTraceWO(");
#nullable restore
#line 31 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                       Write(ViewBag.docEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'");
#nullable restore
#line 31 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                           Write(ViewBag.serial);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n\r\n            }\r\n        });\r\n\r\n    });\r\n\r\n</script>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a144871581a9440f49e643aa25ec616392888e162739eb87d06a982b1ff9d8d96245", async() => {
                WriteLiteral(@"

            <h6 style=""font-family:Calibri;text-align:center;"">Rastreabilidade de Lotes</h6>
            <div class=""container"">
                <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."" />

                <br />
                <div class=""input-group mb-3"">

                    <!-- <button onclick=""AutoTraceBySerial(");
#nullable restore
#line 49 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                       Write(ViewBag.docEntry);

#line default
#line hidden
#nullable disable
                WriteLiteral(",\'");
#nullable restore
#line 49 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                                          Write(ViewBag.serial);

#line default
#line hidden
#nullable disable
                WriteLiteral("\')\">auto</button>-->\r\n\r\n                    <input type=\"hidden\" id=\"serial\"");
                BeginWriteAttribute("value", " value=\"", 1252, "\"", 1275, 1);
#nullable restore
#line 51 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 1260, ViewBag.serial, 1260, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                    <input class=""form-control"" id=""code"" type=""text"" placeholder=""Código"" width=""10px"" />
                    <input class=""form-control"" id=""itemCode"" type=""text"" placeholder=""Cód do Item..."" width=""10px"" />
                    <input class=""form-control"" id=""position"" type=""text"" placeholder=""Posição"" width=""10px"" />
                    <input class=""form-control"" id=""batchNum"" type=""text"" placeholder=""Lote ou série..."" />
                    <input class=""form-control"" id=""quantity"" type=""text"" placeholder=""Quantidade"" width=""10px"" />



                </div>


                <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                    <thead>
                        <tr>
                            <th scope=""col"">#</th>
                            <th scope=""col"">Posição</th>
                            <th scope=""col"">Item</th>
                            <th scope=""col"">Nome</th>
                 ");
                WriteLiteral("           <th scope=\"col\">Quantidade</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody id=\"data\">\r\n");
#nullable restore
#line 74 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                          int count = 0; int n = 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                         while (ViewBag.data.Read())
                        {
                          

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td class=\"font-weight-bold\">");
#nullable restore
#line 80 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                        Write(n);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td><label class=\"form-control\"> ");
#nullable restore
#line 81 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                            Write(ViewBag.data["PosId"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td>\r\n                                    <select class=\"form-control\"");
                BeginWriteAttribute("id", " id=\"", 2917, "\"", 2937, 2);
                WriteAttributeValue("", 2922, "itemCode_", 2922, 9, true);
#nullable restore
#line 83 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2931, count, 2931, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("onchange", " onchange=\"", 2938, "\"", 3007, 5);
                WriteAttributeValue("", 2949, "ChangeItemProdTrace(", 2949, 20, true);
#nullable restore
#line 83 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2969, ViewBag.data["ID"], 2969, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2988, ",\'itemCode_", 2988, 11, true);
#nullable restore
#line 83 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 2999, count, 2999, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3005, "\')", 3005, 2, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a144871581a9440f49e643aa25ec616392888e162739eb87d06a982b1ff9d8d912418", async() => {
#nullable restore
#line 84 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
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
#line 86 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                         foreach (ItemMasterData m in @ViewBag.optionItems)
                                        {
                                            if (@m.PosId == @ViewBag.data["PosId"].ToString())
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a144871581a9440f49e643aa25ec616392888e162739eb87d06a982b1ff9d8d914607", async() => {
#nullable restore
#line 90 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                                       Write(m.ItemCode);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                   WriteLiteral(m.ItemCode);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 91 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </td>\r\n                                <td><label class=\"form-control\">");
#nullable restore
#line 95 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                           Write(ViewBag.data["ItemName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td><label class=\"form-control\">");
#nullable restore
#line 96 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                                                           Write(ViewBag.data["Quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                                <td><div style=\"margin-top:10px \"></div><div style=\"background-image: url(\'../img/IconDecider.png\');\" class=\"icon20x20\" style=\"color: black ; font-size: 15px; margin-top: 40%; \"");
                BeginWriteAttribute("onclick", " onclick=\"", 4077, "\"", 4234, 11);
                WriteAttributeValue("", 4087, "ProductTraceSerialBatch(", 4087, 24, true);
#nullable restore
#line 97 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 4111, ViewBag.data["Id"], 4111, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4130, ",", 4130, 1, true);
#nullable restore
#line 97 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 4131, ViewBag.data["DocEntry"], 4131, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4156, ",\'", 4156, 2, true);
#nullable restore
#line 97 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 4158, ViewBag.data["ItemCode"], 4158, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4183, "\',", 4183, 2, true);
#nullable restore
#line 97 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 4185, ViewBag.data["PosId"], 4185, 22, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4207, ",", 4207, 1, true);
#nullable restore
#line 97 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
WriteAttributeValue("", 4208, ViewBag.data["Quantity"], 4208, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4233, ")", 4233, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div></td>\r\n                            </tr>\r\n");
#nullable restore
#line 99 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
                            count++;
                            n++;
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
#line 109 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
        
    }
}
catch (Exception e)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 115 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"
   Write(e.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 116 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTrace.cshtml"


}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
