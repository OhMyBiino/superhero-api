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
            var superHero = await _context.SuperHeroModels
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == Id);

            return superHero;
        }

        public async Task<SuperHeroModel> Add(SuperHeroModel model) 
        {
            var addedEntity = await _context.SuperHeroModels.AddAsync(model);

            return addedEntity.Entity;
        }

        public async Task<SuperHeroModel> Update(SuperHeroModel latestModel) 
        {
            var existingModel = await _context.SuperHeroModels
                .FirstOrDefaultAsync(s => s.Id == latestModel.Id);

            if (existingModel is not null)
            {
                existingModel.Name = latestModel.Name;
                existingModel.FirstName = latestModel.FirstName;
                existingModel.LastName = latestModel.LastName;
                existingModel.Location = latestModel.Location;

                await _context.SaveChangesAsync();
            }

            return existingModel;
        }

        public async Task<SuperHeroModel> Delete(int Id) 
        {
            var existingModel = await _context.SuperHeroModels.FindAsync(Id);

            if (existingModel is not null) 
            {
                _context.SuperHeroModels.Remove(existingModel);
                await _context.SaveChangesAsync();
            }

            return existingModel;
        }
    }
}
