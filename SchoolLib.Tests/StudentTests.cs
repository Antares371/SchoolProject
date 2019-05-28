using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchoolLib.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentConstructor_WhenGiveName_ShouldBeFalse()
        {
            //Arrange
            string name = "Marek";
            string surname = "Nowak";
            string expectedName = "£ukasz";

            //Act
            Student student = new Student(name, surname);

            //Asert
            Assert.AreNotEqual(expectedName, student.Name);
        }

        [TestMethod]
        public void StudentConstructor_WhenGiveSurname_ShouldBeFalse()
        {
            //Arrange
            string name = "Marek";
            string surname = "Nowak";
            string expectedSurname = "Bogacki";
            //Act
            Student student = new Student(name, surname);

            //Asert
            Assert.AreNotEqual(expectedSurname, student.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_WhenGiveNameEmpty_ThrowArgumetExecption()
        {
            //Arrange
            string name = string.Empty;
            string surname = "Nowak";
            //Act
            Student student = new Student(name, surname);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_WhenGiveSurnameEmpty_ThrowArgumetExecption()
        {
            //Arrange
            string name = "Marek";
            string surname = string.Empty;
            //Act
            Student student = new Student(name, surname);
            //Assert
        }
    }
}
