﻿namespace backend01.Suscriptions.Interfaces.REST.Resources;

public class SuscriptionResource
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Date { get; set; }
    public string Cvv { get; set; }
    public int TypeId { get; set; }
}