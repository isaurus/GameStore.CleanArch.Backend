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
                .ReverseMap();

            CreateMap<CreateGameCommand, Game>()
                .ReverseMap();
        }
    }
}
