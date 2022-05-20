using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina Manes", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Test21()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Franco", "FrancoGarcia@gmail.com", "Alvear y Colombres", "+549 1122354215", "SuperUser", "1000");


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Test22()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Marcelo", "marcelojose@gmail.com", "Libertador y General Paz", "+5491154762312", "SuperUser", "1000");


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Test3()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("", "robertoperez@gmail.com", "Av. Juan B Justo", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The name is required", result.Errors);
        }

        [Fact]
        public void Test31()
        {
            var userController = new UsersController();

            var result = userController.CreateUser(null, "robertoperez@gmail.com", "Av. Juan B Justo", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The name is required", result.Errors);
        }

        [Fact]
        public void Test4()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", "", "Av. Juan B Justo", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Errors);
        }

        [Fact]
        public void Test41()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", null, "Av. Juan B Justo", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Errors);
        }

        [Fact]
        public void Test5()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", "robertoperez@gmail.com", "Av. Juan B Justo", "", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The phone is required", result.Errors);
        }

        [Fact]
        public void Test51()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", "robertoperez@gmail.com", "Av. Juan B Justo", null, "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The phone is required", result.Errors);
        }

        [Fact]
        public void Test6()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", "robertoperez@gmail.com", "", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The address is required", result.Errors);
        }

        [Fact]
        public void Test61()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Roberto Perez", "robertoperez@gmail.com", null, "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The address is required", result.Errors);
        }
    }
}
