using System.Threading.Tasks;
using Authentication.Test.Factories;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Authentication.Test.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private static IService<User> service;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            service = Startup.ServiceProvider.GetService<IService<User>>();
        }

        [TestMethod]
        public async Task Get()
        {
            var user = UserFactory.New();

            await service.Insert(user);

            user = await service.Get(user.Id);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Insert()
        {
            //Arrange

            //Act
            var user = UserFactory.New();


            await service.Insert(user);

            //Assert
            Assert.IsTrue(user.Id > 0);
        }

        [TestMethod]
        public async Task Update()
        {
            //Arrange
            var user = UserFactory.New();

            await service.Insert(user);

            user = await service.Get(user.Id);
            var newUsername = "Tiririca";
            //Act
            user.Username = newUsername;

            await service.Update(user);
            
            user = await service.Get(user.Id);

            //Assert
            Assert.IsTrue(user.Username == newUsername && user.UpdateDate != user.InsertionDate);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Arrange

            var user = UserFactory.New();

            await service.Insert(user);

            user = await service.Get(user.Id);
            var userId = user.Id;
            //Act
            await service.Delete(user);

            user = await service.Get(userId);

            //Assert
            Assert.IsNull(user);
        }
    }
}