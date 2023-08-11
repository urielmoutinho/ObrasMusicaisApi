namespace ObrasMusicaisApi.Models
{
    public class TitularModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public string Categoria { get; set; }
        public ICollection<ObraModel> Obras { get; set; }
    }
}
