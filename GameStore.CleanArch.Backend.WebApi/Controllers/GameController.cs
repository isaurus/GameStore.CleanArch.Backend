using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.CleanArch.Backend.WebApi.Controllers
{
    /// <summary>
    /// Controlador para las operaciones CRUD de Game
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
        /// Obtiene todos los Games
        /// </summary>
        /// <returns>Lista completa de Games existentes</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<GameResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllGames()
        {
            var response = await _gameService.GetAllGamesAsync();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un Game específico por su ID
        /// </summary>
        /// <param name="idGame">El ID único del Game</param>
        /// <returns>Datos completos del Game solicitado</returns>
        [HttpGet]
        [Route("{idGame}")]
        [ProducesResponseType(typeof(GameResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> GetGameById([FromRoute] int idGame)
        {
            var response = await _gameService.GetGameByIdAsync(idGame);
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo Game
        /// </summary>
        /// <param name="model">El GameModel recibido como request para crear</param>
        /// <returns>OkResponseModel sobre el éxito/fracaso de la operación</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> PostGame([FromBody] GameModel model)
        {
            var response = await _gameService.AddGameAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza un Game existente
        /// </summary>
        /// <param name="idGame">El ID único del Game</param>
        /// <param name="model">El GameModel recibido como request para actualizar</param>
        /// <returns>OkResponseModel sobre el éxito/fracaso de la operación</returns>
        [HttpPut]
        [Route("{idGame}")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> PutGame([FromRoute] int idGame, [FromBody] GameModel model)
        {
            var response = await _gameService.UpdateGameAsync(idGame, model);
            return Ok(response);
        }
        
    }
}
