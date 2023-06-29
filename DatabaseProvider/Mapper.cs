using DatabaseProvider.Entities;
using DatabaseProvider.Models;

namespace DatabaseProvider;

internal static class Mapper
{
    public static CompanyModel? Map(this Company? company)
    {
        if (company == null) { return null; }

        return new CompanyModel
        {
            AccountNumbers = company.AccountNumbers?.Select(p => p.Number).ToList(),
            AuthorizedClerks = company.AuthorizedClerks?.Select(p => p.Person.Map()).ToList(),
            HasVirtualAccounts = company.HasVirtualAccounts,
            Krs = company.Krs,
            Name = company.Name,
            Nip = company.Nip,
            Partners = company.Partners?.Select(p => p.Person.Map()).ToList(),
            Pesel = company.Pesel,
            RegistrationDenialBasis = company.RegistrationDenialBasis,
            RegistrationDenialDate = company.RegistrationDenialDate,
            RegistrationLegalDate = company.RegistrationLegalDate,
            Regon = company.Regon,
            RemovalBasis = company.RemovalBasis,
            RemovalDate = company.RemovalDate,
            Representatives = company.Representatives?.Select(p => p.Person.Map()).ToList(),
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

        List<Account>? accountNumbers = null;
        List<AuthorizedClerk>? authorizedClerks = null;
        List<Partner>? partners = null;
        List<Representative>? representatives = null;

        if (company.AccountNumbers != null && company.AccountNumbers.Any())
        {
            accountNumbers = new List<Account>();
            foreach (string number in company.AccountNumbers)
            {
                accountNumbers.Add(new Account { Number = number });
            }
        }
        if (company.AuthorizedClerks != null && company.AuthorizedClerks.Any())
        {
            authorizedClerks = new List<AuthorizedClerk>();
            foreach (PersonModel clerk in company.AuthorizedClerks)
            {
                authorizedClerks.Add(new AuthorizedClerk { Person = clerk.Map()});
            }
        }
        if (company.Partners != null && company.Partners.Any())
        {
            partners = new List<Partner>();
            foreach (PersonModel partner in company.Partners)
            {
                partners.Add(new Partner { Person = partner.Map() });
            }
        }
        if (company.Representatives != null && company.Representatives.Any())
        {
            representatives = new List<Representative>();
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
