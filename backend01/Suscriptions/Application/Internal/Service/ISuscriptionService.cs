using backend01.Suscriptions.Domain.Model.Aggregate;

namespace backend01.Suscriptions.Application.Internal.Service;

public interface ISuscriptionService
{
    Task<IEnumerable<Suscription>> ListAsync();
    Task<Suscription> CreateAsync(Suscription suscription);
}