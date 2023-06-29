using System.ComponentModel.DataAnnotations;

namespace DatabaseProvider.Entities;

internal class AuthorizedClerk
{
    [Required]
    [Key]
    public int Sequence { get; set; }
    [Required]
    public Person Person { get; set; }
}
