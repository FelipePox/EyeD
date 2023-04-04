using EyeD.Application.ViewModels.Peoples;

namespace EyeD.Application.Interfaces
{
    public interface IPeopleServices
    {
        Task<List<ResponsePeopleViewModel>> GetAll();
        Task<ResponsePeopleViewModel> GetById(Guid id);
        Task<ResponsePeopleViewModel> Create(RequestPeopleViewModel viewModel);
        Task<ResponsePeopleViewModel> Edit(Guid id, RequestPeopleViewModel viewModel);
        Task<bool> Delete(Guid id);
    }
}
