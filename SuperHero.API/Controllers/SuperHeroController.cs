using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.API.DBContext;
using SuperHero.API.Models;
using SuperHero.API.Repositories.SuperHeroRepo;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ISuperHeroRepository _superHeroRepository;

        public SuperHeroController(AppDbContext context, ISuperHeroRepository superHeroRepository)
        {
            _context = context;
            _superHeroRepository = superHeroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> getSuperHeroes()
        {
            // mock data
            //var superHeroes = new List<SuperHeroModel>
            //{
            //     new SuperHeroModel
            //    {
            //        Id = 1,
            //        Name = "Peter Parker",
            //        FirstName = "Peter",
            //        LastName = "Parker",
            //        Location = "New York"
            //    },
            //    new SuperHeroModel 
            //    {
            //        Id = 2,
            //        Name = "BatMan",
            //        FirstName = "Bruce",
            //        LastName = "Willis",
            //        Location = "Washington"
            //    }
            //};

            // direct usage of DbContext
            //var superHeroes = await _context.SuperHeroModels.AsNoTracking().ToListAsync();

            // repository pattern usage
            var superHeroes = await _superHeroRepository.GetAll();



            return Ok(superHeroes);
        }
    }
}
