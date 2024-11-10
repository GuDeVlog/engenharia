// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function confirmaExclusaoJogo(id) {
    if (confirm('Deseja mesmo apagar este jogo?'))
        location.href = '/jogo/delete?id=' + id;
}
