#pragma checksum "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21f2aa28e20222e684f0208889c8d69c03535d84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QualityControl_MaterialInspectByDoc), @"mvc.1.0.view", @"/Views/QualityControl/MaterialInspectByDoc.cshtml")]
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
#line 1 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21f2aa28e20222e684f0208889c8d69c03535d84", @"/Views/QualityControl/MaterialInspectByDoc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_QualityControl_MaterialInspectByDoc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
  
    ViewBag.Title = "Inspeção de Materiais";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
 try
{
    if (ViewBag.userSession == "false")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n\r\n           \r\n         \r\n        </script>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21f2aa28e20222e684f0208889c8d69c03535d844483", async() => {
                WriteLiteral(@"
            <h6 style=""font-family:Calibri;text-align:center;"" class=""form-control"" >Inspeção de Materiais</h6>
            <div class=""container"">
                <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."" />
                <br />
                <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                    <thead>
                        <tr>
                            <th scope=""col"">Documento</th>
                            <th scope=""col"">Nota fiscal </th>
                            <th scope=""col"">Cliente</th>
                            <th scope=""col"">Data de Postagem</th>
                            <th scope=""col"">Autor</th>
                        </tr>
                    </thead>
                    <tbody id=""data"">

");
#nullable restore
#line 37 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                         foreach (ReceiptOfGoods receiptOfGood in ViewBag.data)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 1368, "\"", 1421, 3);
                WriteAttributeValue("", 1381, "MaterialInspect(", 1381, 16, true);
#nullable restore
#line 39 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
WriteAttributeValue("", 1397, receiptOfGood.DocEntry, 1397, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1420, ")", 1420, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.DocEntry);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.Invoice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.CardName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.DocDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 44 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        ");
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
#line 52 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
    }


}
catch (Exception e)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 59 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
   Write(e.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 60 "C:\Users\gabriel.castro\Documents\Visual Studio 2019\Projects\SRTP 2.0 v1.4- Debug\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
