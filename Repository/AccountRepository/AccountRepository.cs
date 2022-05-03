using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IAccountRepository;
using RoomRentalBackEnd.Models.SignIn;
using RoomRentalBackEnd.Models.SignUp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ExtraUserModel> _userManager;
        private readonly SignInManager<ExtraUserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<ExtraUserModel> userManager ,SignInManager<ExtraUserModel> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;

        }
        /*.................................Registration User api.................................................................*/
        //we have to put task<IdentityResult> 
        public async Task<IdentityResult> SignUpAsyncMethod(SignUpModel signUpModel)
        {

            var user = new ExtraUserModel()
                {
                    FirstName = signUpModel.FirstName,
                    LastName = signUpModel.LastName,
                    UserName = signUpModel.Email,
                    Email = signUpModel.Email,
                    
                };
            var result =  await _userManager.CreateAsync(user, signUpModel.Password);

            
            if(result.Succeeded)
            {
                var exeUser = await _userManager.FindByEmailAsync(signUpModel.Email);
           
                if (exeUser != null)
                {
                await _userManager.AddToRoleAsync(exeUser,signUpModel.role);
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        /*.............................................signIN api.............................................................................*/
        public async Task<ResponseDTOs> SignInAsyncMethod(SignInModel signInModel)
        {
            var userData =  await _userManager.FindByEmailAsync(signInModel.Email);
            //var userData = await _userManager.AspNetUsers.where(x =>x.email=signInModel.Email,)
            if (userData == null || userData.Email!=signInModel.Email)
            {
                return (new ResponseDTOs { 
                    Errors = "Your mail id is wrong",
                    isSuccess = false,
                 });
            }
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
            {
                return (new ResponseDTOs { 
                    Errors = "Your password is wrong", 
                    Token = null,
                    isSuccess = false,
                    UserEmail = null });
            }
            var role = await _userManager.GetRolesAsync(userData);
            if (role[0]=="user" || role[0]=="owner")
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
