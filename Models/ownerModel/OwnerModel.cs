using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomRentalBackEnd.Models.ownerModel
{
    public class OwnerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int NumberOfMambers { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Colony { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string UserId { get; set; }
        public string OwnerDataStatus { get; set; }
        
        public bool IsActive { get; set; }

    }
}
