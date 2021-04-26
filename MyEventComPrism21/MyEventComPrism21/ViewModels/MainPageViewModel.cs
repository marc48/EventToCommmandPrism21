using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEventComPrism21.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToEventArgsConverterExamplePageCommand { get; private set; }
        public DelegateCommand GoToEventArgsParameterExamplePageCommand { get; private set; }
        public DelegateCommand GoToSimpleExamplePageCommand { get; private set; }

        public MainPageViewModel()
        {

        }
    }
}
