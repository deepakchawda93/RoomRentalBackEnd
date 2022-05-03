using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomRentalBackEnd.Models;
using RoomRentalBackEnd.Models.ownerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomRentalBackEnd.DataBaseConnection
{
    public class DbContextConnect : IdentityDbContext<ExtraUserModel>
    {
        /*  also use  DbContext in place of IdentityDbContext if you are not using Identity package*/
        public DbContextConnect(DbContextOptions<DbContextConnect> options)
            :base(options)
        {

        }
        /*    Here is a database table name declaired*/
        //public DbSet<ModalName>DbNameCreate { get; set; }
        public DbSet<OwnerModel>OwnerModelTable{ get; set; }
        /*   we have two option to make connection with Sql server and this is first way */
        /*   in second way we don't declairebookCodeFirst her direct use in startup.cs class*/
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookStoreApi;Integrated Security = ture");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
