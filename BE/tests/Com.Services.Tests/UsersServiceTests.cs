using Com.Common;
using Com.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Services.Tests
{
    public class UsersServiceTests : BaseSerivceTests<User>
    {
        List<User> users = new List<User>()
        {
            new User
            {
                Id = Constants.AdminId,
                UserName = "admin",
                Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                Email = "admin@yahoo.com",
                FirstName = "Super",
                LastName = "Admin",
                Type = UserTypes.Admin
            },
            new User
            {
                Id = Constants.UserId,
                UserName = "amer",
                Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                Email = "alsaket@yahoo.com",
                FirstName = "Amer",
                LastName = "Ali"
            }
        };

        private IUsersService _service;

        [SetUp]
        public void Setup()
        {
            _service = new UsersService(_mockRepo.Object);
        }

        [Test]
        public void Authenticate_UsernameOrPasswordNullOrEmpty_Error()
        {
            // Arrange
            string username = "";
            string password = "";

            // Act
            User user = _service.Authenticate(username, password);

            // Assert
            AssertUsernameOrPasswordNullOrEmpty($"{this.GetType()} UsernameAndPasswordEmpty falid");


            // Arrange
            username = null;
            password = "111";

            // Act
            user = _service.Authenticate(username, password);

            // Assert
            AssertUsernameOrPasswordNullOrEmpty($"{this.GetType()} UsernamedNull falid");


            // Arrange
            username = "amer";
            password = "";

            // Act
            user = _service.Authenticate(username, password);

            // Assert
            AssertUsernameOrPasswordNullOrEmpty($"{this.GetType()} PasswordEmpty falid");
        }

        [Test]
        public void Authenticate_GivenWrongUserName_Error()
        {
            // Arrange
            var username = "hhh";
            var password = "111";
            GetRepoGetSetUp().Returns(new List<User> {}.AsQueryable());

            // Act
            User user = _service.Authenticate(username, password);

            // Assert
            Assert.AreEqual(1, _service.GetErrors().Count, $"{this.GetType()} GivenWrongUserName failed");
            Assert.IsTrue(_service.GetErrors().Contains("Username is wrong"), $"{this.GetType()} GivenWrongUserName failed");
        }

        [Test]
        public void Authenticate_GivenWrongPassword_Error()
        {
            // Arrange
            GetRepoGetSetUp().Returns(new List<User> { users[1] }.AsQueryable());           

            // Act
            User user = _service.Authenticate("amer", "231");

            // Assert
            Assert.AreEqual(_service.GetErrors().Count, 1, $"{this.GetType()} GivenWrongPassword failed");
            Assert.IsTrue(_service.GetErrors().Contains("Password is wrong"), $"{this.GetType()} GivenWrongPassword failed");
        }

        [Test]
        public void Authenticate_GivenCorrectUserAndPassword_Success()
        {
            // Arrange
            GetRepoGetSetUp().Returns(new List<User> { users[1] }.AsQueryable());

            // Act
            User user = _service.Authenticate("amer", "111");

            // Assert
            Assert.AreEqual(0, _service.GetErrors().Count, $"{this.GetType()} GivenCorrectUserAndPassword failed");
            Assert.IsTrue(users != null, $"{this.GetType()} GivenCorrectUserAndPassword failed");
        }

        [Test]
        public void Register_UserIsNull_Error()
        {
            // Arrange
            User newUser = null;

            // Act
            var addedUser = _service.Register(newUser);

            // Assert
            Assert.IsNull(addedUser, $"{this.GetType()} Register_UserIsNull failed");
            Assert.AreEqual(1, _service.GetErrors().Count, $"{this.GetType()} Register_UserIsNull failed");
        }

        [Test]
        public void Register_UsernameOrPassword_Error()
        {
            // Arrange
            User newUser = null;

            // Act
            var addedUser = _service.Register(newUser);

            // Assert
            Assert.IsNull(addedUser, $"{this.GetType()} Register_UserIsNull failed");
            AssertUsernameOrPasswordNullOrEmpty($"{this.GetType()} Register_UserIsNull failed");
        }

        [Test]
        public void Register_UsernameIsInUse_Error()
        {
            // Arrange
            User newUser = new User { UserName = "amer", Password="2135"};
            GetRepoGetSetUp().Returns(new List<User> { users[1] }.AsQueryable());

            // Act
            var addedUser = _service.Register(newUser);

            // Assert
            Assert.IsNull(addedUser, $"{this.GetType()} Register_UsernameIsInUse failed");
            Assert.Contains("Username is already in use",_service.GetErrors(), $"{ this.GetType()} Register_UsernameIsInUse failed");
        }

        [Test]
        public void Register_UserIsValid_Success()
        {
            // Arrange
            User newUser = new User { Id= Guid.NewGuid(), UserName = "amer2", Password = "777" };
            GetRepoGetSetUp().Returns((IQueryable<User>) null);
            GetRepoCreateSetUp();
            GetRepoSaveSetUp();

            // Act
            var addedUser = _service.Register(newUser);

            // Assert
            _mockRepo.Verify(p => p.Create(It.IsAny<User>()), Times.Once(), $"{this.GetType()} Register_UsernameIsInUse failed");
            _mockRepo.Verify(p => p.Save(), Times.Once(), $"{this.GetType()} Register_UsernameIsInUse failed");
            Assert.IsNotNull(addedUser, $"{this.GetType()} Register_UsernameIsInUse failed");
        }

        private void AssertUsernameOrPasswordNullOrEmpty(string message)
        {
            Assert.IsTrue(_service.GetErrors().Count > 0, message);
            Assert.IsTrue(_service.GetErrors().Contains("Username and password are required"), message);
        }
    }
}