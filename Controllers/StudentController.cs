using expertsession.Data;
using expertsession.Models;
using Microsoft.AspNetCore.Mvc;

namespace expertsession.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRegisterDBContext student1;

        public StudentController(StudentRegisterDBContext student1)
        {
            this.student1 = student1;
        }

        [HttpGet]
        public IActionResult StudentAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentAdd(StudentRegister studentReg)
        {
            var register = new StudentRegister
            {
                student_name = studentReg.student_name,
                student_branch = studentReg.student_branch,
                student_roll = studentReg.student_roll,
            };
            await student1.StudentRegister.AddAsync(register);
            await student1.SaveChangesAsync();
            return RedirectToAction("StudentAdd");
        }

        // ***********************************************************************

        AddStudentModel objStudent = new AddStudentModel();

        [HttpGet]
        public IActionResult Index()
        {
            objStudent = new AddStudentModel();
            List<AddStudentModel> lst = objStudent.getData("");
            return View(lst);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentModel stu)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.insert(stu);
                if (res)
                {
                    TempData["msg"] = "Added successfully";
                }
                else
                {
                    TempData["msg"] = "Not Added. Something went wrong...!!";
                }
            }
            TempData.Keep("msg");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent(string id)
        {
            List<AddStudentModel> emp = objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }

        [HttpGet]
        public IActionResult DeleteStudent(string id)
        {
            List<AddStudentModel> emp = objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditStudent(AddStudentModel stu)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.update(stu);
                if (res)
                {
                    TempData["msg"] = "Updated successfully";
                }
                else
                {
                    TempData["msg"] = "Not Updated. Something went wrong...!!";
                }
            }
            TempData.Keep("msg");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteStudent(AddStudentModel stu)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.delete(stu);
                if (res)
                {
                    TempData["msg"] = "Deleted successfully";
                }
                else
                {
                    TempData["msg"] = "Not Deleted. Something went wrong...!!";
                }
            }
            TempData.Keep("msg");
            return RedirectToAction("Index");
        }
    }
}
