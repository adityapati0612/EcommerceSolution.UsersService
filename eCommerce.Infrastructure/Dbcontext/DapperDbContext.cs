
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.Dbcontext;

public class DapperDbContext
{
    private readonly IConfiguration configuration;
    private readonly IDbConnection connection;
    public DapperDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
        string? connectionstring = configuration.GetConnectionString("PostgresConnection");

        //create a new NpgsqlConnection with the retrived connection string
        connection=new NpgsqlConnection(connectionstring);
    }

    public IDbConnection DbConnection => connection;
}
