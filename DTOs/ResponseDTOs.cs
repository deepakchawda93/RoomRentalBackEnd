using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.DTOs
{
    public class ResponseDTOs
    {
        public string Token { get; set; }
        public IdentityUser UserEmail { get; set; }
        public string Errors { get; set; }
        public bool isSuccess { get; set; }
       public string Role { get; set; } 
        public List<object> UserData { get; set; }
        public string UserId { get; set; }
    }
}
