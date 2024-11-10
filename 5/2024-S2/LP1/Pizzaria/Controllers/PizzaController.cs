

using Pizzaria.DAO;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    public class PizzaController : PadraoController<PizzaViewModel>
    {
        public PizzaController()
        {
            DAO = new PizzaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(PizzaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Preencha o nome da pizza.");
        }
    }
}
