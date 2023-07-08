using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TerraForums.Data;
using TerraForums.Data.Models;
using TerraForums.Models.ApplicationUser;

namespace TerraForums.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }

        public IActionResult Detial(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel() 
            { 
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                /*ProfileImageUrl = user.ProfileImageUrl,*/
                MemberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View();
        }
    }
}
