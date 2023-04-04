using EyeD.Application.ViewModels.HMDs;

namespace EyeD.Application.Interfaces;

public interface IHMDServices
{
    Task<List<ResponseHMDViewModel>> GetAll();
    Task<ResponseHMDViewModel> GetById(Guid id);
    Task<ResponseHMDViewModel> Create(RequestHMDViewModel viewModel);
    Task<ResponseHMDViewModel> Edit(Guid id, RequestHMDViewModel viewModel);
    Task<bool> Delete(Guid id);
}
