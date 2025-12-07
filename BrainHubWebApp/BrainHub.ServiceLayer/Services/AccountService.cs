using BrainHub.DomainLayer.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BrainHub.ServiceLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly ApplicationDbContext _db;

        public AccountService(
            SignInManager<IdentityUser<int>> signInManager,
            UserManager<IdentityUser<int>> userManager,
            ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        public async Task<(bool Success, string Error)> LoginAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return (false, "Email and Password are required");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return (false, "Invalid login attempt");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return (false, "Invalid login attempt");

            var employee = await _db.Employees
                .Include(e => e.CustomRole)
                .FirstOrDefaultAsync(e => e.UserId == user.Id);

            var identityOptions = _signInManager.Options.ClaimsIdentity;

            var claims = new List<Claim>
                {
                    new Claim(identityOptions.UserIdClaimType, user.Id.ToString()),
                    new Claim(identityOptions.UserNameClaimType, user.UserName ?? email),
                };

            // Add roles
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(identityOptions.RoleClaimType, role));

            // Add permission claims
            if (employee?.CustomRole?.Permissions != null)
            {
                var permissions = employee.CustomRole.Permissions
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim());

                foreach (var perm in permissions)
                    claims.Add(new Claim("permission", perm));
            }

            // Default permission for all logged-in users, Profile update
            if (!claims.Any(c => c.Type == "permission" && c.Value == "EmployeeProfileUpdate"))
            {
                claims.Add(new Claim("permission", "EmployeeProfileUpdate"));
            }

            // ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(
                claims,
                IdentityConstants.ApplicationScheme,
                identityOptions.UserNameClaimType,
                identityOptions.RoleClaimType
            );

            var principal = new ClaimsPrincipal(claimsIdentity);

            await _signInManager.Context.SignInAsync(
                IdentityConstants.ApplicationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
                });

            return (true, null);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityUser<int>> GetCurrentUserAsync(System.Security.Claims.ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task<(bool Success, string Error)> ChangePasswordAsync(IdentityUser<int> user, string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                return (false, "All fields are required");

            if (newPassword != confirmPassword)
                return (false, "New password and confirm password do not match");

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
                return (true, null);

            var error = string.Join(", ", result.Errors.Select(e => e.Description));
            return (false, error);
        }
    }
}