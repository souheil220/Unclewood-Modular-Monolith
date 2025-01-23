using System.Data;

namespace Unclewood.Modules.Ingredients.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}