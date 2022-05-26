
using BookStoreApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RoomRentalBackEnd.DataBaseConnection;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IOwnerRepository;
using RoomRentalBackEnd.Models.ownerModel;
using RoomRentalBackEnd.Models.SignUp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.Repository.OwnerRepository
{

    public class OwnerRepository : IOwnerRepository
    {
        /*  here i am access Dbconnection data*/
        private readonly DbContextConnect _context;
        private readonly UserManager<ExtraUserModel> _userManager;
      private readonly IWebHostEnvironment _hostEnvironment;

      /* it is a constructure */
      public OwnerRepository(DbContextConnect context, UserManager<ExtraUserModel> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
         this._hostEnvironment = hostEnvironment;

      }
        public async Task<OwnerResponceDTOs> PostOwnerData(OwnerModel ownerModel)
        {
            try
            {
            ownerModel.ImageSrc = await SaveImage(ownerModel.ImageFile);

            var OwnerDataAdd = new OwnerModel()
                {
                    
                    Address = ownerModel.Address,
                    City = ownerModel.City,
                    Colony = ownerModel.Colony,       
                    NumberOfMambers = ownerModel.NumberOfMambers,
                    Price = ownerModel.Price,
                    ZipCode = ownerModel.ZipCode,
                    State = ownerModel.State,
                    ImageSrc = ownerModel.ImageSrc,
                    UserId = ownerModel.UserId,
                    OwnerDataStatus = "pending",
                    IsActive = true,


                };

                  _context.OwnerModelTable.Add(OwnerDataAdd);
                await _context.SaveChangesAsync();
                return new OwnerResponceDTOs()
                {
                    Data = new List<OwnerModel>()
                    {
                    },
                    Msg = "Data added successfully",
                    Success = true,
                    StatusCode = 200
                    
                };
            }
            catch (Exception ex)
            {
                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false
                   
                };
            }
        }
        public  OwnerResponceDTOs GetOwnerAllData(string Userid)
        {
            try
            {
                var AllOwnerData = _context.OwnerModelTable.Where(x => x.UserId == Userid && x.IsActive==true ).ToList();
            var totalCount = 0;
            var pendingCount = 0;
            var successCount = 0;
            var rejectedCount = 0;
            foreach (var items in AllOwnerData)
            {
               if (items.OwnerDataStatus=="pending")
               {
                 pendingCount = pendingCount+1;
               }
               if (items.OwnerDataStatus=="success")
               {
                  successCount = successCount+1;
               }
               if (items.OwnerDataStatus=="rejected")
               {
                  rejectedCount = rejectedCount+1;
               }
               totalCount = totalCount+1;
            }
            return new OwnerResponceDTOs()
                {
                    Data = new { AllOwnerData , totalCount , pendingCount, successCount , rejectedCount } ,
                    Msg = "get all Owner data sucessfully",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false

                };
            }
        }
        public async Task<OwnerResponceDTOs> EditOwnerData(int Editid, OwnerModel ownerModel)
        {
            try
            {
                //var FindDataById =   _context.OwnerModelTable.Where(x => x.Id == Editid).FirstOrDefault();
                //ids.Image = ownerModel.Image;

                var EditedData = new OwnerModel()
                {

                    Id = Editid,
                    Address = ownerModel.Address,
                    City = ownerModel.City,
                    NumberOfMambers = ownerModel.NumberOfMambers,
                    Colony = ownerModel.Colony,
                    Price = ownerModel.Price,
                    ZipCode = ownerModel.ZipCode,
                   //Image = ownerModel.Image,
                    State = ownerModel.State,
                    UserId = ownerModel.UserId,
                    OwnerDataStatus = "pending",
                    IsActive = true,

                };

                _context.OwnerModelTable. Update(EditedData);
                await _context.SaveChangesAsync();
                return new OwnerResponceDTOs()
                {
                    Data = new List<OwnerModel>()
                    {
                    },
                    Msg = "Data Edited successfully",
                    Success = true,
                    StatusCode = 200
                };
            } 
            catch (Exception ex)
            {
                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false
                };
            }
        }
        public async Task<OwnerResponceDTOs> DeleteSingleOwnerData(int DeleteId)
        {
            try
            {
                var FindDataById = _context.OwnerModelTable.Where(x => x.Id == DeleteId).FirstOrDefault();

                FindDataById.IsActive = false;
                
                 _context.OwnerModelTable.Update(FindDataById);
                await _context.SaveChangesAsync();

                return new OwnerResponceDTOs()
                {
                    Data = new List<OwnerModel>()
                    {
                    },
                    Msg = "Data deleted successfully",
                    Success = true,
                    StatusCode = 200
                };

                //we donot delete data just do active or not active
                //var DeletedId = new OwnerModel()
                //{
                //    Id = DeleteId
                //};

                //_context.OwnerModelTable.Remove(DeletedId);
                //await _context.SaveChangesAsync();
                //return new OwnerResponceDTOs()
                //{
                //    Data = new List<OwnerModel>()
                //    {
                //    },
                //    Msg = "Data deleted successfully",
                //    Success = true,
                //    StatusCode = 200
                //};

            }
            catch (Exception ex)
            {

                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false
                };
            }
        }

        //.................................................Owner Account apis...................................................
        public async Task<OwnerResponceDTOs> GetOwnerAccount(string Ownerid)
        {
            try
            {
                var OwnderDetails = await _userManager.FindByIdAsync(Ownerid);
                
                var response = new { 
                FirstName  = OwnderDetails.FirstName,
                Email= OwnderDetails.Email,
                LastName= OwnderDetails.LastName,
                PhoneNumber= OwnderDetails.PhoneNumber,
                };
           
                return new OwnerResponceDTOs()
                {
                    Data = response,
                    Msg = "get all Owner details sucessfully",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false

                };
            }
        }
        public async Task<OwnerResponceDTOs> EditOwnerAccount(string EditOwnerid,OwnerProfileEditDTOs ownerProfileEditDTOs)       
        {
            try
            {
                var OwnderDetails = await _userManager.FindByIdAsync(EditOwnerid);
                OwnderDetails.PhoneNumber= ownerProfileEditDTOs.PhoneNumber;
                OwnderDetails.FirstName = ownerProfileEditDTOs.FirstName;
                OwnderDetails.LastName = ownerProfileEditDTOs.LastName;
            
                //var EditedAccountData = new ExtraUserModel()
                //{
                //    Id = EditOwnerid,
                //    FirstName = signUpModel.FirstName,
                //    LastName = signUpModel.LastName,
                //    Email = signUpModel.Email,
                //    UserName = signUpModel.Email,
                //    PhoneNumber = signUpModel.PhoneNumber,
                //};

                var result =  await _userManager.UpdateAsync(OwnderDetails);
             
                return new OwnerResponceDTOs()
                {
                    Data = result,
                    Msg = "Data Edited successfully",
                    Success = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new OwnerResponceDTOs()
                {
                    Data = null,
                    Error = ex.Message.ToString(),
                    StatusCode = 400,
                    Success = false
                };
            }
        }



      [NonAction]
      public async Task<string> SaveImage(IFormFile imageFile)
      {
         try
         {
            if(imageFile.Length > 0)
            {
               if(!Directory.Exists(_hostEnvironment.WebRootPath + "\\Upload\\"))
               {
                  Directory.CreateDirectory(_hostEnvironment.WebRootPath + "\\Upload\\");
               }
               string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
               imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
               var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
               using (var fileStream = new FileStream(imagePath, FileMode.Create))
               {
                  await imageFile.CopyToAsync(fileStream);
               }
               return imageName;
            }
            else
            {
               return "Failed";
            }
         }
         catch (Exception ex)
         {
            return ex.Message.ToString();
            
         }

         
      }

      [NonAction]
      public void DeleteImage(string imageName)
      {
         var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
         if (System.IO.File.Exists(imagePath))
            System.IO.File.Delete(imagePath);
      }


   }
}
