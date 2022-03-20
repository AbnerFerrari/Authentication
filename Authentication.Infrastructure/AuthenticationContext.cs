using Microsoft.EntityFrameworkCore;

public sealed class AuthenticationContext : DbContext
{
    private AppSettings _appSettings;

    public AuthenticationContext(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseNpgsql(_appSettings.ConnectionString));
    }

    public DbSet<User> Users { get; set; }
}