using EyeD.Application.ViewModels.User;
using EyeD.Application.ViewModels.Users;

namespace EyeD.Application.Interfaces;

public interface IUserServices
{
   Task<LoginResponseUserViewModel> Login(LoginRequestUserViewModel viewModel);
   Task<List<ResponseUserViewModel>> GetAll();
   Task<ResponseUserViewModel> GetById(Guid id);
   Task<ResponseUserViewModel> Create(RequestUserViewModel viewModel);
   Task<ResponseUserViewModel> Edit(Guid id, RequestUserViewModel viewModel);
   Task<bool> Delete(Guid id); 
}
