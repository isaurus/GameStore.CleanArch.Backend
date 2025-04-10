using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.CleanArch.Backend.WebApi.Controllers
{
    /// <summary>
    /// Controlador para las operaciones CRUD de 'Game'
    /// </summary>
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Crea un nuevo 'Game'
        /// </summary>
        /// <param name="model">El 'GameModel' recibido como 'request'</param>
        /// <returns>¿?</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(GameModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<GameModel>> PostGame([FromBody] GameModel model)
        {
            await _gameService.AddGameAsync(model);
            return NoContent(); // CAMBIAR? > PARA ESO TENGO QUE IMPLEMENTAR EL GET
        }
    }
}
