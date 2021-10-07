using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyEventComPrism21.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private string _networkAccess;
        public string NetworkAccess
        {
            get { return _networkAccess; }
            set { SetProperty(ref _networkAccess, value); }
        }

        public DelegateCommand GoToConn1PageCommand { get; private set; }
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
            GoToConn1PageCommand = new DelegateCommand(GotoConn1Page);

            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkAccess = e.NetworkAccess.ToString();
        }

        private async void GotoConn1Page()
        {
            await _navigationService.NavigateAsync("Conn1Page");
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
