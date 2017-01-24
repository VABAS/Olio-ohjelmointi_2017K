using System;
namespace H03T05
{
    class Student
    {
        private string studentId;
        private string firstName;
        private string lastName;
        private string birthDate;
        private string group;
        
        // Properties.
        public string StudentId {
            get { return studentId; }
            set { studentId = value; }
        }
        public string FistName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public string BirthDate {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public string Group {
            get { return group; }
            set { group = value; }
        }
        
        // Constructors.
        public Student (string studentId, string firstName, string lastName, string birthDate, string group)
        {
            StudentId = studentId;
            FistName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Group = group;
            Console.WriteLine("Created new student '" + firstName + " " + lastName + "' (" + studentId + ").");
        }
        
        // Methods.
        public void printData ()
        {
            Console.WriteLine("Printing student data:");
            Console.WriteLine("ID: " + studentId);
            Console.WriteLine("Name: " + firstName + " " + lastName);
            Console.WriteLine("Birthday: " + birthDate);
            Console.WriteLine("Group:" + group);
            Console.WriteLine();
        }
    }
}