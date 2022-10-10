using api_movimentoManual.Data;
using api_movimentoManual.Model;
using api_movimentoManual.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movimentoManual.Repository
{
    public class ProdutoCosifRepository : IProdutoCosifRepository
    {
        private readonly AppDbContext _produtoCosifRepository;

        public ProdutoCosifRepository(AppDbContext produtoCosifRepository)
        {
            _produtoCosifRepository = produtoCosifRepository;
        }

        public Task<List<ProdutoCosifModel>> GetAll()
        {
            var produtosCosif = _produtoCosifRepository.PRODUTO_COSIF.AsNoTracking().ToListAsync();

            return produtosCosif;
        }

        public Task<List<ProdutoCosifModel>> GetByProduto(string cod_produto)
        {
            var produtosCosif = _produtoCosifRepository.PRODUTO_COSIF.AsNoTracking().Where(w => w.COD_PRODUTO == cod_produto).ToListAsync();

            return produtosCosif;
        }
    }
}
