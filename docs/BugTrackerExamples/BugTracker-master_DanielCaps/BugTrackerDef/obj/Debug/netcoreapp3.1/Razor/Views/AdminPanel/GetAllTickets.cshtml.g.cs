#pragma checksum "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "743eb603475394f5fb3155c51af82325971da449"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminPanel_GetAllTickets), @"mvc.1.0.view", @"/Views/AdminPanel/GetAllTickets.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"743eb603475394f5fb3155c51af82325971da449", @"/Views/AdminPanel/GetAllTickets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fb3caa700aa993ed68c9fab645895b6863b6b7a", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminPanel_GetAllTickets : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BugTrackerDef.Domain.Ticket>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
  
    ViewData["Title"] = "GetAllTickets";
    Layout = "~/Views/AdminPanel/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            \n            <th>\n                ");
#nullable restore
#line 14 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 17 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.AssignedDev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 20 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Submitter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 23 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 26 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.TicketPriority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 29 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 32 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            \n            \n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 40 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 43 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 46 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssignedDev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 49 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Submitter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 52 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 55 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.TicketPriority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 58 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            \n            <td>\n                ");
#nullable restore
#line 62 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 65 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.ActionLink("Edit", "EditTicket", new {  id=item.TicketID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 66 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.ActionLink("Details", "DetailsTicket", new {  id=item.TicketID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 67 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
           Write(Html.ActionLink("Delete", "DeleteTicket", new {  id=item.TicketID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 70 "C:\Users\carlo\Downloads\BugTracker-master\BugTrackerDef\Views\AdminPanel\GetAllTickets.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BugTrackerDef.Domain.Ticket>> Html { get; private set; }
    }
}
#pragma warning restore 1591
