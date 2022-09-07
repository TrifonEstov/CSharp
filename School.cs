using MyFirstApp;

namespace Project1
{
    internal class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Student> _studentsList;

        public List<Student> StudentsList
        {
            get { return _studentsList; }
            set { _studentsList = value; }
        }

        public School(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddStudent(Student student)
        {
            StudentsList.Add(student);
        }

        public void RemoveStuden(int studentId)
        {
            foreach (var student in StudentsList)
            {
                if (student.Id == studentId)
                {
                    StudentsList.Remove(student);
                }
            }
        }

        public List<Student> ExcellentStuden()
        {
            List<Student> excellentStudents = new List<Student>();

            foreach (var student in StudentsList)
            {
                //TODO
            }

            return excellentStudents;
        }
    }
}
