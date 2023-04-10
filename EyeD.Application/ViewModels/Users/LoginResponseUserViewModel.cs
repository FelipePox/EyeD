namespace EyeD.Application.ViewModels.User;

public sealed class LoginResponseUserViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }  
    public DateTime AtualizadoEm { get; set; }
    public bool Ativo { get; set; } 
    public string Token { get; set; } = string.Empty;
}