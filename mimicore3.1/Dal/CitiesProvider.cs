using mimicore3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.Dal
{
    public class CitiesProvider
    {
        public static List<City> cities { get; private set; }
        public static List<Province> provinces { get; private set; }

        static CitiesProvider()
        {
            cities = GenerateCities();
            provinces = GenerateProvinces();
        }

        private static List<City> GenerateCities()
        {
            var cities = new List<City>();

            cities.Add(new City
            {
                Id = 1,
                Name = "Montreal",
                ProvinceId = 1
            });

            cities.Add(new City
            {
                Id = 2,
                Name = "Sherbrooke",
                ProvinceId = 1
            });

            cities.Add(new City
            {
                Id = 3,
                Name = "Rimouski",
                ProvinceId = 1
            });

            cities.Add(new City
            {
                Id = 4,
                Name = "Brossard",
                ProvinceId = 1
            });

            cities.Add(new City
            {
                Id = 5,
                Name = "Toronto",
                ProvinceId = 2
            });

            cities.Add(new City
            {
                Id = 6,
                Name = "Waterloo",
                ProvinceId = 2
            });

            cities.Add(new City
            {
                Id = 7,
                Name = "London",
                ProvinceId = 2
            });

            cities.Add(new City
            {
                Id = 8,
                Name = "Calgary",
                ProvinceId = 3
            });

            cities.Add(new City
            {
                Id = 9,
                Name = "Edmonton",
                ProvinceId = 3
            });

            cities.Add(new City
            {
                Id = 10,
                Name = "Banff",
                ProvinceId = 3
            });

            cities.Add(new City
            {
                Id = 11,
                Name = "Vancouver",
                ProvinceId = 4
            });

            cities.Add(new City
            {
                Id = 12,
                Name = "Victoria",
                ProvinceId = 4
            });

            cities.Add(new City
            {
                Id = 13,
                Name = "Richmond",
                ProvinceId = 4
            });

            return cities;
        }

        private static List<Province> GenerateProvinces()
        {
            var provinces = new List<Province>();

            provinces.Add(new Province
            {
                Id = 1,
                Name = "Quebec"
            });

            provinces.Add(new Province
            {
                Id = 2,
                Name = "Ontario"
            });

            provinces.Add(new Province
            {
                Id = 3,
                Name = "Alberta"
            }); 
            
            provinces.Add(new Province
            {
                Id = 4,
                Name = "British Columbia"
            });

            return provinces;
        }
    }
}
