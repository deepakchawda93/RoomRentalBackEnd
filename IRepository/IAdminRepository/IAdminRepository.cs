using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.Models.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.IRepository.IAdminRepository
{
    public interface IAdminRepository
    {
        Task<ResponseDTOs> AdminSignInMethod(SignInModel signInModel);
    }
}
