using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

using WebApplication12.Models.Student;

namespace WebApplication12.StudentLogic
{

    public class Dodotodo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Edad { get; set; }
    }

    public class StudentDoSomething
    {

        public string jsonFilePath;

        public StudentDoSomething()
        {
            jsonFilePath = @"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json";
        }

        public List<StudentData> readJsonFile()
        {
            // Read student file
            var _StudentData = System.IO.File.ReadAllText(jsonFilePath);

            // Create a list of student
            List<StudentData> _StudentList = new List<StudentData>();

            // Deserialize Student List
            _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

            Debug.WriteLine("Holaaaaa desde read file");

            return _StudentList;
        }
    }

    public class changeStudent
    {

        Boolean _studentModified;

        public changeStudent()
        {
            _studentModified = false;

        }

        public int changeStudentAge(StudentData _student)
        {
            if(_student.Age < 10)
            {
                _student.Age = _student.Age + 15;
                _studentModified = true;
            }

            if(_studentModified == false)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}