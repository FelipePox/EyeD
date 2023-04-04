using EyeD.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EyeD.Application.Auth;

public static class TokenServices
{
    public static string GenerateToken(User user) // Recebendo usuário para acessar as informações
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // Instanciando classe para geração do token

        var key = Encoding.ASCII.GetBytes(Settings.SECRET); // Encriptando a chave transformando em array de bytes

        var tokenDescriptor = new SecurityTokenDescriptor // criação do token
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email.Endereco),
            }), // Definindo as "afirmações" (claims) referentes aos perfis/roles (funcao) dos usuários
            Expires = DateTime.UtcNow.AddHours(48), // Vida útil do token (8 horas) **Nesse caso 8 horas
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Credenciais para criar o token
                                                                                    // (utilizando sha256
        };

        var token = tokenHandler.CreateToken(tokenDescriptor); // Criando token
        return tokenHandler.WriteToken(token); // retornando token como uma STRING 
    }
}
