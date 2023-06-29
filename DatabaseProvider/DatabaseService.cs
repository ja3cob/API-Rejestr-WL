using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DatabaseProvider.Models;
using DatabaseProvider.Entities;
using DatabaseProvider.Util;

namespace DatabaseProvider;

public class DatabaseService : IDatabaseService
{
	private CompanyDbContext DbContext { get; }
	public DatabaseService()
	{
		var services = new ServiceCollection();

		var configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
		services.AddDbContext<CompanyDbContext>(options =>
		options.UseSqlite(configuration.GetConnectionString(Constants.WLConnectionName)));

		DbContext = services.BuildServiceProvider().GetRequiredService<CompanyDbContext>();
		DbContext.Database.EnsureCreated();
	}

	public bool Insert(CompanyModel company)
	{
		try
		{
			var mapped = company.Map();
			if (mapped == null) { return false; }

			DbContext.Companies.Add(mapped);
			DbContext.SaveChanges();
		}
		catch (Exception) { return false; }
		return true;
	}
    public bool Delete(string nip)
    {
		var company = DbContext.Companies.FirstOrDefault(p => p.Nip == nip);
        if (company == null) { return false; }

		try
		{
			DbContext.Companies.Remove(company);
			DbContext.SaveChanges();
		}
		catch (Exception) { return false; }
		return true;
    }

	public CompanyModel? Get(string nip)
	{
		var company = DbContext.Companies.FirstOrDefault(p => p.Nip == nip);
		return company.Map();
	}

    public List<CompanyModel>? GetAll()
    {
        var companies = DbContext.Companies.ToList();
		if(companies == null) { return null; }

		var mappedCompanies = new List<CompanyModel>();
		foreach (Company company in companies)
		{
			var mappedCompany = company.Map();
			if (mappedCompany == null) { continue; }
			mappedCompanies.Add(mappedCompany);
		}

		return mappedCompanies;
    }
}