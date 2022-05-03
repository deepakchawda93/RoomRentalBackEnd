using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.Models.SignIn;
using RoomRentalBackEnd.Models.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.IRepository.IAccountRepository
{
   public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsyncMethod(SignUpModel signUpModel);
        Task<ResponseDTOs> SignInAsyncMethod(SignInModel signInModel);


    }
}
