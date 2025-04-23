using System.Diagnostics.CodeAnalysis;
using GameStore.CleanArch.Backend.API.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GameStore.CleanArch.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class GameResponseModelListExample : IExamplesProvider<IEnumerable<GameResponseModel>>
    {
        public IEnumerable<GameResponseModel> GetExamples()
        {
            return new List<GameResponseModel>
            {
                new GameResponseModelExample().GetExamples()
            };
        }
    }

}
