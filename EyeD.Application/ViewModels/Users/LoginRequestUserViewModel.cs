﻿namespace EyeD.Application.ViewModels.User;

public sealed class LoginRequestUserViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}