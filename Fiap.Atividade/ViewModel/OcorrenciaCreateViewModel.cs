using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Atividade.ViewModel
{
    public class OcorrenciaCreateViewModel
    {
        public long OcorrenciaId { get; set; }
        [Display(Name = "Dia da Ocorrência")]
        [DataType(DataType.Date)]
        public DateTime DiaOcorrencia { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Display(Name = "Descrição")]
        [StringLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [Display(Name = "Tipo")]
        public SelectList Tipo { get; set; }

        public OcorrenciaCreateViewModel() 
        { 
            Tipo = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
