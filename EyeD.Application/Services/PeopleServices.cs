using AutoMapper;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.Peoples;
using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Domain.ValueObjects;
using EyeD.Infra.Data.Transactions;

namespace EyeD.Application.Services;

public class PeopleServices : IPeopleServices
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPeopleRepository _peopleRepository;

    public PeopleServices(IMapper mapper, IUnitOfWork unitOfWork, IPeopleRepository peopleRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _peopleRepository = peopleRepository;
    }

    public async Task<ResponsePeopleViewModel> Create(RequestPeopleViewModel viewModel)
    {

        if(await _peopleRepository.GetOneWhere(i => i.ImageId.Texto == viewModel.ImageId) is not null)
        {
            throw new Exception("ImageId já existente no banco de dados!");
        }
        if(await _peopleRepository.GetOneWhere(f => f.FaceId.Texto == viewModel.FaceId) is not null)
        {
            throw new Exception("FaceId já existente no banco de dados!");

        }
        var people = new People(
            new FullName(viewModel.FirstName),
            new FaceId(viewModel.FaceId),
            new ImageId(viewModel.ImageId),
            new ExternalImageId(viewModel.ExternalImageId),
            new ReferenceDocument(viewModel.ReferenceDocument),
            new URL(viewModel.Imagem)
            );

        if (!people.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var peopleResponse = await _peopleRepository.Insert(people);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar a Pessoa.");

        return _mapper.Map<ResponsePeopleViewModel>(peopleResponse);
    }

    public async Task<bool> Delete(Guid id)
    {
        var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id) ?? throw new Exception("Pessoa inexistente.");
        await _peopleRepository.Delete(peopleExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar apagar Pessoa.");

        return true;

    }

    public async Task<ResponsePeopleViewModel> Edit(Guid id, RequestPeopleViewModel viewModel)
    {
        var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id) ?? throw new Exception("Pessoa inexistente.");

        peopleExistente.Update(
           new FullName(viewModel.FirstName),
           new FaceId(viewModel.FaceId),
           new ImageId(viewModel.ImageId),
           new ExternalImageId(viewModel.ExternalImageId),
           new ReferenceDocument(viewModel.ReferenceDocument),
           new URL(viewModel.Imagem)
           );

        if (!peopleExistente.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var peopleResponse = await _peopleRepository.Update(peopleExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar as alterações em Pessoa.");

        return _mapper.Map<ResponsePeopleViewModel>(peopleResponse);
    }

    public async Task<List<ResponsePeopleViewModel>> GetAll()
      => _mapper.Map<List<ResponsePeopleViewModel>>
            (await  _peopleRepository.GetAll());

    public async Task<ResponsePeopleViewModel> GetByFaceId(string faceId)
    {
        if (faceId == "")
            throw new Exception("Id inválido.");

        var faceExistente = await _peopleRepository.GetOneWhere(p => p.FaceId.Texto == faceId);
        return faceExistente is null 
            ? throw new Exception("Face inexistente.") 
            : _mapper.Map<ResponsePeopleViewModel>(faceExistente);
    }

    public async Task<ResponsePeopleViewModel> GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new Exception("Id inválido.");

        var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id);

        return peopleExistente is null 
            ? throw new Exception("Pessoa inexistente.") 
            : _mapper.Map<ResponsePeopleViewModel>(peopleExistente);
    }
}
