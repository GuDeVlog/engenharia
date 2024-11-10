function apagar(id) {
    swal({
        title: "Confirma?",
        text: "Você deseja mesmo apagar este registro?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Apagar",
        cancelButtonText: "Não!",
        closeOnConfirm: true
    },
        function () {
            location.href = '/funcionario/apagar?id=' + id;
        });

}