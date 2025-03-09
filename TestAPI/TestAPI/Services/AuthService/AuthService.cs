﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPI.Helpers.TokenSettings;
using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.UserManagement.DTO;
using TestAPI.Models.DomainModels.UserManagement.UserModel;

namespace TestAPI.Services.AuthManagement
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOptions<JwtSettings> _options;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> options)
        {
            _userManager = userManager;

            _options = options;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {

            var authModel = new AuthModel();
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                authModel.Massage = " UserName existed already";

                return authModel;
            }

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                authModel.Massage = " Email existed already";

                return authModel;
            }




            var newUser = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                authModel.Massage = string.Join(",", result.Errors.Select(e => e.Description));
                return authModel;
            }

            Console.WriteLine("befor generate token");
            var Token = GenerateAccessToken(newUser);
            Console.WriteLine("After generate token");

            authModel.Massage = "User successfuly created";
            authModel.Email = newUser.Email;
            authModel.IsAuthenticated = true;
            authModel.ExpireOn = DateTime.Now.AddHours(_options.Value.ExpireOn);
            authModel.UserName = newUser.UserName;
            authModel.Token = Token;
            authModel.IsAuthenticated = true;

            Console.WriteLine("befor sent  authModel instance");

            return authModel;
        }



        public async Task<AuthModel> LoginAsync(LoginModel model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Massage = " User not found";

                return authModel;
            }



            var Token = GenerateAccessToken(user);

            authModel.Email = user.Email;
            authModel.IsAuthenticated = true;
            authModel.ExpireOn = DateTime.Now.AddHours(_options.Value.ExpireOn);
            authModel.UserName = user.UserName;
            authModel.Token = Token;


            return authModel;
        }




        private string GenerateAccessToken(ApplicationUser user)
        {

            if (string.IsNullOrEmpty(_options.Value.SecretKey))
            {
                throw new ArgumentNullException(nameof(_options.Value.SecretKey), "JWT Secret Key is missing.");
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)

            };


            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey));
            var signingCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var jwttoken = new JwtSecurityToken
            (
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                expires: DateTime.Now.AddHours(_options.Value.ExpireOn),
                claims: authClaims,
                signingCredentials: signingCred

            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwttoken);

            return token.ToString();
        }

    }
}
