using orkut2x.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace orkut2x.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();
            username.Text = AuthProvider.Username;
            profilePicture.Source = AuthProvider.Pic;
		}

        private void LogoutButton_Clicked(object sender, EventArgs e) {
            AuthProvider.Pic = "capi.png"; //default
            AuthProvider.Username = "";
            AuthProvider.Uuid = "";
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}