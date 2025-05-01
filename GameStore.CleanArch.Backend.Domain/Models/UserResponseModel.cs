namespace GameStore.CleanArch.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de respuesta para las consultas sobre la DB (Queries).
    /// </summary>
    public class UserResponseModel
    {
        /// <summary>
        /// El ID del User solicitado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// El nombre del User solicitado.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Los apellidos del User solicitado.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// El alias del User solicitado.
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }
}
