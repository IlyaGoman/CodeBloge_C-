using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UserControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);
            
            var controllerActual = new UserController(userName);

            controllerActual.SetUserData(gender, birthDate);

            var controllerExpected = new UserController(userName);

            Assert.AreEqual(userName, controllerActual.CurrentUser.Name);
            Assert.AreEqual(gender, controllerActual.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controllerActual.CurrentUser.BirthDate);
            Assert.AreEqual(1, controllerActual.CurrentUser.Weight);
            Assert.AreEqual(1, controllerActual.CurrentUser.Height);

        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();

            var controller = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}