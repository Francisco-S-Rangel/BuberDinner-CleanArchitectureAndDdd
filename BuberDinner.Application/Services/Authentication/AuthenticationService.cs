using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        //1.Validade if the user exists
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("User with given email does not exist.");
        }
        //2.Validade if the password is correct
        if(user.Password != password){
             throw new Exception("Invalid password.");
        }
        //3.Create the JwtToken
          var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //1.Check if the user already exists - Validade if the user does exist or not
        if(_userRepository.GetUserByEmail(email) is not null){
            throw new Exception("User with given email already exists.");
        }

        //2.Create user (generate unique Id) and persist to DataBase
        var user = new User{
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password
            };

        _userRepository.Add(user);

        //3.Create the JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

         return new AuthenticationResult(
            user,
            token
         );
    
    }
}