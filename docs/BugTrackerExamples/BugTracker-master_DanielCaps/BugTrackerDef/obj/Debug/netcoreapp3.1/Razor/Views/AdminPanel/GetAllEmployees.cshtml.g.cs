#pragma checksum "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d720e61fa6833de5f24be66568664ab1f886d1d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminPanel_GetAllEmployees), @"mvc.1.0.view", @"/Views/AdminPanel/GetAllEmployees.cshtml")]
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
#line 1 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\_ViewImports.cshtml"
using BugTrackerDef;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\_ViewImports.cshtml"
using BugTrackerDef.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d720e61fa6833de5f24be66568664ab1f886d1d7", @"/Views/AdminPanel/GetAllEmployees.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fb3caa700aa993ed68c9fab645895b6863b6b7a", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminPanel_GetAllEmployees : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BugTrackerDef.Domain.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateEmployee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
  
    ViewData["Title"] = "GetAllEmployees";
    Layout = "~/Views/AdminPanel/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d720e61fa6833de5f24be66568664ab1f886d1d74021", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 16 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 22 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 28 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 31 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 34 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 37 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 40 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.ActionLink("Edit", "EditEmployee", new {  id=item.EmployeeID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 41 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.ActionLink("Details", "DetailsEmployee", new {  id=item.EmployeeID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 42 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
           Write(Html.ActionLink("Delete", "DeleteEmployee", new {  id=item.EmployeeID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 45 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllEmployees.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<BugTrackerDef.Domain.ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BugTrackerDef.Domain.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
