#pragma checksum "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2efb51356fe685f12086c7347ec321c72c571d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditAuthor), @"mvc.1.0.view", @"/Views/Admin/EditAuthor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/EditAuthor.cshtml", typeof(AspNetCore.Views_Admin_EditAuthor))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2efb51356fe685f12086c7347ec321c72c571d7", @"/Views/Admin/EditAuthor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4ecce07a27cd6ebdafd308597dcdecd93f46a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditAuthor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebLib.Models.AuthorModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
  
    Layout = "_WorkLayout";
    ViewData["Title"] = "WebLib | Изменение автора";

#line default
#line hidden
            BeginContext(92, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(129, 30, false);
#line 8 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
Write(Html.Partial("_AdminBookMenu"));

#line default
#line hidden
            EndContext();
            BeginContext(159, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 10 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
 using (Html.BeginForm("EditAuthor", "Admin", FormMethod.Post, new { @class = "input-wrapper" }))
{
    

#line default
#line hidden
            BeginContext(270, 25, false);
#line 12 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
            EndContext();
            BeginContext(297, 41, true);
            WriteLiteral("    <div class=input-form-area>\r\n        ");
            EndContext();
            BeginContext(339, 48, false);
#line 14 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.LabelFor(m => m.Surname, "Фамилия автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(387, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(398, 91, false);
#line 15 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.ValidationMessageFor(m => m.Surname, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(489, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(500, 86, false);
#line 16 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.EditorFor(m => m.Surname, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(586, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=input-form-area>\r\n        ");
            EndContext();
            BeginContext(642, 46, false);
#line 19 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.LabelFor(m => m.FirstName, "Имя автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(688, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(699, 93, false);
#line 20 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.ValidationMessageFor(m => m.FirstName, null, new { @class = "validation-message dark" }));

#line default
#line hidden
            EndContext();
            BeginContext(792, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(803, 88, false);
#line 21 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.EditorFor(m => m.FirstName, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(891, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=input-form-area>\r\n        ");
            EndContext();
            BeginContext(947, 52, false);
#line 24 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.LabelFor(m => m.Patronymic, "Отчество автора:"));

#line default
#line hidden
            EndContext();
            BeginContext(999, 65, true);
            WriteLiteral("\r\n        <span class=\"validation-message dark\"></span>\r\n        ");
            EndContext();
            BeginContext(1065, 89, false);
#line 26 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
   Write(Html.EditorFor(m => m.Patronymic, new { htmlAttributes = new { @class = "input-form" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1154, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
            BeginContext(1172, 74, true);
            WriteLiteral("    <input type=\"submit\" class=\"submit-button-gray\" value=\"Сохранить\" />\r\n");
            EndContext();
#line 31 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Admin\EditAuthor.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebLib.Models.AuthorModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
