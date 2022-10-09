using api_movimentoManual.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api_movimentoManual.Controller
{

    [ApiController]
    [Route(template: "v1")]
    public class ProdutoCosif_Controller : ControllerBase
    {
        [EnableCors]
        [HttpGet]
        [Route(template: "produtoCosif")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var produtosCosif = await context.PRODUTO_COSIF.AsNoTracking().ToListAsync();

            return Ok(produtosCosif);
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produtoCosif/{COD_COSIF}")]
        public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbContext context,
        [FromRoute] string COD_COSIF)
        {

            var produtoCosif = await context.
                                    PRODUTO_COSIF.
                                    AsNoTracking().
                                    FirstOrDefaultAsync(x => x.COD_COSIF == COD_COSIF);

            return produtoCosif == null ? NotFound() : Ok(produtoCosif);
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produtoCosif/produto/{COD_PRODUTO}")]
        public async Task<IActionResult> GetByProdutoIdAsync(
        [FromServices] AppDbContext context,
        [FromRoute] string COD_PRODUTO)
        {

            var produtoCosif = await context.
                                    PRODUTO_COSIF.
                                    AsNoTracking().
                                    Where(x => x.COD_PRODUTO == COD_PRODUTO).
                                    ToListAsync();

            return produtoCosif == null ? NotFound() : Ok(produtoCosif);
        }

    }
    
}

