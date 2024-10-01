using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.ViewModel
{
    public class CasaCreateViewModel
    {
        public long CasaId { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        public CasaCreateViewModel() { }
    }
}
