using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);


            Assert.ThrowsException<ArgumentNullException>(() => new User("", new Gender(gender), birthDate, 100, 100));
            Assert.ThrowsException<ArgumentNullException>(() => new User(userName, null, birthDate, 100, 100));
            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), DateTime.Parse("01.01.1000"), 100, 100));
            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate, -100, 100));
            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate, 100, -100));
        }
    }
}