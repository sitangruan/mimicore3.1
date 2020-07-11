using mimicore3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mimicore3._1.Dal
{
    public static class EmployeesProvider
    {
        public static List<Employee> employees { get; private set; }

        static EmployeesProvider()
        {
            employees = GenerateInitialEmployees();
        }

        public static List<Employee> GetEmployees()
        {
            return employees;
        }

        public static void RemoveEmployee(int Id)
        {
            if (employees.Any(emp => emp.Id == Id))
            {
                employees.Remove(employees.Find(emp => emp.Id == Id));
            }
        }

        public static void AddOrUpdateEmployee(Employee emp)
        {
            RemoveEmployee(emp.Id);
            employees.Add(emp);
        }

        private static List<Employee> GenerateInitialEmployees()
        {
            var empls = new List<Employee>();

            empls.Add(new Employee
            {
                Id = 1,
                FirstName = "Brad",
                LastName = "Pitt",
                CityId = 1,
                Address = "1000 Rocky Mountain",
                DepartmentId = 1,
                CreateDate = new DateTime(2015, 11, 30)
            });

            empls.Add(new Employee
            {
                Id = 1,
                FirstName = "Johny",
                LastName = "Depp",
                CityId = 11,
                Address = "234 Calvin",
                DepartmentId = 2,
                CreateDate = new DateTime(2016, 7, 1)
            });

            empls.Add(new Employee
            {
                Id = 1,
                FirstName = "Debroah",
                LastName = "Cox",
                CityId = 6,
                Address = "2200 Gordon",
                DepartmentId = 3,
                CreateDate = new DateTime(2017, 10, 15)
            });

            empls.Add(new Employee
            {
                Id = 1,
                FirstName = "Leonardo",
                LastName = "DiCaprios",
                CityId = 9,
                Address = "999 Walls drive",
                DepartmentId = 4,
                CreateDate = new DateTime(2018, 5, 25)
            });

            return empls;
        }
    }
}
