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
    public class PokemonCardsController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        ////private readonly ILogger<WeatherForecastController> _logger;

        ////public WeatherForecastController(ILogger<WeatherForecastController> logger)
        ////{
        ////    _logger = logger;
        ////}

        private readonly PokemonBinderContext _context;
        private readonly IMapper _mapper;

        public PokemonCardsController(PokemonBinderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet(Name = "GetCards")]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _context.PokemonCards
                .AsNoTracking()
                .ToListAsync();

            var cardsDto = _mapper.Map<List<PokemonCardDto>>(cards);
            return Ok(cardsDto);

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
