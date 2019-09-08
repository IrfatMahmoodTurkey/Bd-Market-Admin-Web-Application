#pragma checksum "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ae0567f8882da9a58bf0955689ae2b0e1e0ff9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Delivery_ViewAll), @"mvc.1.0.view", @"/Views/Delivery/ViewAll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Delivery/ViewAll.cshtml", typeof(AspNetCore.Views_Delivery_ViewAll))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ae0567f8882da9a58bf0955689ae2b0e1e0ff9b", @"/Views/Delivery/ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e784d0848b3ddf482a3054ad19237c933aefb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Delivery_ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
  
    ViewData["Title"] = "BD Market - View Delivery";
    ViewData["DeliveryActive"] = "active";

#line default
#line hidden
            BeginContext(107, 114, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 221, "\"", 261, 1);
#line 10 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
WriteAttributeValue("", 228, Url.Action("ViewAll","Delivery"), 228, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(262, 355, true);
            WriteLiteral(@">Delivery</a>
        </li>
        <li class=""breadcrumb-item active"">View All</li>
    </ol>

    <div class=""row"" style=""padding-top: 10px; padding-bottom: 10px"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <div class=""form-horizontal"">
                <div style=""width: 100%"">
                    <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 617, "\"", 676, 5);
            WriteAttributeValue("", 627, "location.href", 627, 13, true);
            WriteAttributeValue(" ", 640, "=", 641, 2, true);
            WriteAttributeValue(" ", 642, "\'", 643, 2, true);
#line 20 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
WriteAttributeValue("", 644, Url.Action("Add", "Delivery"), 644, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 674, "\';", 674, 2, true);
            EndWriteAttribute();
            BeginContext(677, 1457, true);
            WriteLiteral(@" class=""add_button""><i class=""fas fa-plus-square""></i> Add Delivery</button>
                </div>
            </div>
        </div>
        <div class=""col-md-4""></div>
    </div>
    <br />

    <div class=""card mb-3"">
        <div class=""card-header"">
            <i class=""fas fa-table""></i>
            Delivery Info Table
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>SL</th>
                            <th>Place Name</th>
                            <th>Charge</th>
                            <th>Action Name</th>
                            <th>Action Time</th>
                            <th>Action By</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tfoot>
               ");
            WriteLiteral(@"         <tr>
                            <th>SL</th>
                            <th>Place Name</th>
                            <th>Charge</th>
                            <th>Action Name</th>
                            <th>Action Time</th>
                            <th>Action By</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                    <tbody>
");
            EndContext();
#line 59 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                          
                            int count = 1;

                            foreach (Delivery delivery in ViewBag.Deliveries)
                            {

#line default
#line hidden
            BeginContext(2318, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(2397, 5, false);
#line 65 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(2402, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2450, 18, false);
#line 66 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(delivery.PlaceName);

#line default
#line hidden
            EndContext();
            BeginContext(2468, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2516, 15, false);
#line 67 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(delivery.Charge);

#line default
#line hidden
            EndContext();
            BeginContext(2531, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2579, 19, false);
#line 68 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(delivery.ActionDone);

#line default
#line hidden
            EndContext();
            BeginContext(2598, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2646, 19, false);
#line 69 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(delivery.ActionTime);

#line default
#line hidden
            EndContext();
            BeginContext(2665, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2713, 17, false);
#line 70 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                   Write(delivery.ActionBy);

#line default
#line hidden
            EndContext();
            BeginContext(2730, 49, true);
            WriteLiteral("</td>\r\n                                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2779, "\"", 2838, 1);
#line 71 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
WriteAttributeValue("", 2786, Url.Action("Edit","Delivery", new {id=delivery.Id}), 2786, 52, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2839, 55, true);
            WriteLiteral(">Edit</a></td>\r\n                                </tr>\r\n");
            EndContext();
#line 73 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"

                                count++;
                            }
                        

#line default
#line hidden
            BeginContext(2996, 159, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-footer small text-muted\">Updated Table at ");
            EndContext();
            BeginContext(3156, 26, false);
#line 81 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Delivery\ViewAll.cshtml"
                                                              Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(3182, 34, true);
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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