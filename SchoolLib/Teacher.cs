using SchoolLib.Collection;
using SchoolLib.Collection.Reporting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Teacher : Person
    {
        public ReportingCollection<Subject> Subjects { get; set; }
        public Teacher(string name, string surname) : base(name, surname)
        {
            Subjects = new ReportingCollection<Subject>();
            Subjects.BeforeCollectionChange += Subjects_BeforeCollectionChange;
        }

        private void Subjects_BeforeCollectionChange(object sender, ReportingCollectionEventArgs e)
        {
            Subject subject = e.Item as Subject;
            if(Subjects.Any(s => s.Name == subject.Name))
                e.Cancel = true;
        }
    }
}
