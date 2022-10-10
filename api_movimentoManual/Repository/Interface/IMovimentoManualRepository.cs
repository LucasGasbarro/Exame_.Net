using api_movimentoManual.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Repository.Interface
{
    public interface IMovimentoManualRepository
    {
        public Task<List<MovimentoManualModel>> GetAll();
        public int GetNumLancamento(int mes, int ano);
    }
}
