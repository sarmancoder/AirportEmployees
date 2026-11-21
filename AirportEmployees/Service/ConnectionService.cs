using AirportEmployees.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportEmployees.Service
{
    public class ConnectionService
    {

        private readonly string _connectionString;

        public ConnectionService(IConfiguration configuration)
        {
            _connectionString = configuration
                .GetConnectionString("AirportDb")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena de conexión AirportDb.");
        }

        public AirportContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AirportContext>()
                .UseMySQL(_connectionString)
                .Options;

            return new AirportContext(options);
        }

    }
}
