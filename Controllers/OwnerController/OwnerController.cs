using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomRentalBackEnd.DTOs;
using RoomRentalBackEnd.IRepository.IOwnerRepository;
using RoomRentalBackEnd.Models.ownerModel;
using RoomRentalBackEnd.Models.SignUp;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomRentalBackEnd.Controllers.OwnerController
{
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "owner")]
   //[Route("api/[controller]")]
   [ApiController]
   public class OwnerController : ControllerBase
   {
      private readonly IOwnerRepository _ownerRepository;
      public OwnerController(IOwnerRepository ownerRepository) {

         _ownerRepository = ownerRepository;
      }

      [HttpGet("getOwnerData/{Userid}")]
      public IActionResult GetOwnerAllData([FromRoute] string Userid)
      {
         if (ModelState.IsValid)
         {
            var result = _ownerRepository.GetOwnerAllData(Userid);
            if (result.Success == true)
            {
               return Ok(result);
            }
            else
            {
               return Ok(result);

            }
         }
         else
         {
            return Ok(ModelState);

         }

      }

      [HttpPost("AddOwnerData")]
      public async Task<IActionResult> PostOwnerData([FromBody] OwnerModel ownerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _ownerRepository.PostOwnerData(ownerModel);
                if (result.Success == false)
                {
                    return Ok(result);
                }
                return Ok(result);
            }
            else
            {
                return Ok(ModelState);
            }
        }
        [HttpPut("updateOwnerData/{Editid}")]
        public async Task<IActionResult> EditOwnerData([FromRoute] int Editid, [FromBody] OwnerModel ownerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _ownerRepository.EditOwnerData( Editid,ownerModel);
                if(result.Success== true)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
                
            }
            else
            {
                return Ok(ModelState);
            }
        }
            // DELETE api/<OwnerController>/5
            [HttpDelete("DeleteOwnerData/{DeleteId}")]
        public async  Task<IActionResult> DeleteSingleOwnerData( [FromRoute] int DeleteId)
        {
           var result =  await _ownerRepository.DeleteSingleOwnerData(DeleteId);
            return Ok(result);

        }
        //.............................................Owner Account apis...........................................................
        [HttpGet("GetOwnerAccount/{Ownerid}")]
        public async Task<IActionResult> GetOwnerAccount([FromRoute] string Ownerid)
        {
            if (ModelState.IsValid)
            {
                var result = await _ownerRepository.GetOwnerAccount(Ownerid);
                if (result.Success == true)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(result);

                }
            }
            else
            {
                return Ok(ModelState);

            }

        }
        [HttpPut("updateOwnerAccount/{EditOwnerid}")]
        public async Task<IActionResult>EditOwnerAccount([FromRoute] string EditOwnerid, [FromBody] OwnerProfileEditDTOs ownerProfileEditDTOs )
        {
            if (ModelState.IsValid)
            {
                var result = await _ownerRepository.EditOwnerAccount(EditOwnerid, ownerProfileEditDTOs);
                if (result.Success == true)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }

            }
            else
            {
                return Ok(ModelState);
            }
        }



    }
}
