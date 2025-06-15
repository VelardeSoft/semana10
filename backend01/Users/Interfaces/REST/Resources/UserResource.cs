﻿namespace backend01.Users.Interfaces.REST.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Dni { get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
    public string Address { get; set; }
    public int RoleId { get; set; }
}