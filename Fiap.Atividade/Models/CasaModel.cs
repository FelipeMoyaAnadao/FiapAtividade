using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.Models
{
    [Table("tbl_casa")]
    [Index(nameof(Localizacao), IsUnique = true)]
    public class CasaModel
    {
        [Key]
        public long CasaId { get; set; }
        [Required]
        public string Localizacao { get; set; }
    }
}
