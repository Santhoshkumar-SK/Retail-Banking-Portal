#pragma checksum "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "112d7b7acf38ade36ad6d15103d90f94368410d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_transactionHistory), @"mvc.1.0.view", @"/Views/Customer/transactionHistory.cshtml")]
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
#line 1 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\_ViewImports.cshtml"
using RetailBankingPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\_ViewImports.cshtml"
using RetailBankingPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"112d7b7acf38ade36ad6d15103d90f94368410d9", @"/Views/Customer/transactionHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"835cff53c994a4ba28f66b1b41c8108ac2f3d5d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_transactionHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RetailBankingPortal.Models.TransactionHistory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/MainStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
  
    ViewData["Title"] = "TransactionHistory";
    Layout = "~/Views/Customer/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "112d7b7acf38ade36ad6d15103d90f94368410d94526", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 8 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
            WriteLiteral("    <h1>Transaction History</h1>\r\n    <hr />\r\n");
            WriteLiteral(@"    <div class=""card transactionbg"">
        <div class=""card-body"">
            
            <table class=""table"">
                <thead>
                    <tr>

                        <th>CustomerId</th>
                        <th>AccountId</th>
                        <th>CounterpartyAccountId</th>
                        <th>Transfer Amount</th>
                        <th>Closing Balance</th>
                        <th>DateofTransaction</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 31 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n\r\n                            <td>");
#nullable restore
#line 35 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(Html.DisplayFor(modelItem => item.AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CounterpartyAccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(Html.DisplayFor(modelItem => item.TransferAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ClosingBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                           Write(String.Format("{0:d/M/yyyy}", item.DateofTranasction));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 42 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 47 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
        <strong>No transaction found</strong>
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
");
#nullable restore
#line 56 "F:\cts\Hands on\Dot Net\BankPortalBackup\Final Project\Retail Banking Portal\New folder\RetailBankingPortal\RetailBankingPortal\Views\Customer\transactionHistory.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RetailBankingPortal.Models.TransactionHistory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
