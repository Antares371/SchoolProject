using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLib.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void ClassConstructor_WhenGiveName_ShouldBeEqual()
        {
            //Arrange
            string expected = "1A";

            //Act
            Class @class = new Class("1A");

            //Assert                 
            Assert.AreEqual(expected, @class.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClassConstructor_WhenNameIsEmpty_ShouldThrowArgumentException()
        {
            //Arrange
            string name = string.Empty;
            //Act
            Class @class = new Class(name);
            //Assert                 

        }

        [TestMethod]
        public void AddStudent_StudentsCountIsEqualZero_ShouldBeEqual1()
        {
            //Arrange
            Class @class = new Class("1A");
            Student student = new Student("Jan", "Kowalski");
            int expectedIndex = 1;

            //Act
            @class.AddStudent(student);
            int result = @class.Students.Count;
            //Assert                 
            Assert.AreEqual(expectedIndex, result);
        }

        [TestMethod]
        public void StudentIndex_AfterAdd3Students_ThirdStudentIndexShouldBeEqual3()
        {
            //Arrange
            Class @class = new Class("1A");
            int expected = 3;
            int result = -1;
            @class.AddStudent(new Student("A", "A1"));
            @class.AddStudent(new Student("B", "B1"));
                var thirdStudent = new Student("C", "C1");
            @class.AddStudent(thirdStudent);
            //Act
            foreach(var item in @class.Students)
            {
                if(item.Value != thirdStudent)
                    continue;
                result = item.Key;
            }

            //Assert                 
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StudentIndex_AfterSecondRemoveStudent_ThirdStudentIndexShouldBeEqual3()
        {
            //Arrange
            Class @class = new Class("1A");
            int expected = 3;
            int result = -1;
                var s1 = new Student("A", "A1");
                var s2 = new Student("B", "B1");
            var s3= new Student("C", "C1");
            @class.AddStudent(s1);
            @class.AddStudent(s2);
            @class.RemoveStudent(s2);
            @class.AddStudent(s3);
            //Act
            foreach(var item in @class.Students)
            {
                if(item.Value != s3)
                    continue;
                result = item.Key;
            }

            //Assert                 
            Assert.AreEqual(expected, result);
        }

    }
}
