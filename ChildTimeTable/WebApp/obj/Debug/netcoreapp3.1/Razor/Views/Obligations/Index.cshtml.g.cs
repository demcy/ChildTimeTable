#pragma checksum "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac01675f55cdba27ba16d8e90510d677e68c9630"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Obligations_Index), @"mvc.1.0.view", @"/Views/Obligations/Index.cshtml")]
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
#line 1 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac01675f55cdba27ba16d8e90510d677e68c9630", @"/Views/Obligations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dec085bf195b01abb92852e860e2ca042d6a2857", @"/Views/_ViewImports.cshtml")]
    public class Views_Obligations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ObligationDataModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table style=\"width: 100%\">\r\n    <tr>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 188, "\"", 284, 3);
            WriteAttributeValue("", 198, "location.href=\'", 198, 15, true);
#nullable restore
#line 10 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 213, Url.Action("Index", "Obligations", new {dt = Model.Date.AddDays(-1)}), 213, 70, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 283, "\'", 283, 1, true);
            EndWriteAttribute();
            WriteLiteral(" >&#8810;</button>\r\n        </td>\r\n        <td>\r\n            <h3 style=\"text-align: center\">");
#nullable restore
#line 13 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                      Write(Model.Date.ToString("d MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 505, "\"", 600, 3);
            WriteAttributeValue("", 515, "location.href=\'", 515, 15, true);
#nullable restore
#line 16 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 530, Url.Action("Index", "Obligations", new {dt = Model.Date.AddDays(1)}), 530, 69, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 599, "\'", 599, 1, true);
            EndWriteAttribute();
            WriteLiteral(">&#8811;</button>\r\n        </td>\r\n                    \r\n    </tr>\r\n</table>\r\n\r\n\r\n\r\n<h4>Tasks for me:</h4>\r\n");
#nullable restore
#line 25 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
  
    int i = 0;
    string linkI = "t";
    string switchI = "s";

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
 foreach (var item in Model.Obligations!.Where(o => o.ChildId == ViewBag.User))
{
    linkI += i;
    switchI += i;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"input-group d-flex\">\r\n");
#nullable restore
#line 35 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
         if (item.Status)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button type=\"button\" class=\"btn btn-success flex-fill\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 37 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                                                    Write(linkI);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-3\">\r\n                        ");
#nullable restore
#line 40 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                   Write(item!.Time.StartTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 40 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                             Write(item!.Time.EndTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        ");
#nullable restore
#line 43 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </button>\r\n");
#nullable restore
#line 47 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button type=\"button\" class=\"btn btn-warning flex-fill\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 50 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                                                    Write(linkI);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-3\">\r\n                        ");
#nullable restore
#line 53 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                   Write(item!.Time.StartTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 53 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                             Write(item!.Time.EndTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        ");
#nullable restore
#line 56 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </button>\r\n");
#nullable restore
#line 60 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n            \r\n        <div class=\"input-group-append\">\r\n");
#nullable restore
#line 64 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
             using (Html.BeginForm("ChangeStatus", "Obligations", new {id = item.Id}))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <label class=\"switch\">\r\n");
#nullable restore
#line 67 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                     if (item.Status)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"checkbox\"");
            BeginWriteAttribute("onchange", " onchange=\"", 2327, "\"", 2437, 7);
            WriteAttributeValue("", 2338, "setTimeout(function()", 2338, 21, true);
            WriteAttributeValue(" ", 2359, "{", 2360, 2, true);
            WriteAttributeValue("\r\n                            ", 2361, "formDelay(", 2391, 40, true);
#nullable restore
#line 70 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 2401, i, 2401, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2403, ")", 2403, 1, true);
            WriteAttributeValue("\r\n                        ", 2404, "},", 2430, 28, true);
            WriteAttributeValue(" ", 2432, "400)", 2433, 5, true);
            EndWriteAttribute();
            WriteLiteral(" checked>\r\n");
#nullable restore
#line 72 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"checkbox\"");
            BeginWriteAttribute("onchange", " onchange=\"", 2567, "\"", 2677, 7);
            WriteAttributeValue("", 2578, "setTimeout(function()", 2578, 21, true);
            WriteAttributeValue(" ", 2599, "{", 2600, 2, true);
            WriteAttributeValue("\r\n                            ", 2601, "formDelay(", 2631, 40, true);
#nullable restore
#line 76 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 2641, i, 2641, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2643, ")", 2643, 1, true);
            WriteAttributeValue("\r\n                        ", 2644, "},", 2670, 28, true);
            WriteAttributeValue(" ", 2672, "400)", 2673, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 78 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"slider round\"></span>\r\n                </label>\r\n");
#nullable restore
#line 81 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 2839, "\"", 2850, 1);
#nullable restore
#line 85 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 2844, linkI, 2844, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n        <dl>\r\n            <dt>From</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 89 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Parent.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 89 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                Write(Html.DisplayFor(modelItem => item.Parent.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>Location</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 93 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Location.LocationValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>Type</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 97 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ObligationType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n");
#nullable restore
#line 101 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
    i++;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4>My tasks:</h4>\r\n");
#nullable restore
#line 104 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
 foreach (var item in Model.Obligations.Where(o => o.ParentId == Model.PersonId))
{
    linkI += i;
    switchI += i;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"input-group d-flex\">\r\n        <button type=\"button\" class=\"btn btn-info flex-fill\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 109 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                                             Write(linkI);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <div class=\"row\">\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 112 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
               Write(item!.Time.StartTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 112 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                         Write(item!.Time.EndTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 115 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </button>\r\n        <div class=\"input-group-append\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac01675f55cdba27ba16d8e90510d677e68c963018083", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                WriteLiteral(item.Id);

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
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac01675f55cdba27ba16d8e90510d677e68c963020333", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 121 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                                  WriteLiteral(item.Id);

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
            WriteLiteral("\r\n        </div>\r\n        \r\n    </div>\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 4300, "\"", 4311, 1);
#nullable restore
#line 125 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
WriteAttributeValue("", 4305, linkI, 4305, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n        <dl>\r\n            <dt>To</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 129 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Child.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 129 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Child.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>Location</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 133 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Location.LocationValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>Type</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 137 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ObligationType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n");
#nullable restore
#line 141 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
    i++;
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
 if (Model.Today)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac01675f55cdba27ba16d8e90510d677e68c963024882", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-dt", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 146 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
                                 WriteLiteral(Model.Date);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dt"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-dt", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dt"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 148 "/Users/kira/RiderProjects/idc0009-2019s/ChildTimeTable/WebApp/Views/Obligations/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        function formDelay(i) { \r\n            let statusForm = document.getElementsByTagName(\'form\')[i+1];       \r\n            statusForm.submit();\r\n    }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ObligationDataModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
