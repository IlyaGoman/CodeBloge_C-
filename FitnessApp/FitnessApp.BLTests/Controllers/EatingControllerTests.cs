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
            var eatingController = new EatingController(new User("Ilya"));

            var addFood = new Food("Water");
            var weight = 300;

            //Act
            eatingController.Add(addFood, weight);

            //Assert
            Assert.AreEqual(addFood.Name, eatingController.Foods.SingleOrDefault(f=>f.Name==addFood.Name));
        }
    }
}