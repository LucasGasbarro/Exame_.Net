using api_movimentoManual.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service.Interface
{
    public interface IMovimentoManualService
    {
        public Task<List<MovimentoManualModel>> GetAll();
        public int GetNumLancamento(int mes, int ano);
    }
}
