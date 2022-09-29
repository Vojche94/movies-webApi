using MoviesApp.DAL;
using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Mapper;
using MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MoviesApp.Helpers;
using MoviesApp.Configuration;
using Microsoft.Extensions.Options;
using MoviesApp.Exceptions;
using System.Text.RegularExpressions;

namespace MoviesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IRepository<UserDto> userRepository,
                           IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _appSettings = options.Value;

        }

        public UserModel Authenticate(string username, string password)
        {
            var hashedPass = StringHasher.HasherGenerator(password);

            var user = _userRepository.GetAll().SingleOrDefault(user =>
            user.Username == username && user.Password == hashedPass);

            

            if (user == null)
            {
                throw new UserExceptions(user.Id,user.Username,"This user cannot be found int the databse");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(50),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
            

        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAll()
                .Select(user => UserMapper.ToUserModel(user)).ToList();
        }

        public void Register(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new UserExceptions(null, model.FirstName, "Firstname is requried");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new UserExceptions(null, model.LastName, "Last Name is required");
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                throw new UserExceptions(null, model.Username, "Username is required");
            }

            if (ValidateUsername(model.Username))
            {
                throw new UserExceptions(null, model.Username, "Username alreadt exists");
            }

            if (!ValidatePassword(model.Password))
            {
                throw new UserExceptions(null, model.Password, "Password is too weak");
            }

            if (model.Password != model.ConfrimPassword)
            {
                throw new UserExceptions(null, model.ConfrimPassword, "Password confirm didnt match");
            }

            var hashedPass = StringHasher.HasherGenerator(model.Password);

            var user = new UserDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPass,

            };
            _userRepository.Add(user);

        }
        private bool ValidateUsername(string username)
        {
            return _userRepository.GetAll().Any(user => user.Username == username);
        }

        private bool ValidatePassword(string password)
        {
            var passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }
    }
}
