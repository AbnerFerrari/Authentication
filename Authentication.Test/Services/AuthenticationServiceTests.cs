using System;
using System.Threading.Tasks;
using Authentication.Test.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Authentication.Test.Services
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private static AuthenticationService service;
        private static IService<User> _serviceUser;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            service = Startup.ServiceProvider.GetService<AuthenticationService>();
            _serviceUser = Startup.ServiceProvider.GetService<IService<User>>();
        }

        [TestMethod]
        public async Task Authenticate_InvalidUser()
        {
            var user = UserFactory.New();
            await _serviceUser.Insert(user);
            var loginRequest = new LoginRequest
            {
                Email = user.Email,
                Password = ""
            };

            await Assert.ThrowsExceptionAsync<Exception>(async () => await service.Authenticate(loginRequest));
        }

        [TestMethod]
        public async Task Authenticate()
        {
            var user = UserFactory.New();
            await _serviceUser.Insert(user);
            var loginRequest = new LoginRequest
            {
                Email = user.Email,
                Password = user.Password
            };

            var loginResult = await service.Authenticate(loginRequest);

            Assert.IsNotNull(loginResult);
        }
    }
}
