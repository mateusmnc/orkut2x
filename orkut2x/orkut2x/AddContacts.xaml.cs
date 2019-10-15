using orkut2x.model;
using orkut2x.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace orkut2x
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContacts : ContentPage
	{
        ObservableCollection<User> FriendsSource { get; set; }

        public AddContacts ()
		{
			InitializeComponent ();
            DataExchanger dataExchanger = new DataExchanger();
            FriendsSource = new ObservableCollection<User>();
            User[] users = dataExchanger.getUsers();
            if (users.Length > 0) {
                foreach (User user in users) {
                    FriendsSource.Add(user);
                }
            }

            FriendsList.ItemsSource = FriendsSource;
            BindingContext = FriendsSource;
        }

        private void AddFriend_Clicked(object sender, EventArgs e) {
            ImageButton imgButton = sender as ImageButton;
            string friendUuid = imgButton.CommandParameter as string;
            DataExchanger de = new DataExchanger();
            if(de.addFriend(AuthProvider.Uuid, friendUuid)) {
                FriendsSource.Remove(FriendsSource.First(x => x.uuid == friendUuid));
                return;
            }

            DisplayAlert("Ops!", "Não foi possivel adicionar o amigo, tente mais tarde", "Ok");

        }
    }
}