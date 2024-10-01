using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.Models
{
    [Table("tbl_ocorrencia")]
    public class OcorrenciaModel
    {
        [Key]
        public long OcorrenciaId { get; set; }

        [Required]
        public DateTime DiaOcorrencia { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; }
    }
}
