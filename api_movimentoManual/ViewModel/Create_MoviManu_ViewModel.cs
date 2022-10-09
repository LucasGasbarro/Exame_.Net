using api_movimentoManual.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;
using api_movimentoManual.Data;
using System.Linq;

namespace api_movimentoManual.ViewModel
{
    public class Create_MoviManu_ViewModel
    {
        [Required]
        [Range(1,12, ErrorMessage = "O mes deve estar entre 1 e 12.")]
        public int DAT_MES { get; set; }
        [Required]
        [Range (2000,2999, ErrorMessage = "O ano deve estar entre 2000 e 2999")]
        public int DAT_ANO { get; set; }
        [Required]
        [Range(0,999999999999999999, ErrorMessage = "O valor deve conter no máximo 18 caracteres.")]
        public int NUM_LANCAMENTO { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "O valor deve conter no máximo 4 caracteres.")]
        public string COD_PRODUTO { get; set; }
        [MaxLength(50, ErrorMessage = "O valor deve conter no máximo 50 caracteres.")]
        public string DES_PRODUTO { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "O valor deve conter no máximo 11 caracteres.")]
        public string COD_COSIF { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "O valor deve conter no máximo 50 caracteres.")]
        public string DES_DESCRICAO { get; set; }
        [Required]
        public DateTime DAT_MOVIMENTO { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "O valor deve conter no máximo 15 caracteres.")]
        public string COD_USUARIO { get; set; }
        [Required]
        [Range(0.00, 999999999999999999.99,ErrorMessage ="O valor deve conter no máximo 18 caracteres.")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "O valor deve conter no máximo duas casas decimais.")]
        public decimal VAL_VALOR { get; set; }

        public int Get_NumLancamento(int mes, int ano)
        {
            int output = 0;

            try
            {
                using (var context = new AppDbContext())
                {
                    var query = from mm in context.MOVIMENTO_MANUAL
                                where mm.DAT_MES == mes && mm.DAT_ANO == ano
                                select mm.NUM_LANCAMENTO;

                    output = query.Count() + 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return output;
        }
    }
}
