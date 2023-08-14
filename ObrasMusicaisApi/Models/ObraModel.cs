namespace ObrasMusicaisApi.Models
{
    public class ObraModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public ICollection<TitularModel> Titulares { get; set; }

    }
}
