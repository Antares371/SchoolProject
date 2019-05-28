using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLib.Tests
{
    [TestClass]
    public class TeacherTests
    {
        [TestMethod]
        public void TeacherConstructor_WhenGiveName_ShouldBeTrue()
        {
            //Arrange
            string name = "Janusz";
            string surname = "Zawadzki";
            string expectedName = "Janusz";

            //Act
            Teacher teacher = new Teacher(name, surname);

            //Asert
            Assert.AreEqual(expectedName, teacher.Name);
        }

        [TestMethod]
        public void TeacherConstructor_WhenGiveSurname_ShouldBeTrue()
        {
            //Arrange
            string name = "Janusz";
            string surname = "Zawadzki";
            string expectedSurname = "Zawadzki";
            //Act
            Teacher teacher = new Teacher(name, surname);

            //Asert
            Assert.AreEqual(expectedSurname, teacher.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TeacherConstructor_WhenGiveNameEmpty_ThrowArgumetExecption()
        {
            //Arrange
            string name = string.Empty;
            string surname = "Zawadzki";
            //Act
            Teacher teacher = new Teacher(name, surname);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TeacherConstructor_WhenGiveSurnameEmpty_ThrowArgumetExecption()
        {
            //Arrange
            string name = "Janusz";
            string surname = string.Empty;
            //Act
            Teacher teacher = new Teacher(name, surname);
            //Assert
        }

        [TestMethod]
        public void AddSubject_WhenCountIsZero_ShouldBeOne()
        {
            //Arrange
            Teacher teacher = new Teacher("Jan", "Kowalski");
            int expected = 1;
            //Act
            teacher.Subjects.Add(new Subject("Matematyka"));
            //Assert
            Assert.AreEqual(expected, teacher.Subjects.Count);
        }

        [TestMethod]
        public void AddSubject_AddMathWhenExist_ShouldBeSingle()
        {
            //Arrange
            Teacher teacher = new Teacher("Jan", "Kowalski");
            int expected = 1;
            //Act
            teacher.Subjects.Add(new Subject("Math"));
            teacher.Subjects.Add(new Subject("Math"));
            //Assert                 
            Assert.AreEqual(expected, teacher.Subjects.Count);
        }
    }
}
