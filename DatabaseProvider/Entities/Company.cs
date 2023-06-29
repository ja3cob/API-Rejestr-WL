﻿namespace DatabaseProvider.Entities;

internal class Company
{
    public string Name { get; set; }
    public string? Nip { get; set; }
    public string? StatusVat { get; set; }
    public string? Regon { get; set; }
    public string? Pesel { get; set; }
    public string? Krs { get; set; }
    public string? ResidenceAddress { get; set; }
    public string? WorkingAddress { get; set; }
    public List<Person>? Representatives { get; set; }
    public List<Person>? AuthorizedClerks { get; set; }
    public List<Person>? Partners { get; set; }
    public DateTime? RegistrationLegalDate { get; set; }
    public DateTime? RegistrationDenialDate { get; set; }
    public string? RegistrationDenialBasis { get; set; }
    public DateTime? RestorationDate { get; set; }
    public string? RestorationBasis { get; set; }
    public DateTime? RemovalDate { get; set; }
    public string? RemovalBasis { get; set; }
    public List<string>? AccountNumbers { get; set; }
    public bool? HasVirtualAccounts { get; set; }
}