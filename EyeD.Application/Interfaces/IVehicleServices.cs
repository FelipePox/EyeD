using EyeD.Application.ViewModels.Vehicles;

namespace EyeD.Application.Interfaces
{
    public interface IVehicleServices
    {
        Task<List<ResponseVehicleViewModel>> GetAll();
        Task<ResponseVehicleViewModel> GetById(Guid id);
        Task<ResponseVehicleViewModel> Create(RequestVehicleViewModel viewModel);
        Task<ResponseVehicleViewModel> Edit(Guid id, RequestVehicleViewModel viewModel);
        Task<bool> Delete(Guid id);
    }
}
