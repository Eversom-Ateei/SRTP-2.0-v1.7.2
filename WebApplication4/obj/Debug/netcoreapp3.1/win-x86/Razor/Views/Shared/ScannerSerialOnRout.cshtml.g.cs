#pragma checksum "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe58273ceed807be9f9c54a008396c520657af91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ScannerSerialOnRout), @"mvc.1.0.view", @"/Views/Shared/ScannerSerialOnRout.cshtml")]
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
#line 1 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe58273ceed807be9f9c54a008396c520657af91", @"/Views/Shared/ScannerSerialOnRout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_ScannerSerialOnRout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
  
    ViewBag.Title = "Scanner Serial";
    Layout = "~/Views/Shared/Home.cshtml";
    int line = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Usuário Desconectado!</h2>\r\n");
#nullable restore
#line 12 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
}
else
{



#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe58273ceed807be9f9c54a008396c520657af914154", async() => {
                WriteLiteral(@"
        <h6 style=""font-family:Calibri;text-align:center;"">N° de Séries</h6>
        <div class=""container"">
            <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">
            <br>

            <input class=""form-control"" id=""serial"" type=""text"" placeholder=""Adicionar Nº de Série ou Lote...""");
                BeginWriteAttribute("onblur", " onblur=\"", 557, "\"", 694, 13);
                WriteAttributeValue("", 566, "AddSerialRout(", 566, 14, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 580, ViewBag.docEntry, 580, 17, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 597, ",", 597, 1, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 598, ViewBag.sequence, 598, 17, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 615, ",", 615, 1, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 616, ViewBag.posId, 616, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 630, ",", 630, 1, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 631, ViewBag.idRgSetup, 631, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 649, ",", 649, 1, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 650, ViewBag.timeRegisterId, 650, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 673, ",\'", 673, 2, true);
#nullable restore
#line 23 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 675, ViewBag.resource, 675, 17, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 692, "\')", 692, 2, true);
                EndWriteAttribute();
                WriteLiteral(@">
            
            <br>

            <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Serial/Lote</th>
                        <th scope=""col"">Quantidade</th>

                    </tr>
                </thead>
                <tbody id=""data"">
                    
");
#nullable restore
#line 38 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
                     while (ViewBag.data.Read())
                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1277, "\"", 1290, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <td>");
#nullable restore
#line 42 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
                       Write(line);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
                       Write(ViewBag.data["N_serie"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>0</td>\r\n                        <td> <div style=\"background-image: url(\'../img/IconTrace.png\');\" class=\"icon20x20\" style=\"color: black ; font-size: 15px; \"");
                BeginWriteAttribute("onclick", " onclick=\"", 1576, "\"", 1650, 5);
                WriteAttributeValue("", 1586, "ProductTrace(\'", 1586, 14, true);
#nullable restore
#line 45 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 1600, ViewBag.data["N_serie"], 1600, 24, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1624, "\',", 1624, 2, true);
#nullable restore
#line 45 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue(" ", 1626, ViewBag.data["PosId"], 1627, 22, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1649, ")", 1649, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div></td>\r\n\r\n                        <td><div style=\"background-image: url(\'../img/delete.png\');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" data-toggle=\"modal\" data-target=\"#id_");
#nullable restore
#line 47 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
                                                                                                                                                                                                          Write(ViewBag.data["ID"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1894, "\"", 1946, 3);
                WriteAttributeValue("", 1907, "DeleteSerialRout(\'", 1907, 18, true);
#nullable restore
#line 47 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
WriteAttributeValue("", 1925, ViewBag.data["ID"], 1925, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1944, "\')", 1944, 2, true);
                EndWriteAttribute();
                WriteLiteral("></div>\r\n\r\n                        \r\n                    </tr>\r\n");
#nullable restore
#line 51 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"
                    line++;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    ");
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
#line 58 "C:\Users\gabriel.castro\Documents\SRTP 2.0 v1.2- editando\WebApplication4\Views\Shared\ScannerSerialOnRout.cshtml"


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
