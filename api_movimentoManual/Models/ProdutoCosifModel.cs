using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_movimentoManual.Model
{
    public class ProdutoCosifModel
    {
        
        [ForeignKey("COD_PRODUTO")]
        [Required]
        [MaxLength(4)]
        public string COD_PRODUTO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [MaxLength(11)]
        public string COD_COSIF { get; set; }

        [MaxLength(30)]
        public string COD_CLASSIFICACAO { get; set; }
        [MaxLength(1)]
        public string STA_STATUS { get; set; }
    }
}
