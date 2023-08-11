using ObrasMusicaisApi.Controllers;

namespace ObrasMusicaisApi.Repos
{
    public interface IObrasRepo
    {
        Task<IEnumerable<ObrasController> GetAllAsync();

        Task<ObrasController?> GetAsync(Guid id);

        Task<ObrasController> AddAsync(Obra obra);

        Task<ObrasController?> UpdateAsync(Obra obra);

        Task<ObrasController?> DeleteAsync(Guid id);
    }
}
