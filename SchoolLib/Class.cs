using SchoolLib.Collection;
using SchoolLib.Collection.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Class
    {
        private int index = 1;
        public string Name { get; set; }

        public int TeachersCount { get; set; }

        private ReportingCollection<StudentListItem> students;

        public Dictionary<int, Student> Students
        {
            get
            {
                Dictionary<int, Student> studentsList = new Dictionary<int, Student>();
                foreach(var studentItem in students)
                {
                    studentsList.Add(studentItem.Index, studentItem.Student);
                }
                return studentsList;
            }
        }
        private Class()
        {
            students = new ReportingCollection<StudentListItem>();
            students.BeforeCollectionChange += Students_BeforeCollectionChange;
            students.AfterCollectionChanged += Students_AfterCollectionChange;
        }

        public Class(string name) :this()
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        private void Students_BeforeCollectionChange(object sender, ReportingCollectionEventArgs e)
        {
            Student student = e.Item as Student;
            if(Students.ContainsValue(student))
                e.Cancel = false;
        }

        private void Students_AfterCollectionChange(object sender, ReportingCollectionEventArgs e)
        {
            if(e.Action == ReportingCollectionAction.Add)
                index++;
        }

        public void AddStudent(Student student)
        {
            students.Add(new StudentListItem(index, student));
        }
        private class StudentListItem
        {
            public int Index { get; private set; }
            public Student Student { get; private set; }

            public StudentListItem(int index, Student student)
            {
                Index = index;
                Student = student;
            }

        }

        public bool RemoveStudent(Student s2)
        {
          return  students.Remove(students.FirstOrDefault(i => i.Student == s2));
        }
    }
}
