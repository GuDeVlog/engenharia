using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerramentasASPNet.Models
{
    public class FerramentaViewModel
    {
        
        public int Id { get; set; }

        
        public string Descricao { get; set; }

        
        public int FabricanteId { get; set; }
    }
}
