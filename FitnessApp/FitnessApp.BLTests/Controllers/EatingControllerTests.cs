using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest_WhenAddedNewFoodIntoEating_ShouldAreEquals()
        {
            //Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var userGender = Guid.NewGuid().ToString(); ;
            var userBirthDate = DateTime.Now.AddYears(-20);
            var userController = new UserController(userName);
            userController.SetUserData(userGender, userBirthDate);

            var eatingController = new EatingController(userController.CurrentUser);
            var foodName = Guid.NewGuid().ToString();

            var addFood = new Food(foodName);
            var weight = rnd.Next(10,500);

            //Act
            eatingController.Add(addFood, weight);

            //Assert
            Assert.AreEqual(addFood.Name, eatingController.Foods.SingleOrDefault(f => f.Name == addFood.Name).Name);
            Assert.AreEqual(addFood.Name, eatingController.Eating.Foods.Keys.SingleOrDefault(f => f.Name == addFood.Name).Name);
        }
    }
}