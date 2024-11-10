using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAula.Model
{
    public class AlunoViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public double mensalidade { get; set; }
        public int cidadeId { get; set; }
        public DateTime dataDeNascimento { get; set; }
    }
}
