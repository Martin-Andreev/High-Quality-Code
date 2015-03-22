using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherPerson)
        {
            string firstPersonBirthDate = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            string secondPersonBirthDate = otherPerson.OtherInfo.Substring(otherPerson.OtherInfo.Length - 10);
            DateTime firstDate = DateTime.Parse(firstPersonBirthDate);
            DateTime secondDate = DateTime.Parse(secondPersonBirthDate);
            return firstDate > secondDate;
        }
    }
}
