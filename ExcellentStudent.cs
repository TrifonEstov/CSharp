using MyFirstApp;
using Newtonsoft.Json.Linq;
using Project1;
using System.Collections;

class ExcellentStudent

{
    static void Main(string[] args)
    {
        School theSchool = new School("Sofia High School", "str. Sofia 1, Sofia");

        JArray jsonObjects = JsonDataFileReader.GetJArray("Students.json");
        List<JObject> students = jsonObjects.ToObject<List<JObject>>();
        List<JObject> studentsListWithIds =  AddStudentId(students);

        foreach (var student in studentsListWithIds)
        {
            Student currentStudentFromTheList = student.ToObject<Student>();
            currentStudentFromTheList.Name = student.GetValue("Name").ToObject<string>();
            currentStudentFromTheList.Id = student.GetValue("Id").ToObject<int>();
            currentStudentFromTheList.Marks = student.GetValue("Marks").ToObject<Dictionary<string, int>>();
            theSchool.StudentsList.Add(currentStudentFromTheList);
        }

        List<Student> excellentStudents = theSchool.GetExcelentStudents();
        
        foreach (var excellentStudent in excellentStudents)
        {
            excellentStudent.Speak();
        }
    }

    private static List<JObject> AddStudentId(List<JObject> students)
    {
        List<JObject> studentsListWithIds = new List<JObject>();
        foreach (var studentObject in students)
        {
            Random random = new Random();
            int randomId = random.Next();
            studentObject.Add("Id", randomId);
            studentsListWithIds.Add(studentObject);
        }
        return studentsListWithIds;
    }
    private static void WriteToFile(string outputFile, string pancakeNameList)
    {
        StreamWriter writer = new StreamWriter(outputFile);
        writer.WriteLine(pancakeNameList);
        writer.Dispose();
    }

    private static string CreateFinalNameList(List<string> filteredPeople)
    {
        string finalMessage = string.Join(" and ", filteredPeople) + " will make pancakes.";
        
        return finalMessage;
    }

    private static List<string> FilterPeopleForPancakes(Dictionary<string, string[]> nameProductPair)
    {
        List<string> filteredNamesForPancakes = new List<string>();
        foreach (var pair in nameProductPair)
        {
            List<string> products = pair.Value.ToList();
            if (products.Contains("Eggs") && products.Contains("Milk") && products.Contains("Butter") && products.Contains("Flour"))
            {
                filteredNamesForPancakes.Add(pair.Key);
            }
        }

        return filteredNamesForPancakes; 
    }

    private static Dictionary<string, string> GetStudentInfo(List<string> lines)
    {
        Dictionary<string, string> nameAgeSubjectMarksPairs = new Dictionary<string, string>();
        foreach (string line in lines)
        {
            string[] nameAgeAndSubjectMarks = line.Split(":");
            string nameAgePair = nameAgeAndSubjectMarks[0];
            string subjectMakrsPair = nameAgeAndSubjectMarks[1];

            nameAgeSubjectMarksPairs.Add(nameAgePair, subjectMakrsPair);
        }

        return nameAgeSubjectMarksPairs;
    }
}