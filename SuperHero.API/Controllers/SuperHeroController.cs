using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.API.DBContext;
using SuperHero.API.Models;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuperHeroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> getSuperHeroes()
        {

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

            var superHeroes = await _context.SuperHeroModels.AsNoTracking().ToListAsync();


            return Ok(superHeroes);
        }
    }
}
