#pragma checksum "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC v8 - Controle de Acesso\CadAlunoMVC\Views\Shared\Error.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f2d74c6c44f8415c4183fc5b443813d217b1db16277ed6ff3dbb2a8c3a22bf09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC v8 - Controle de Acesso\CadAlunoMVC\Views\_ViewImports.cshtml"
using CadAlunoMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC v8 - Controle de Acesso\CadAlunoMVC\Views\_ViewImports.cshtml"
using CadAlunoMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f2d74c6c44f8415c4183fc5b443813d217b1db16277ed6ff3dbb2a8c3a22bf09", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"920eddd16055001f106ef38d389e50d42a2834e714f4cae3e3c7f1420f883f57", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC v8 - Controle de Acesso\CadAlunoMVC\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Ocorreu um erro!</h1>\r\n<h2 class=\"text-danger\">Infelizmente um erro ocorreu em sua solicitação. \r\n    <br />\r\n    Tente novamente mais tarde...\r\n</h2>\r\n\r\n<h3>Informação para  o desenvolvedor:</h3>\r\n<span class=\"code\">\r\n    ");
#nullable restore
#line 14 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC v8 - Controle de Acesso\CadAlunoMVC\Views\Shared\Error.cshtml"
Write(Model.Erro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</span>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
