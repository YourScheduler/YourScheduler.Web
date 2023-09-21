//using AutoMapper;
//using FluentAssertions;
//using Moq;
//using Xunit;
//using YourScheduler.BusinessLogic.Models.DTOs;
//using YourScheduler.Infrastructure.Entities;
//using YourScheduler.Infrastructure.Repositories.Interfaces;
//using UserService = YourScheduler.BusinessLogic.Services.UserService;

//namespace YourScheduler.BusinessLogic.xUnitTests.ServiceTests
//{


//    public class UserServiceTests
//    {
//        private readonly Mock<IUsersRepository> _repositoryMock= new Mock<IUsersRepository>();
//        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
//        private readonly UserService _userService;
//        public UserServiceTests()
//        {
//            _userService = new UserService(_repositoryMock.Object, _mapperMock.Object);
//        }

//        [Fact]
//        public void Test_GetAllUsers()
//        {
            
//            _repositoryMock.Setup(r => r.GetUsersFromDataBase()).Returns(new List<ApplicationUser>
//            {
//                new ApplicationUser(),
//                new ApplicationUser(),
//                new ApplicationUser()
//            });
//            _mapperMock.Setup(m => m.Map<ApplicationUser>(new ApplicationUserDto())).Returns(new ApplicationUser());
//            var users = _userService.GetAllUsers();

//            users.Should().HaveCount(3);
//            users.Should().NotBeNullOrEmpty();

//        }
//        [Theory]
//        [InlineData(1)]
//        [InlineData(4)]
//        [InlineData(3)]
//        [InlineData(2)]
//        public void Test_GetUserById_ShouldReturnUserIfIdIsInRange(int id)
//        {
//            var dataBase = new List<ApplicationUser>
//            {
//                new ApplicationUser
//                {
//                    Id = 1
//                },
//                new ApplicationUser
//                {
//                    Id = 2
//                },
//                new ApplicationUser
//                {
//                    Id = 3
//                },
//                new ApplicationUser
//                {
//                    Id = 4
//                }
//            };

//            _repositoryMock.Setup(r => r.GetUserById(id)).Returns(dataBase.FirstOrDefault(d => d.Id == id));

//            _mapperMock.Setup(m => m.Map<ApplicationUserDto>(It.IsAny<ApplicationUser>())).Returns((ApplicationUser user) => new ApplicationUserDto { Id = user.Id });
//            var user = _userService.GetUserById(id);

//            user.Should().NotBeNull();
//            user.Id.Should().Be(id);
//        }
//        [Theory]
//        [InlineData(12)]
//        [InlineData(46)]
//        [InlineData(61)]
//        [InlineData(6)]
//        [InlineData(7)]
//        public void Test_GetUserById_ShouldThrowException(int id)
//        {
//            var dataBase = new List<ApplicationUser>
//            {
//                new ApplicationUser
//                {
//                    Id = 1
//                },
//                new ApplicationUser
//                {
//                    Id = 2
//                },
//                new ApplicationUser
//                {
//                    Id = 3
//                },
//                new ApplicationUser
//                {
//                    Id = 4
//                }
//            };

//            _repositoryMock.Setup(r => r.GetUserById(id)).Returns(dataBase.FirstOrDefault(d => d.Id == id));

//            _mapperMock.Setup(m => m.Map<ApplicationUserDto>(It.IsAny<ApplicationUser>())).Returns((ApplicationUser user) => new ApplicationUserDto { Id = user.Id });

//            Action act = () => _userService.GetUserById(id);

//            act.Should().Throw<NullReferenceException>();
//        }
//        [Fact]
//        public void Test_AddUser_ShouldSucceed()
//        {
//            var dataBase = new List<ApplicationUser>();

//            var userToBeAdded = new ApplicationUserDto { Id = 12, Email = "Kokos12@gmail.com" };

//            _repositoryMock.Setup(r => r.AddUser(It.IsAny<ApplicationUser>())).Callback((ApplicationUser user) => dataBase.Add(user));

//            _mapperMock.Setup(m => m.Map<ApplicationUser>(It.IsAny<ApplicationUserDto>())).Returns((ApplicationUserDto userDto) => new ApplicationUser {Id = userDto.Id, Email = userDto.Email});

//            _userService.AddUser(userToBeAdded);

//            dataBase.Should().NotBeNullOrEmpty();
//            dataBase.Should().HaveCount(1);
//            dataBase.Find(d => d.Id == 12).Email.Should().Be("Kokos12@gmail.com");

//        }
//        [Theory]
//        [InlineData("Koko12@gmail.com")]
//        [InlineData("Kierat2@gmail.com")]
//        [InlineData("WybiegDlaSzczurów@gmail.com")]
//        [InlineData("Gromnica69@gmail.com")]
//        public void Test_GetUserByEmail_ShouldSucceed(string email)
//        {
//            var dataBase = new List<ApplicationUser>
//            {
//                new ApplicationUser
//                {
//                    Id = 1,
//                    Email = "Koko12@gmail.com"

//                },
//                new ApplicationUser
//                {
//                    Id = 2,
//                    Email = "Kierat2@gmail.com"
//                },
//                new ApplicationUser
//                {
//                    Id = 3,
//                    Email = "WybiegDlaSzczurów@gmail.com"
//                },
//                new ApplicationUser
//                {
//                    Id = 4,
//                    Email = "Gromnica69@gmail.com"
//                }
//            };

//            _repositoryMock.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns(dataBase.FirstOrDefault(d => d.Email == email));
//            _mapperMock.Setup(m => m.Map<ApplicationUserDto>(It.IsAny<ApplicationUser>())).Returns((ApplicationUser user) => new ApplicationUserDto { Id = user.Id, Email = user.Email});

//            var user = _userService.GetUserByEmail(email);

//            user.Should().NotBeNull();
//            user.Email.Should().Be(email);


//        }
//    }
//}
