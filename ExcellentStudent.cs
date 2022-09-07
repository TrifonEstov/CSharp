using MyFirstApp;
using Project1;
using System.Collections;

class ExcellentStudent

{
    static void Main(string[] args)
    {
        /*string sourceFile = GetTestDataPath("TextFile1.txt");
        List<string> linesOfStudents = GetLinesFromFile(sourceFile);
        Dictionary<string, string> studentsInfoFromFile = GetStudentInfo(linesOfStudents);
        Dictionary<string,int> nameAgePairs = new Dictionary<string, int>();
        List<string> subjectMarks = new List<string>();

        foreach (string line in linesOfStudents)
        {
            string[] currentStudentInfo = line.Split(":");
            string[] currentNameAgeInfo = currentStudentInfo[0].Split(",");
            string name = currentNameAgeInfo[0];
            int age = int.Parse(currentNameAgeInfo[1]);
            nameAgePairs.Add(name, age);
            subjectMarks.Add(currentStudentInfo[1]);
        }

        School theSchool = new School("Sofia High School", "str. Sofia 1, Sofia");*/


        object jsonObject = JsonDataFileReader.GetJArray("Students.json");
        string jsonString = jsonObject.ToString();
        Console.WriteLine(jsonString);



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

    private static List<string> GetLinesFromFile(string path)
    {
        List<string> lines = new List<string>();
        StreamReader reader = new StreamReader(path);
        string line;

        do
        {
            line = reader.ReadLine();
            if (line != null)
            {
                lines.Add(line);
            }
        } while (line != null);
        reader.Dispose();

        return lines;
    }

    private static string GetTestDataPath(string fileName)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        basePath = basePath.Replace(@"\bin\Debug\net6.0\", "");
        string absolutePath = basePath + $"\\TestData\\{fileName}";

        return absolutePath;
    }
}