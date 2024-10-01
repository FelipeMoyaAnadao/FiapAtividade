using Fiap.Atividade.Models;
namespace Fiap.Atividade.ViewModel
{
    public class SistemaAlarmePaginacaoViewModel
    {
        public IEnumerable<SistemaAlarmeModel> SistemaAlarmes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => SistemaAlarmes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/SistemaAlarme?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/SistemaAlarme?pagina={CurrentPage + 1}&amp;tamanho={PageSize}" : "";
    }
    public class SistemaAlarmePaginacaoReferenciaViewModel
    {
        public IEnumerable<SistemaAlarmeModel> SistemaAlarmes { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/SistemaAlarme?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/SistemaAlarme?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}
