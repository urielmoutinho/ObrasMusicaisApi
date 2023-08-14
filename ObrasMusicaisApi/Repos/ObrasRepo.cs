using Microsoft.EntityFrameworkCore;
using ObrasMusicaisApi.Controllers;
using ObrasMusicaisApi.Data;
using ObrasMusicaisApi.Models;
using System.Threading.Tasks;

namespace ObrasMusicaisApi.Repos
{
    public class ObrasRepo : IObrasRepo
    {
        private readonly ObrasDbContext obrasDbContext;
        public ObrasRepo(DbContext dbContext)
        {
            this.obrasDbContext = obrasDbContext;
        }
        public async Task<ObraModel> AddAsync(ObraModel obra)
        {
            await obrasDbContext.AddAsync(obra);
            await obrasDbContext.SaveChangesAsync();
            return obra;
        }

        public Task<ObraModel> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ObraModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObraModel> UpdateAsync(ObraModel obra)
        {
            var existingObra = await obrasDbContext.Obras.Include(x => x.Titulares).FirstOrDefaultAsync(x => x.Id == obra.Id);

            if (existingObra != null)
            {
                existingObra.Id = obra.Id;
                existingObra.Nome = obra.Nome;
                existingObra.Genero = obra.Genero;
                existingObra.Titulares = obra.Titulares;

                await obrasDbContext.SaveChangesAsync();

                return existingObra;

            }

            return null;
        }

        public Task<IEnumerable<ObraModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
