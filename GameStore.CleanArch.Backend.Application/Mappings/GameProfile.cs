using AutoMapper;
using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Application.Features.Game.Commands;
using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Application.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameModel>()
                .ReverseMap();

            CreateMap<GameModel, GameResponseModel>()
                .ReverseMap();

            CreateMap<Game, GameResponseModel>()
            .ForMember(dest => dest.ShortDescription, opt =>
                opt.MapFrom(src =>
                    !string.IsNullOrEmpty(src.Description)
                        ? (src.Description.Length > 50
                            ? src.Description.Substring(0, 50) + "..."
                            : src.Description)
                        : string.Empty))
            .ForMember(dest => dest.ReleaseYear, opt =>
                opt.MapFrom(src => src.Release.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.FormattedPrice, opt =>
                opt.MapFrom(src => src.Price.ToString("C", System.Globalization.CultureInfo.CurrentCulture)));

            CreateMap<CreateGameCommand, Game>()
                .ReverseMap();

            CreateMap<UpdateGameCommand, Game>()
                .ReverseMap();
        }
    }
}
