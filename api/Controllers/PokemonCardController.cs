using api.DbContexts;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonCardsController : ControllerBase
    {
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
        }

        [HttpGet("{PokemonCardId}")]
        public async Task<ActionResult<PokemonCardDto>> GetPokemonCard(int PokemonCardId)
        {
            var pokemonCard = await _context.PokemonCards
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.PokemonCardId == PokemonCardId);

            if (pokemonCard == null)
            {
                return NotFound();
            }

            var pokemonCardDto = _mapper.Map<PokemonCardDto>(pokemonCard);

            return Ok(pokemonCardDto);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonCardDto>> AddPokemonCard(PokemonCardCreationDto pokemonCard)
        {
            var binderid = pokemonCard.BinderId;

            var binder = await _context.Binders
                .Include(b => b.PokemonCard)
                .FirstOrDefaultAsync(b => b.BinderId == binderid);

            if (binder == null)
            {
                return NotFound();
            }

            var newPokemonCard = _mapper.Map<Entities.PokemonCard>(pokemonCard);

            binder.PokemonCard.Add(newPokemonCard);

            await _context.SaveChangesAsync();

            // do you want to return the card or return the binder?
            var binderDto = _mapper.Map<BinderDetailsDto>(binder);

            //var createdPokemonCardToReturn = _mapper.Map<Models.PokemonCardDto>(newPokemonCard);

            return CreatedAtRoute("GetBinder",
                new
                {
                    BinderId = binderid
                },
                binderDto);
        }

        [HttpPut("{PokemonCardId}")]
        public async Task<ActionResult> UpdatePokemonCard(int PokemonCardId, PokemonCardUpdateDto pokemonCard)
        {
            var existingPokemonCard = await _context.PokemonCards
                .FirstOrDefaultAsync(c => c.PokemonCardId == PokemonCardId);

            if (existingPokemonCard == null)
            {
                return NotFound();
            }

            _mapper.Map(pokemonCard, existingPokemonCard);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{PokemonCardId}")]
        public async Task<ActionResult> PartiallyUpdatePokemonCard(int PokemonCardId, JsonPatchDocument<PokemonCardUpdateDto> patchDocument)
        {
            var existingPokemonCard = await _context.PokemonCards
                .FirstOrDefaultAsync(c => c.PokemonCardId == PokemonCardId);

            if (existingPokemonCard == null)
            {
                return NotFound();
            }

            var pokemonCardToPatch = _mapper.Map<PokemonCardUpdateDto>(existingPokemonCard);

            patchDocument.ApplyTo(pokemonCardToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!TryValidateModel(pokemonCardToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(pokemonCardToPatch, existingPokemonCard);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{PokemonCardId}")]
        public async Task<ActionResult> DeletePokemonCard(int PokemonCardId)
        {
            var existingPokemonCard = await _context.PokemonCards
                .FirstOrDefaultAsync(c => c.PokemonCardId == PokemonCardId);

            if (existingPokemonCard == null)
            {
                return NotFound();
            }

            _context.PokemonCards.Remove(existingPokemonCard);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
