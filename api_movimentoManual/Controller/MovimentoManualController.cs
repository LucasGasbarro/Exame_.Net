using api_movimentoManual.Data;
using api_movimentoManual.Model;
using api_movimentoManual.Models;
using api_movimentoManual.Service;
using api_movimentoManual.Service.Interface;
using api_movimentoManual.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace api_movimentoManual.Controller
{
    [ApiController]
    [Route(template: "v1")]
    public class MovimentoManualController : ControllerBase
    {

        private readonly IMovimentoManualService _movimentoManualService;

        public MovimentoManualController(IMovimentoManualService movimentoManualService)
        {
            _movimentoManualService = movimentoManualService;
        }

        [EnableCors]
        [HttpGet]
        [Route(template: "movimentosManual")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var movManuais = await _movimentoManualService.GetAll();

            return Ok(movManuais);
        }

        [EnableCors]
        [HttpPost]
        [Route(template: "movimentosManual")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] Create_MoviManu_ViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movimentacaoManual = new MovimentoManualModel
            {
                DAT_MES = Convert.ToInt32(model.DAT_MES),
                DAT_ANO = Convert.ToInt32(model.DAT_ANO),
                NUM_LANCAMENTO = Get_NumLancamento(model.DAT_MES, model.DAT_ANO),
                COD_PRODUTO = model.COD_PRODUTO,
                COD_COSIF = model.COD_COSIF,
                DES_DESCRICAO = model.DES_DESCRICAO,
                DAT_MOVIMENTO = DateTime.Now,
                COD_USUARIO = "TESTE",
                VAL_VALOR = Convert.ToDecimal(model.VAL_VALOR)
            };

            try
            {
                await context.MOVIMENTO_MANUAL.AddAsync(movimentacaoManual);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        private int Get_NumLancamento(int mes, int ano)
        {
            int output = 0;

            try
            {
                output = _movimentoManualService.GetNumLancamento(mes, ano);
            }
            catch (Exception)
            {
                throw;
            }

            return output;
        }
    }
}
