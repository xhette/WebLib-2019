#pragma checksum "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\DepartmentsByLibrary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57747ff1e305b8d0fa25fc1c234e250f2cd5528f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Librarian_DepartmentsByLibrary), @"mvc.1.0.view", @"/Views/Librarian/DepartmentsByLibrary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Librarian/DepartmentsByLibrary.cshtml", typeof(AspNetCore.Views_Librarian_DepartmentsByLibrary))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57747ff1e305b8d0fa25fc1c234e250f2cd5528f", @"/Views/Librarian/DepartmentsByLibrary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4ecce07a27cd6ebdafd308597dcdecd93f46a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Librarian_DepartmentsByLibrary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebLib.Models.DepartmentModel>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 86, true);
            WriteLiteral("\r\n<select id=\"department-list\" name=\"SelectedDepartmentId\" class=\"select-drop-list\">\r\n");
            EndContext();
#line 4 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\DepartmentsByLibrary.cshtml"
     foreach (WebLib.Models.DepartmentModel item in Model)
    {

#line default
#line hidden
            BeginContext(204, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(212, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e973b07a3b01439caa8fe8e9d24e4a2b", async() => {
                BeginContext(238, 9, false);
#line 6 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\DepartmentsByLibrary.cshtml"
                            Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 6 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\DepartmentsByLibrary.cshtml"
           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(256, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "Q:\stydying\3K2S\BD\mine\WebLib\WebLib\Views\Librarian\DepartmentsByLibrary.cshtml"
    }

#line default
#line hidden
            BeginContext(265, 11, true);
            WriteLiteral("</select>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebLib.Models.DepartmentModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
