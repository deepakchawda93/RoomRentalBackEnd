using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IAdminRepository;
using RoomRentalBackEnd.Models.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.Controllers.AdminController
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(IAdminRepository adminRepository, RoleManager<IdentityRole> roleManager)
        {
            _adminRepository = adminRepository;
            _roleManager = roleManager;
        }

        [HttpPost("admin/login")]
        public async Task<ResponseDTOs> AdminSignInMethod([FromBody] SignInModel signInModel)
        {
            try
            {
                var result = await _adminRepository.AdminSignInMethod(signInModel);
                if (!result.isSuccess)
                {
                    return result;
                }

                //Response.Cookies.Append("access_token", result.Token, new CookieOptions { HttpOnly = true });
                return (new ResponseDTOs { Token = result.Token, Errors= null, UserId = result.UserId, isSuccess=result.isSuccess, UserData = result.UserData, Role=result.Role });
            }
            catch (System.Exception ex)
            {

                return (new ResponseDTOs { Errors= ex.Message });
            }


        }


    }
}
