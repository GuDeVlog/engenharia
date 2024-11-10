function consultar() {
    var estado = $("#estado").val();
    var cidade = $("#cidade").val();
    var rua = $("#rua").val();
    $.ajax({
        url: "/home/ConsultaEndereco",
        data: { estado: estado, cidade: cidade, rua: rua },
        dataType: "json",
        success: function (resultados) {
            if (resultados.erro != undefined) {
                alert(resultados.msg);
            }
            else {
                var html = "<table class='table table-striped'>";
                html += "<tr>";
                html += "<th>CEP</th> <th>Logradouro</th> <th>Bairro</th>"
                html += "</tr>";
                for (var n = 0; n < resultados.length; n++) {
                    html += "<tr>";
                    html += "<td>" + resultados[n].cep + "</td>"
                    html += "<td>" + resultados[n].logradouro + "</td>"
                    html += "<td>" + resultados[n].bairro + "</td>"
                    html += "</tr>";
                }
                html += "</table>";
                $("#resultado").html(html);
            }
        }
    });
}