using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_movimentoManual.Model
{
    public class Produto
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [MaxLength(4)]
        public string COD_PRODUTO { get; set; }
        [MaxLength(30)]
        public string DES_PRODUTO { get; set; }
        [MaxLength(1)]
        public string STA_STATUS { get; set; }
    }
}
