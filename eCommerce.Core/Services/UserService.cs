

using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System.Reflection.Metadata;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user= await  userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null) 
        { 
            return null;
        }
        
        return mapper.Map<AuthenticationResponse>(user) with { Success=true,Token="token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new ApplicationUser object from registerrequest

        ApplicationUser? user = new ApplicationUser()
        {
           PersonName=registerRequest.PersonName,
           Email=registerRequest.Email,
           Password=registerRequest.Password,
            Gender = registerRequest.Gender.ToString()

        };
        ApplicationUser? registeredUser =await userRepository.AddUser(user);

        if (registeredUser == null) { return null; }

        //return success response
        return mapper.Map<AuthenticationResponse>(user) with { Success=true,Token="token"};
    }
}
