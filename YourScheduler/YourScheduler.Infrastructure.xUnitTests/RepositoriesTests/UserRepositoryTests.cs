﻿using FluentAssertions;
using Xunit;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class UserRepositoryTests
    {
        private readonly ApplicationUser[] multipleUsers = new ApplicationUser[]
        {
                new ApplicationUser
                {
                    Id = 2, Email = "kokela@gmail.com", Displayname = "Dubaduba", Name = "Karina", Surname = "Dubalińska"
                },
                new ApplicationUser
                {
                    Id = 3, Email = "sprea@gmail.com", Displayname = "Bonica", Name = "Jasmina", Surname = "Kiebab"
                },
                new ApplicationUser
                {
                    Id = 4, Email = "debancja@gmail.com", Displayname = "DiraNotka", Name = "Kierosław", Surname = "Autokaru"
                }
        };

        [Fact]
        public async Task Test_AddUser_ShouldSucceed()
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);

            var userToBeAdded = new ApplicationUser { Id = 1, Email = "Karinka@gmail.com", Displayname = "kekanka", Name = "Bolinka", Surname = "Savarova" };

            await _repositoryMock.AddUserAsync(userToBeAdded);

            _dbContextMock.Users.First(d => d.Email == userToBeAdded.Email).Should().BeSameAs(userToBeAdded);
        }
        [Fact]
        public void Test_GetUsersFromDataBase()
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);

            _dbContextMock.Users.AddRange(multipleUsers);
            _dbContextMock.SaveChanges();


            var users = _repositoryMock.GetUsersFromDataBaseQueryable().ToList();

            users.Should().NotBeNull();
            users.Count().Should().Be(3);
        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task Test_GetUserById_ShouldSucceed(int id)
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);

            _dbContextMock.Users.AddRange(multipleUsers);
            _dbContextMock.SaveChanges();

            var userRetrieved = await _repositoryMock.GetUserByIdAsync(id);

            userRetrieved.Should().NotBeNull();
            userRetrieved.Should().BeSameAs(multipleUsers.FirstOrDefault(u => u.Id == id));
        }
        [Theory]
        [InlineData(7)]
        [InlineData(14)]
        [InlineData(5)]
        public void Test_GetUserById_ShouldReturnNull(int id)
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);


            _dbContextMock.Users.AddRange(multipleUsers);
            _dbContextMock.SaveChanges();

            var userRetrieved = _repositoryMock.GetUserByIdAsync(id);

            userRetrieved.Should().BeNull();
        }
        [Theory]
        [InlineData("kokela@gmail.com")]
        [InlineData("sprea@gmail.com")]
        [InlineData("debancja@gmail.com")]
        public void Test_GetUserByEmail_ShouldSucceed(string mail)
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);


            _dbContextMock.Users.AddRange(multipleUsers);
            _dbContextMock.SaveChanges();

            var userRetrieved = _repositoryMock.GetUserByEmailAsync(mail);

            userRetrieved.Should().NotBeNull();
            userRetrieved.Should().BeSameAs(multipleUsers.First(u => u.Email == mail));
        }
        [Theory]
        [InlineData("kokasela@gmail.com")]
        [InlineData("sprefa@gmail.com")]
        [InlineData("degabancja@gmail.com")]
        public void Test_GetUserByEmail_ShouldReturnNull(string mail)
        {
            var _dbContextMock = ContextGenerator.Generate();
            var _repositoryMock = new UsersRepository(_dbContextMock);

            _dbContextMock.Users.AddRange(multipleUsers);
            _dbContextMock.SaveChanges();

            var userRetrieved = _repositoryMock.GetUserByEmailAsync(mail);

            userRetrieved.Should().BeNull();
        }
    }
}
