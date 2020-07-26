using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mimicore3._1.Dal;
using mimicore3._1.Models;
using mimicore3._1.Models.ViewModels;

namespace mimicore3._1.Controllers.Api
{
    [Produces("application/json")]
    public class CommonController : BaseApiController<CommonController>
    {
        public CommonController(ILogger<CommonController> logger) : base(logger)
        {
        }

        [HttpGet]
        public List<ProviceCitiesView> GetProvinceCities()
        {
            var cities = CitiesProvider.Cities;
            var provices = CitiesProvider.Provinces;

            var pcArray = from prov in provices
                         select (new ProviceCitiesView
                         {
                             Id = prov.Id,
                             Name = prov.Name,
                             Cities = (from city in cities where city.ProvinceId == prov.Id select city).ToList()
                         });

            return pcArray.ToList();
        }
    }
}
