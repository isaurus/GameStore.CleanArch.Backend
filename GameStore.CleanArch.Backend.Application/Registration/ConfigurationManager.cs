using Microsoft.Extensions.Configuration;

namespace GameStore.CleanArch.Backend.Application.Registration
{
    public class ConfigurationManager
    {
        public static IConfiguration? Configuration { get; set; }

        #region Swagger
        public static bool SwaggerEnabled
        {
            get
            {
                if (Configuration != null && bool.TryParse(Configuration["Swagger:Enabled"], out bool enabled))
                {
                    return enabled;
                }
                return false;
            }
        }
        #endregion Swagger

        #region ConnectionStrings

        public static string? LocalDB
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:DefaultConnection"] : string.Empty;
            }
        }

        public static string? DockerSQLServer
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:DockerSQLServerConnection"] : string.Empty ;
            }
        }

        public static string? DockerPostgreSQL
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:DockerPostgreSQLConnection"] : string.Empty;
            }
        }

        public static string? LocalSQLPlus
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:LocalSQLServerConnectionPlus"] : string.Empty;
            }
        }

    }
    #endregion ConnectionStrings

}