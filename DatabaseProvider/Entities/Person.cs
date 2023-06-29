using System.ComponentModel.DataAnnotations;

namespace DatabaseProvider.Entities;

internal class Person
{
    [Required]
    [Key]
    public int Sequence { get; set; }
    public string? CompanyName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Pesel { get; set; }
    public string? Nip { get; set; }
}
