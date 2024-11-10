function apagarPaciente(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = '/paciente/Delete?id=' + id;
} 


function apagarAtendimento(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = '/atendimento/Delete?id=' + id;
} 