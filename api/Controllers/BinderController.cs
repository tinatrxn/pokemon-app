using api.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using AutoMapper;
using api.Models;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BindersController : ControllerBase
    {

        private readonly PokemonBinderContext _context;
        private readonly IMapper _mapper;

        public BindersController(PokemonBinderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet(Name = "GetBinders")]
        public async Task<IActionResult> GetAllBinders()
        {
            var binders = await _context.Binders
                .Include(i => i.PokemonCard)
                .AsNoTracking()
                .ToListAsync();

            var bindersDto = _mapper.Map<List<BinderDto>>(binders);
            return Ok(bindersDto);

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
