using Microsoft.AspNetCore.Identity;

namespace BrainHub.ServiceLayer.Services
{
    public interface IAccountService
    {
        Task<(bool Success, string Error)> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<(bool Success, string Error)> ChangePasswordAsync(IdentityUser<int> user, string oldPassword, string newPassword, string confirmPassword);
        Task<IdentityUser<int>> GetCurrentUserAsync(System.Security.Claims.ClaimsPrincipal principal);
    }
}
