using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLib.Tests
{
    [TestClass]
    public class SubjectTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubjectConstructor_WhenGiveNameEmpty_ThrowArgumetNullExecption()
        {
            //Arrange
            string name = string.Empty;

            //Act
            Subject subject = new Subject(name);

            //Asert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubjectConstructor_WhenGiveNameAndLessonsCountLessThanZero_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            string name = "Math";
            int lessonCount = -1;

            //Act
            Subject subject = new Subject(name, lessonCount);

            //Asert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubjectConstructor_WhenGiveTasksCountLessThanZero_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            string name = "Math";
            int lessonCount = 2;
            int tasksCount = -5;

            //Act
            Subject subject = new Subject(name, lessonCount, tasksCount);

            //Asert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubjectTasksCount_WhenWriteNegativeNumber_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            string name = "Math";

            int tasksCount = -5;
            Subject subject = new Subject(name);

            //Act
            subject.TasksCount = tasksCount;
            //Asert

        }

        [TestMethod]
        public void SubjectTasksCount_WhenWritePositiveNumber_ShouldBeEqual()
        {
            //Arrange
            string name = "Math";
            int tasksCount = 5;
            int expected = 5;
            Subject subject = new Subject(name);

            //Act
            subject.TasksCount = tasksCount;
            int result = subject.TasksCount;

            //Asert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubjectLessonCount_WhenWriteNegativeNumber_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            string name = "Math";
            int lessonsCount = -5;
            Subject subject = new Subject(name);

            //Act
            subject.LessonsCount = lessonsCount;
            //Asert

        }

        [TestMethod]
        public void SubjectLessonCount_WhenWritePositiveNumber_ShouldBeEqual()
        {
            //Arrange
            string name = "Math";
            int lessonsCount = 5;
            int expected = 5;
            Subject subject = new Subject(name);

            //Act
            subject.LessonsCount = lessonsCount;
            int result = subject.LessonsCount;

            //Asert
            Assert.AreEqual(expected, result);
        }
    }
}
