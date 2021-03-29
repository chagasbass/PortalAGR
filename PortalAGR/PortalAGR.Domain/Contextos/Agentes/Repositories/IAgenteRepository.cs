using PortalAGR.Domain.Contextos.Agentes.Entities;
using System.Threading.Tasks;

namespace PortalAGR.Domain.Contextos.Agentes.Repositories
{
    public interface IAgenteRepository
    {
        Task<Agente> CadastrarAgenteAsync(Agente agente);
        Task<Agente> AtualizarAgenteAsync(Agente agente);
        Task<Agente> ExcluirAgenteAsync(string agenteId);
    }
}
