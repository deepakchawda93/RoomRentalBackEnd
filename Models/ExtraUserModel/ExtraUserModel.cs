﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models
{
    public class ExtraUserModel :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
