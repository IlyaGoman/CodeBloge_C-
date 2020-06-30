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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var rnd = new Random();

            var userName = Guid.NewGuid().ToString();
            var userGender = Guid.NewGuid().ToString(); ;
            var userBirthDate = DateTime.Now.AddYears(-20);
            var userController = new UserController(userName);
            userController.SetUserData(userGender, userBirthDate);

            var exersiceController = new ExerciseController(userController.CurrentUser);
            var activityName = Guid.NewGuid().ToString();
            var activity = new Activity(activityName, rnd.Next(10, 50));

            //Act
            exersiceController.Add(activity, DateTime.Now.AddMinutes(-10), DateTime.Now);

            //Assert
            Assert.AreEqual(activity.Name, exersiceController.Activities.SingleOrDefault(f => f.Name == activity.Name).Name);
            //Assert.AreEqual(activity.Name, exersiceController.Activities.First().Name);
        }
    }
}