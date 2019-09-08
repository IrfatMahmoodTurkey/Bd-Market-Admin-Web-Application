#pragma checksum "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ee9a444323cb6ce9a75fad966f87d0e7248fe3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Designation_ViewAll), @"mvc.1.0.view", @"/Views/Designation/ViewAll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Designation/ViewAll.cshtml", typeof(AspNetCore.Views_Designation_ViewAll))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ee9a444323cb6ce9a75fad966f87d0e7248fe3d", @"/Views/Designation/ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e784d0848b3ddf482a3054ad19237c933aefb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Designation_ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
  
    ViewData["Title"] = "BD Market - View Designation";
    ViewData["DesignationActive"] = "active";

#line default
#line hidden
            BeginContext(113, 114, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 227, "\"", 270, 1);
#line 10 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
WriteAttributeValue("", 234, Url.Action("ViewAll","Designation"), 234, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(271, 358, true);
            WriteLiteral(@">Designation</a>
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
            BeginWriteAttribute("onclick", " onclick=\"", 629, "\"", 691, 5);
            WriteAttributeValue("", 639, "location.href", 639, 13, true);
            WriteAttributeValue(" ", 652, "=", 653, 2, true);
            WriteAttributeValue(" ", 654, "\'", 655, 2, true);
#line 20 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
WriteAttributeValue("", 656, Url.Action("Add", "Designation"), 656, 33, false);

#line default
#line hidden
            WriteAttributeValue("", 689, "\';", 689, 2, true);
            EndWriteAttribute();
            BeginContext(692, 1380, true);
            WriteLiteral(@" class=""add_button""><i class=""fas fa-plus-square""></i> Add Designation</button>
                </div>
            </div>
        </div>
        <div class=""col-md-4""></div>
    </div>
    <br />

    <div class=""card mb-3"">
        <div class=""card-header"">
            <i class=""fas fa-table""></i>
            Designation Table
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>SL</th>
                            <th>Designation Name</th>
                            <th>Action Name</th>
                            <th>Action Time</th>
                            <th>Action By</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                       ");
            WriteLiteral(@"     <th>SL</th>
                            <th>Designation Name</th>
                            <th>Action Name</th>
                            <th>Action Time</th>
                            <th>Action By</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                    <tbody>
");
            EndContext();
#line 57 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                          
                            int count = 1;

                            foreach (Designation desigantion in ViewBag.Designations)
                            {

#line default
#line hidden
            BeginContext(2264, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(2343, 5, false);
#line 63 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                   Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(2348, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2396, 16, false);
#line 64 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                   Write(desigantion.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2412, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2460, 22, false);
#line 65 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                   Write(desigantion.ActionDone);

#line default
#line hidden
            EndContext();
            BeginContext(2482, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2530, 22, false);
#line 66 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                   Write(desigantion.ActionTime);

#line default
#line hidden
            EndContext();
            BeginContext(2552, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2600, 20, false);
#line 67 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                   Write(desigantion.ActionBy);

#line default
#line hidden
            EndContext();
            BeginContext(2620, 49, true);
            WriteLiteral("</td>\r\n                                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2669, "\"", 2734, 1);
#line 68 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
WriteAttributeValue("", 2676, Url.Action("Edit","Designation", new {id=desigantion.Id}), 2676, 58, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2735, 55, true);
            WriteLiteral(">Edit</a></td>\r\n                                </tr>\r\n");
            EndContext();
#line 70 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"

                                count++;
                            }
                        

#line default
#line hidden
            BeginContext(2892, 159, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-footer small text-muted\">Updated Table at ");
            EndContext();
            BeginContext(3052, 26, false);
#line 78 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Designation\ViewAll.cshtml"
                                                              Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(3078, 28, true);
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n");
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
