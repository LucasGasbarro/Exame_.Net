using api_movimentoManual.Data;
using api_movimentoManual.Models;
using api_movimentoManual.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movimentoManual.Repository
{
    public class MovimentoManualRepository : IMovimentoManualRepository
    {
        private readonly AppDbContext _movimentoManualRepository;

        public MovimentoManualRepository(AppDbContext movimentoManualRepository)
        {
            _movimentoManualRepository = movimentoManualRepository;
        }

        public async Task<List<MovimentoManualModel>> GetAll()
        {
            var movManuais = await _movimentoManualRepository.MOVIMENTO_MANUAL.AsNoTracking().Include(p => p.Produto).ToListAsync();

            return movManuais;
        }

        public int GetNumLancamento(int mes, int ano)
        {
            return _movimentoManualRepository.MOVIMENTO_MANUAL.AsNoTracking().Where(w => w.DAT_MES == mes && w.DAT_ANO == ano).Count() + 1;
        }
    }
}
