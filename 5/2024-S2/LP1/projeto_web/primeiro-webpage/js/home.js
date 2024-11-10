let validaBuscaCampo = document.getElementById('q');

document.querySelector('#form-busca').onsubmit = function() {
    if (document.querySelector('#q').value == '') {
    document.querySelector('#form-busca').style.background = 'red';
    return false;
    }
};



$('.menu-departamentos li:has(ul) > a').click(function(e) {
    e.preventDefault();
    $(this).next('ul').slideToggle('fast');
});