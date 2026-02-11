using AutoMapper;

namespace api.Profiles
{
    public class PokemonCardProfile : Profile
    {
        public PokemonCardProfile() 
        {
            CreateMap<Entities.PokemonCard, Models.PokemonCardDto>();
            CreateMap<Entities.PokemonCard, Models.PokemonCardCreationDto>();
            CreateMap<Entities.PokemonCard, Models.PokemonCardUpdateDto>();

            CreateMap<Models.PokemonCardCreationDto, Entities.PokemonCard>();
            CreateMap<Models.PokemonCardUpdateDto, Entities.PokemonCard>();

        }
    }
}
