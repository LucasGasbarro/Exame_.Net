using api_movimentoManual.Models;
using api_movimentoManual.Repository.Interface;
using api_movimentoManual.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service
{
    public class MovimentoManualService : IMovimentoManualService
    {
        private readonly IMovimentoManualRepository _movimentoManualRepository;

        public MovimentoManualService(IMovimentoManualRepository movimentoManualRepository)
        {
            _movimentoManualRepository = movimentoManualRepository;
        }

        public async Task<List<MovimentoManualModel>> GetAll()
        {
            var movManuais = await _movimentoManualRepository.GetAll();

            return movManuais;
        }

        public int GetNumLancamento(int mes, int ano)
        {
            return _movimentoManualRepository.GetNumLancamento(mes, ano);

        }
    }
}
