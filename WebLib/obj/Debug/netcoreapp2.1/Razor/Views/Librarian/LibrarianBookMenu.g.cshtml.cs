#pragma checksum "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\LibrarianBookMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f5125cf3cca4d8ed59c883d80ee728e8af011ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Librarian_LibrarianBookMenu), @"mvc.1.0.view", @"/Views/Librarian/LibrarianBookMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Librarian/LibrarianBookMenu.cshtml", typeof(AspNetCore.Views_Librarian_LibrarianBookMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f5125cf3cca4d8ed59c883d80ee728e8af011ea", @"/Views/Librarian/LibrarianBookMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4ecce07a27cd6ebdafd308597dcdecd93f46a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Librarian_LibrarianBookMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 336, true);
            WriteLiteral(@" <div class=""work-page-menu"">
        <nav class=""menu-navigation"">
            <input type=""text"" placeholder=""Поиск"" class=""db-search"">
            <span class=""menu-title"">
                НАВИГАЦИЯ
            </span>
            <ul class=""menu-navigation-items"">
                <li class=""menu-item"">
                    ");
            EndContext();
            BeginContext(337, 90, false);
#line 9 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\LibrarianBookMenu.cshtml"
               Write(Html.ActionLink("Авторы", "Authors", "Librarian", null, new { @class = "menu-item-link" }));

#line default
#line hidden
            EndContext();
            BeginContext(427, 85, true);
            WriteLiteral("\r\n                </li>\r\n                <li class=\"menu-item\">\r\n                    ");
            EndContext();
            BeginContext(513, 87, false);
#line 12 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\LibrarianBookMenu.cshtml"
               Write(Html.ActionLink("Книги", "Books", "Librarian", null, new { @class = "menu-item-link" }));

#line default
#line hidden
            EndContext();
            BeginContext(600, 85, true);
            WriteLiteral("\r\n                </li>\r\n                <li class=\"menu-item\">\r\n                    ");
            EndContext();
            BeginContext(686, 94, false);
#line 15 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\LibrarianBookMenu.cshtml"
               Write(Html.ActionLink("Отделы", "Departments", "Librarian", null, new { @class = "menu-item-link" }));

#line default
#line hidden
            EndContext();
            BeginContext(780, 85, true);
            WriteLiteral("\r\n                </li>\r\n                <li class=\"menu-item\">\r\n                    ");
            EndContext();
            BeginContext(866, 96, false);
#line 18 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\LibrarianBookMenu.cshtml"
               Write(Html.ActionLink("Библиотеки", "Libraries", "Librarian", null, new { @class = "menu-item-link" }));

#line default
#line hidden
            EndContext();
            BeginContext(962, 195, true);
            WriteLiteral("\r\n                </li>\r\n            </ul>\r\n        </nav>\r\n        <footer class=\"work-footer\">\r\n            Copyright (c) 2019<br>\r\n            Created by Margo\r\n        </footer>\r\n    </div>\r\n");
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
