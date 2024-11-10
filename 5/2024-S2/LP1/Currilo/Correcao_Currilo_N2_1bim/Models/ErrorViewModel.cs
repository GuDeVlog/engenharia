using System;

namespace Correcao_Currilo_N2_1bim.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Erro { get; set; }

        public ErrorViewModel(string erro)
        {
            Erro = erro;
        }

        public ErrorViewModel()
        {
        }
    }
}
