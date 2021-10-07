using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyEventComPrism21.ViewModels
{
    public class Conn1PageViewModel : BindableBase
    {
        private string _networkAccess;
        public string NetworkAccess
        {
            get { return _networkAccess; }
            set { SetProperty(ref _networkAccess, value); }
        }

        private string _conn2;
        public string Conn2
        {
            get { return _conn2; }
            set { SetProperty(ref _conn2, value); }
        }

        private string _conn3;
        public string Conn3
        {
            get { return _conn3; }
            set { SetProperty(ref _conn3, value); }
        }

        public Conn1PageViewModel()
        {
            _networkAccess = Connectivity.NetworkAccess.ToString();
			// (Unknown, None, Local, Constrained, Internet)

            if (Connectivity.NetworkAccess  == Xamarin.Essentials.NetworkAccess.None)
            {
                _networkAccess = "NetworkAccess:None: Please connect first.";
            }

            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;


            _conn2 = "Conn2 - leer...";
            _conn3 = "Conn3 - leer...";


        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                NetworkAccess = e.NetworkAccess.ToString();
            });
            //_networkAccess = e.NetworkAccess.ToString();

            // Forts. z.B.
            if (!e.ConnectionProfiles.Contains(ConnectionProfile.Bluetooth))
            {
                // TODO Handle Bluetooth oder andere
            }
			// Bluetooth	1	
			// The bluetooth data connection.

			// Cellular	2	
			// The mobile/cellular data connection.

			// Ethernet	3	
			// The ethernet data connection.

			// Unknown	0	
			// Other unknown type of connection.

			// WiFi	4	
			// The WiFi data connection.

        }
    }
}
