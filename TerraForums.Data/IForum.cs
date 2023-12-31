﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraForums.Data.Models;

namespace TerraForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}
