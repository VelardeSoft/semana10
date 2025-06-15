﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend01.Suscriptions.Domain.Model.Aggregate;

public class TypeSuscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Costo { get; set; }
    public ICollection<Suscription> Suscriptions { get; set; }
}