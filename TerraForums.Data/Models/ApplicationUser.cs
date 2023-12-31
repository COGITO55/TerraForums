﻿using Microsoft.AspNetCore.Identity;

namespace TerraForums.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        /* public string ProfileImageUrl { get; set; } */
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }
    }
}