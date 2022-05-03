using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IAccountRepository;
using RoomRentalBackEnd.Models.SignIn;
using RoomRentalBackEnd.Models.SignUp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.Controllers.AccountController
{

    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IAccountRepository accountRepository, RoleManager<IdentityRole> roleManager)
        {
            _accountRepository = accountRepository;
            _roleManager = roleManager;
        }

        //..........................Registration api..........................
        [HttpPost("Registration")]
        public async Task<IActionResult> SignUpAsyncMethod([FromBody] SignUpModel signUpModel)
        {


            try
            {
                    var result = await _accountRepository.SignUpAsyncMethod(signUpModel);
                    if (result.Succeeded)
                    {
                        return Ok(new { success = result.Succeeded, msg = "User Register successfully" });
                    }

                    return Ok(new { error = result.Errors, success = false });

                }
                catch (System.Exception ex)
                {

                    return Ok(new { error = ex.Message });
                }
            }
        
        [HttpPost("login")]
        public async Task<ResponseDTOs> SignInAsyncMethod([FromBody] SignInModel signInModel)
        {
            try
            {
                var result = await _accountRepository.SignInAsyncMethod(signInModel);
                if (!result.isSuccess)
                {
                    return result;
                }
              
                //Response.Cookies.Append("access_token", result.Token, new CookieOptions { HttpOnly = true });
                return (new ResponseDTOs { Token = result.Token,Errors= null, UserId = result.UserId, isSuccess=result.isSuccess, UserData = result.UserData,Role=result.Role});
            }
            catch (System.Exception ex)
            {

                return (new ResponseDTOs {  Errors= ex.Message });
            }
           
       
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {

            Response.Cookies.Delete("access_token");
            return Ok(new { msg= "user logout successfully"});
        }





        //create new role in role table you have to call this api and set comman role table to role you can set role like admin,user,superAdmin,many more
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromForm] string name)
        {

            if (name == null)
                return BadRequest(new { Error = "Null Role cant Be Add" });

            //If a role already Exist
            var existingRole = await _roleManager.RoleExistsAsync(name);
            if (existingRole)
            {

                return BadRequest(new { Error = "Role Already Exist" });
            }

            //Role has been added successfully
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));

            if (roleResult.Succeeded)
            {
                return Ok(new { result = $"The Role {name} has been added Succesfully" });
            }
            return Ok(new { error = $"The Role {name} has not added" });
        }

    }
}
