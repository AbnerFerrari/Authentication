using System.Threading.Tasks;
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
            var user = new User
            {
                Password = "Arroz",
                Username = "Abner Ferrari",
                Role = "Administrador"
            };

            await service.Insert(user);

            user = await service.Get(user.Id);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Insert()
        {
            //Arrange

            //Act
            var user = new User
            {
                Password = "Arroz",
                Username = "Abner Ferrari",
                Role = "Administrador"
            };

            await service.Insert(user);

            //Assert
            Assert.IsTrue(user.Id > 0);
        }

        [TestMethod]
        public async Task Update()
        {
            //Arrange
            var user = new User
            {
                Password = "Arroz",
                Username = "Abner Ferrari",
                Role = "Administrador"
            };

            await service.Insert(user);

            user = await service.Get(user.Id);

            //Act
            user.Username = "Tiririca";

            await service.Update(user);

            //Assert
            Assert.IsTrue(user.Username == "Tiririca" && user.UpdateDate != user.InsertionDate);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Arrange
            var user = new User
            {
                Password = "Arroz",
                Username = "Abner Ferrari",
                Role = "Administrador"
            };

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