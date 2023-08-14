using Microsoft.EntityFrameworkCore;
using ObrasMusicaisApi.Controllers;
using ObrasMusicaisApi.Models;
using ObrasMusicaisApi.Models.ViewModels;

namespace ObrasMusicaisApi.Repos
{
    public class TitularesRepo : ITitularesRepo
    {
        private readonly DbContext dbContext;
        public TitularesRepo(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TitularModel> AddAsync(TitularModel titular)
        {
            await dbContext.AddAsync(titular);
            await dbContext.SaveChangesAsync();
            return titular;
        }

        public Task<TitularModel> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TitularModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EditTitularesRequest> UpdateAsync(EditTitularesRequest titular)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TitularModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

