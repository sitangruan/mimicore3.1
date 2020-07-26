using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mimicore3._1.Dal;
using mimicore3._1.Models.ViewModels;

namespace mimicore3._1.Controllers.Api
{
    [Produces("application/json")]
    public class EmployeeController : BaseApiController<EmployeeController>
    {
        public EmployeeController(ILogger<EmployeeController> logger) : base(logger)
        {
        }

        [HttpGet]
        public List<EmployeeView> GetEmployees()
        {
            var emps = EmployeesProvider.GetEmployees();
            var cities = CitiesProvider.Cities;
            var provinces = CitiesProvider.Provinces;
            var departments = DepartmentsProvider.Departments;

            var views = from emp in emps
                        join city in cities on emp.CityId equals city.Id
                        join prov in provinces on city.ProvinceId equals prov.Id
                        join dept in departments on emp.DepartmentId equals dept.Id
                        select new EmployeeView
                        {
                            Id = emp.Id,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            CityId = emp.CityId,
                            CityName = city.Name,
                            ProvinceId = city.ProvinceId,
                            ProvinceName = prov.Name,
                            Address = emp.Address,
                            DepartmentId = emp.DepartmentId,
                            DepartmentName = dept.Name,
                            CreateDate = emp.CreateDate
                        };

            return views.ToList();
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            EmployeesProvider.RemoveEmployee(Id);
            return NoContent();
        }
    }
}
