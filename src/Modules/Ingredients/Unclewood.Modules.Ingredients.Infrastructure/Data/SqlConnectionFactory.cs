using System.Data;
using Npgsql;
using Unclewood.Modules.Ingredients.Application.Data;

namespace Unclewood.Modules.Ingredients.Infrastructure.Data;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}