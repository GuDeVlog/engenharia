using CadJogos1.DAO;
using CadJogos1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadJogos1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                JogoViewModel j = new JogoViewModel();
                j.Id = Convert.ToInt32(txtId.Text);
                j.Descricao = txtDescricao.Text;
                j.Valor = Convert.ToDouble(txtPreco.Text);
                j.CategoriaId = Convert.ToInt32(txtCategoria.Text);
                j.Data = Convert.ToDateTime(txtData.Text);

                JogoDAO dao = new JogoDAO();
                dao.Incluir(j);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            try
            {
                JogoViewModel j = new JogoViewModel();
                j.Id = Convert.ToInt32(txtId.Text);
                j.Descricao = txtDescricao.Text;
                j.Valor = Convert.ToDouble(txtPreco.Text);
                j.CategoriaId = Convert.ToInt32(txtCategoria.Text);
                j.Data = Convert.ToDateTime(txtData.Text);


                JogoDAO dao = new JogoDAO();
                dao.Alterar(j);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja mesmo apagar?",
                "atenção!!!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    JogoDAO dao = new JogoDAO();
                    dao.Excluir(Convert.ToInt32(txtId.Text));
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                var j = dao.Consulta(Convert.ToInt32(txtId.Text));
                if (j == null)
                    MessageBox.Show("Jogo não existe");
                else
                {
                    txtId.Text = j.Id.ToString();
                    txtDescricao.Text = j.Descricao;
                    txtPreco.Text = j.Valor.ToString();
                    txtCategoria.Text = j.CategoriaId.ToString();
                    txtData.Text = j.Data.ToShortDateString();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                var lista = dao.Listar();
                dataGridView1.DataSource = lista;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
