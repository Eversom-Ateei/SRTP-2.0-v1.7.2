#pragma checksum "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51b57436ecc5703eaff95e18f3b6c6e5367bd406dd4a53112112271456413510"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Index), @"mvc.1.0.view", @"/Views/Shared/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"51b57436ecc5703eaff95e18f3b6c6e5367bd406dd4a53112112271456413510", @"/Views/Shared/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b082b762a216bfff973b964f5a8b688262dc980e97b9ec47c5e410a5f2c61a8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
  
    ViewBag.Title = "Home Page";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"container mt-5 mb-3\">\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
             while (ViewBag.TopOrdensList.Read())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-4"">
                    <div class=""card p-3 mb-2"">
                        <div class=""d-flex justify-content-between"">
                            <div class=""d-flex flex-row align-items-center"">
                                <div class=""icon""> <i class=""bx bxl-mailchimp""></i> </div>
                                <div class=""ms-2 c-details"">
                                    <h6 class=""mb-0"">");
#nullable restore
#line 17 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                Write(ViewBag.TopOrdensList["ItemName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6> <span>OP-");
#nullable restore
#line 17 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                                                                 Write(ViewBag.TopOrdensList["ORDEM"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"badge\"> <span>");
#nullable restore
#line 20 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                 Write(ViewBag.TopOrdensList["ItemCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </div>\r\n                        </div>\r\n                        <div class=\"mt-5\">\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                              

                                decimal s = ((@Math.Round(@ViewBag.TopOrdensList["CmpltQty"], 2) * 100) / @Math.Round(@ViewBag.TopOrdensList["PlannedQty"], 2));

                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <h3 class=\"heading\">");
#nullable restore
#line 30 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                           Write(ViewBag.TopOrdensList["CardCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>");
#nullable restore
#line 30 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                                                 Write(ViewBag.TopOrdensList["CardName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n                            <div class=\"mt-5\">\r\n                                <div class=\"progress\">\r\n                                    <div class=\"progress-bar\" role=\"progressbar\"");
            BeginWriteAttribute("style", " style=\"", 1513, "\"", 1559, 3);
            WriteAttributeValue("", 1521, "width:", 1521, 6, true);
#nullable restore
#line 33 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
WriteAttributeValue(" ", 1527, s.ToString().Replace(",","."), 1528, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1558, "%", 1558, 1, true);
            EndWriteAttribute();
            WriteLiteral(" aria-valuenow=\"60\"");
            BeginWriteAttribute("aria-valuemin", " aria-valuemin=\"", 1579, "\"", 1644, 1);
#nullable restore
#line 33 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
WriteAttributeValue("", 1595, Math.Round(@ViewBag.TopOrdensList["CmpltQty"],2), 1595, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("aria-valuemax", " aria-valuemax=\"", 1645, "\"", 1712, 1);
#nullable restore
#line 33 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
WriteAttributeValue("", 1661, Math.Round(@ViewBag.TopOrdensList["PlannedQty"],2), 1661, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                                </div>\r\n                                <div class=\"mt-3\"> <span class=\"text1\">");
#nullable restore
#line 35 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                                  Write(Math.Round(@ViewBag.TopOrdensList["CmpltQty"],2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Concluídos <span class=\"text2\">de ");
#nullable restore
#line 35 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"
                                                                                                                                                      Write(Math.Round(@ViewBag.TopOrdensList["PlannedQty"],2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Unidades</span></span> </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 40 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\Shared\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>");
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
