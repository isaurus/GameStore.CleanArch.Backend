using System.Diagnostics.CodeAnalysis;
using GameStore.CleanArch.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GameStore.CleanArch.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class GameModelExample : IExamplesProvider<GameModel>
    {
        public GameModel GetExamples()
        {
            return new GameModel
            {
                Title = "The Last Of Us 2",
                Description = "15 años después, nada es lo mismo",
                Release = new DateOnly(2020, 6, 19),
                Price = 59.99M
            };
        }
    }
}
