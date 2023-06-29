using System.ComponentModel.DataAnnotations;

namespace DatabaseProvider.Entities;

internal class Account
{
    [Required]
    [Key]
    public int Sequence { get; set; }
    [Required]
    public string Number { get; set; }
}
