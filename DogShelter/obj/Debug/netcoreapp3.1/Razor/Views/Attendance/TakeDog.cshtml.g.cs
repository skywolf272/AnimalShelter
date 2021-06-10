#pragma checksum "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "864401c52669fdba4c0cafa68749dfd24a434584"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attendance_TakeDog), @"mvc.1.0.view", @"/Views/Attendance/TakeDog.cshtml")]
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
#line 1 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\_ViewImports.cshtml"
using DogShelter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\_ViewImports.cshtml"
using DogShelter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"864401c52669fdba4c0cafa68749dfd24a434584", @"/Views/Attendance/TakeDog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf5f4cc15da546d67f80e4f3e1ec0cad8f1ab5a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Attendance_TakeDog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DogShelter.Models.Dog>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary bg-primary text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Attendance", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MoreAboutDog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"d-flex mt-3 flex-wrap\">\r\n");
#nullable restore
#line 4 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
         foreach (Dog dog in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"box-shadow rounded shadow-lg d-flex m-3\" style=\"max-height: 350px; width: 900px;\">\r\n            <img class=\"rounded\" style=\"height: 100%; background-size: cover;\"");
            BeginWriteAttribute("src", " src=\"", 316, "\"", 334, 1);
#nullable restore
#line 7 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
WriteAttributeValue("", 322, dog.ImgPath, 322, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-holder-rendered=\"true\">\r\n\r\n            <ul class=\"list-group list-group-flush p-4\" style=\"width: 100%\">\r\n                <h3>");
#nullable restore
#line 10 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
               Write(dog.Nickname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <li class=\"list-group-item\">Возраст: ");
#nullable restore
#line 11 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                                Write(dog.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 12 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                  
                    if (dog.Male)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item\">Пол: мужской</li>\r\n");
#nullable restore
#line 16 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item\">Пол: женский</li>\r\n");
#nullable restore
#line 20 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">Краткое описание: ");
#nullable restore
#line 22 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                                         Write(dog.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <div class=\"d-flex p-3 justify-content-between align-items-center\">\r\n                    <div class=\"btn-group\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "864401c52669fdba4c0cafa68749dfd24a4345847067", async() => {
                WriteLiteral("Узнать больше");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                                                                                                                                  WriteLiteral(dog.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <small class=\"text-muted\">");
#nullable restore
#line 27 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                         Write(dog.DogPostDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 27 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                                              Write(dog.DogPostDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 27 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
                                                                                     Write(dog.DogPostDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                </div>\r\n            </ul>\r\n        </div>\r\n");
#nullable restore
#line 31 "C:\programming\c# ASP\AnimalShelter\DogShelter\Views\Attendance\TakeDog.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DogShelter.Models.Dog>> Html { get; private set; }
    }
}
#pragma warning restore 1591
