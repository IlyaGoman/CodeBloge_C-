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
        public void CreateUser_WhenUserNameNullOrWhiteSpace()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "male";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 100;
            var height = 100;

            Assert.ThrowsException<ArgumentNullException>(() => new User("", new Gender(gender), birthDate, weight, height));
            Assert.ThrowsException<ArgumentNullException>(() => new User(null, new Gender(gender), birthDate, weight, height));
        }

        [TestMethod()]
        public void CreateUser_WhenGenderIsNull()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 100;
            var height = 100;

            Assert.ThrowsException<ArgumentNullException>(() => new User(userName, null, birthDate, weight, height));
        }

        [TestMethod()]
        public void CreateUser_WhenBirthDateOutOfRange()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-800);
            var birthDate1 = DateTime.Now.AddYears(+100);
            var weight = 100;
            var height = 100;

            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate, weight, height));
            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate1, weight, height));
        }

        [TestMethod()]
        public void CreateUser_WhenWeightOrHeightOutOfRange()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight1 = 100;
            var height1 = -100;
            var weight2 = -100;
            var height2 = 100;

            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate, weight1, height1));
            Assert.ThrowsException<ArgumentException>(() => new User(userName, new Gender(gender), birthDate, weight2, height2));
        }
    }
}