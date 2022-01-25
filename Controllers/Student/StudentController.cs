using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication12.Models.Student;
using WebApplication12.StudentLogic;

using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace WebApplication12.Controllers.Student
{
    public class StudentController : Controller
    {
      
        // GET: Student
        public ActionResult StudentList()
        {
            List<StudentData> StudentList = new List<StudentData>();

            StudentList.Add(new StudentData { StudentId = 27, StudentName = "Alberto", Age = 29 });
            //StudentList.Add(new StudentData { StudentId = 5, StudentName = "Alberto", Age = 27 });
            //StudentList.Add(new StudentData { StudentId = 21, StudentName = "Alberto", Age = 28 });
            //StudentList.Add(new StudentData { StudentId = 9, StudentName = "Alberto", Age = 29 });

            var empnamesEnum = from emp in StudentList
                               select emp.StudentId;


            var maxZ = StudentList.Max(obj => obj.StudentId);

            List<int> empnames = empnamesEnum.ToList();

            Debug.WriteLine("Holaaaaa aquiii: {0}", maxZ);


            string json = JsonConvert.SerializeObject(StudentList);

            List<StudentData> students = JsonConvert.DeserializeObject<List<StudentData>>(json);

            Debug.WriteLine("Holaaaaa: {0}", json);

            //Debug.WriteLine("Holaaaaa1111111: {0}", StudentList);





            //System.IO.File.WriteAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json", json);


            System.IO.File.AppendAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json", json + Environment.NewLine);



            //return View();
            return View(StudentList);
        }


        [ActionName("Find")]
        public ActionResult GetById(string CompanyId, string searchString)
        {



            //Debug.WriteLine("Holaaaaa aquiii Monsssssssssssssssss: {0}", _Id);

            var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

            List<StudentData> _StudentList = new List<StudentData>();

            _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);


            StudentLogic.Dodotodo fai = new Dodotodo();

            fai.Edad = 10;

            StudentLogic.StudentDoSomething qualcosa = new StudentDoSomething();

            qualcosa.readJsonFile();



            //creamos una lista tipo SelectListItem
            List<SelectListItem> lst = new List<SelectListItem>();

            //De la siguiente manera llenamos manualmente,
            //Siendo el campo Text lo que ve el usuario y
            //el campo Value lo que en realidad vale nuestro valor
            lst.Add(new SelectListItem() { Text = "Alberto", Value = "Alberto" });
            lst.Add(new SelectListItem() { Text = "Tom", Value = "Tom" });
            lst.Add(new SelectListItem() { Text = "Pollo", Value = "3" });
            lst.Add(new SelectListItem() { Text = "Gato", Value = "4" });

            //Agregamos la lista a nuestro SelectList
            ViewBag.CompanyId = new SelectList(lst, "Value", "Text");

            Debug.WriteLine("Holaaaaa aquiii Monsssssssssssssssss company: {0}", CompanyId);

            if (!String.IsNullOrEmpty(searchString))
            {
                var newList = _StudentList.Where(s => s.StudentName.Contains(searchString) || s.StudentName == CompanyId);
                return View(newList);
            }
            else
            {
                return View(_StudentList);
            }

            //string json1 = JsonConvert.SerializeObject(newList);

            //Debug.WriteLine("Holaaaaa aquiii Monsssssssssssssssss: {0}", json1);            
        }


        public ActionResult CreateStudent()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CreateStudent(StudentData newStudent)
        {

            if (ModelState.IsValid)
            {

                
                string jsonStudent = JsonConvert.SerializeObject(newStudent);
                Debug.WriteLine("Holaaaaa json student: {0}", jsonStudent);
                Debug.WriteLine("Holaaaaa student age: {0}", newStudent.Age);


                var _StudentDataFile = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

                var _StudentListFile = JsonConvert.DeserializeObject<List<StudentData>>(_StudentDataFile);


                // Chande the student age
                changeStudent changeStudent = new changeStudent();

                changeStudent.changeStudentAge(newStudent);


                _StudentListFile.Add(newStudent);


                string jsonNewFile = JsonConvert.SerializeObject(_StudentListFile);

                System.IO.File.WriteAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json", jsonNewFile);

                //db.AddToMovies(newMovie);
                //db.SaveChanges();

                return RedirectToAction("Find");
            }
            else
            {
                return View(newStudent);
            }
        }

        // GET: Student Delete (View detail of the student to be deleted)
        public ActionResult DeleteStudent(int? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                // Read student file
                var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

                // Create a list of student
                List<StudentData> _StudentList = new List<StudentData>();

                // Deserialize Student List
                _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

                // Select the student to be deleted
                var studentToDelete = _StudentList.Where(s =>  s.StudentId == id).First();


                //string json1 = JsonConvert.SerializeObject(studentToDelete);

                //Debug.WriteLine("Holaaaaa aquiii Monsssssssssssssssss: {0}", json1);


                //StudentData oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentData>(json1);

                // Return detail data of the student to be deletet
                return View(studentToDelete);

            }
        }

        // POST: Student delete
        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Read student file
            var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

            // Create a list of student
            List<StudentData> _StudentList = new List<StudentData>();

            // Deserialize Student List
            _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

            // Select the student to be deleted
            var studentToDelete = _StudentList.Where(s => s.StudentId == id).First();

            string json1 = JsonConvert.SerializeObject(studentToDelete);

            Debug.WriteLine("Holaaaaa delete student arghhttttt: {0}", json1);

            if (studentToDelete != null)
                _StudentList.Remove(studentToDelete);

            string jsonNewFile = JsonConvert.SerializeObject(_StudentList);

            System.IO.File.WriteAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json", jsonNewFile);

            //db.AddToMovies(newMovie);
            //db.SaveChanges();

            return RedirectToAction("Find");

        }

        public ActionResult StudentDetail(int id)
        {
            // Read student file
            var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

            // Create a list of student
            List<StudentData> _StudentList = new List<StudentData>();

            // Deserialize Student List
            _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

            // Select the student to be deleted
            var studentDetail = _StudentList.Where(s => s.StudentId == id).First();

            return View(studentDetail);

        }


        public ActionResult EditStudent(int id)
        {

            // Read student file
            var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

            // Create a list of student
            List<StudentData> _StudentList = new List<StudentData>();

            // Deserialize Student List
            _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

            // Select the student to be deleted
            var studentToEdit = _StudentList.Where(s => s.StudentId == id).First();

            return View(studentToEdit);
        }

        // POST: Student edit
        [HttpPost, ActionName("EditStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(StudentData editStudent)
        {
            if (ModelState.IsValid)
            {


                string jsonStudent = JsonConvert.SerializeObject(editStudent);
                Debug.WriteLine("Holaaaaa json student: {0}", jsonStudent);
                Debug.WriteLine("Holaaaaa student iddddd: {0}", editStudent.StudentId);


                // Read student file
                var _StudentData = System.IO.File.ReadAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json");

                // Create a list of student
                List<StudentData> _StudentList = new List<StudentData>();

                // Deserialize Student List
                _StudentList = JsonConvert.DeserializeObject<List<StudentData>>(_StudentData);

                int id = editStudent.StudentId;

                Debug.WriteLine("Holaaaaa student iddddd2222222: {0}", id);


                // Select the student to be deleted
                var studentToEdit = _StudentList.Where(s => s.StudentId == id).First();





                // Update student
                StudentData _studentEdited = studentToEdit;

                 _studentEdited.StudentId = editStudent.StudentId;

                _studentEdited.Age = editStudent.Age;

                _studentEdited.StudentName = editStudent.StudentName;

                // Remove student from file list
                _StudentList.Remove(studentToEdit);

                // Add edited student to file list
                _StudentList.Add(_studentEdited);


                string jsonNewFile = JsonConvert.SerializeObject(_StudentList);

                System.IO.File.WriteAllText(@"C:\Proyectos\phtree_test\WebApplication12\App_Data\student.json", jsonNewFile);

                //db.AddToMovies(newMovie);
                //db.SaveChanges();

                return RedirectToAction("Find");
            }
            else
            {
                return View(editStudent);
            }

        }

    }
}