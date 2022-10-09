using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api_movimentoManual.Model;
using System;
using Microsoft.AspNetCore.Mvc;
using api_movimentoManual.Data;
using System.Linq;

namespace api_movimentoManual.Models
{
    public class Movimento_Manual
    {
        [Key, Column(Order = 0)]
        [Required]
        [Range(1, 12)]
        public int DAT_MES { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [Range(2000, 2999)]
        public int DAT_ANO { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        [Range(0, 999999999999999999)]
        public int NUM_LANCAMENTO { get; set; }

        [ForeignKey("COD_PRODUTO")]
        [Required]
        [MaxLength(4)]
        public string COD_PRODUTO { get; set; }

        [ForeignKey("COD_COSIF")]
        [Required]
        [MaxLength(11)]
        public string COD_COSIF { get; set; }

        [MaxLength(50)]
        [Required]
        public string DES_DESCRICAO { get; set; }

        [Required]
        public DateTime DAT_MOVIMENTO { get; set; }

        [MaxLength(15)]
        [Required]
        public string COD_USUARIO { get; set; }

        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        public decimal VAL_VALOR { get; set; }
    }
}
