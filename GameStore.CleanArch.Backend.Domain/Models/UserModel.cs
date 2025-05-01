namespace GameStore.CleanArch.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de la entidad User para la request. Recibido por alguno de los endpoints en el controller.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Nombre del usuario (Máx. 50 caracteres).
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Apellidos del usuario (Máx. 255 caracteres).
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Alias del usuario (Máx. 50 caracteres).
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }
}
