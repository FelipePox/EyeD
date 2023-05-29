using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities
{
    public sealed class User : Entity
    {
        private User()
        { }

        public User(Name nome, Email email, Password password) : base()
        {
            Nome = nome;
            Email = email;
            Password = password;

            AddNotifications(Nome,Email);
        }
        public Name Nome { get; private set; }
        public Email Email { get; private set; }   
        public Password Password { get; private set; }


        public void Update(Name nome, Email email, Password password)
        {
            Nome = nome;
            Email = email;
            Password = password;
           

            AddNotifications(Nome,Email,Password);

            if (IsValid)
                AtualizadoEm = DateTime.Now.ToLocalTime();
        }
    }
}
