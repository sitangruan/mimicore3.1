using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.Models.ViewModels
{
    public class EmployeeView: Employee
    {
        public string CityName { get; set; }
        
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }

        public string DepartmentName { get; set; }
    }
}
