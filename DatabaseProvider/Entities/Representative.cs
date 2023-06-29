using System.ComponentModel.DataAnnotations;

namespace DatabaseProvider.Entities;

internal class Representative
{
    [Required]
    [Key]
    public int Sequence { get; set; }
    [Required]
    public Person Person { get; set; }
}
