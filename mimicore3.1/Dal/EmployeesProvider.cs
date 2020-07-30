using mimicore3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mimicore3._1.Dal
{
    public static class EmployeesProvider
    {
        public static List<Employee> Employees { get; private set; }

        static EmployeesProvider()
        {
            Employees = GenerateInitialEmployees();
        }

        public static List<Employee> GetEmployees()
        {
            return Employees;
        }

        public static void RemoveEmployee(int Id)
        {
            if (Employees.Any(emp => emp.Id == Id))
            {
                Employees.Remove(Employees.Find(emp => emp.Id == Id));
            }
        }

        public static void AddOrUpdateEmployee(int Id, string FirstName, string LastName, string Address, int CityId, int DepartmentId)
        {
            if (Id <= 0 || !Employees.Any(emp => emp.Id == Id))
            {
                var newEmpId = Employees.Max(emp => emp.Id) + 1;
                Employees.Add(new Employee
                {
                    Id = newEmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    Address = Address,
                    CityId = CityId,
                    DepartmentId = DepartmentId,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                });
            }
            else
            {
                var found = Employees.Find(emp => emp.Id == Id);
                found.Id = Id;
                found.FirstName = FirstName;
                found.LastName = LastName;
                found.Address = Address;
                found.CityId = CityId;
                found.DepartmentId = DepartmentId;
                found.UpdateDate = DateTime.Now;
            }
        }

        private static List<Employee> GenerateInitialEmployees()
        {
            var empls = new List<Employee>();

            var date1 = new DateTime(2015, 11, 30);
            empls.Add(new Employee
            {
                Id = 1,
                FirstName = "Brad",
                LastName = "Pitt",
                CityId = 1,
                Address = "1000 Rocky Mountain",
                DepartmentId = 1,
                CreateDate = date1,
                UpdateDate = date1
            });

            var date2 = new DateTime(2016, 7, 1);
            empls.Add(new Employee
            {
                Id = 2,
                FirstName = "Johny",
                LastName = "Depp",
                CityId = 11,
                Address = "234 Calvin",
                DepartmentId = 2,
                CreateDate = date2,
                UpdateDate = date2
            });

            var date3 = new DateTime(2017, 10, 15);
            empls.Add(new Employee
            {
                Id = 3,
                FirstName = "Debroah",
                LastName = "Cox",
                CityId = 6,
                Address = "2200 Gordon",
                DepartmentId = 3,
                CreateDate = date3,
                UpdateDate = date3
            });

            var date4 = new DateTime(2018, 5, 25);
            empls.Add(new Employee
            {
                Id = 4,
                FirstName = "Leonardo",
                LastName = "DiCaprio",
                CityId = 9,
                Address = "999 Walls drive",
                DepartmentId = 4,
                CreateDate = date4,
                UpdateDate = date4
            });



            var date5 = new DateTime(2016, 3, 22);
            empls.Add(new Employee
            {
                Id = 5,
                FirstName = "Tom",
                LastName = "Hanks",
                CityId = 2,
                Address = "6677 Guy",
                DepartmentId = 3,
                CreateDate = date5,
                UpdateDate = date5
            });

            var date6 = new DateTime(2018, 5, 25);
            empls.Add(new Employee
            {
                Id = 6,
                FirstName = "Sarah",
                LastName = "Kennis",
                CityId = 3,
                Address = "8000 Westmount",
                DepartmentId = 1,
                CreateDate = date6,
                UpdateDate = date6
            });

            var date7 = new DateTime(2018, 5, 25);
            empls.Add(new Employee
            {
                Id = 7,
                FirstName = "Bree",
                LastName = "Brown",
                CityId = 7,
                Address = "355 Peel",
                DepartmentId = 3,
                CreateDate = date7,
                UpdateDate = date7
            });

            var date8 = new DateTime(2018, 5, 25);
            empls.Add(new Employee
            {
                Id = 4,
                FirstName = "Taylor",
                LastName = "Swift",
                CityId = 9,
                Address = "5556 Harcon",
                DepartmentId = 2,
                CreateDate = date8,
                UpdateDate = date8
            });

            return empls;
        }
    }
}
