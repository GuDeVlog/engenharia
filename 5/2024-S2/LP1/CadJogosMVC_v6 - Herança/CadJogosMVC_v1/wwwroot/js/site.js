function excluirJogo(id) {
    if (confirm('Confirma a exclusão do jogo?'))
        location.href = "/jogo/delete?id=" + id;
}



function aplicaFiltroConsultaAvancada() {
    var vDescricao = document.getElementById('descricao').value;
    var vCategoria = document.getElementById('categoria').value;
    var vDataInicial = document.getElementById('dataInicial').value;
    var vDataFinal = document.getElementById('dataFinal').value;
    $.ajax({
        url: "/jogo/ObtemDadosConsultaAvancada",
        data: { descricao: vDescricao, categoria: vCategoria, dataInicial: vDataInicial, dataFinal: vDataFinal },
        success: function (dados) {
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });
}