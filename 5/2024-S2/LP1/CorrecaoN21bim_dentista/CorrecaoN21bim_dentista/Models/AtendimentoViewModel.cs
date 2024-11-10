using System;
using System.Security.Permissions;

namespace CorrecaoN21bim_dentista.Models
{
    public class AtendimentoViewModel
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataProcedimento { get; set; }
        public int TipoProcedimento { get; set; }
        public string Observacoes { get; set; }
        public double Preco { get; set; }
    }
}
