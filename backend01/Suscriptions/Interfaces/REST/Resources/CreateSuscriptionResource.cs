using System.ComponentModel.DataAnnotations;

namespace backend01.Suscriptions.Interfaces.REST.Resources;

public class CreateSuscriptionResource
{
    [Required]
    public string Number { get; set; }
    [Required]
    public string Date { get; set; }
    [Required]
    public string Cvv { get; set; }
    [Required]
    public int TypeId { get; set; }
}