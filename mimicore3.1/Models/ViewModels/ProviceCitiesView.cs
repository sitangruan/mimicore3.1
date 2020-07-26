using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.Models.ViewModels
{
    public class ProviceCitiesView: Province
    {
        public List<City> Cities { get; set; }
    }
}
