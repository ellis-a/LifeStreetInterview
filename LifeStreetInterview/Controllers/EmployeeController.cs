using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeStreetInterview.Models;

namespace LifeStreetInterview.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly LifestreetContext _context;

        public EmployeeController(LifestreetContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("employee/post")]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee.ToDbObject());
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return Json(employee);
        }

        [HttpGet]
        [Route("employee")]
        public IActionResult ReadAll()
        {
            var employees = _context.Employees.ToList();
            return Json(employees);
        }

        [HttpGet]
        [Route("employee/{id}")]
        public IActionResult ReadById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!EmployeeExists(id.Value))
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Json(employee);
        }

        [HttpPost]
        [Route("employee/put/{id}")]
        public IActionResult Update(int id, EmployeeModel employee)
        {
            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(employee.ToDbObject());
                _context.SaveChanges();
                return Ok();
            }
            return Json(employee);
        }

        [HttpDelete]
        [Route("employee/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}