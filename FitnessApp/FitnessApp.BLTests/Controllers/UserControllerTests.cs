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
        public void SetUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);
            var controllerActual = new UserController(userName);

            controllerActual.SetUserData(gender, birthDate);

            var controllerExpected = new UserController(userName);

            Assert.AreEqual(userName, controllerExpected.CurrentUser.Name);
            Assert.AreEqual(gender, controllerExpected.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controllerExpected.CurrentUser.BirthDate);
            Assert.AreEqual(1, controllerExpected.CurrentUser.Weight);
            Assert.AreEqual(1, controllerExpected.CurrentUser.Height);

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