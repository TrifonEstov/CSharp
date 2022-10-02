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
        private int _age;
        private Dictionary<string, int> _subjectMarks;

        public Student(int id, string name, int age, Dictionary<string, int> marks)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsExcellent { get; set; }

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

        public Dictionary<string, int> Marks { get; set; }

        public bool IsExcelent => Marks.Values.Where(value => value == 6).Count() == Marks.Values.Count;

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
