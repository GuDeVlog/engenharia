using cadFuncionarioMVC_V1.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadFuncionarioMVC_V1.Models
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public EnumTipoFuncionario Tipo { get; set; }

    }
}
