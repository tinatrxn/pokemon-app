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
        }
        [HttpGet("{BinderId}", Name = "GetBinder")]
        public async Task<ActionResult<BinderDetailsDto>> GetBinder(int BinderId)
        {
            var binder = await _context.Binders
                .Include(i => i.PokemonCard)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BinderId == BinderId);

            if (binder == null)
            {
                return NotFound();
            }

            var binderDetailsDto = _mapper.Map<BinderDetailsDto>(binder);

            return Ok(binderDetailsDto);
        }
    }
}
