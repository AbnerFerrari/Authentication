using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Authentication.Test.Services
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private static AuthenticationService service;

        [ClassInitialize]
        public static void Setup()
        {
            service = Startup.ServiceProvider.GetService<AuthenticationService>();
        }

        [TestMethod]
        public async Task Authenticate_InvalidUser()
        {
            var loginRequest = new LoginRequest
            {
                Email = "test@test.com",
                Password = "123"
            };

            await service.Authenticate(loginRequest);
        }
    }
}
