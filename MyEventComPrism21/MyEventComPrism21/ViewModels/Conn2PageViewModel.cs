using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyEventComPrism21.ViewModels
{
    public class Conn2PageViewModel : BindableBase, IPageLifecycleAware
    {
        IPageDialogService _dialogService;
        void IPageLifecycleAware.OnAppearing()
        {
            
        }

        private string _connStatus;
        public string ConnStatus
        {
            get { return _connStatus; }
            set { SetProperty(ref _connStatus, value); }
        }
        public Conn2PageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            // bei Monetmagno in OnAppearing
            _connStatus = "C Network Access: " + Connectivity.NetworkAccess.ToString();

            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
        }

        private async void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {
            ConnStatus = "Network Access: " + e.NetworkAccess;
            await _dialogService.DisplayAlertAsync("Connectivity Changed", "Network Access: " + e.NetworkAccess, "OK");
        }

        protected void OnAppearing()
        {
            // funktioniert NICHT !
            //base.OnAppearing();

            _connStatus = "OA Network Access: " + Connectivity.NetworkAccess.ToString();
        }

        public void OnNavigatedTo()
        {
            _connStatus = "ON Network Access: " + Connectivity.NetworkAccess.ToString();
        }

 

        public void OnDisappearing()
        {
            throw new NotImplementedException();
        }
    }
}
