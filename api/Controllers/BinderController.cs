using api.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using AutoMapper;
using api.Models;
using api.Services;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BindersController : ControllerBase
    {

        private readonly PokemonBinderContext _context;
        private readonly IMapper _mapper;
        const int maxPageSize = 9;

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
        }
        [HttpGet("{BinderId}", Name = "GetBinder")]
        public async Task<ActionResult<BinderDetailsDto>> GetBinder(int BinderId, int pageNumber = 1, int pageSize = 9)
        {
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            var binder = await _context.Binders
                .FirstOrDefaultAsync(b => b.BinderId == BinderId);

            if (binder == null)
            {
                return NotFound();
            }

            var totalCards = await _context.PokemonCards
                .Where(c => c.BinderId == BinderId)
                .CountAsync();

            var actualPageSize = Math.Min(pageSize, totalCards - (pageNumber - 1) * pageSize);

            var paginationMetadata = new PaginationMetadata(totalCards, actualPageSize, pageNumber);

            var pageCards = await _context.PokemonCards
                .Where(c => c.BinderId == BinderId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var binderDetailsDto = _mapper.Map<BinderDetailsDto>(binder);
            binderDetailsDto.PokemonCard = _mapper.Map<List<PokemonCardDto>>(pageCards);

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

            return (binderDetailsDto);
        }

        //[HttpGet("{BinderId}", Name = "GetBinder")]
        //public async Task<ActionResult<BinderDetailsDto>> GetBinder(int BinderId, int pageNumber = 1, int pageSize = 9)
        //{
        //    if (pageSize > maxPageSize)
        //    {
        //        pageSize = maxPageSize;
        //    }

        //    var binder = await _context.Binders
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(b => b.BinderId == BinderId);

        //    if (binder == null)
        //    {
        //        return NotFound();
        //    }

        //    var totalCards = await _context.Entry(binder)
        //        .Collection(b => b.PokemonCard)
        //        .Query()
        //        .CountAsync();

        //    await _context.Entry(binder)
        //        .Collection(b => b.PokemonCard)
        //        .Query()
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .LoadAsync();

        //    var pokemonCards = await _context.PokemonCards
        //        .Where(c => c.BinderId == BinderId)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    var binderDetailsDto = _mapper.Map<BinderDetailsDto>(binder);
        //    binderDetailsDto.PokemonCard = _mapper.Map<List<PokemonCardDto>>(pokemonCards);

        //    var paginationMetadata = new
        //    {
        //        totalCount = totalCards,
        //        pageSize,
        //        currentPage = pageNumber,
        //        totalPages = (int)Math.Ceiling(totalCards / (double)pageSize),
        //        pagecount = 3
        //    };

        //    Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

        //    return Ok(binderDetailsDto);
        //}
    }
}
