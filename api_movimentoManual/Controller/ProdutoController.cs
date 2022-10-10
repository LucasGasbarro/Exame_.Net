using api_movimentoManual.Data;
using api_movimentoManual.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api_movimentoManual.Controller
{
 
    [ApiController]
    [Route(template: "v1")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "produto")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var produtos = _produtoService.GetAll();

            return Ok(produtos.Result);
        }
    }
}
