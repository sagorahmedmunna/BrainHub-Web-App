using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BrainHub.ServiceLayer.Services;

namespace BrainHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #region Index (Login)
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string email, string password)
        {
            var (success, error) = await _accountService.LoginAsync(email, password);
            if (success)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", error);
            return View();
        }
        #endregion

        #region Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Change Password
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = await _accountService.GetCurrentUserAsync(User);
            if (user == null)
                return RedirectToAction("Index");

            var (success, error) = await _accountService.ChangePasswordAsync(user, oldPassword, newPassword, confirmPassword);
            if (success)
            {
                ViewBag.Message = "Password changed successfully!";
                return View();
            }

            ModelState.AddModelError("", error);
            return View();
        }
        #endregion
    }
}