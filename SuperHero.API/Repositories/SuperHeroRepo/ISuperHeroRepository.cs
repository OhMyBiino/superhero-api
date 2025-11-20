using SuperHero.API.Models;

namespace SuperHero.API.Repositories.SuperHeroRepo
{
    public interface ISuperHeroRepository
    {
        Task<IEnumerable<SuperHeroModel>> GetAll();
        Task <SuperHeroModel> GetById(int Id);
        Task <SuperHeroModel> Add(SuperHeroModel model);
        Task <SuperHeroModel> Update(int Id, SuperHeroModel model);
        Task <SuperHeroModel> Delete(int Id);
    }
}
