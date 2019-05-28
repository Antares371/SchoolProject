using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLib.Tests
{
    [TestClass]
    public class SchoolTests
    {
        public void SchoolConstructor_WhenCreateClassesCollection_IsNotNull()
        {
            //Arrange

            //Act
            School school = new School();
            //Assert
            Assert.IsNotNull(school.Classes);
        }

        [TestMethod]
        public void SchoolConstructor_WhenCreateClassesCountIs0_ShouldBeTrue()
        {
            //Arrange
            int expected = 0;
            //Act
            School school = new School();
            //Assert
            Assert.AreEqual(expected, school.Classes.Count);
        }
        [TestMethod]
        public void SchoolConstructor_WhenCreateStudentsCollection_IsNotNull()
        {
            //Arrange

            //Act
            School school = new School();
            //Assert
            Assert.IsNotNull(school.Students);
        }

        [TestMethod]
        public void SchoolConstructor_WhenCreateStudentsCountIs0_ShouldBeTrue()
        {
            //Arrange
            int expected = 0;
            //Act
            School school = new School();
            //Assert
            Assert.AreEqual(expected, school.Students.Count);
        }
        [TestMethod]
        public void AddNewClass_WhenAddNewNotExistingClass_ClassCountShouldEqualOne()
        {

            //Arrange
            string className = "1A";
            School school = new School();
            int expected = 1;
            //Act
            school.AddNewClass(className);
            //Assert
            Assert.AreEqual(expected, school.Classes.Count);
        }
        [TestMethod]
        public void AddNewClass_WhenAddNewClassWithTheSameNameWhatExisting_ClassCountShouldEqualOne()
        {          
            //Arrange
            string className = "1A";
            School school = new School();
            int expected = 1;
            school.AddNewClass(className);
            //Act
            school.AddNewClass(className);
            //Assert
            Assert.AreEqual(expected, school.Classes.Count);
        }

        [TestMethod]
        public void GetStudents_WhenAddOneClassWithOneStudent_SchouldBeEqualOne()
        {
            //Arrange
            School school = new School();
            Student student = new Student("Jan", "Kowalski");
            int expected = 1;
            //Act
            Class @class = school.AddNewClass("1A");
            @class.AddStudent(student);
            int result = school.Students.Count;
            //Assert                 
            Assert.AreEqual(expected, result);
        }

       



    }
}
