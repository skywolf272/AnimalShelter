#pragma checksum "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa73473faf7b4d2ef35f8899367cdcce2ac7e208"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CurrentNew), @"mvc.1.0.view", @"/Views/Home/CurrentNew.cshtml")]
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
#line 1 "C:\Programming\ASP\DogShelter\DogShelter\Views\_ViewImports.cshtml"
using DogShelter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programming\ASP\DogShelter\DogShelter\Views\_ViewImports.cshtml"
using DogShelter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa73473faf7b4d2ef35f8899367cdcce2ac7e208", @"/Views/Home/CurrentNew.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf5f4cc15da546d67f80e4f3e1ec0cad8f1ab5a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CurrentNew : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DogShelter.Models.News>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\" style=\"width:80%\">\r\n");
#nullable restore
#line 4 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
      
        if (Model != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2 class=\"font-weight-bold\">\r\n                ");
#nullable restore
#line 8 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h2>\r\n            <p class=\"font-weight-light\">\r\n                    ");
#nullable restore
#line 11 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
               Write(Model.NewsDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 11 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
                                    Write(Model.NewsDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 11 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
                                                          Write(Model.NewsDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <p>\r\n                ");
#nullable restore
#line 14 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
           Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <img style=\" height: 500px;\"");
            BeginWriteAttribute("src", " src=\"", 464, "\"", 484, 1);
#nullable restore
#line 16 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
WriteAttributeValue("", 470, Model.ImgPath, 470, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 17 "C:\Programming\ASP\DogShelter\DogShelter\Views\Home\CurrentNew.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DogShelter.Models.News> Html { get; private set; }
    }
}
#pragma warning restore 1591
