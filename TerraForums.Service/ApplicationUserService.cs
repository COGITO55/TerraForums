﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraForums.Data;
using TerraForums.Data.Models;

namespace TerraForums.Service
{
    class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(
                user => user.Id == id);
        }

        /*public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }*/
    }
}
