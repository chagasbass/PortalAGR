using Flunt.Notifications;
using Flunt.Validations;
using PortalAGR.Shared.Notifications;
using PortalAGR.Shared.ValueObjects;
using System;
using System.Collections.Generic;

namespace PortalAGR.Domain.Contextos.Agentes.ValueObjects
{
    public class DadosAgente : ValueObject, IValidatable
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cidade { get; private set; }

        public DadosAgente(string nome, DateTime dataNascimento, string cidade)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cidade = cidade;

            SatisfiedBy();
        }

        public void AlterarNome(string nome) => new DadosAgente(nome, DataNascimento, Cidade);
        public void AlterarCidade(string cidade) => new DadosAgente(Nome, DataNascimento, cidade);
        public void AlterarDataNascimento(DateTime dataNascimento) => new DadosAgente(Nome, dataNascimento, Cidade);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return default;
        }

        public void SatisfiedBy()
        {
            AddNotifications(new Contract<Notification>()
           .Requires()
           .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome do agente é inválido")
           .IsLowerThan(Nome, 4, nameof(Nome), "O nome deve conter no mínimo 4 caracteres.")
           .IsNotNullOrEmpty(Cidade, nameof(Cidade), "A cidade do agente é inválida")
           .IsLowerThan(DataNascimento, DateTime.Now, nameof(DataNascimento), "Data de nascimento do agente é inválida"));
        }
    }
}
