﻿using TerraForums.Data.Models;

namespace TerraForums.Data
{
    public interface IPost
    {
        Post GetById(int Id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);

        Task Add(Post post);
        Task Delete(int Id);
        Task EditPostContent(int Id, string newContent);
    }
}
