﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend01.Suscriptions.Domain.Model.Aggregate;

public class Suscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Number { get; set; }
    [Required]
    public string Date { get; set; }
    [Required]
    public string Cvv { get; set; }
    [Required]
    public int TypeId { get; set; }
    public TypeSuscription Type { get; set; }
}