document.getElementById('contato-form').addEventListener('submit', function(e) {
    e.preventDefault(); // Impede o envio padrão do formulário

    // Exibe o pop-up de agradecimento
    alert('Obrigado pelo seu contato! Em breve, nossa equipe entrará em contato.');

    // Limpa os dados do formulário
    e.target.reset();
});