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


        [HttpGet("{Id:int}")]
        public async Task<ActionResult<SuperHeroModel>> GetSuperHeroById(int Id)
        {
            var superHero = await _superHeroRepository.GetById(Id);

            if (superHero is null) return NotFound($"Superhero with Id: {Id} could not be found");

            return Ok(superHero);
        }


        [HttpPost]
        public async Task<ActionResult<SuperHeroModel>> AddSuperHero(SuperHeroModel model)
        {
            var addedSuperHero = await _superHeroRepository.Add(model);

            return Ok(addedSuperHero);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<SuperHeroModel>> UpdateSuperHero(int Id, SuperHeroModel model) 
        {
            var matchedModel = await _superHeroRepository.GetById(Id);

            if (matchedModel is null) return BadRequest("Id does not match.");

            var updatedSuperHero = await _superHeroRepository.Update(Id, model);

            if (updatedSuperHero is null) return BadRequest($"SuperHero with Id {Id} could not be updated");

            return Ok(updatedSuperHero);
        }

        [HttpDelete]
        public async Task<ActionResult<SuperHeroModel>> DleteSuperHero(int Id) 
        {
            var deletedSuperHero = await _superHeroRepository.Delete(Id);

            if(deletedSuperHero is null) return NotFound($"SuperHero with Id {Id} could not be found for deletion");

            return Ok(deletedSuperHero);
        }
    }
}
