using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEventComPrism21.ViewModels
{
    public class TestPageViewModel : BindableBase
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public TestPageViewModel()
        {
            _title = "Testseite";
        }
    }
}
