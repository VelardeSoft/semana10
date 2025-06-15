using backend01.Reservations.Domain.Model.Aggregate;

namespace backend01.Reservations.Applications.Internal.Service;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> ListAsync();
    Task<Reservation> CreateAsync(Reservation reservation);
}