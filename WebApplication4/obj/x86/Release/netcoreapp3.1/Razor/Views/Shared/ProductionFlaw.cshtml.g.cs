#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1161e96bddcf5ef0927599b77f110362d19ec2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ProductionFlaw), @"mvc.1.0.view", @"/Views/Shared/ProductionFlaw.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1161e96bddcf5ef0927599b77f110362d19ec2a", @"/Views/Shared/ProductionFlaw.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ProductionFlaw : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
  
    ViewBag.Title = "Inspeção de Materiais";
    Layout = "~/Views/Shared/Home.cshtml";
    int line = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h6 style=""font-family:Calibri;text-align:center;font-size-adjust:inherit;"" class=""form-control"">Falhas de Produção</h6>
    <div class=""container"">
        <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">

        <h5 style=""float:left;"">OP: ");
#nullable restore
#line 19 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                               Write(ViewBag.docEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Serial: ");
#nullable restore
#line 19 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                                                         Write(ViewBag.serial);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <br>\r\n\r\n        <button");
            BeginWriteAttribute("onclick", " onclick=\"", 639, "\"", 649, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""save"" type=""button"" class=""btn btn-secondary btn-sm"" style=""float: left; margin-left: 94% ; margin-bottom : 1%"" ; disabled>Salvar</button>
        <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Item</th>
                    <th>Defeito</th>
                    <th>Responsável</th>
                    <th>Comentário</th>
                    <th>Bloqueado por</th>
                </tr>
            </thead>
            <tbody id=""data"">
");
#nullable restore
#line 36 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                 while (ViewBag.data.Read())
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(line);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(ViewBag.data["Flaw"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 42 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"
                       Write(ViewBag.data["ItemCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"

                    line++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n         <div style=\"background-image: url(\'../img/IconAdd.png\');\" class=\"icon40x40\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px;\"></div>\r\n    </div>\r\n");
#nullable restore
#line 56 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\ProductionFlaw.cshtml"

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
