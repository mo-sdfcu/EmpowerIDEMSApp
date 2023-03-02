using EmpowerIDEMSApp.DataAccessLayer;
using EmpowerIDEMSApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace EmpowerIDEMSApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EMSDbContext dbContext;
        public EmployeeController(EMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// this method retrieve all the employees and search
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  IActionResult Index()
        {
            var employees = (from emp in dbContext.Employees
                             select emp
                             ).ToList();
            return View(employees);
        }
        #region Edit
        /// <summary>
        /// this method update an employee after it has been selected
        /// from Index view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get employee by id
            var employee = (from emp in dbContext.Employees
                            where emp.Id == id
                            select emp
                            ).FirstOrDefault();
            return View(employee);
        }
        /// <summary>
        /// This method post the update
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var _employee = (from emp in dbContext.Employees
                                 where emp.Id == employee.Id
                                 select emp
                                ).FirstOrDefault();
                if (employee != null)
                {
                    _employee.FullName = employee.FullName;
                    _employee.EmailAddress = employee.EmailAddress;
                    _employee.BirthDate = employee.BirthDate;
                    _employee.DepartmentName = employee.DepartmentName;
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
                return View("Error");
        
        }
        #endregion
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId=Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        #region Add New Employee
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(NewEmployeeViewModel newEmployeeModel)
        {
            Employee employee = new Employee();
            employee.FullName = newEmployeeModel.FullName;
            employee.EmailAddress = newEmployeeModel.EmailAddress;
            employee.BirthDate = newEmployeeModel.BirthDate;
            employee.DepartmentName = newEmployeeModel.DepartmentName;
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Employee
        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = (from emp in dbContext.Employees
                            where emp.Id == Id
                            select emp
                          ).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            var employee = (from e in dbContext.Employees
                            where e.Id == emp.Id
                            select e
                            ).FirstOrDefault();
           if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index"); //go back to the employee list/search view
            }
            return RedirectToAction("Index"); //need to send it to the error view
        }
         
        #endregion
    }
}
