using Fiap.Atividade.Models;

namespace Fiap.Atividade.ViewModel
{
    public class OcorrenciaPaginacaoViewModel
    {
        public IEnumerable<OcorrenciaModel> Ocorrencias { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Ocorrencias.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Ocorrencia?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Ocorrencia?pagina={CurrentPage + 1}&amp;tamanho={PageSize}" : "";
    }
    public class OcorrenciaPaginacaoReferenciaViewModel
    {
        public IEnumerable<OcorrenciaModel> Ocorrencias { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Ocorrencia?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Ocorrencia?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}
