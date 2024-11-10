using CadAluno.DAO;
using CadAluno.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadAluno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void ValidaAluno(AlunoViewModel a)
        {
            if (a.Id <= 0)
                throw new Exception("Id não pode ser negativo!");
            if (string.IsNullOrEmpty(a.Nome))
                throw new Exception("Informe o nome!");
            if (a.Mensalidade < 0)
                throw new Exception("Mensalidade não pode ser negativa!");
            if (a.CidadeId <= 0)
                throw new Exception("Código da cidade não ser negativo!");
            if (a.DataNascimento > DateTime.Now)
                throw new Exception("Data de nascimento inválida!");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoViewModel a = new AlunoViewModel();
                a.Id = Convert.ToInt32(txtCodigo.Text);
                a.Nome = txtNome.Text;
                a.CidadeId = Convert.ToInt32(txtCidadeId.Text);
                a.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                a.Mensalidade = Convert.ToDouble(txtMensalidade.Text);

                ValidaAluno(a);

                AlunoDAO dao = new AlunoDAO();
                dao.Inserir(a);
            }
            catch (Exception erro)
            {
                if (erro is FormatException)
                    MessageBox.Show("Digite apenas números nos campos numéricos!");
                else MessageBox.Show(erro.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoViewModel a = new AlunoViewModel();
                a.Id = Convert.ToInt32(txtCodigo.Text);
                a.Nome = txtNome.Text;
                a.CidadeId = Convert.ToInt32(txtCidadeId.Text);
                a.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                a.Mensalidade = Convert.ToDouble(txtMensalidade.Text);

                ValidaAluno(a);

                AlunoDAO dao = new AlunoDAO();
                dao.Alterar(a);
            }
            catch (Exception erro)
            {
                if (erro is FormatException)
                    MessageBox.Show("Digite apenas números nos campos numéricos!");
                else MessageBox.Show(erro.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                dao.Excluir(Convert.ToInt32(txtCodigo.Text));
            }
            catch (Exception erro)
            {
                if (erro is FormatException)
                    MessageBox.Show("Digite apenas números nos campos numéricos!");
                else MessageBox.Show(erro.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                AlunoViewModel a = dao.Consultar(Convert.ToInt32(txtCodigo.Text));
                if (a == null)
                    MessageBox.Show("Não encontrado !");
                else
                {
                    txtCodigo.Text = a.Id.ToString();
                    txtNome.Text = a.Nome;
                    txtCidadeId.Text = a.CidadeId.ToString();
                    txtDataNascimento.Text = a.DataNascimento.ToShortDateString();
                    txtMensalidade.Text = a.Mensalidade.ToString();
                }
            }
            catch (Exception erro)
            {
                if (erro is FormatException)
                    MessageBox.Show("Digite apenas números nos campos numéricos!");
                else MessageBox.Show(erro.Message);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                var lista = dao.ConsultarTodosAlunos();
                txtResumo.Clear();
                foreach (var aluno in lista)
                {
                    txtResumo.Text += Environment.NewLine +
                        $"Nome: {aluno.Nome} " +
                        $"Código: {aluno.Id} " +
                        $"Cidade: {aluno.CidadeId} " +
                        $"Data nascimento: {aluno.DataNascimento.ToShortDateString()} " +
                        $"Mensalidade: {aluno.Mensalidade.ToString("c")} ";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
