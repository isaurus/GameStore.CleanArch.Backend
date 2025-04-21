namespace GameStore.CleanArch.Backend.Domain.Models
{
    /// <summary>
    /// 'Model' (DTO) para 'Game'.
    /// </summary>
    public class GameModel
    {
        
        /// <summary>
        /// El ID único del 'Game'.
        /// </summary>
        /// <example>9</example>
        public int Id { get; set; }
        

        /// <summary>
        /// Título del 'Game' (Máx. 50 caracteres).
        /// </summary>
        /// <example>The Last Of Us 2</example>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del 'Game' (Máx. 255 caracteres).
        /// </summary>
        /// <example>¿Preparado para el apocalipsis?</example>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de lanzamiento.
        /// </summary>
        /// <example>19/06/2020</example>
        public DateTime Release { get; set; }

        /// <summary>
        /// Precio del 'Game' (Máx. 50 caracteres).
        /// </summary>
        /// <example>59.99</example>
        public decimal Price { get; set; }
    }
}
