using api_movimentoManual.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Repository.Interface
{
    public interface IProdutoRepository
    {
        public Task<List<ProdutoModel>> GetAll();
    }
}
