using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cadFuncionarioMVC_V1.Enumeradores
{
    public enum EnumTipoFuncionario
    {        
        [Display(Name ="Vendedor")]
        vendedor = 'V',

        [Display(Name = "Gerente")]
        gerente = 'G',
        
        [Display(Name = "Engenheiro")]
        engenheiro = 'E',

        [Display(Name = "Analista de Sistemas Sênior")]
        analistaSistemas = 'A',


        [Display(Name = "Outros")]
        outros = 'O'
    }
}
