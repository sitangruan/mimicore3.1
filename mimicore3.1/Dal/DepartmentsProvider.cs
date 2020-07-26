using mimicore3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.Dal
{
    public static class DepartmentsProvider
    {
        public static List<Department> Departments { get; private set; }

        static DepartmentsProvider()
        {
            Departments = GenerateDepartments();
        }

        private static List<Department> GenerateDepartments()
        {
            var dep = new List<Department>();

            dep.Add(new Department
            {
                Id = 1,
                Name = "Sales"
            });

            dep.Add(new Department
            {
                Id = 2,
                Name = "Marketing"
            });

            dep.Add(new Department
            {
                Id = 3,
                Name = "Accounting"
            }); 
            
            dep.Add(new Department
            {
                Id = 4,
                Name = "Support"
            });

            return dep;
        }
    }
}
