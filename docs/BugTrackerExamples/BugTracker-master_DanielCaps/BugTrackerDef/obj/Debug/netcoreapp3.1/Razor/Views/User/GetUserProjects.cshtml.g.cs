#pragma checksum "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0eaad5c65f097f3a8ce2686526e7755c7ca5276"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetUserProjects), @"mvc.1.0.view", @"/Views/User/GetUserProjects.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0eaad5c65f097f3a8ce2686526e7755c7ca5276", @"/Views/User/GetUserProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fb3caa700aa993ed68c9fab645895b6863b6b7a", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetUserProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BugTrackerDef.Domain.Project>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailsProject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h4>Your Projects</h4>\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 13 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 16 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            \n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 25 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0eaad5c65f097f3a8ce2686526e7755c7ca52765327", async() => {
#nullable restore
#line 29 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
                                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
                                                     WriteLiteral(item.ProjectID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 32 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 35 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.CreatorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 38 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\User\GetUserProjects.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BugTrackerDef.Domain.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
