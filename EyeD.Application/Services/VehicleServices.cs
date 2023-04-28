using AutoMapper;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.Vehicles;
using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Domain.ValueObjects;
using EyeD.Infra.Data.Transactions;

namespace EyeD.Application.Services;

public sealed class VehicleServices : IVehicleServices
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleServices(IVehicleRepository vehicleRepository,
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResponseVehicleViewModel> Create(RequestVehicleViewModel viewModel)
    {
        var veiculo = new Vehicles(
           new Plate(viewModel.Plate),
           new Model(viewModel.Model),
           new Brand(viewModel.Brand),
           new ModelYear(viewModel.ModelYear),
           new ReferenceDocument(viewModel.ReferenceDocument)
           );
        
            

        if (!veiculo.IsValid)
            throw new Exception("Os dados inseridos estão inválidos");

        var veiculoResponse = await _vehicleRepository.Insert(veiculo);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar o cardápio");

        return _mapper.Map<ResponseVehicleViewModel>(veiculoResponse);
    }

    public async Task<bool> Delete(Guid id)
    {
        var restauranteExistente = await _vehicleRepository.GetOneWhere(v =>  v.Id == id);

        if (restauranteExistente is null)
            throw new Exception("Restaurante inexistente");

        await _vehicleRepository.Delete(restauranteExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar o veículo");

        return true;
    }

    public async Task<ResponseVehicleViewModel> Edit(Guid id, RequestVehicleViewModel viewModel)
    {
        var veiculoExistente = await _vehicleRepository.GetOneWhere(v => v.Id == id);

        if (veiculoExistente is null)
            throw new Exception("Restaurante inexistente");

          veiculoExistente.Update(
           new Plate(viewModel.Plate),
           new Model(viewModel.Model),
           new Brand(viewModel.Brand),
           new ModelYear(viewModel.ModelYear),
          new ReferenceDocument(viewModel.ReferenceDocument)
            );

        if (!veiculoExistente.IsValid)
            throw new Exception("Os dados inseridos estão inválidos");

        var veiculoResponse = await _vehicleRepository.Update(veiculoExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar as alterações no veículo");

        return _mapper.Map<ResponseVehicleViewModel>(veiculoResponse);

    }

    public async Task<List<ResponseVehicleViewModel>> GetAll()
    => _mapper.Map<List<ResponseVehicleViewModel>>
        (await _vehicleRepository.GetAll());

    public async Task<ResponseVehicleViewModel> GetById(Guid id)
    {
           if (id == Guid.Empty)
              throw new Exception("Id inválido."); 

            var veiculoExistente = await _vehicleRepository.GetOneWhere(v => v.Id == id);

           if (veiculoExistente is null)
             throw new Exception("Veículo inexistente");

          return _mapper.Map<ResponseVehicleViewModel>(veiculoExistente);
    }
}
