using System;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace MyEventComPrism21.Views
{
    public partial class Conn2Page : ContentPage
    {
        public interface IPageNavigationAware
        {
            void OnAppearing();
            void OnDisappearing();
        }

        public Conn2Page()
        {
            InitializeComponent();
            LabelStatus.Text = "Constructor";
            
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("No Internet", "", "OK");
                LabelTest.IsVisible = false;
                return;
            }
            else
            {
                LabelTest.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            (BindingContext as IPageNavigationAware)?.OnAppearing();
            LabelStatus.Text = "OA Behind Net Access: " + Connectivity.NetworkAccess.ToString();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                LabelConnection.FadeTo(0).ContinueWith((result) => { });
                LabelStatus.Text = "Changed Net Access: " + Connectivity.NetworkAccess.ToString();
            }
            else
            {
                LabelConnection.FadeTo(1).ContinueWith((result) => { });
                LabelStatus.Text = "Changed Net Access: " + Connectivity.NetworkAccess.ToString();
            }
        }

        protected override void OnDisappearing()
        {
            (BindingContext as IPageNavigationAware)?.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
    }
}
