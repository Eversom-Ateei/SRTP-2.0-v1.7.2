#pragma checksum "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32c93c0d591bec009f5a23f692221fd8b40851e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductTrace_ProductTraceSerialBatch), @"mvc.1.0.view", @"/Views/ProductTrace/ProductTraceSerialBatch.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32c93c0d591bec009f5a23f692221fd8b40851e4", @"/Views/ProductTrace/ProductTraceSerialBatch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fff4eb847734ec2c3f91807e9b1a08bbda85e45", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductTrace_ProductTraceSerialBatch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
  
    ViewBag.Title = "Selecão de Serial e Lotes";
    Layout = "~/Views/Shared/Home.cshtml";
    int count = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
 try
{
    if (ViewBag.userSession == "false")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"background-image: url(\'../img/IconDisconected.png\');\" class=\"icon200x200\"></div>\r\n");
#nullable restore
#line 12 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n          \r\n        </script>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32c93c0d591bec009f5a23f692221fd8b40851e44751", async() => {
                WriteLiteral(@"

            <h6 style=""font-family:Calibri;text-align:center;"">Registro de Tempo</h6>
            <div class=""container"">
                <input class=""form-control"" id=""filterKey"" type=""text"" placeholder=""Pesquisar..."" />
                <br />
                <div>
                    <h4>");
#nullable restore
#line 26 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                   Write(ViewBag.itemCode);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 26 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                       Write(ViewBag.itemName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>

                    <button onclick=""SaveTableProductTraceSerialBatch()"" id=""save"" type=""button"" class=""btn btn-secondary btn-sm"" style=""float: left; margin-left: 94% ; margin-bottom : 1%"" ; disabled>Salvar</button>
                
                </div>
                <table class=""table table-sm table-hover"" style=""background-color:rgb(255, 255, 255); font-family:Calibri"">
                    <thead>
                        <tr>
                            <th scope=""col"">Lote</th>
                            <th scope=""col"">Quantidade</th>
                            <th scope=""col"">UM</th>
                            <th scope=""col"">Itens Por UM</th>
                            <th scope=""col"">--</th>
                        </tr>
                    </thead>

                    <tbody id=""data"">
                        <input type=""hidden"" id=""pos""");
                BeginWriteAttribute("value", " value=\"", 1601, "\"", 1623, 1);
#nullable restore
#line 43 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 1609, ViewBag.posId, 1609, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" id=\"user\"");
                BeginWriteAttribute("value", " value=\"", 1683, "\"", 1711, 1);
#nullable restore
#line 44 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 1691, ViewBag.userSession, 1691, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" id=\"baseQty\"");
                BeginWriteAttribute("value", " value=\"", 1774, "\"", 1798, 1);
#nullable restore
#line 45 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 1782, ViewBag.baseQty, 1782, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 1848, "\"", 1879, 2);
                WriteAttributeValue("", 1853, "prodTraceSerBatchId_", 1853, 20, true);
#nullable restore
#line 46 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 1873, count, 1873, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" value=\"0\" />\r\n                        <tr>\r\n                            <td>\r\n                                <select class=\"form-control\" id=\"BatchNum_0\" onchange=\"StatusButton(\'save\', \'Salvar\')\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32c93c0d591bec009f5a23f692221fd8b40851e49032", async() => {
                    WriteLiteral("...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
                WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                     foreach (SerialBatchNum stringbatch in @ViewBag.optionsbatch)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32c93c0d591bec009f5a23f692221fd8b40851e410991", async() => {
#nullable restore
#line 53 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                         Write(stringbatch.BatchNum);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 53 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                                                 Write(stringbatch.Quantity);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
#nullable restore
#line 53 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                                                                       Write(stringbatch.UomName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                           WriteLiteral(stringbatch.BatchNum);

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
#line 54 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </select>
                            </td>

                            <td><input type=""number"" id=""Quantity_0"" class=""form-control"" onchange=""StatusButton('save', 'Salvar')"" onkeyup=""StatusButton('save', 'Salvar')"" /></td>
                            <td><input type=""text"" id=""UoM_0"" class=""form-control"" onchange=""StatusButton('save', 'Salvar')"" onkeyup=""StatusButton('save', 'Salvar')"" /></td>
                            <td><input type=""number"" id=""QtByUnit_0"" class=""form-control"" onchange=""StatusButton('save', 'Salvar')"" onkeyup=""StatusButton('save', 'Salvar')"" /></td>
                            <td><div> </div></td>

                            <td><input type=""hidden"" id=""ProductTraceId""");
                BeginWriteAttribute("value", " value=\"", 3233, "\"", 3264, 1);
#nullable restore
#line 63 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 3241, ViewBag.ProductTraceId, 3241, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n\r\n                            <td><input type=\"hidden\" id=\"ItemCode\"");
                BeginWriteAttribute("value", " value=\"", 3343, "\"", 3368, 1);
#nullable restore
#line 65 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 3351, ViewBag.itemCode, 3351, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                        </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                          count = @count + 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                         while (ViewBag.data.Read())
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <select class=\"form-control\"");
                BeginWriteAttribute("id", " id=\"", 3675, "\"", 3695, 2);
                WriteAttributeValue("", 3680, "BatchNum_", 3680, 9, true);
#nullable restore
#line 72 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 3689, count, 3689, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32c93c0d591bec009f5a23f692221fd8b40851e417040", async() => {
#nullable restore
#line 73 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                    Write(ViewBag.data["BatchNum"]);

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
                WriteLiteral("\r\n");
#nullable restore
#line 74 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                         foreach (SerialBatchNum stringbatch in @ViewBag.optionsbatch)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32c93c0d591bec009f5a23f692221fd8b40851e419049", async() => {
#nullable restore
#line 76 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                             Write(stringbatch.BatchNum);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 76 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                                                     Write(stringbatch.Quantity);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
#nullable restore
#line 76 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                                                                                                           Write(stringbatch.UomName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                               WriteLiteral(stringbatch.BatchNum);

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
#line 77 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </td>\r\n\r\n                                <td><input type=\"text\"");
                BeginWriteAttribute("id", " id=\"", 4283, "\"", 4303, 2);
                WriteAttributeValue("", 4288, "Quantity_", 4288, 9, true);
#nullable restore
#line 81 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 4297, count, 4297, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" onchange=\"StatusButton(\'save\', \'Salvar\')\" onkeyup=\"StatusButton(\'save\', \'Salvar\')\"");
                BeginWriteAttribute("value", " value=\"", 4408, "\"", 4441, 1);
#nullable restore
#line 81 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 4416, ViewBag.data["Quantity"], 4416, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                                <td><input type=\"text\"");
                BeginWriteAttribute("id", " id=\"", 4506, "\"", 4522, 2);
                WriteAttributeValue("", 4511, "UoM0_", 4511, 5, true);
#nullable restore
#line 82 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 4516, count, 4516, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" onchange=\"StatusButton(\'save\', \'Salvar\')\" onkeyup=\"StatusButton(\'save\', \'Salvar\')\" /></td>\r\n                                <td><input type=\"number\"");
                BeginWriteAttribute("id", " id=\"", 4693, "\"", 4714, 2);
                WriteAttributeValue("", 4698, "QtByUnit0_", 4698, 10, true);
#nullable restore
#line 83 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 4708, count, 4708, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" onchange=\"StatusButton(\'save\', \'Salvar\')\" onkeyup=\"StatusButton(\'save\', \'Salvar\')\" /></td>\r\n                                <td><a");
                BeginWriteAttribute("href", " href=\"", 4867, "\"", 4874, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"nav-link\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4892, "\"", 4940, 3);
                WriteAttributeValue("", 4902, "DeleteSerialBatch(", 4902, 18, true);
#nullable restore
#line 84 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 4920, ViewBag.data["ID"], 4920, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4939, ")", 4939, 1, true);
                EndWriteAttribute();
                WriteLiteral(">Excluir</a></td>\r\n\r\n                            </tr>\r\n");
                WriteLiteral("                            <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 5047, "\"", 5078, 2);
                WriteAttributeValue("", 5052, "prodTraceSerBatchId_", 5052, 20, true);
#nullable restore
#line 88 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 5072, count, 5072, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 5079, "\"", 5106, 1);
#nullable restore
#line 88 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 5087, ViewBag.data["ID"], 5087, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 89 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"

                            count++;
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <input type=\"hidden\" id=\"count\"");
                BeginWriteAttribute("value", " value=\"", 5234, "\"", 5248, 1);
#nullable restore
#line 93 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
WriteAttributeValue("", 5242, count, 5242, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        ");
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
#line 99 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
    }
}
catch (Exception e)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 104 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"
   Write(e.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 105 "C:\Users\Eversom.Fragozo\Desktop\SRTP 2.0 v1.7 - Debug\WebApplication4\Views\ProductTrace\ProductTraceSerialBatch.cshtml"


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
