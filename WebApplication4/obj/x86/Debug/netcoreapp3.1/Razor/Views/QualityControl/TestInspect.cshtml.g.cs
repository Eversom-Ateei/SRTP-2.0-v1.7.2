#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e2b82b699bec2aff6e614ae3e7d7ed1c66cf596"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QualityControl_TestInspect), @"mvc.1.0.view", @"/Views/QualityControl/TestInspect.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e2b82b699bec2aff6e614ae3e7d7ed1c66cf596", @"/Views/QualityControl/TestInspect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_QualityControl_TestInspect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
  
    ViewBag.Title = "Teste de Produtos";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n\r\n    </script>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e2b82b699bec2aff6e614ae3e7d7ed1c66cf5964290", async() => {
                WriteLiteral(@"
        <h6 style=""font-family:Calibri;text-align:center;"">Teste de Produtos</h6>
        <div class=""container"">
            <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">
            <br>
            <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Ordem</th>
                        <th>Cód. do Item</th>
                        <th>Descrição</th>
                        <th>Quantidade</th>
                        <th>Data da Postagem</th>
                    </tr>
                </thead>
                <tbody id=""data"">

");
#nullable restore
#line 36 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                     while (ViewBag.data.Read())
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1150, "\"", 1198, 3);
                WriteAttributeValue("", 1163, "alert(", 1163, 6, true);
#nullable restore
#line 38 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
WriteAttributeValue("", 1169, ViewBag.data["ID_RG_TEMPO"], 1169, 28, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1197, ")", 1197, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                            <td>");
#nullable restore
#line 40 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["ID_RG_TEMPO"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["ORDEM"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 43 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["ItemName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 44 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["Quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 45 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                           Write(ViewBag.data["TERMINO"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
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
#line 54 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\TestInspect.cshtml"
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
