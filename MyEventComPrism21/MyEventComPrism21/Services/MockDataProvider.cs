using MyEventComPrism21.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEventComPrism21.Services
{
    public class MockDataProvider : IDataProvider
    {
        public List<Developer> GetAllData()
        {
            return new List<Developer>()
            {
                new Developer()
                {
                    FullName = "Brian Lagunas",
                    Country = "United States"
                },
                new Developer()
                {
                    FullName = "Dan Siegel",
                    Country = "United States"
                },
                new Developer()
                {
                    FullName = "Glenn Versweyveld",
                    Country = "Belgium"
                },
                new Developer()
                {
                    FullName = "Hussain Abbasi",
                    Country = "United States"
                },
                new Developer()
                {
                    FullName = "Almir Vuk",
                    Country = "Bosnia and Herzegovina"
                },
            };
        }
    }
}
