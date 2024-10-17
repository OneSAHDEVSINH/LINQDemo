using LINQDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQDemo.BAL
{
    public class CityProvider
    {
        public List<City> Cities;
        public CityProvider() 
        {
            Cities = new List<City>()
            {
                new City() {CityId=1, Name="Nadiad" },
                new City() {CityId=2, Name="Ahmedabad" },
                new City() {CityId=3, Name="Surat" },
                new City() {CityId=4, Name="Rajkot" },
                new City() {CityId=5, Name="Gondal" },
                new City() {CityId=6, Name="Vadodara" },

            };
        }
    }
}