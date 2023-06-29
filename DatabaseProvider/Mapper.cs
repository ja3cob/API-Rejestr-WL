using DatabaseProvider.Entities;
using DatabaseProvider.Models;

namespace DatabaseProvider;

internal static class Mapper
{
    public static CompanyModel? Map(this Company? company)
    {
        if (company == null) { return null; }

        var accountNumbers = new List<string>();
        var authorizedClerks = new List<PersonModel>();
        var partners = new List<PersonModel>();
        var representatives = new List<PersonModel>();

        if (company.AccountNumbers != null)
        {
            accountNumbers = company.AccountNumbers.Select(p => p.Number).ToList();
        }
        if (company.AuthorizedClerks != null)
        {
            authorizedClerks = company.AuthorizedClerks.Select(p => p.Person.Map()).ToList();
        }
        if (company.Partners != null)
        {
            partners = company.Partners.Select(p => p.Person.Map()).ToList();
        }
        if (company.Representatives != null)
        {
            representatives = company.Representatives.Select(p => p.Person.Map()).ToList();
        }

        return new CompanyModel
        {
            AccountNumbers = accountNumbers,
            AuthorizedClerks = authorizedClerks,
            HasVirtualAccounts = company.HasVirtualAccounts,
            Krs = company.Krs,
            Name = company.Name,
            Nip = company.Nip,
            Partners = partners,
            Pesel = company.Pesel,
            RegistrationDenialBasis = company.RegistrationDenialBasis,
            RegistrationDenialDate = company.RegistrationDenialDate,
            RegistrationLegalDate = company.RegistrationLegalDate,
            Regon = company.Regon,
            RemovalBasis = company.RemovalBasis,
            RemovalDate = company.RemovalDate,
            Representatives = representatives,
            ResidenceAddress = company.ResidenceAddress,
            RestorationBasis = company.RestorationBasis,
            RestorationDate = company.RestorationDate,
            StatusVat = company.StatusVat,
            WorkingAddress = company.WorkingAddress
        };
    }

    public static Company? Map(this CompanyModel? company)
    {
        if(company == null) { return null; }
        if(company.Nip == null)
        {
            throw new ArgumentException("Nip cannot be null");
        }

        var accountNumbers = new List<Account>();
        var authorizedClerks = new List<AuthorizedClerk>();
        var partners = new List<Partner>();
        var representatives = new List<Representative>();

        if (company.AccountNumbers != null && company.AccountNumbers.Any())
        {
            foreach (string number in company.AccountNumbers)
            {
                accountNumbers.Add(new Account { Number = number });
            }
        }
        if (company.AuthorizedClerks != null && company.AuthorizedClerks.Any())
        {
            foreach (PersonModel clerk in company.AuthorizedClerks)
            {
                authorizedClerks.Add(new AuthorizedClerk { Person = clerk.Map()});
            }
        }
        if (company.Partners != null && company.Partners.Any())
        {
            foreach (PersonModel partner in company.Partners)
            {
                partners.Add(new Partner { Person = partner.Map() });
            }
        }
        if (company.Representatives != null && company.Representatives.Any())
        {
            foreach (PersonModel representative in company.Representatives)
            {
                representatives.Add(new Representative { Person = representative.Map() });
            }
        }

        return new Company
        {
            AccountNumbers = accountNumbers,
            AuthorizedClerks = authorizedClerks,
            HasVirtualAccounts = company.HasVirtualAccounts,
            Krs = company.Krs,
            Name = company.Name,
            Nip = company.Nip,
            Partners = partners,
            Pesel = company.Pesel,
            RegistrationDenialBasis = company.RegistrationDenialBasis,
            RegistrationDenialDate = company.RegistrationDenialDate,
            RegistrationLegalDate = company.RegistrationLegalDate,
            Regon = company.Regon,
            RemovalBasis = company.RemovalBasis,
            RemovalDate = company.RemovalDate,
            Representatives = representatives,
            ResidenceAddress = company.ResidenceAddress,
            RestorationBasis = company.RestorationBasis,
            RestorationDate = company.RestorationDate,
            StatusVat = company.StatusVat,
            WorkingAddress = company.WorkingAddress
        };
    }

    public static PersonModel Map(this Person person) 
    {
        return new PersonModel
        {
            CompanyName = person.CompanyName,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Nip = person.Nip,
            Pesel = person.Pesel
        };
    }

    public static Person Map(this PersonModel person)
    {
        return new Person
        {
            CompanyName = person.CompanyName,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Nip = person.Nip,
            Pesel = person.Pesel
        };
    }
}
