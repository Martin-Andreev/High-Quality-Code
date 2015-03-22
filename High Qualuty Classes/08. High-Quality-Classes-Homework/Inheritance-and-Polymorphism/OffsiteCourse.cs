using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
             get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town can not be null or empty!");
                }

                this.town = value;
            }
        }


        public override string ToString()
        {
            StringBuilder OffsiteCourseResult = new StringBuilder();
            if (this.Town != null)
            {
                OffsiteCourseResult.Append("; Town = " + this.Town);
            }

            OffsiteCourseResult.Append(" }");
            return base.ToString() + OffsiteCourseResult.ToString();
        }
    }
}
