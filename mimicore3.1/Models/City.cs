using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }
    }

    public class Province
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
