using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLib.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonConstructor_WhenGiveName_ShouldBeTrue()
        {
            //Arrange
            string name = "Jan";
            string surname = "Kowalski";
            string expectedName = "Jan";

            //Act
            Person person = new Person(name, surname);

            //Asert
            Assert.AreEqual(expectedName, person.Name);
        }

        [TestMethod]
        public void PersonConstructor_WhenGiveSurname_ShouldBeTrue()
        {
            //Arrange
            string name = "Jan";
            string surname = "Kowalski";
            string expectedSurname = "Kowalski";
            //Act
            Person person = new Person(name, surname);

            //Asert
            Assert.AreEqual(expectedSurname, person.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonConstructor_WhenGiveNameEmpty_ThrowArgumetExecption()
        {      
            //Arrange
            string name = string.Empty;
            string surname = "Kowalski";
            //Act
            Person person = new Person(name, surname);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonConstructor_WhenGiveSurnameEmpty_ThrowArgumetExecption()
        {
            //Arrange
            string name = "Jan";
            string surname = string.Empty;
            //Act
            Person person = new Person(name, surname);
            //Assert
        }
    }
}
