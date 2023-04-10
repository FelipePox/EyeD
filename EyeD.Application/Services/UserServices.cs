using AutoMapper;
using EyeD.Application.Auth;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.User;
using EyeD.Infra.Data.Interfaces;

namespace EyeD.Application.Services;

public sealed class UserServices : IUserServices
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserServices(IUserRepository userRepository , IMapper mapper )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<LoginResponseUserViewModel> Login(LoginRequestUserViewModel viewModel)
    {

        if (string.IsNullOrEmpty(viewModel.Email) || string.IsNullOrWhiteSpace(viewModel.Email))
            throw new Exception("Email inválido.");

        if (string.IsNullOrEmpty(viewModel.Senha) || string.IsNullOrWhiteSpace(viewModel.Senha))
            throw new Exception("Senha inválida.");

        var usuarioExistente = await _userRepository.GetOneWhere(
            c => c.Email.Endereco == viewModel.Email
            && c.Password.Texto == viewModel.Senha);

        if (usuarioExistente is null)
            throw new Exception("Não existe nenhum usuário com as credencias especificadas.");

        var token = TokenServices.GenerateToken(usuarioExistente);

        var usuarioMapeado = _mapper.Map<LoginResponseUserViewModel>(usuarioExistente);
        usuarioMapeado.Token = token;

        return usuarioMapeado;
    }
}
