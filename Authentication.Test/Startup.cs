using Authentication.Test.Mocks;
using Authentication.Test.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Authentication.Test.Services
{
    [TestClass]
    public class Startup
    {
        public static ServiceProvider ServiceProvider;
        private static AuthenticationContext _context;
        private static TestType testType = TestType.IntegratedTest;


        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            var services = new ServiceCollection();
            

            IConfiguration _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var appSettings = _configuration.GetSection("AppSettings").Get<AppSettings>();

            if (testType != TestType.UnitTest)
            {
                services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
                services.AddScoped(typeof(IService<>), typeof(BaseService<>));

                _context = new AuthenticationContext(new DbContextOptions<AuthenticationContext>(), appSettings);
                _context.Database.EnsureCreated();
            }
            else
            {
                services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoryMock<>));
                services.AddScoped(typeof(IService<>), typeof(BaseServiceMock<>));
            }
            
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped(typeof(AuthenticationService));
            services.AddSingleton(appSettings);

            services.AddDbContext<AuthenticationContext>();

            ServiceProvider = services.BuildServiceProvider();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            if (testType != TestType.UnitTest)
                _context.Database.EnsureDeleted();
        }
    }
}

