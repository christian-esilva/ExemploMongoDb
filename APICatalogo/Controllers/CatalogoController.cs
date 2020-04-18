using APICatalogo.Context;
using APICatalogo.Models;
using CargaCatalogo;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("api")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly CatalogoContext _catalogoContext;

        public CatalogoController(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        [HttpGet("produtos/{codigo}")]
        public IActionResult GetProduto(string codigo)
        {
            Produto prod = null;
            if (codigo.StartsWith("p"))
                prod = _catalogoContext.GetItems<Produto>(codigo);

            if (prod != null)
                return new ObjectResult(prod);
            else
                return NotFound();
        }

        [HttpGet("servicos/{codigo}")]
        public IActionResult GetServico(string codigo)
        {
            Servico servico = null;
            if (codigo.StartsWith("s"))
                servico = _catalogoContext.GetItems<Servico>(codigo);

            if (servico != null)
                return new ObjectResult(servico);
            else
                return NotFound();
        }
    }
}
