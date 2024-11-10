using CadastroAlunoV1.DAO;
using CadastroAlunoV1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAlunoV1.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                List<AlunoViewModel> lista = dao.Listagem();
                return View(lista);

            }
            catch (Exception ex) 
            { 
                return View("error", ex.ToString());
            }
        }

        public IActionResult Create()
        {
            AlunoViewModel aluno = new AlunoViewModel();
            aluno.DataNascimento = DateTime.Now;
            return View("Form", aluno);
        }
        public IActionResult Salvar(AlunoViewModel aluno)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                dao.Inserir(aluno);
                return RedirectToAction("index");

            }
            catch (Exception erro)
            {
            return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
