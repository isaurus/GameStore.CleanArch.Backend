namespace GameStore.CleanArch.Backend.Domain.Entities
{
    public class BaseEntity
    {

        // AUDIT Y PROPIEDAD BOOLEANA PARA DESHABILITAR REGISTRO EN LUGAR DE BORRAR EN DB
        public int Id{ get; set; }
    }
}
