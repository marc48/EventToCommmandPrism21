using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyEventComPrism21.Views
{
    public partial class MainPage : ContentPage
    {
        public interface IPageNavigationAware
        {
            void OnAppearing();
            void OnDisappearing();
        }

        public MainPage()
        {
            InitializeComponent();
            Infobox.Text = "Infobox Code behind...";
        }



        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                LabelConnection.FadeTo(0).ContinueWith((result) => { });
                Infobox.Text = "Changed Net Access: " + Connectivity.NetworkAccess.ToString();
                Infobox.BackgroundColor = Color.LightGreen;
            }
            else
            {
                LabelConnection.FadeTo(1).ContinueWith((result) => { });
                Infobox.Text = "Changed Net Access: " + Connectivity.NetworkAccess.ToString();
                Infobox.BackgroundColor = Color.Red;
            }
        }

        protected override void OnAppearing()
        {
            (BindingContext as IPageNavigationAware)?.OnAppearing();
            LabelConnection.Text = "OA Behind Net Access: " + Connectivity.NetworkAccess.ToString();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        protected override void OnDisappearing()
        {
            (BindingContext as IPageNavigationAware)?.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
    }
}
