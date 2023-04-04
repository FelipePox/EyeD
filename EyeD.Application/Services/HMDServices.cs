using AutoMapper;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.HMDs;
using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Domain.ValueObjects;
using EyeD.Infra.Data.Transactions;

namespace EyeD.Application.Services
{
    public sealed class HMDServices : IHMDServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHMDRepository _hmdRepository;

        public HMDServices(IMapper mapper, IUnitOfWork unitOfWork, IHMDRepository hMDRepository)
        {
          _mapper = mapper;
          _unitOfWork = unitOfWork;
          _hmdRepository = hMDRepository;
        }
        public async Task<ResponseHMDViewModel> Create(RequestHMDViewModel viewModel)
        {
            var hmd = new HMDs(
                new Description(viewModel.Description),
                new IPV4(viewModel.IPV4),
                new SKU(viewModel.SKU),
                new MacAddress(viewModel.MacAddress)
                );

            if (!hmd.IsValid)
                throw new Exception("Os dados inseridos estão inválidos.");

            var hmdResponse = await _hmdRepository.Insert(hmd);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar o HMD.");

            return _mapper.Map<ResponseHMDViewModel>(hmdResponse);

        }

        public async Task<bool> Delete(Guid id)
        {
            var hmdExistente = await _hmdRepository.GetOneWhere(r => r.Id == id);

            if (hmdExistente is null)
                throw new Exception("HMD inexistente.");

            await _hmdRepository.Delete(hmdExistente);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar as alterações HMD.");

            return true;
        }

        public async Task<ResponseHMDViewModel> Edit(Guid id, RequestHMDViewModel viewModel)
        {
            var hmdExistente = await _hmdRepository.GetOneWhere(r => r.Id == id);

            if (hmdExistente is null)
                throw new Exception("HMD inexistente.");

               hmdExistente.Update(
               new Description(viewModel.Description),
               new IPV4(viewModel.IPV4),
               new SKU(viewModel.SKU),
               new MacAddress(viewModel.MacAddress)
               );

            if (!hmdExistente.IsValid)
                throw new Exception("Os dados inseridos estão inválidos.");

            var hmdResponse = await _hmdRepository.Update(hmdExistente);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar as alterações no HMD.");

            return _mapper.Map<ResponseHMDViewModel>(hmdResponse);

        }

        public async Task<List<ResponseHMDViewModel>> GetAll()
          => _mapper.Map<List<ResponseHMDViewModel>>
            (await _hmdRepository.GetAll());
            
        public async Task<ResponseHMDViewModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id inválido.");

            var hmdsExistente = await _hmdRepository.GetOneWhere(c => c.Id == id);

            if (hmdsExistente is null)
                throw new Exception("HMD inexistente.");

            return _mapper.Map<ResponseHMDViewModel>(hmdsExistente);

        }
    }
}
