using AutoMapper;
using EyeD.Application.Auth;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.User;
using EyeD.Application.ViewModels.Users;
using EyeD.Domain.Entities;
using EyeD.Domain.ValueObjects;
using EyeD.Infra.Data.Interfaces;
using EyeD.Infra.Data.Transactions;

namespace EyeD.Application.Services;

public sealed class UserServices : IUserServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserServices(IUserRepository userRepository , IMapper mapper, IUnitOfWork unitOfWork )
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<ResponseUserViewModel> Create(RequestUserViewModel viewModel)
    {
        if (await _userRepository.GetOneWhere(i => i.Email.Endereco == viewModel.Email) is not null)
        {
            throw new Exception("Email já existente no banco de dados!");
        }

        var user = new User(
            new Name(viewModel.Nome),
            new Email(viewModel.Email),
            new Password(viewModel.Senha)
            );

        if(!user.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var userResponse = await _userRepository.Insert(user);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao criar o Usuário.");

        return _mapper.Map<ResponseUserViewModel>(userResponse);
    }

    public async Task<bool> Delete(Guid id)
    {
        var userExistente = await _userRepository.GetOneWhere(p => p.Id == id) ?? throw new Exception("User inexistente.");
        await _userRepository.Delete(userExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar apagar User.");
        return true;
    }

    public async Task<ResponseUserViewModel> Edit(Guid id, RequestUserViewModel viewModel)
    {
        var userExistente = await _userRepository.GetOneWhere(p => p.Id == id) ?? throw new Exception("User inexistente.");

         userExistente.Update(
            new Name(viewModel.Nome),
            new Email(viewModel.Email),
            new Password(viewModel.Senha)
            );

        if (!userExistente.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var userResponse = await _userRepository.Update(userExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar as alterações em User.");

        return _mapper.Map<ResponseUserViewModel>(userResponse);

    }

    public async Task<List<ResponseUserViewModel>> GetAll()
     => _mapper.Map<List<ResponseUserViewModel>>
            (await _userRepository.GetAll());

    public async Task<ResponseUserViewModel> GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new Exception("Id inválido.");

        var userExistente = await _userRepository.GetOneWhere(p => p.Id == id);

        return userExistente is null
            ? throw new Exception("Usuário inexistente.")
            : _mapper.Map<ResponseUserViewModel>(userExistente);

    }

    public async Task<LoginResponseUserViewModel> Login(LoginRequestUserViewModel viewModel)
    {

        if (string.IsNullOrEmpty(viewModel.Email) || string.IsNullOrWhiteSpace(viewModel.Email))
            throw new Exception("Email inválido.");

        if (string.IsNullOrEmpty(viewModel.Senha) || string.IsNullOrWhiteSpace(viewModel.Senha))
            throw new Exception("Senha inválida.");

        var usuarioExistente = await _userRepository.GetOneWhere(
            c => c.Email.Endereco == viewModel.Email
            && c.Password.Texto == viewModel.Senha) ?? throw new Exception("Não existe nenhum usuário com as credencias especificadas.");
        var token = TokenServices.GenerateToken(usuarioExistente);

        var usuarioMapeado = _mapper.Map<LoginResponseUserViewModel>(usuarioExistente);
        usuarioMapeado.Token = token;

        return usuarioMapeado;
    }
}
