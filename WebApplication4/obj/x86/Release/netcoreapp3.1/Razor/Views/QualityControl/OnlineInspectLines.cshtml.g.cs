#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fcd8a4d95df3b866cec45dcb83e44f6cd955971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QualityControl_OnlineInspectLines), @"mvc.1.0.view", @"/Views/QualityControl/OnlineInspectLines.cshtml")]
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
#line 1 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fcd8a4d95df3b866cec45dcb83e44f6cd955971", @"/Views/QualityControl/OnlineInspectLines.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_QualityControl_OnlineInspectLines : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
  
    ViewBag.Title = "Inspeção de Rotas";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n    \r\n    </script>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fcd8a4d95df3b866cec45dcb83e44f6cd9559714266", async() => {
                WriteLiteral(@"
        <h6 style=""font-family:Calibri;text-align:center;font-size-adjust:inherit;"" class=""form-control"" >Inspeção Rotas</h6>
        <div class=""container"">
            <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">
            <br>
            <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                <thead>
                    <tr>
                        <th>Parâmetro</th>
                        <th>Descrição</th>
                        <th>Observação</th>
                        <th>Status</th>
                        <th>comentário</th>
                        <th>Bloqueado por</th>
                    </tr>
                </thead>
                <tbody id=""data"">

");
#nullable restore
#line 36 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                     while (ViewBag.data.Read())
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1202, "\"", 1241, 3);
                WriteAttributeValue("", 1215, "alert(", 1215, 6, true);
#nullable restore
#line 38 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
WriteAttributeValue("", 1221, ViewBag.data["ID"], 1221, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1240, ")", 1240, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                            <td>");
#nullable restore
#line 40 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["COD_PARAMETRO"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["PARAMETRO"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["VALOR"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 43 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["APROVADO"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 44 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["OBS"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 45 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                           Write(ViewBag.data["MOTIVO_STATUS"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
#nullable restore
#line 49 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
               Write(ViewBag.data.Close());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    ");
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
#line 55 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\OnlineInspectLines.cshtml"
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
