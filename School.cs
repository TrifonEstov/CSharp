using MyFirstApp;

namespace Project1
{
    public class School
    {
        public School(string name, string address)
        {
            Name = name;
            Address = address;
            StudentsList = new List<Student>();
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public List<Student> StudentsList { get; set; }

        public void AddStudent(Student student)
        {
            StudentsList.Add(student);
        }

        public void AddStudents(List<Student> students)
        {
            StudentsList.AddRange(students);
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

        public List<Student> GetExcelentStudents() => StudentsList.Where(student => student.IsExcelent).ToList();
    }
}
