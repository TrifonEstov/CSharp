using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    public class Student
    {
        private const int GraduateAge = 18;
        private int _id;
        private int _age;
        private Dictionary<string, int> _subjectMarks;

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public bool IsExcellent { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 7)
                {
                    throw new ArgumentException("You are not old enough");
                }
                else
                {
                    _age = value;
                }
            }
        }

        public void Speak()
        {
            int yearsLeft = GraduateAge - Age;

            if (yearsLeft <= 0)
            {
                Console.WriteLine($"Hello I'm {Name} and I'll graduate this year.");
            }
            else
            {
                Console.WriteLine($"Hello I'm {Name} and I've got {yearsLeft} years to graduate.");
            }
        }
    }
}
