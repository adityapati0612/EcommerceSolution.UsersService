using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Dbcontext;


namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext dbContext;
    public UserRepository(DapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        //sql query to insert user data into user table
        string query = "INSERT INTO  public.\"Users\"(\"UserId\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserId,@Email,@PersonName,@Gender,@Password) ";
        int countRowsAffected= await dbContext.DbConnection.ExecuteAsync(query, user);

        if (countRowsAffected > 0)
            return user; 
        else
            return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {

        //Sql query to select user email and password

        string query=" SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parameters = new { Email=email,Password=password};

        ApplicationUser? user = await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);

        return user;
    }
}
