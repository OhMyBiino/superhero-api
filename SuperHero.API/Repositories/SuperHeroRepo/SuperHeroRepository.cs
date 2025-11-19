using Microsoft.EntityFrameworkCore;
using SuperHero.API.DBContext;
using SuperHero.API.Models;

namespace SuperHero.API.Repositories.SuperHeroRepo
{
    public sealed class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly AppDbContext _context;
        public SuperHeroRepository(AppDbContext context)
        {
            _context = context;
        }

        //get all superheroes
        public async Task<IEnumerable<SuperHeroModel>> GetAll()
        {
            List<SuperHeroModel> superHeroes = await _context.SuperHeroModels.AsNoTracking().ToListAsync();

            return superHeroes;
        }

        //get superhero by id
        public async Task<SuperHeroModel> GetById(int Id) 
        {
            throw new NotImplementedException();
        }

        public async Task<SuperHeroModel> Add(SuperHeroModel model) 
        {
            throw new NotImplementedException();
        }

        public async Task<SuperHeroModel> Update(SuperHeroModel latestModel) 
        {
            throw new NotImplementedException();
        }

        public async Task<SuperHeroModel> Delete(int Id) 
        {
            throw new NotImplementedException();
        }
    }
}
