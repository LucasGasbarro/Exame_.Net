using api_movimentoManual.Model;
using api_movimentoManual.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace api_movimentoManual.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> PRODUTO { get; set; }
        public DbSet<Produto_Cosif> PRODUTO_COSIF { get; set; }
        public DbSet<Movimento_Manual> MOVIMENTO_MANUAL { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>()
                .HasKey(x => x.COD_PRODUTO);
            modelBuilder.Entity<Produto_Cosif>()
                .HasKey(x => new { x.COD_COSIF, x.COD_PRODUTO });
            modelBuilder.Entity<Movimento_Manual>()
                .HasKey(x => new { x.DAT_MES, x.DAT_ANO, x.NUM_LANCAMENTO, x.COD_PRODUTO, x.COD_COSIF});

            modelBuilder.Entity<Produto>()
                .HasData(new { COD_PRODUTO = "PR01", DES_PRODUTO = "PRD 001", STA_STATUS = "A" },
                            new { COD_PRODUTO = "PR02", DES_PRODUTO = "PRD 002", STA_STATUS = "D" },
                            new { COD_PRODUTO = "PR03", DES_PRODUTO = "PRD 003", STA_STATUS = "A" });
            modelBuilder.Entity<Produto_Cosif>()
                .HasData(new { COD_PRODUTO = "PR01", COD_COSIF = "PRDCOS001", COD_CLASSIFICACAO = "CL1", STA_STATUS = "A" },
                            new { COD_PRODUTO = "PR01", COD_COSIF = "PRDCOS999", COD_CLASSIFICACAO = "CL999", STA_STATUS = "A" },
                            new { COD_PRODUTO = "PR02", COD_COSIF = "PRDCOS002", COD_CLASSIFICACAO = "CL2", STA_STATUS = "D" },
                            new { COD_PRODUTO = "PR03", COD_COSIF = "PRDCOS003", COD_CLASSIFICACAO = "CL3", STA_STATUS = "A" });
        }
    }
}
