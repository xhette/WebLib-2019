#pragma checksum "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f07e19f98817d7a2e9e2d68159ed74a00407dda1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AddDepartment), @"mvc.1.0.view", @"/Views/Admin/AddDepartment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AddDepartment.cshtml", typeof(AspNetCore.Views_Admin_AddDepartment))]
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
#line 1 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\_ViewImports.cshtml"
using WebLib;

#line default
#line hidden
#line 2 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\_ViewImports.cshtml"
using WebLib.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f07e19f98817d7a2e9e2d68159ed74a00407dda1", @"/Views/Admin/AddDepartment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4ecce07a27cd6ebdafd308597dcdecd93f46a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AddDepartment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebLib.Models.Repositories.CompositeModels.Departments.DepartmentEditModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
  
    Layout = "_WorkLayout";
    ViewData["Title"] = "WebLib | Добавление отдела";

#line default
#line hidden
            BeginContext(95, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(180, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(183, 30, false);
#line 10 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
Write(Html.Partial("_AdminBookMenu"));

#line default
#line hidden
            EndContext();
            BeginContext(213, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 12 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
 using (Html.BeginForm("AddDepartment", "Admin", FormMethod.Post, new { @class = "input-wrapper" }))
{
    

#line default
#line hidden
            BeginContext(327, 36, false);
#line 14 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
Write(Html.HiddenFor(m => m.Department.Id));

#line default
#line hidden
            EndContext();
            BeginContext(365, 41, true);
            WriteLiteral("    <div class=input-form-area>\r\n        ");
            EndContext();
            BeginContext(407, 50, false);
#line 16 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
   Write(Html.LabelFor(m => m.Department.Name, "Название:"));

#line default
#line hidden
            EndContext();
            BeginContext(457, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(468, 99, false);
#line 17 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
   Write(Html.ValidationMessageFor(m => m.Department.Name, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(567, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(578, 94, false);
#line 18 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
   Write(Html.EditorFor(m => m.Department.Name, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(672, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=input-form-area>\r\n        ");
            EndContext();
            BeginContext(728, 52, false);
#line 21 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
   Write(Html.LabelFor(m => m.SelectedLibrary, "Библиотека:"));

#line default
#line hidden
            EndContext();
            BeginContext(780, 65, true);
            WriteLiteral("\r\n        <span class=\"validation-message dark\"></span>\r\n        ");
            EndContext();
            BeginContext(846, 133, false);
#line 23 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
   Write(Html.DropDownListFor(m => m.SelectedLibrary, Model.Libraries as SelectList, new { @class = "select-drop-list", id = "library-list" }));

#line default
#line hidden
            EndContext();
            BeginContext(979, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
            BeginContext(995, 74, true);
            WriteLiteral("    <input type=\"submit\" class=\"submit-button-gray\" value=\"Сохранить\" />\r\n");
            EndContext();
#line 27 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddDepartment.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebLib.Models.Repositories.CompositeModels.Departments.DepartmentEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
