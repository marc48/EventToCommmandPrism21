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
        public DelegateCommand GoToTestPageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToEventArgsConverterExamplePageCommand = new DelegateCommand(GoToEventArgsConverterExamplePage);
            GoToEventArgsParameterExamplePageCommand = new DelegateCommand(GoToEventArgsParameterExamplePage);
            GoToSimpleExamplePageCommand = new DelegateCommand(GoToSimpleExamplePage);
            GoToTestPageCommand = new DelegateCommand(GoToTestPage);
        }

        private async void GoToTestPage()
        {
            await _navigationService.NavigateAsync("TestPage");
        }

        private async void GoToEventArgsConverterExamplePage()
        {
            await _navigationService.NavigateAsync("EventArgsConverterExamplePage");
        }

        private async void GoToEventArgsParameterExamplePage()
        {
            await _navigationService.NavigateAsync("EventArgsParameterExamplePage");
        }

        private async void GoToSimpleExamplePage()
        {
            await _navigationService.NavigateAsync("SimpleExamplePage");
        }
    }
}
