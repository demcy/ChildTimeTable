#pragma checksum "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8e83cb3a253a2441d03c7d8fb7c58f6e3a98ae2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Persons_Index), @"mvc.1.0.view", @"/Views/Persons/Index.cshtml")]
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
#line 1 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8e83cb3a253a2441d03c7d8fb7c58f6e3a98ae2", @"/Views/Persons/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dec085bf195b01abb92852e860e2ca042d6a2857", @"/Views/_ViewImports.cshtml")]
    public class Views_Persons_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Domain.Person>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-4\">\r\n\r\n        <table class=\"table\">\r\n            <thead>\r\n            <tr>\r\n                <h3>My Family</h3>\r\n            </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 17 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
             foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 414, "\"", 460, 1);
#nullable restore
#line 20 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
WriteAttributeValue("", 420, Html.DisplayFor(modelItem => item.Logo), 420, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"logo\" width=\"64\" height=\"64\"/>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 23 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 23 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 26 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <tr>
                <td colspan=""2"">
                    <button type=""button"" class=""btn btn-warning btn-block"" onclick=""newPerson()"">Add Person</button>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
    <div class=""col"">
        <div>
            <table style=""width: 100%"">
                <tr>
                    <td>
                        <button type=""button"" class=""btn btn-outline-info"" onclick=""previous()"">&#8810;</button>
                    </td>
                    <td>
                        <h3 style=""text-align: center"" id=""monthAndYear"">Month and Year</h3>
                    </td>
                    <td>
                        <button type=""button"" class=""btn btn-outline-info"" onclick=""next()"">&#8811;</button>
                    </td>
                    
                </tr>
            </table>
            
            
            <table class=""table"">
                <thead>
                <tr>
    ");
            WriteLiteral(@"                <th>Mon</th>
                    <th>Tue</th>
                    <th>Wed</th>
                    <th>Thu</th>
                    <th>Fri</th>
                    <th>Sat</th>
                    <th>Sun</th>
                </tr>
                </thead>
                <tbody id=""calendar-body""></tbody>
            </table>
        </div>
    </div>
</div>

");
#nullable restore
#line 71 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
 using(Html.BeginForm("NotificationCreate", "Persons"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div id=""newPerson-div"" style=""display: none"">
                    <h4 style=""text-align: center; color: white"">Please input pesron email</h4>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"">&#64;</span>
                        </div>
                        <input name=""email"" class=""form-control""/>
                    </div>
                    <input type=""submit"" class=""btn btn-success btn-block"" value=""Send invitation"" onclick=""closeNewPerson()""/>
                    <button type=""button"" class=""btn btn-primary"" style=""position: absolute; right: 5px; top: 5px"" onclick=""closeNewPerson()"">X</button>
                            
                </div>
");
#nullable restore
#line 85 "/Users/kira/RiderProjects/idc0009-2019s/THREE/ChildTimeTable/WebApp/Views/Persons/Index.cshtml"
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Domain.Person>> Html { get; private set; }
    }
}
#pragma warning restore 1591
