using Flunt.Notifications;
using Flunt.Validations;
using PortalAGR.Domain.Contextos.Agentes.Enumerations;
using PortalAGR.Domain.Contextos.Agentes.ValueObjects;
using PortalAGR.Shared.Entities;
using PortalAGR.Shared.Extensions;
using PortalAGR.Shared.Notifications;
using System;

namespace PortalAGR.Domain.Contextos.Agentes.Entities
{
    public class Agente : Entity, IValidatable
    {
        public DadosAgente DadosAgente { get; private set; }
        public Patente Patente { get; private set; }
        public string IdPSN { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; set; }
        public bool RegistroValido { get; set; }

        public Agente(DadosAgente dadosAgente, Patente patente, string idPSN, string email, string senha)
        {
            DadosAgente = dadosAgente;
            Patente = patente;
            IdPSN = idPSN;
            Email = email;
            Senha = senha;
            DataCadastro = DateTime.UtcNow;
            RegistroValido = true;

            SatisfiedBy();
            ValidarSenha(Senha);
        }

        #region Métodos
        public void AlterarDadosDoAgente(DadosAgente dadosAgente) => DadosAgente = dadosAgente;
        public void AlterarPatente(Patente patente) => Patente = patente;
        public void AlterarIdPsn(string idPsn) => IdPSN = idPsn;
        public void AlterarEmail(string email) => Email = email;
        public void ValidarSenha(string senha)
        {
            Senha = senha;

            AddNotifications(new Contract<Notification>()
           .Requires()
           .IsNotNullOrEmpty(Senha, nameof(Senha), "A senha do agente é obrigatória"));

            Senha = PasswordExtension.EncriptarSenha(senha);
        }
        public void SatisfiedBy()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(Patente, nameof(Patente), "A patente do agente é obrigatória")
            .IsNotNullOrEmpty(IdPSN, nameof(IdPSN), "A IdPSN do agente é obrigatória")
            .IsEmailOrEmpty(Email, nameof(Email), "O e-mail do agente é obrigatório"));

            AddNotifications(DadosAgente);
        }

        #endregion
    }
}
