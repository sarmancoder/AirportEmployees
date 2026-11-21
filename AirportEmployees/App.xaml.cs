using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using AirportEmployees.Service;
using Microsoft.EntityFrameworkCore;
using System;

namespace AirportEmployees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; }

        public ConnectionService Connection { get; set; }

        public App()
        {
            Configuration = new ConfigurationBuilder()
            .AddUserSecrets<App>()
            .Build();

            string? connectionString =
                Configuration.GetConnectionString("AirportDb");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "No se encontró la cadena de conexión AirportDb.");
            }

            try
            {
                Connection = new ConnectionService(Configuration);

                using var context = Connection.CreateDbContext();

                bool connected = context.Database.CanConnect();
            } catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
            }
        }
}

}
