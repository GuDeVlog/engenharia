﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogos1.Model
{
    public class JogoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor  { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
    }
}
