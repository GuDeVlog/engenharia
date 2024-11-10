using Calculadora_Potencia_ex_10._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Potencia_ex_10._1
{
    public partial class Form1 : Form
    {
        private ComboBox comboBoxJogos;


        public Form1()
        {
            InitializeComponent();
            // Certifique-se de que o comboBoxJogos já foi adicionado através do designer
            // Preenche o ComboBox e configura o manipulador de eventos
            PreencherComboBox();
            comboBox1.SelectedIndexChanged += comboBoxJogos_SelectedIndexChanged;
        }

        // Método para preencher o ComboBox
        private void PreencherComboBox()
        {
            // Crie uma lista de objetos JogoViewModel
            List<JogoViewModel> jogos = new List<JogoViewModel>
            {
                new JogoViewModel { Id = 1, Descricao = "Futebol de Campo - Campeonato Local", Categoria = "Futebol" },
                new JogoViewModel { Id = 2, Descricao = "Futsal - Torneio Escolar", Categoria = "Futsal" },
                new JogoViewModel { Id = 3, Descricao = "Society - Liga Amadora", Categoria = "Futebol" },
                new JogoViewModel { Id = 4, Descricao = "Tênis - Campeonato Regional", Categoria = "Tênis" }
            };


            // Atribua a lista ao ComboBox
            comboBox1.DataSource = jogos;

            // Defina qual propriedade será exibida e qual será o valor interno do ComboBox
            comboBox1.DisplayMember = "Categoria";  // Exibe a descrição do jogo
            comboBox1.ValueMember = "Id";           // O valor interno será o Id do jogo
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxJogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera o jogo selecionado
            JogoViewModel jogoSelecionado = (JogoViewModel)comboBox1.SelectedItem;

            if (jogoSelecionado != null)
            {
                MessageBox.Show($"Jogo selecionado: {jogoSelecionado.Descricao}, Valor de Locação: {jogoSelecionado.ValorLocacao}");
            }
        }
    }
}
