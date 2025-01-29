using System.Data;

namespace Unclewood.Common.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}