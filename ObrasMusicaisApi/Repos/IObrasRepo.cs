using ObrasMusicaisApi.Controllers;
using ObrasMusicaisApi.Models;

namespace ObrasMusicaisApi.Repos
{
    public interface IObrasRepo
    {
        Task<IEnumerable<ObraModel>> GetAllAsync();

        Task<ObraModel> GetAsync(Guid id);

        Task<ObraModel> AddAsync(ObraModel obra);

        Task<ObraModel> UpdateAsync(ObraModel obra);

        Task<ObraModel> DeleteAsync(Guid id);
    }
}
