using MyEventComPrism21.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEventComPrism21.Services
{
    public interface IDataProvider
    {
        List<Developer> GetAllData();
    }
}
