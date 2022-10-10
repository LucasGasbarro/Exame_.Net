using api_movimentoManual.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service.Interface
{
    public interface IProdutoService
    {
        public Task<List<ProdutoModel>> GetAll();
    }
}
