using System;
using System.Collections.Generic;
using System.Text;
using Prism.AppModel;

namespace MyEventComPrism21.Services
{
    public interface INavigationAware
    {
         void OnAppearing();
         void OnDisappearing();
    }
}
