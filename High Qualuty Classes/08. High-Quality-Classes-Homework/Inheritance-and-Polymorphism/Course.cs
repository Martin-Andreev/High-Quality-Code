namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private IList<string> students;

        public Course(string courseName)
        {
            this.CourseName = courseName;
        }

        public Course(string localCourseName, string teacherName)
            : this(localCourseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string localCourseName, string teacherName, IList<string> students)
            : this(localCourseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name can not be null or empty!");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name can not be null or empty!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        throw new ArgumentNullException("Student name can not be null or empty!");
                    }
                }

                this.students = value;
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                throw new ArgumentNullException("Students list is empty!");
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = " + this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = " + this.TeacherName);
            }

            result.Append("; Students = " + this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
