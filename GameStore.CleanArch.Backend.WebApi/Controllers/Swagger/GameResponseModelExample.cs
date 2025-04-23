using System.Diagnostics.CodeAnalysis;
using GameStore.CleanArch.Backend.API.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GameStore.CleanArch.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class GameResponseModelExample : IExamplesProvider<GameResponseModel>
    {
        public GameResponseModel GetExamples() => new GameResponseModel
        {
            Id = 1,
            Title = "Celeste",
            ShortDescription = "Una aventura de plataformas sobre la superación personal.",
            ReleaseYear = "2018",
            FormattedPrice = "14,99 €"
        };
    }
}
