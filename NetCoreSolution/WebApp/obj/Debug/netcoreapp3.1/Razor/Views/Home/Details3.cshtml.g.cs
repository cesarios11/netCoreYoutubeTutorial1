#pragma checksum "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4a39edb0480a17351fc8f8ef69fbcdea0448bb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details3), @"mvc.1.0.view", @"/Views/Home/Details3.cshtml")]
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
#line 6 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\_ViewImports.cshtml"
using WebApp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4a39edb0480a17351fc8f8ef69fbcdea0448bb4", @"/Views/Home/Details3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d5c79bd31abb7b2ace1eee61c37fd5b8742b34f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Details3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Amigo>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
    
    ViewBag.Title = "Details 3";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 6 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
Write(ViewData["cabecera"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 7 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
  
    var _modelo = ViewData["amigo1"] as WebApp.Models.Amigo;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <label>Nombre: </label><label>");
#nullable restore
#line 11 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(_modelo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Email: </label><label>");
#nullable restore
#line 12 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                            Write(_modelo.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Ciudad: </label><label>");
#nullable restore
#line 13 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(_modelo.Ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n</div>\r\n<br />\r\n<h2>");
#nullable restore
#line 16 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
Write(ViewBag.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>    \r\n<div>\r\n    <label>Nombre: </label><label>");
#nullable restore
#line 18 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(ViewBag.Amigo2.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Email: </label><label>");
#nullable restore
#line 19 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                            Write(ViewBag.Amigo2.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Ciudad: </label><label>");
#nullable restore
#line 20 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(ViewBag.Amigo2.Ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n</div>\r\n<br />\r\n<h2>Fuertemente tipado</h2>\r\n<div>\r\n    <label>Nombre: </label><label>");
#nullable restore
#line 25 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Email: </label><label>");
#nullable restore
#line 26 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                            Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n    <label>Ciudad: </label><label>");
#nullable restore
#line 27 "C:\Users\Administrador\Documents\CESARIOS\UDEMY\GIT GITHUB\netCoreRepo\tutorial1\NetCoreSolution\WebApp\Views\Home\Details3.cshtml"
                             Write(Model.Ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Amigo> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
