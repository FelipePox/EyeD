namespace EyeD.Application.ViewModels.User
{
   public sealed class LoginResponseUserViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string  Senha { get;  set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
        public string Token { get; set; }
    }
}
