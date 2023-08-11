using ObrasMusicaisApi.Controllers;

namespace ObrasMusicaisApi.Repos
{
    public class ObrasRepo : IObrasRepo
    {
        public Task<ObrasController> AddAsync(Obra obra)
        {
            throw new NotImplementedException();
        }

        public Task<ObrasController?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ObrasController?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ObrasController?> UpdateAsync(Obra obra)
        {
            throw new NotImplementedException();
        }
    }
}
