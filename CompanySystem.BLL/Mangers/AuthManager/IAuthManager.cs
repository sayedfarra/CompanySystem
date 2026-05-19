using CompanySystem.BLL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace CompanySystem.BLL.Mangers.AuthManager
{
    public interface IAuthManager
    {
        Task<IdentityResult> RegisterAsync(RegisterVM registerVM);
        Task<SignInResult> LoginAsync(LoginVM loginVM);
        Task LogoutAsync();
    }
}
