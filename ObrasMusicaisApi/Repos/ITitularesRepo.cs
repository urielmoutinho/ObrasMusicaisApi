using ObrasMusicaisApi.Models;
using ObrasMusicaisApi.Models.ViewModels;

namespace ObrasMusicaisApi.Repos
{
    public interface ITitularesRepo
    {
        Task<TitularModel> AddAsync(TitularModel titular);
        Task<TitularModel> DeleteAsync(Guid id);
        Task<IEnumerable<TitularModel>> GetAllAsync();
        Task<TitularModel> GetAsync(Guid id);
        Task<EditTitularesRequest> UpdateAsync(EditTitularesRequest titular);
    }
}