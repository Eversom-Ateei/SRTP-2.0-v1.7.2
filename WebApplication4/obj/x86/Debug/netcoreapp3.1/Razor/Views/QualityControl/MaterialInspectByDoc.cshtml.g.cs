#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b53d7e19f148857ad49e306cf4e267d919041d00"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b53d7e19f148857ad49e306cf4e267d919041d00", @"/Views/QualityControl/MaterialInspectByDoc.cshtml")]
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
#line 2 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
  
    ViewBag.Title = "Inspeção de Materiais";
    Layout = "~/Views/Shared/Home.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
 try
{
    if (ViewBag.userSession == "false")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 11 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <script>

            $(document).ready(function () {
                /* ao pressionar uma tecla em um campo que seja de class=""pula"" */
                $('#filter').click(function (e) {
                    if ($('#filterItems').prop(""hidden"") == true)
                    {
                        $(""#filterItems"").prop(""hidden"", false);
                    } else {
                        $(""#filterItems"").prop(""hidden"", true);
                    }
                });
                $('#CheckStatus').click(function (e) {

                    $(""#title"").prop(""hidden"", true);
                    $(""#loading"").click();

                    ///$(""#loading"").prop(""hidden"", false);
                   if ($('#CheckStatus').prop(""checked"") == true) {
                        window.location.href = ""../QualityControl/MaterialInspectByDoc?status=1"";
                        
                    } else {

                        window.location.href = ""../QualityControl/MaterialInspectBy");
            WriteLiteral("Doc?status=0\";\r\n\r\n                    }\r\n                });\r\n            });\r\n\r\n        </script>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53d7e19f148857ad49e306cf4e267d919041d005493", async() => {
                WriteLiteral(@"

            <h6 style=""font-family:Calibri;text-align:center;"" class=""form-control"" id=""title"">Inspeção de Materiais</h6>


            <h4 id=""loading"" style=""color: black ; font-size: 15px; "" data-toggle=""modal"" data-target=""#ModalTimeReg"" hidden>load</h4>

            <div class=""modal fade bd-example-modal-lg"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"" id=""ModalTimeReg"">
                <div class=""modal-dialog modal-lg"">                

                     <div  style=""margin-left:50%; margin-top:50%;"">   <div id=""loadingx"" class=""lds-roller "" ><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div> </div>
                
                </div>
            </div>


            <h6 id=""loading1"" style=""font-family:Calibri;text-align:center;"" class=""form-control loading"" hidden></h6>

            <div class=""container"">
                <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pe");
                WriteLiteral(@"squisar..."" />
                <b>
                    <label>Filtros:</label>
                </b>
                <div style=""display: inline-block; "">
                    <div id=""filter"" style=""background-image: url('../img/IconDropDown.png');"" class=""icon15x10"" ></div>
                </div>
                <div id=""filterItems"" hidden>

");
#nullable restore
#line 72 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                     if (ViewBag.status == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input class=\"form-check-inline\" id=\"CheckStatus\" type=\"checkbox\" />\r\n");
#nullable restore
#line 75 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input class=\"form-check-inline\" id=\"CheckStatus\" type=\"checkbox\" checked />\r\n");
#nullable restore
#line 79 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    <b>  <label class=""form-check-inline"">Documentos Concluídos</label></b>
                </div>

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
#line 97 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                         foreach (ReceiptOfGoods receiptOfGood in ViewBag.data)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr");
                BeginWriteAttribute("ondblclick", " ondblclick=\"", 4033, "\"", 4086, 3);
                WriteAttributeValue("", 4046, "MaterialInspect(", 4046, 16, true);
#nullable restore
#line 99 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
WriteAttributeValue("", 4062, receiptOfGood.DocEntry, 4062, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4085, ")", 4085, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <td>");
#nullable restore
#line 100 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.DocEntry);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 101 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.Invoice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 102 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.CardName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 103 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.DocDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 104 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
                               Write(receiptOfGood.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 106 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
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
#line 112 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
    }


}
catch (Exception e)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 119 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"
   Write(e.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 120 "C:\Users\Eversom.Fragozo\Desktop\Projetos\SRTP\Eversom\SRTP 2.0 v1.9\WebApplication4\Views\QualityControl\MaterialInspectByDoc.cshtml"

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
