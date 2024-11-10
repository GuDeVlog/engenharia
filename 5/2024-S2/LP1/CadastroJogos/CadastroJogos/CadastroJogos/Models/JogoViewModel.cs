using System;

namespace CadastroJogos.Models
{
    public class JogoViewModel
    {
        
            public int Id { get; set; }
            public string Descricao { get; set; }
            public double Valor { get; set; }
          
            public DateTime DataLocacao { get; set; }
        
    }
}
