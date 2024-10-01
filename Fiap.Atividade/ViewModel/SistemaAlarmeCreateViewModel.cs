using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.ViewModel
{
    public class SistemaAlarmeCreateViewModel
    {
        public long SistemaAlarmeId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "O nome não pode exceder 30 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [Display(Name = "Tipo")]
        public SelectList Tipo { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [Display(Name = "Localização")]
        [StringLength(50, ErrorMessage = "A localização não pode exceder 50 caracteres.")]
        public string Localizacao { get; set; }

        public SistemaAlarmeCreateViewModel() 
        {
            Tipo = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
