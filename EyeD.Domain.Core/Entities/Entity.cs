using Flunt.Notifications;

namespace EyeD.Domain.Core.Entities
{
   public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now.ToLocalTime();
            AtualizadoEm = DateTime.Now.ToLocalTime();
            Ativo = true;
        }

        public Guid Id { get; protected set; }
        public DateTime CriadoEm { get; protected set; }
        public DateTime AtualizadoEm { get; protected set; }
        public bool Ativo { get; protected set; }

        public void Activate()
        {
            if (IsValid)
                Ativo = true;
        }

        public void Deactivate()
        {
            if (IsValid)
                Ativo = false;
        }
    }
}
