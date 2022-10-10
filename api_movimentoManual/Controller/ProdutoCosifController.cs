using api_movimentoManual.Data;
using api_movimentoManual.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api_movimentoManual.Controller
{

    [ApiController]
    [Route(template: "v1")]
    public class ProdutoCosifController : ControllerBase
    {
        private readonly IProdutoCosifService _produtoCosifService;

        public ProdutoCosifController(IProdutoCosifService produtoCosifService)
        {
            _produtoCosifService = produtoCosifService;
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produtoCosif")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var produtosCosif = await _produtoCosifService.GetAll();

            return Ok(produtosCosif);
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produtoCosif/produto/{COD_PRODUTO}")]
        public async Task<IActionResult> GetByProdutoIdAsync(
        [FromServices] AppDbContext context,
        [FromRoute] string COD_PRODUTO)
        {

            var produtoCosif = await _produtoCosifService.GetByProduto(COD_PRODUTO);

            return produtoCosif == null ? NotFound() : Ok(produtoCosif);
        }

    }
    
}

