using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IAdminRepository;
using RoomRentalBackEnd.Models.SignIn;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.Repository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ExtraUserModel> _userManager;
        private readonly SignInManager<ExtraUserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;

        public AdminRepository(Microsoft.AspNetCore.Identity.UserManager<ExtraUserModel> userManager, SignInManager<ExtraUserModel> signInManager, IConfiguration configuration, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<ResponseDTOs> AdminSignInMethod(SignInModel signInModel)
        {
            var userData = await _userManager.FindByEmailAsync(signInModel.Email);
            var role = await _userManager.GetRolesAsync(userData);

            if (userData == null || userData.Email!=signInModel.Email)
            {
                return (new ResponseDTOs {
                    Errors = "Your mail id is wrong",
                    isSuccess = false,
                });
            }
            if(userData.Email== signInModel.Email)
            {
                if(role[0]!="admin")
                {
                    return (new ResponseDTOs {
                        Errors = "Your mail id is wrong",
                        isSuccess = false,
                    });
                }
            }
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
            {
                return (new ResponseDTOs {
                    Errors = "Your password is wrong",
                    Token = null,
                    isSuccess = false,
                    UserEmail = null
                });
            }
           
            if (role[0]=="admin")
            {
                IdentityOptions _options = new IdentityOptions();
                //generete token here
                var authClaims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,signInModel.Email),
                new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
                var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                  issuer: _configuration["JWT:ValidIssuer"],
                  audience: _configuration["JWT:ValidAudience"],
                  expires: DateTime.Now.AddDays(1),
                  claims: authClaims,
                  signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                  );
                var NewToken = new JwtSecurityTokenHandler().WriteToken(token);


                return (new ResponseDTOs {
                    Token = NewToken, UserId = userData.Id, isSuccess = true, Role = role[0], UserData = new List<object>()
                {
                userData.Email,userData.FirstName,userData.LastName,
            }

                });

            }
            else
            {
                return (new ResponseDTOs {
                    Errors = "Your Credincial is wrong",
                    Token = null,
                    isSuccess = false,
                    UserEmail = null
                });

            }



        }
    }
}
