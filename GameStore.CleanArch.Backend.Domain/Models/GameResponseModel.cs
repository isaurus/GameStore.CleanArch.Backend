namespace GameStore.CleanArch.Backend.API.Models
{
    /// <summary>
    /// Modelo de respuesta para las consultas sobre la DB (Queries).
    /// </summary>
    public class GameResponseModel
    {
        /// <summary>
        /// El ID del Game solicitado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// El título del Game solicitado.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// La descripción del Game solicitado.
        /// </summary>
        public string ShortDescription { get; set; } = string.Empty;

        /// <summary>
        /// La fecha de lanzamiento del Game solicitado.
        /// </summary>
        public string ReleaseYear { get; set; } = string.Empty;

        /// <summary>
        /// El precio del Game solicitado.
        /// </summary>
        public string FormattedPrice { get; set; } = string.Empty;
    }
}
