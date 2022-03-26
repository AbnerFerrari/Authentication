using Microsoft.EntityFrameworkCore;

public sealed class AuthenticationContext : DbContext
{
    private readonly AppSettings _appSettings;

    public AuthenticationContext(DbContextOptions<AuthenticationContext> options, AppSettings appSettings) : base(options)
    {
        _appSettings = appSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_appSettings.ConnectionString).UseSnakeCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}