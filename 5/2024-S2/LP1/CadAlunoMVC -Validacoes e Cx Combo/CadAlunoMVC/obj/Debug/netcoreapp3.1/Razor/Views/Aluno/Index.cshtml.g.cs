#pragma checksum "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1bd1af5dcbae5594b1128f3eb5f989fb620d2efb42e4badf9e4bbeadecdef97e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aluno_Index), @"mvc.1.0.view", @"/Views/Aluno/Index.cshtml")]
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
#line 1 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\_ViewImports.cshtml"
using CadAlunoMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\_ViewImports.cshtml"
using CadAlunoMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1bd1af5dcbae5594b1128f3eb5f989fb620d2efb42e4badf9e4bbeadecdef97e", @"/Views/Aluno/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"920eddd16055001f106ef38d389e50d42a2834e714f4cae3e3c7f1420f883f57", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Aluno_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AlunoViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    //var nome = prompt('Qual é o seu nome?')
    //alert(nome);
    //alert(""Seja bem vindo ao cadastro de usuários!"");
</script>

<h2>Listagem de Alunos</h2>

<a href=""/aluno/create"" class=""btn btn-info"">Novo Registro</a>
<br />

<table class=""table table-responsive table-striped"">
    <tr>
        <th>Ações</th>
        <th>RA</th>
        <th>Nome</th>
        <th>Data de nascimento</th>
        <th>Mensalidade</th>
    </tr>
");
#nullable restore
#line 25 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
     foreach (var aluno in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 639, "\"", 670, 2);
            WriteAttributeValue("", 646, "/aluno/edit?id=", 646, 15, true);
#nullable restore
#line 29 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
WriteAttributeValue("", 661, aluno.Id, 661, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n                    <img src=\"/img/edit_48.png\" class=\"iconeAluno\" />\r\n                </a>\r\n                &nbsp;&nbsp;\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 816, "\"", 851, 3);
            WriteAttributeValue("", 823, "javascript:apagar(", 823, 18, true);
#nullable restore
#line 33 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
WriteAttributeValue("", 841, aluno.Id, 841, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 850, ")", 850, 1, true);
            EndWriteAttribute();
            WriteLiteral(" >\r\n                    <img src=\"/img/delete_48.png\" class=\"iconeAluno\" />\r\n                </a>\r\n            </td>\r\n            <td>");
#nullable restore
#line 37 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
           Write(aluno.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
           Write(aluno.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
           Write(aluno.DataNascimento.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
           Write(aluno.Mensalidade?.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 42 "W:\Professores\Prof. Eduardo\2024-S2\LP1\CadAlunoMVC -Validacoes e Cx Combo\CadAlunoMVC\Views\Aluno\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n<script>\r\n    function apagar(id) {\r\n        if (confirm(\'Deseja apagar?\'))\r\n            location.href = \'/aluno/delete?id=\' + id;\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AlunoViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
