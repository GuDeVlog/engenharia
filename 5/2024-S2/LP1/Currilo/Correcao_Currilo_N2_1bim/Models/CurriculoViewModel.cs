using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correcao_Currilo_N2_1bim.Models
{
    public class CurriculoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public double PretensaoSalarial { get; set; }
        public string CargoPretendido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Resumo { get; set; }
        public string FormacaoAcademica1 { get; set; }
        public string FormacaoAcademica2 { get; set; }
        public string Idioma1 { get; set; }
        public string Idioma2 { get; set; }


        public int Idade
        {
            get => (int)(DateTime.Now.Subtract(DataNascimento).TotalDays / 365);
        }
    }
}
