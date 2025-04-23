namespace GameStore.CleanArch.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de la entidad Game para las request. Recibido por algunos de los endpoints en el controller.
    /// </summary>
    public class GameModel
    {       

        /// <summary>
        /// Título del Game (Máx. 50 caracteres).
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del Game (Máx. 255 caracteres).
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de lanzamiento.
        /// </summary>
        public DateOnly Release { get; set; }

        /// <summary>
        /// Precio del Game (Máx. 50 caracteres).
        /// </summary>
        public decimal Price { get; set; }
    }
}