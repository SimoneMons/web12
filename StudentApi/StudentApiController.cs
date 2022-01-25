using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApplication12.Models.Student;

using WebApplication12.StudentLogic;

namespace WebApplication12.StudentApi
{
    public class StudentApiController : ApiController
    {
        // GET Student Data api/StudentApi

        public IHttpActionResult Get()
        {
            //var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

            //List<StudentData> _StudentList = new List<StudentData>();

            //_StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

            //string json1 = JsonConvert.SerializeObject(_StudentList);

            //Debug.WriteLine("Holaaaaa aquiii Monsssssssssssssssss: {0}", json1);

            StudentDoSomething studentDo = new StudentDoSomething();

            List<StudentData> _StudentList = studentDo.readJsonFile();

            if (_StudentList == null)
            {
                return NotFound();
            }

            return Ok(_StudentList);
        }
    }
}
