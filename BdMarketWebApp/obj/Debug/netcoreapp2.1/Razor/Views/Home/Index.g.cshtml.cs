#pragma checksum "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "321aea1335ea2c92b9ca8ac82a56afb0081599e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"321aea1335ea2c92b9ca8ac82a56afb0081599e3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e784d0848b3ddf482a3054ad19237c933aefb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/vendor/chart.js/Chart.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "BD Market - Home";
    ViewData["HomeActive"] = "active";

#line default
#line hidden
            BeginContext(116, 1514, true);
            WriteLiteral(@"
<style>
    #card_item {
        background: #0f0c29; /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #24243e, #302b63, #0f0c29); /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #24243e, #302b63, #0f0c29); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
    }

    #card_stock {
        background: #200122; /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #6f0000, #200122); /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #6f0000, #200122); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
    }

    #card_new_order {
        background: #000000; /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #0f9b0f, #000000); /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #0f9b0f, #000000); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            WriteLiteral(@"
    }

    #card_user {
        background: #c31432; /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #240b36, #c31432); /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #240b36, #c31432); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
    }
</style>

<div class=""container-fluid"">
    <!-- Breadcrumbs-->
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item"">
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1630, "\"", 1664, 1);
#line 37 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 1637, Url.Action("Index","Home"), 1637, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1665, 521, true);
            WriteLiteral(@">Dashboard</a>
        </li>
        <li class=""breadcrumb-item active"">Overview</li>
    </ol>
    <!-- Icon Cards-->
    <div class=""row"">
        <div class=""col-xl-3 col-sm-6 mb-3"">
            <div class=""card text-white bg-primary o-hidden h-100"" id=""card_item"">
                <div class=""card-body"">
                    <div class=""card-body-icon"">
                        <i class=""fas fa-sitemap""></i>
                    </div>
                    <div class=""mr-5""><span style=""font-size: 30px;"">");
            EndContext();
            BeginContext(2187, 17, false);
#line 49 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(ViewData["Items"]);

#line default
#line hidden
            EndContext();
            BeginContext(2204, 114, true);
            WriteLiteral("</span> Items!</div>\r\n                </div>\r\n                <a class=\"card-footer text-white clearfix small z-1\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2318, "\"", 2357, 1);
#line 51 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 2325, Url.Action("ViewAll","Product"), 2325, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2358, 640, true);
            WriteLiteral(@">
                    <span class=""float-left"">View Details</span>
                    <span class=""float-right"">
                        <i class=""fas fa-angle-right""></i>
                    </span>
                </a>
            </div>
        </div>
        <div class=""col-xl-3 col-sm-6 mb-3"">
            <div class=""card text-white bg-warning o-hidden h-100"" id=""card_stock"">
                <div class=""card-body"">
                    <div class=""card-body-icon"">
                        <i class=""fas fa-box-open""></i>
                    </div>
                    <div class=""mr-5""><span style=""font-size: 30px;"">");
            EndContext();
            BeginContext(2999, 17, false);
#line 65 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(ViewData["Stock"]);

#line default
#line hidden
            EndContext();
            BeginContext(3016, 123, true);
            WriteLiteral("</span> Items No Stock!</div>\r\n                </div>\r\n                <a class=\"card-footer text-white clearfix small z-1\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3139, "\"", 3178, 1);
#line 67 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 3146, Url.Action("ViewAll","Product"), 3146, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3179, 655, true);
            WriteLiteral(@">
                    <span class=""float-left"">View Details</span>
                    <span class=""float-right"">
                        <i class=""fas fa-angle-right""></i>
                    </span>
                </a>
            </div>
        </div>
        <div class=""col-xl-3 col-sm-6 mb-3"">
            <div class=""card text-white bg-success o-hidden h-100"" id=""card_new_order"">
                <div class=""card-body"">
                    <div class=""card-body-icon"">
                        <i class=""fas fa-fw fa-shopping-cart""></i>
                    </div>
                    <div class=""mr-5""><span style=""font-size: 30px;"">");
            EndContext();
            BeginContext(3835, 20, false);
#line 81 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(ViewData["NewOrder"]);

#line default
#line hidden
            EndContext();
            BeginContext(3855, 119, true);
            WriteLiteral("</span> New Orders!</div>\r\n                </div>\r\n                <a class=\"card-footer text-white clearfix small z-1\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3974, "\"", 4018, 1);
#line 83 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 3981, Url.Action("NewOrdered","OrderItem"), 3981, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4019, 634, true);
            WriteLiteral(@">
                    <span class=""float-left"">View Details</span>
                    <span class=""float-right"">
                        <i class=""fas fa-angle-right""></i>
                    </span>
                </a>
            </div>
        </div>
        <div class=""col-xl-3 col-sm-6 mb-3"">
            <div class=""card text-white bg-danger o-hidden h-100"" id=""card_user"">
                <div class=""card-body"">
                    <div class=""card-body-icon"">
                        <i class=""fas fa-user""></i>
                    </div>
                    <div class=""mr-5""><span style=""font-size: 30px;"">");
            EndContext();
            BeginContext(4654, 17, false);
#line 97 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(ViewData["Users"]);

#line default
#line hidden
            EndContext();
            BeginContext(4671, 114, true);
            WriteLiteral("</span> Users!</div>\r\n                </div>\r\n                <a class=\"card-footer text-white clearfix small z-1\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4785, "\"", 4826, 1);
#line 99 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 4792, Url.Action("ViewAllUsers","User"), 4792, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4827, 433, true);
            WriteLiteral(@">
                    <span class=""float-left"">View Details</span>
                    <span class=""float-right"">
                        <i class=""fas fa-angle-right""></i>
                    </span>
                </a>
            </div>
        </div>
    </div>

    <!-- Area Chart Example-->
    <div class=""card mb-3"">
        <div class=""card-header"">
            <i class=""fas fa-chart-area""></i>
            ");
            EndContext();
            BeginContext(5261, 17, false);
#line 113 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
       Write(DateTime.Now.Year);

#line default
#line hidden
            EndContext();
            BeginContext(5278, 228, true);
            WriteLiteral("\'s Sold Amount Analysis\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <canvas id=\"yearAmountChart\" width=\"100%\" height=\"30\"></canvas>\r\n        </div>\r\n        <div class=\"card-footer small text-muted\">Updated at ");
            EndContext();
            BeginContext(5507, 26, false);
#line 118 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                        Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(5533, 145, true);
            WriteLiteral("</div>\r\n    </div>\r\n\r\n    <div class=\"card mb-3\">\r\n        <div class=\"card-header\">\r\n            <i class=\"fas fa-chart-area\"></i>\r\n            ");
            EndContext();
            BeginContext(5679, 17, false);
#line 124 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
       Write(DateTime.Now.Year);

#line default
#line hidden
            EndContext();
            BeginContext(5696, 230, true);
            WriteLiteral("\'s Sold Profit Analysis\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <canvas id=\"profitAmountChart\" width=\"100%\" height=\"30\"></canvas>\r\n        </div>\r\n        <div class=\"card-footer small text-muted\">Updated at ");
            EndContext();
            BeginContext(5927, 26, false);
#line 129 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                        Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(5953, 505, true);
            WriteLiteral(@"</div>
    </div>

    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-chart-area""></i>
                    Four Year's Sold Profit Analysis
                </div>
                <div class=""card-body"">
                    <canvas id=""AmountChart"" width=""100%"" height=""30""></canvas>
                </div>
                <div class=""card-footer small text-muted"">Updated at ");
            EndContext();
            BeginContext(6459, 26, false);
#line 142 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(6485, 504, true);
            WriteLiteral(@"</div>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-chart-area""></i>
                    Four Year's Sold Profit Analysis
                </div>
                <div class=""card-body"">
                    <canvas id=""ProfitChart"" width=""100%"" height=""30""></canvas>
                </div>
                <div class=""card-footer small text-muted"">Updated at ");
            EndContext();
            BeginContext(6990, 26, false);
#line 154 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                                                                Write(DateTime.Now.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(7016, 66, true);
            WriteLiteral("</div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(7082, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95360d8f5a0241c1a10ec0c026a8b26a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7143, 349, true);
            WriteLiteral(@"
<script>
    // Area Chart Example
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,""Segoe UI"",Roboto,""Helvetica Neue"",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    var amounts = ");
            EndContext();
            BeginContext(7493, 66, false);
#line 167 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
             Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.YearlyAmountByMonth)));

#line default
#line hidden
            EndContext();
            BeginContext(7559, 1593, true);
            WriteLiteral(@";

    // Bar Chart Example
    var ctx = document.getElementById(""yearAmountChart"");
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [""Jan"", ""Feb"", ""Mar"", ""Apr"", ""May"", ""Jun"", ""Jul"", ""Aug"", ""Sept"", ""Oct"", ""Nov"", ""Dec""],
            datasets: [{
                label: ""Amount"",
                backgroundColor: ""#1B5E20"",
                borderColor: ""#1B5E20"",
                data: amounts
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'month'
                    },
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 5000000,
                        maxTicksLimi");
            WriteLiteral(@"t: 5
                    },
                    gridLines: {
                        display: true
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });


    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,""Segoe UI"",Roboto,""Helvetica Neue"",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';


    var profits = ");
            EndContext();
            BeginContext(9153, 64, false);
#line 218 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
             Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.YearProfitByMonth)));

#line default
#line hidden
            EndContext();
            BeginContext(9217, 1963, true);
            WriteLiteral(@";

// Area Chart Example
    var ctx = document.getElementById(""profitAmountChart"");
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [""Jan"", ""Feb"", ""Mar"", ""Apr"", ""May"", ""Jun"", ""Jul"", ""Aug"", ""Sept"", ""Oct"", ""Nov"", ""Dec""],
            datasets: [{
                label: ""Profit"",
                lineTension: 0.3,
                backgroundColor: ""#80CBC4"",
                borderColor: ""#1B5E20"",
                pointRadius: 5,
                pointBackgroundColor: ""#263238"",
                pointBorderColor: ""#263238"",
                pointHoverRadius: 5,
                pointHoverBackgroundColor: ""#00695C"",
                pointHitRadius: 50,
                pointBorderWidth: 2,
                data: profits,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'month'
                    },
                    gridLines: {
            ");
            WriteLiteral(@"            display: false
                    },
                    ticks: {
                        maxTicksLimit: 7
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 5000000,
                        maxTicksLimit: 5
                    },
                    gridLines: {
                        color: ""rgba(0, 0, 0, .125)"",
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });

    // Area Chart Example
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,""Segoe UI"",Roboto,""Helvetica Neue"",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    var years = ");
            EndContext();
            BeginContext(11181, 52, false);
#line 276 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
           Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.Years)));

#line default
#line hidden
            EndContext();
            BeginContext(11233, 25, true);
            WriteLiteral(";\r\n    var yearAmounts = ");
            EndContext();
            BeginContext(11259, 57, false);
#line 277 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                 Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.YearAmount)));

#line default
#line hidden
            EndContext();
            BeginContext(11316, 1539, true);
            WriteLiteral(@";

    // Bar Chart Example
    var ctx = document.getElementById(""AmountChart"");
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: years,
            datasets: [{
                label: ""Amount"",
                backgroundColor: ""#1B5E20"",
                borderColor: ""#1B5E20"",
                data: yearAmounts,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'year'
                    },
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 5000000,
                        maxTicksLimit: 5
                    },
                    gridLines: {
                ");
            WriteLiteral(@"        display: true
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });

    // Area Chart Example
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,""Segoe UI"",Roboto,""Helvetica Neue"",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    var yearProfit = ");
            EndContext();
            BeginContext(12856, 57, false);
#line 327 "Z:\Dot Net Core\BdMarketWebApp\BdMarketWebApp\Views\Home\Index.cshtml"
                Write(Html.Raw(JsonConvert.SerializeObject(ViewBag.YearProfit)));

#line default
#line hidden
            EndContext();
            BeginContext(12913, 1205, true);
            WriteLiteral(@";

    // Bar Chart Example
    var ctx = document.getElementById(""ProfitChart"");
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: years,
            datasets: [{
                label: ""Profit"",
                backgroundColor: ""#1B5E20"",
                borderColor: ""#1B5E20"",
                data: yearProfit,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'year'
                    },
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 5000000,
                        maxTicksLimit: 5
                    },
                    gridLines: {
                 ");
            WriteLiteral("       display: true\r\n                    }\r\n                }],\r\n            },\r\n            legend: {\r\n                display: false\r\n            }\r\n        }\r\n    });\r\n</script>");
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