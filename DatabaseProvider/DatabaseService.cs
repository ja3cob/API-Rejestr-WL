using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
}