using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace XamFormsBiometrics
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            bool supported = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (supported)
            {
                AuthenticationRequestConfiguration conf =
                    new AuthenticationRequestConfiguration("Access your account",
                        "Access your account");
                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);

                if (result.Authenticated)
                {
                    await DisplayAlert("Success!", "Authentication successful!", "Ok");
                }
                else
                {
                    await DisplayAlert("Sorry!", "Authentication failed!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Sorry!", "Biometrics are not available on your device", "Ok");
            }
            
        }
    }
}
