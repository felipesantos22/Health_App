using Health.Domain.Enums;

namespace Health.Domain.Entities;

public class Doctor: BaseEntity
{
    public string? Name { get; set; }
    public string? Crm { get; set; }
    public Especiality Especiality { get; set; }
}