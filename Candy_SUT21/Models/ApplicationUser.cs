﻿using Microsoft.AspNetCore.Identity;

namespace Candy_SUT21.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Customer? Customer { get; set; }
    }
}
