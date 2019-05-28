using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Subject
    {
        public string Name { get; set; }

        private int lessonCount;
        public int LessonsCount
        {
            get { return lessonCount; }
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException(nameof(lessonCount));
                lessonCount = value;
            }
        }

        private int tasksCount;
        public int TasksCount
        {
            get { return tasksCount; }
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException(nameof(tasksCount));
                tasksCount = value;
            }
        }

        public Subject(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public Subject(string name, int lessonCount) : this(name)
        {
            if(lessonCount < 0)
                throw new ArgumentOutOfRangeException(nameof(lessonCount));
            LessonsCount = lessonCount;
        }
        public Subject(string name, int lessonCount, int taskCount) : this(name, lessonCount)
        {
            if(taskCount < 0)
                throw new ArgumentOutOfRangeException(nameof(taskCount));
            TasksCount = taskCount;
        }

    }
}
