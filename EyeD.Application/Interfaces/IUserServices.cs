using EyeD.Application.ViewModels.User;

namespace EyeD.Application.Interfaces
{
    public interface IUserServices
    {
       Task<LoginResponseUserViewModel> Login(LoginRequestUserViewModel viewModel);
    }
}
