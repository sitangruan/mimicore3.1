using System;

namespace mimicore3._1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
