using System.ComponentModel.DataAnnotations;

namespace DatabaseProvider.Entities;

internal class Company
{
    public string? Name { get; set; }
    [Required]
    [Key]
    public string Nip { get; set; }
    public string? StatusVat { get; set; }
    public string? Regon { get; set; }
    public string? Pesel { get; set; }
    public string? Krs { get; set; }
    public string? ResidenceAddress { get; set; }
    public string? WorkingAddress { get; set; }
    public List<Representative>? Representatives { get; set; }
    public List<AuthorizedClerk>? AuthorizedClerks { get; set; }
    public List<Partner>? Partners { get; set; }
    public DateTime? RegistrationLegalDate { get; set; }
    public DateTime? RegistrationDenialDate { get; set; }
    public string? RegistrationDenialBasis { get; set; }
    public DateTime? RestorationDate { get; set; }
    public string? RestorationBasis { get; set; }
    public DateTime? RemovalDate { get; set; }
    public string? RemovalBasis { get; set; }
    public List<Account>? AccountNumbers { get; set; }
    public bool? HasVirtualAccounts { get; set; }
}
