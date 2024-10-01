using Fiap.Atividade.Models;

namespace Fiap.Atividade.ViewModel
{
    public class CasaPaginacaoViewModel
    {
        public IEnumerable<CasaModel> Casas { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Casas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Casa?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Casa?pagina={CurrentPage + 1}&amp;tamanho={PageSize}" : "";
    }
    public class CasaPaginacaoReferenciaViewModel
    {
        public IEnumerable<CasaModel> Casa { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Casa?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Casa?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}
