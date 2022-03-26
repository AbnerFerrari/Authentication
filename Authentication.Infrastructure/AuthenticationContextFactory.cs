using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AuthenticationContextFactory : IDesignTimeDbContextFactory<AuthenticationContext>
{
    public AuthenticationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthenticationContext>();

        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        AppSettings appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

        return new AuthenticationContext(optionsBuilder.Options, appSettings);
    }
}