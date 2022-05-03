using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.Models.ownerModel;
using RoomRentalBackEnd.Models.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.IRepository.IOwnerRepository
{
    public interface IOwnerRepository
    {
        Task<OwnerResponceDTOs> PostOwnerData(OwnerModel ownerModel);
        OwnerResponceDTOs GetOwnerAllData(string Userid);
        Task<OwnerResponceDTOs> EditOwnerData(int Editid, OwnerModel ownerModel);
        Task<OwnerResponceDTOs> DeleteSingleOwnerData(int DeleteId);
        Task<OwnerResponceDTOs> GetOwnerAccount(string Ownerid);
        Task<OwnerResponceDTOs> EditOwnerAccount(string EditOwnerid, OwnerProfileEditDTOs ownerProfileEditDTOs);
    }
}
