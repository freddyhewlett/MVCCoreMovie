#pragma checksum "D:\Workplace\MVCCoreMovie\WebUI\Views\Movie\GenreMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9ca9d9b590384177f7f238350d97493028bcb3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_GenreMenu), @"mvc.1.0.view", @"/Views/Movie/GenreMenu.cshtml")]
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
#line 1 "D:\Workplace\MVCCoreMovie\WebUI\Views\_ViewImports.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9ca9d9b590384177f7f238350d97493028bcb3b", @"/Views/Movie/GenreMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37106fa2ab6bb7c306ea2371328db9c86058e300", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_GenreMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Domain.Models.Genre>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"btn-group btn-group-justified\">\r\n");
#nullable restore
#line 6 "D:\Workplace\MVCCoreMovie\WebUI\Views\Movie\GenreMenu.cshtml"
         foreach (var genre in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Workplace\MVCCoreMovie\WebUI\Views\Movie\GenreMenu.cshtml"
       Write(Html.ActionLink(genre.Name, "Browse", "Movie", new { Genre = genre.Name }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Workplace\MVCCoreMovie\WebUI\Views\Movie\GenreMenu.cshtml"
                                                                                                                           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 10 "D:\Workplace\MVCCoreMovie\WebUI\Views\Movie\GenreMenu.cshtml"
   Write(Html.ActionLink("More...", "Index", "Genre", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Domain.Models.Genre>> Html { get; private set; }
    }
}
#pragma warning restore 1591