using Microsoft.AspNetCore.Mvc;
using TerraForums.Data;
using TerraForums.Data.Models;
using TerraForums.Models.Forum;
using TerraForums.Models.Post;
using TerraForums.Models.Search;

namespace TerraForums.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListings = posts.Select(posts => new PostListingModel
            {
                Id = posts.Id,
                AuthorId = posts.User.Id,
                AuthorName = posts.User.UserName,
                Title = posts.Title,
                DatePosted = posts.Created.ToString(),
                RepliesCount = posts.Replies.Count(),
                Forum = BuildForumListing(posts)
            });

            var model = new SearchResultModel
            {
                Posts = postListings,
                SearchQuery = searchQuery,
                EmptySearchResult = areNoResults
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.Id,
                ImageUrl = forum.ImageUrl,
                Name = forum.Title,
                Description = forum.Description
            };

        }

        [HttpPost]
        public IActionResult Search(string searchQuery) 
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}
