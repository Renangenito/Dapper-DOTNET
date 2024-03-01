using Microsoft.AspNetCore.Mvc;
using Dapper.Models;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        const string connectionString = "Server=localhost,1433;Database=DBCarLocadora;User ID=sa;Password=senha@1234xxxy";

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Categoria> Get()
        {
            var connection = new SqlConnection(connectionString);

            //SELECT VIA DAPPER
            //string query = "select * from categorias";
            //return connection.Query<CategoriaModel>(query);

            //return connection.GetAll<Categoria>();





            //INSERT VIA DAPPER
            Categoria categoria = new Categoria();
            categoria.Descricao = "Nova Categoria teste 2";
            categoria.ValorDiaria = 100.11M;
            categoria.Ativo = true;
            categoria.DataInclusao = DateTime.Now;

            //connection.Open();
            //string query = "INSERT INTO Categorias(Descricao, ValorDiaria, Ativo, DataInclusao, DataAlteracao) VALUES (@Descricao, @ValorDiaria, @Ativo, @DataInclusao, @DataAlteracao)";
            //connection.ExecuteScalar(query, categoria);
            connection.Insert<Categoria>(categoria);

            return null;
        }
    }
}