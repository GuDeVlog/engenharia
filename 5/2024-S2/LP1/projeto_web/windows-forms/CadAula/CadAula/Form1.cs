using CadAula.Model;
using CadAula.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadAula
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ValidaAluno(AlunoViewModel a)
        {
            if (a.id < 0)
                throw new Exception("Id não pode ser negativo!");
            if (string.IsNullOrEmpty(a.nome))
                throw new Exception("Informe o nome!");
            if (a.mensalidade < 0)
                throw new Exception("Mensalidade não pode ser negativa!");
            if (a.cidadeId <= 0)
                throw new Exception("Código da cidade não pode ser negativo!");
            if (a.dataDeNascimento > DateTime.Now)
                throw new Exception("Data de nascimento inválida!");
        }

        private AlunoViewModel PreencheDadosVO()
        {
            AlunoViewModel aluno = new AlunoViewModel
            {
                id = Convert.ToInt32(textBox6.Text),
                cidadeId = Convert.ToInt32(textBox10.Text),
                mensalidade = Convert.ToDouble(textBox8.Text),
                nome = textBox7.Text,
                dataDeNascimento = DateTime.ParseExact(textBox9.Text, "dd/MM/yyyy", null) //salva a data no padrão dia/mes/ano
            };
            return aluno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoViewModel aluno = PreencheDadosVO();
                ValidaAluno(aluno);
                AlunoDAO dao = new AlunoDAO();
                dao.Inserir(aluno);
                MessageBox.Show("Aluno inserido com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoViewModel aluno = PreencheDadosVO();
                ValidaAluno(aluno);
                AlunoDAO dao = new AlunoDAO();
                dao.Alterar(aluno);
                MessageBox.Show("Aluno alterado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int alunoId = Convert.ToInt32(textBox6.Text);
                AlunoDAO dao = new AlunoDAO();
                dao.Excluir(alunoId);
                MessageBox.Show("Aluno excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

    }
}
