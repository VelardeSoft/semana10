using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend01.Suscriptions.Domain.Model.Aggregate;
using backend01.Users.Domain.Model.Aggregate;

namespace backend01.Reservations.Domain.Model.Aggregate;

public class Reservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string CantDate { get; set; }
    
    [Required]
    public int ScooterId { get; set; }
    public Scooter.Domain.Model.Aggregate.Scooter Scooter { get; set; }
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public int SuscriptionId { get; set; }
    public Suscription Suscription { get; set; }
}