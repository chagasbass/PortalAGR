using PortalAGR.Shared.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace PortalAGR.Domain.Contextos.Agentes.Enumerations
{
    public class Patente : Enumeration
    {
        public static Patente Agente { get; } = new Patente(0, nameof(Agente));
        public static Patente Tenente { get; } = new Patente(1, nameof(Tenente));

        private readonly static List<Patente> _Patentes = new()
        {
            Agente,
            Tenente
        };

        public Patente(int id, string name) : base(id, name) { }

        public Patente RetornarPatente(string nome) => _Patentes.FirstOrDefault(x => x.Name.Equals(nome));
    }
}
