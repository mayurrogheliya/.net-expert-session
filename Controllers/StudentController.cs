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

    }
}
