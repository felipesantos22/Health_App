﻿namespace Health.Domain.Entities;

public class User: BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    
    public DateTime DateTime { get; set; } = DateTime.Now;
}