using System;

namespace cadFuncionarioMVC_V1.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Erro { get; set; }
        public ErrorViewModel() { }
        public ErrorViewModel(string erro) {
            this.Erro = erro;
        }



    }
}
