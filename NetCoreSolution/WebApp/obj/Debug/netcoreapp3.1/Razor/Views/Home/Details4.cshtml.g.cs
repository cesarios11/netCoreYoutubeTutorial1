#pragma checksum "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa64ad220364973e904b6a2ff531e47e0dc443cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details4), @"mvc.1.0.view", @"/Views/Home/Details4.cshtml")]
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
#line 6 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\_ViewImports.cshtml"
using WebApp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa64ad220364973e904b6a2ff531e47e0dc443cf", @"/Views/Home/Details4.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f69a98cc6b1963eb5c509e6cbcebe8fe295c122", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Details4 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetallesView>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/myscript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
     
    ViewBag.Title = "Amigos detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 6 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
Write(Model.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 7 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
Write(Model.Subtitulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<div>\r\n    <label>Nombre: </label><label>");
#nullable restore
#line 9 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
                             Write(Model.Amigo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Email: </label><label>");
#nullable restore
#line 10 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
                            Write(Model.Amigo.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Ciudad: </label><label>");
#nullable restore
#line 11 "C:\Users\Lenovo\Documents\CESARIOS\GIT HUB REPO\NET CORE\YOUTUBE TUTORIAL 1\NetCoreSolution\WebApp\Views\Home\Details4.cshtml"
                             Write(Model.Amigo.Ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa64ad220364973e904b6a2ff531e47e0dc443cf5846", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetallesView> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
