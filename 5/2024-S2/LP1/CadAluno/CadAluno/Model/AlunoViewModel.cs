using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAluno.Model
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Mensalidade { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
