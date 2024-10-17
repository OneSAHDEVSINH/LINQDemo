using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQDemo.DAL;

namespace LINQDemo.BAL
{
    public class PersonProvider
    {
        public List<Person> Persons;
        public PersonProvider()
        {
            Persons = new List<Person>()
            {
                new Person() { PersonId = 1, Name = "John", Age = 22, CityId = 1 },
                new Person() { PersonId = 2, Name = "Moin", Age = 45, CityId = 2 },
                new Person() { PersonId = 3, Name = "Bill", Age = 28, CityId = 3 },
                new Person() { PersonId = 4, Name = "Ram", Age = 18, CityId = 4 },
                new Person() { PersonId = 5, Name = "Ronit", Age = 45, CityId = 5 },
            };
        }
    }
}