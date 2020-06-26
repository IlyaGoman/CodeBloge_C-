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
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var eatingController = new EatingController(new User(userName));

            var addFood = new Food(foodName);
            var weight = 300;

            //Act
            eatingController.Add(addFood, weight);

            //Assert
            Assert.AreEqual(addFood.Name, eatingController.Foods.SingleOrDefault(f=>f.Name==addFood.Name).Name);
        }
    }
}