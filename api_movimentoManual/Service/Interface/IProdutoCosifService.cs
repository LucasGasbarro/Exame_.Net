using api_movimentoManual.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service.Interface
{
    public interface IProdutoCosifService
    {
        public Task<List<ProdutoCosifModel>> GetAll();
        public Task<List<ProdutoCosifModel>> GetByProduto(string cod_produto);
    }
}
