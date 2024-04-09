using Microsoft.AspNetCore.Mvc;
//TODO: reference Models namespace
using COMP003B_Lecture_3.Models;

namespace COMP003B_Lecture_3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>();
        //GET: Studets/ 
        [HttpGet]
        public IActionResult Index()
        {
            return View(_students);
        }
        //Get: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        //Post: Studets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            //TODO: add model state validation
            if (ModelState.IsValid)
            {
                //TODO: Check if student already exists
                if (!_students.Any(s => s.Id == student.Id))
                {
                    //TODO: add student to list
                    _students.Add(student);
                }

                //TODO: redirect to Index
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Get: Students/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //TODO: Check if id is null
            if(id== null)
            {
                return NotFound();
            }
            //TODO: find student by id
            var student = _students.FirstOrDefault(p => p.Id == id);

            //TODO: Check if student is still null
            if(student == null)
            {
                return NotFound();
            }

            //TODO: Return student to view
            return View(student);
        }

        //Post: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            //TODO: Check if Id is same as student Id
            if (id != student.Id)
            {
                return NotFound();
            }


            if(ModelState.IsValid)
            {
                var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
                if(existingStudent != null)
                {
                    //TODO: Update student details
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }

                //TODO: return back to index
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        //Get: Students/ Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //TODO: Null check
            if(id == null)
            {
                return NotFound();
            }

            //TODO: find student by id
            var student = _students.FirstOrDefault(s => s.Id == id);

            //TODO: NUll Check
            if(student == null)
            {
                return NotFound();
            }
            //TODO: returns the view of the student found from the list
            return View(student);
        }

        //Post: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            //TODO: Look for student
            var student = _students.FirstOrDefault(s => s.Id == id);
            //TODO: Student found on list
            if(student != null)
            {
                //TODO: Removes student
                _students.Remove(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
