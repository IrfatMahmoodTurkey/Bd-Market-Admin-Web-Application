#pragma checksum "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93ec02eb3d5358c07b45d9b9ef089f04fecc57e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_StockIn), @"mvc.1.0.view", @"/Views/Product/StockIn.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/StockIn.cshtml", typeof(AspNetCore.Views_Product_StockIn))]
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
#line 1 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\_ViewImports.cshtml"
using BdMarketWebApp;

#line default
#line hidden
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\_ViewImports.cshtml"
using BdMarketWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93ec02eb3d5358c07b45d9b9ef089f04fecc57e1", @"/Views/Product/StockIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e784d0848b3ddf482a3054ad19237c933aefb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_StockIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StockIn", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
  
    ViewData["Title"] = "BD Market - Stock in";
    ViewData["ItemActive"] = "active";

#line default
#line hidden
            BeginContext(98, 114, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 212, "\"", 251, 1);
#line 10 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
WriteAttributeValue("", 219, Url.Action("ViewAll","Product"), 219, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(252, 263, true);
            WriteLiteral(@">Product</a>
        </li>
        <li class=""breadcrumb-item active"">Stock In</li>
    </ol>

    <div class=""row"">
        <div class=""col-md-3""></div>
        <div class=""col-md-6"">
            <h2>Stock In Item</h2>
            <hr />

            ");
            EndContext();
            BeginContext(515, 1339, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a72d65e366134564b6ea30e073075d6a", async() => {
                BeginContext(566, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(585, 29, false);
#line 22 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
           Write(Html.Raw(ViewData["Message"]));

#line default
#line hidden
                EndContext();
                BeginContext(614, 57, true);
                WriteLiteral("\r\n\r\n                <input type=\"hidden\" name=\"ProductId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 671, "\"", 701, 1);
#line 24 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
WriteAttributeValue("", 679, ViewData["ProductId"], 679, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(702, 163, true);
                WriteLiteral("/>\r\n\r\n                <div class=\"form-group\">\r\n                    <label>Product Title</label>\r\n                    <br/>\r\n                    <input type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 865, "\"", 898, 1);
#line 29 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
WriteAttributeValue("", 873, ViewData["ProductTitle"], 873, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(899, 287, true);
                WriteLiteral(@" placeholder=""Product Title"" class=""form-control"" readonly=""readonly""/>
                    <br/>
                </div>

                <div class=""form-group"">
                    <label>Previous Quantity</label>
                    <br/>
                    <input type=""text""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1186, "\"", 1219, 1);
#line 36 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Product\StockIn.cshtml"
WriteAttributeValue("", 1194, ViewData["PrevQuantity"], 1194, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1220, 627, true);
                WriteLiteral(@" placeholder=""Previous Quantity"" class=""form-control"" readonly=""readonly""/>
                    <br/>
                </div>


                <div class=""form-group"">
                    <label>Quantity</label>
                    <br/>
                    <input type=""number"" name=""quantity"" value=""1"" placeholder=""Enter Quantity"" class=""form-control"" min=""1"" max=""10000000""/>
                    <br/>
                </div>


                <div class=""form-group"">
                    <input type=""submit"" class=""btn btn-default"" value=""Stock In"" style=""width: 100%""/>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1854, 76, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-3\"></div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
