using api_movimentoManual.Data;
using api_movimentoManual.Model;
using api_movimentoManual.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_movimentoManual.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly AppDbContext _produtoRepository;

        public ProdutoRepository(AppDbContext produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            var produto = await _produtoRepository.PRODUTO.AsNoTracking().ToListAsync();

            return produto;
        }
    }
}
