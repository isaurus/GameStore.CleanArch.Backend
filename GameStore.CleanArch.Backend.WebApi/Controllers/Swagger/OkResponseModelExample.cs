using GameStore.CleanArch.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GameStore.CleanArch.Backend.WebApi.Controllers.Swagger
{
    public class OkResponseModelExample : IExamplesProvider<OkResponseModel>
    {
        public OkResponseModel GetExamples()
        {
            return new OkResponseModel
            {
                Id = 34,
                Message = "Operación realizada exitosamente"
            };
        }
    }
}
