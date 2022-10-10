using api_movimentoManual.Model;
using api_movimentoManual.Repository.Interface;
using api_movimentoManual.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service
{
    public class ProdutoCosifService : IProdutoCosifService
    {
        private readonly IProdutoCosifRepository _produtoCosifRepository;

        public ProdutoCosifService(IProdutoCosifRepository produtoCosifRepository)
        {
            _produtoCosifRepository = produtoCosifRepository;
        }

        public async Task<List<ProdutoCosifModel>> GetAll()
        {
            var produtoCosif = await _produtoCosifRepository.GetAll();
            
            return produtoCosif;
        }

        public async Task<List<ProdutoCosifModel>> GetByProduto(string cod_produto)
        {
            var produCosif = await _produtoCosifRepository.GetByProduto(cod_produto);

            return produCosif;
        }
    }
}
