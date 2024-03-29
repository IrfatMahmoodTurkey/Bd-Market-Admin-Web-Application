#pragma checksum "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "654f87bbed4e8a382c3288350e6891bb3f377848"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ViewAllUsers), @"mvc.1.0.view", @"/Views/User/ViewAllUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/ViewAllUsers.cshtml", typeof(AspNetCore.Views_User_ViewAllUsers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"654f87bbed4e8a382c3288350e6891bb3f377848", @"/Views/User/ViewAllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e784d0848b3ddf482a3054ad19237c933aefb1", @"/Views/_ViewImports.cshtml")]
    public class Views_User_ViewAllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BdMarketWebApp.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
  
    ViewData["Title"] = "BD Market - View Users";
    ViewData["UserActive"] = "active";

#line default
#line hidden
            BeginContext(133, 114, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 247, "\"", 286, 1);
#line 10 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
WriteAttributeValue("", 254, Url.Action("ViewAll","Product"), 254, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(287, 351, true);
            WriteLiteral(@">User</a>
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
            BeginWriteAttribute("onclick", " onclick=\"", 638, "\"", 702, 5);
            WriteAttributeValue("", 648, "location.href", 648, 13, true);
            WriteAttributeValue(" ", 661, "=", 662, 2, true);
            WriteAttributeValue(" ", 663, "\'", 664, 2, true);
#line 20 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
WriteAttributeValue("", 665, Url.Action("RegisterUser", "User"), 665, 35, false);

#line default
#line hidden
            WriteAttributeValue("", 700, "\';", 700, 2, true);
            EndWriteAttribute();
            BeginContext(703, 1556, true);
            WriteLiteral(@" class=""add_button""><i class=""fas fa-plus-square""></i> Add User</button>
                </div>
            </div>
        </div>
        <div class=""col-md-4""></div>
    </div>
    <br />

    <div class=""card mb-3"">
        <div class=""card-header"">
            <i class=""fas fa-table""></i>
            User Table
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>SL</th>
                            <th>User Name</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Verification Code</th>
                            <th>Is Verified</th>
                            <th>Registration Date</th>
                            <th>Action</th>
                        </tr>
                    </thead>
 ");
            WriteLiteral(@"                   <tfoot>
                        <tr>
                            <th>SL</th>
                            <th>User Name</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Verification Code</th>
                            <th>Is Verified</th>
                            <th>Registration Date</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                    <tbody>
");
            EndContext();
#line 61 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                          
                            int count = 1;

                            foreach (User user in ViewBag.Users)
                            {

#line default
#line hidden
            BeginContext(2430, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(2509, 5, false);
#line 67 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(2514, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2562, 13, false);
#line 68 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2575, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2623, 10, false);
#line 69 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2633, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2681, 10, false);
#line 70 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(user.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(2691, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2739, 21, false);
#line 71 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(user.VerificationCode);

#line default
#line hidden
            EndContext();
            BeginContext(2760, 9, true);
            WriteLiteral("</td>\r\n\r\n");
            EndContext();
#line 73 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                     if (user.Verify == 1)
                                    {

#line default
#line hidden
            BeginContext(2868, 59, true);
            WriteLiteral("                                        <td>Verified</td>\r\n");
            EndContext();
#line 76 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3047, 63, true);
            WriteLiteral("                                        <td>Not Verified</td>\r\n");
            EndContext();
#line 80 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                    }

#line default
#line hidden
            BeginContext(3149, 42, true);
            WriteLiteral("\r\n                                    <td>");
            EndContext();
            BeginContext(3192, 24, false);
#line 82 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                   Write(user.AccountCreatingTime);

#line default
#line hidden
            EndContext();
            BeginContext(3216, 49, true);
            WriteLiteral("</td>\r\n                                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3265, "\"", 3322, 1);
#line 83 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
WriteAttributeValue("", 3272, Url.Action("Banned","User", new {id=user.UserId}), 3272, 50, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3323, 62, true);
            WriteLiteral(">Banned User</a></td>\r\n                                </tr>\r\n");
            EndContext();
#line 85 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"

                                count++;
                            }
                        

#line default
#line hidden
            BeginContext(3487, 159, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-footer small text-muted\">Updated Table at ");
            EndContext();
            BeginContext(3647, 26, false);
#line 93 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\User\ViewAllUsers.cshtml"
                                                              Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(3673, 26, true);
            WriteLiteral("</div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BdMarketWebApp.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
