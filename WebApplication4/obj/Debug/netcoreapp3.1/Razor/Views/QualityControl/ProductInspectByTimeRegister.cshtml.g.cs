#pragma checksum "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "fc390393dccd9b1c007c7ef798c992ac89ea80dd0f345ec6f90c47d7978febf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QualityControl_ProductInspectByTimeRegister), @"mvc.1.0.view", @"/Views/QualityControl/ProductInspectByTimeRegister.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"fc390393dccd9b1c007c7ef798c992ac89ea80dd0f345ec6f90c47d7978febf2", @"/Views/QualityControl/ProductInspectByTimeRegister.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b082b762a216bfff973b964f5a8b688262dc980e97b9ec47c5e410a5f2c61a8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_QualityControl_ProductInspectByTimeRegister : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
  
    ViewBag.Title = "ProductInspect";
    Layout = "~/Views/Shared/Home.cshtml";
    int line = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
 if (ViewBag.userSession == "false")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 12 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n      \r\n    </script>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc390393dccd9b1c007c7ef798c992ac89ea80dd0f345ec6f90c47d7978febf24656", async() => {
                WriteLiteral(@"
        <h6 style=""font-family:Calibri;text-align:center;"" class=""form-control"" id=""title"">Inspeção Final</h6>

        <h6 id=""loading"" style=""font-family:Calibri;text-align:center;"" class=""form-control loading"" hidden></h6>







        <div class=""container"">
            <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."">
            <br>
            <div class=""input-group mb-3""><button class=""form-control""");
                BeginWriteAttribute("onclick", " onclick=\"", 777, "\"", 826, 3);
                WriteAttributeValue("", 787, "ApproveAll(", 787, 11, true);
#nullable restore
#line 33 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
WriteAttributeValue("", 798, ViewBag.timeRegisterId, 798, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 821, ",\'Y\')", 821, 5, true);
                EndWriteAttribute();
                WriteLiteral(">Aprovar Todos</button> <button class=\"form-control\"");
                BeginWriteAttribute("onclick", " onclick=\"", 879, "\"", 928, 3);
                WriteAttributeValue("", 889, "ApproveAll(", 889, 11, true);
#nullable restore
#line 33 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
WriteAttributeValue("", 900, ViewBag.timeRegisterId, 900, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 923, ",\'B\')", 923, 5, true);
                EndWriteAttribute();
                WriteLiteral(@">Bloquear Todos</button></div>
            <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>N° de Série/Lote</th>
                        <th>Cód. do Item</th>
                        <th>Descrição</th>
                        <th>Quantidade</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody id=""data"">

");
#nullable restore
#line 47 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                     while (ViewBag.data.Read())
                    {



#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1591, "\"", 1644, 3);
                WriteAttributeValue("", 1604, "ProductInspectLines(", 1604, 20, true);
#nullable restore
#line 51 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
WriteAttributeValue("", 1624, ViewBag.data["ID"], 1624, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1643, ")", 1643, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                           Write(line);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                           Write(ViewBag.data["N_SERIE"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                            <td>");
#nullable restore
#line 55 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                           Write(ViewBag.data["ITEM"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 56 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                           Write(ViewBag.data["ItemName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 57 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                           Write(ViewBag.data["QUANTIDADE"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                <a tabindex=\"0\" data-toggle=\"popover\" data-trigger=\"focus\" title=\"Inspecionado por:\" data-content=\"");
#nullable restore
#line 59 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                                                                                                              Write(ViewBag.data["FirstName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 59 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                                                                                                                                         Write(ViewBag.data["LastName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" às ");
#nullable restore
#line 59 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                                                                                                                                                                      Write(ViewBag.data["DATA"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">\r\n");
#nullable restore
#line 60 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                     if (@ViewBag.data["APROVADO"] == "Y")
                                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div style=\"background-image: url(\'../img/IconCheck.png\');\" class=\"icon20x20\"></div>\r\n");
#nullable restore
#line 64 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                     if (@ViewBag.data["APROVADO"] == "B")
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div style=\"background-image: url(\'../img/IconBlock.png\');\" class=\"icon20x20\"></div>\r\n");
#nullable restore
#line 68 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                     if (@ViewBag.data["APROVADO"] == "N")
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div style=\"background-image: url(\'../img/IconWait.png\'); text-align:center;\" class=\"icon20x20\"></div>\r\n");
#nullable restore
#line 73 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </a>\r\n                            </td>\r\n                          \r\n                        </tr>\r\n");
#nullable restore
#line 78 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                        line++;
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
                      
                        ViewBag.data.Close();
                    

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
#line 88 "C:\Users\Administrador\Documents\Visual Studio 2019\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\QualityControl\ProductInspectByTimeRegister.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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