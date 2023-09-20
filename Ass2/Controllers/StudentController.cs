using Ass2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> student = new List<Student>();

        public StudentController()
        {
            if (student.Count == 0)
            {
                student.Add(new Student { StudentID = 1, Name = "abc", DateOfBirth = DateTime.Parse("01-06-2002"), Gender = "female", Hobbies = new List<string> { "Dancing" } });
            }
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(student.ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student s = student.Where(stud => stud.StudentID == id).FirstOrDefault();
            return View(s);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            var model = new Student();
            model.Hobbies = new List<string> { "Sports", "Reading", "Dancing", "Touring", "Adventure" };
            return View(model);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStudent)
        {
            try
            {
                student.Add(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Hobbies = new List<string> { "Sports", "Reading", "Dancing", "Touring", "Adventure" };
            Student sedit = student.Where(stud => stud.StudentID == id).FirstOrDefault();

            return View(sedit);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student editStudent)
        {
            try
            {
                Student sedit = student.Where(stud => stud.StudentID == id).FirstOrDefault();
                sedit.Name = editStudent.Name;
                sedit.DateOfBirth = editStudent.DateOfBirth;
                sedit.Gender = editStudent.Gender;
                sedit.Hobbies = editStudent.Hobbies;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student sdlt = student.Where(stud => stud.StudentID == id).FirstOrDefault();
            return View(sdlt);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Student s = student.Where(stud => stud.StudentID == id).FirstOrDefault();
                student.Remove(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
