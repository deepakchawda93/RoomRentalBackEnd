using RoomRentalBackEnd.Models.ownerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.DTOs
{
    public class OwnerResponceDTOs
    {
        //public List<OwnerModel> Data { get; set; }
        public dynamic Data { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public int StatusCode { get; set; }

    }
}
