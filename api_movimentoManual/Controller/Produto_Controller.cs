using api_movimentoManual.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api_movimentoManual.Controller
{
 
    [ApiController]
    [Route(template: "v1")]
    public class Produto_Controller : ControllerBase
    {
        [EnableCors]
        [HttpGet]
        [Route(template: "produto")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var produtos = await context.PRODUTO.AsNoTracking().ToListAsync();

            return Ok(produtos);
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produto/{COD_PRODUTO}")]
        public async Task<IActionResult> GetByIdAsync(
                [FromServices] AppDbContext context,
                [FromRoute] string COD_PRODUTO)
        {
            var produto = await context.
                                PRODUTO.
                                AsNoTracking().
                                FirstOrDefaultAsync(x => x.COD_PRODUTO == COD_PRODUTO);

            return produto == null ? NotFound() : Ok(produto);
        }

    }
}
