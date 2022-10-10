using api_movimentoManual.Model;
using api_movimentoManual.Repository.Interface;
using api_movimentoManual.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Service
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            var produto = await _produtoRepository.GetAll();

            return produto;
        }
    }
}
