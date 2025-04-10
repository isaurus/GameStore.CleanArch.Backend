using Microsoft.Extensions.Configuration;

namespace GameStore.CleanArch.Backend.Application.Registration
{
    public class ConfigurationManager
    {
        public static IConfiguration? Configuration { get; set; }

        #region ConnectionStrings

        public static string? LocalDB
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:DefaultConnection"] : string.Empty;
            }
        }
    }
    #endregion ConnectionStrings
}