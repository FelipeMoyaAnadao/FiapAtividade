using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.Models
{
    [Table("tbl_sistema_alarme")]
    [Index(nameof(Localizacao), IsUnique = true)]
    public class SistemaAlarmeModel
    {
        [Key]
        public long SistemaAlarmeId { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; }

        [Required]
        public string Localizacao { get; set; }
    }
}
