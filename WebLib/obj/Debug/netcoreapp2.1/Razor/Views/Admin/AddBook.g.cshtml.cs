#pragma checksum "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70cf6442fd81f96aa597f9bd4283e0947f16fec7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AddBook), @"mvc.1.0.view", @"/Views/Admin/AddBook.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AddBook.cshtml", typeof(AspNetCore.Views_Admin_AddBook))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70cf6442fd81f96aa597f9bd4283e0947f16fec7", @"/Views/Admin/AddBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4ecce07a27cd6ebdafd308597dcdecd93f46a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AddBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebLib.Models.Repositories.CompositeModels.Books.BookEditModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
  
    Layout = "_WorkLayout";
    ViewData["Title"] = "WebLib | Добавление книги";

#line default
#line hidden
            BeginContext(92, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(166, 30, false);
#line 8 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
Write(Html.Partial("_AdminBookMenu"));

#line default
#line hidden
            EndContext();
            BeginContext(196, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 10 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
     using (Html.BeginForm("AddBook", "Admin", FormMethod.Post, new { @class = "input-wrapper" }))
    {
        

#line default
#line hidden
            BeginContext(316, 30, false);
#line 12 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
   Write(Html.HiddenFor(m => m.Book.Id));

#line default
#line hidden
            EndContext();
            BeginContext(357, 36, false);
#line 13 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
   Write(Html.HiddenFor(m => m.Book.AuthorId));

#line default
#line hidden
            EndContext();
            BeginContext(404, 32, false);
#line 14 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
   Write(Html.HiddenFor(m => m.Author.Id));

#line default
#line hidden
            EndContext();
            BeginContext(440, 49, true);
            WriteLiteral("        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(490, 55, false);
#line 17 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.Author.Surname, "Фамилия автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(545, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(560, 98, false);
#line 18 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.ValidationMessageFor(m => m.Author.Surname, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(658, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(673, 93, false);
#line 19 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.EditorFor(m => m.Author.Surname, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(766, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(834, 53, false);
#line 22 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.Author.FirstName, "Имя автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(887, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(902, 100, false);
#line 23 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.ValidationMessageFor(m => m.Author.FirstName, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(1002, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1017, 95, false);
#line 24 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.EditorFor(m => m.Author.FirstName, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1112, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(1180, 59, false);
#line 27 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.Author.Patronymic, "Отчество автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(1239, 73, true);
            WriteLiteral("\r\n            <span class=\"validation-message dark\"></span>\r\n            ");
            EndContext();
            BeginContext(1313, 96, false);
#line 29 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.EditorFor(m => m.Author.Patronymic, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(1477, 46, false);
#line 32 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.Book.Title, "Название: "));

#line default
#line hidden
            EndContext();
            BeginContext(1523, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1538, 94, false);
#line 33 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.ValidationMessageFor(m => m.Book.Title, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(1632, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1647, 89, false);
#line 34 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.EditorFor(m => m.Book.Title, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(1804, 52, false);
#line 37 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.SelectedDepartmentId, "Отдел:"));

#line default
#line hidden
            EndContext();
            BeginContext(1856, 73, true);
            WriteLiteral("\r\n            <span class=\"validation-message dark\"></span>\r\n            ");
            EndContext();
            BeginContext(1930, 143, false);
#line 39 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.DropDownListFor(m => m.SelectedDepartmentId, Model.Departments as SelectList, new { @class = "select-drop-list", id = "department-list" }));

#line default
#line hidden
            EndContext();
            BeginContext(2073, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=input-form-area>\r\n            ");
            EndContext();
            BeginContext(2141, 54, false);
#line 42 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.LabelFor(m => m.SelectedLibraryId, "Библиотека:"));

#line default
#line hidden
            EndContext();
            BeginContext(2195, 73, true);
            WriteLiteral("\r\n            <span class=\"validation-message dark\"></span>\r\n            ");
            EndContext();
            BeginContext(2269, 135, false);
#line 44 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
       Write(Html.DropDownListFor(m => m.SelectedLibraryId, Model.Libraries as SelectList, new { @class = "select-drop-list", id = "library-list" }));

#line default
#line hidden
            EndContext();
            BeginContext(2404, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
            BeginContext(2424, 78, true);
            WriteLiteral("        <input type=\"submit\" class=\"submit-button-gray\" value=\"Сохранить\" />\r\n");
            EndContext();
#line 48 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"

    }

#line default
#line hidden
            BeginContext(2511, 232, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n\r\n        $(\'#library-list\').change(function()\r\n        {\r\n            var id = $(this).val();\r\n            $.ajax({\r\n                type: \'GET\',\r\n                url: \'");
            EndContext();
            BeginContext(2744, 37, false);
#line 62 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\AddBook.cshtml"
                 Write(Url.Action("DepartmentListByLibrary"));

#line default
#line hidden
            EndContext();
            BeginContext(2781, 217, true);
            WriteLiteral("/\',\r\n                data: { index: id },\r\n                success: function (data) {\r\n\r\n                    $(\'#department-list\').replaceWith(data);\r\n                }\r\n            });\r\n        });\r\n    })\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebLib.Models.Repositories.CompositeModels.Books.BookEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
