using SchoolLib.Collection;
using SchoolLib.Collection.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class School
    {
        public ReportingCollection<Class> Classes { get; private set; }

        public List<Student> Students { get { return GetStudents(); } }
        public School()
        {
            Classes = new ReportingCollection<Class>();
            Classes.BeforeCollectionChange += Classes_BeforeCollectionChange;
        }

        private void Classes_BeforeCollectionChange(object sender, ReportingCollectionEventArgs e)
        {
            Class @class = e.Item as Class;
            if(ClassExist(@class.Name))
                e.Cancel = true;   
        }

        public bool ClassExist(string className)
        {
            if(Classes.Any(s => s.Name == className))
                return true;
            return false;
        }

        private List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            foreach(var @class in Classes)
            {
                students.AddRange(@class.Students.Values);
            }
            return students;
        }

        public Class AddNewClass(string className)
        {
            if(ClassExist(className))
                return Classes.FirstOrDefault(c=> c.Name == className);

            Class newClass = new Class(className);
            Classes.Add(newClass);
            return newClass;
        }
    }
}
