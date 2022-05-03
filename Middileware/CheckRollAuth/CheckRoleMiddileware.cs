

using Microsoft.AspNetCore.Http;
using System;

using System.Threading.Tasks;

namespace RoomRentalBackEnd.Middileware.CheckRollAuth
{
    public class CheckRoleMiddileware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            await context.Response.WriteAsync("This is first custome middleware \n");
                 await next(context);
        }
    }
}