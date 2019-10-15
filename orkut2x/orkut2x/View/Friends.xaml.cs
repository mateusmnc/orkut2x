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

namespace orkut2x.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Friends : ContentPage
	{
        ObservableCollection<User> FriendsSource { get; set; }

        public Friends() {
            InitializeComponent();

            FriendsSource = new ObservableCollection<User>();
            updateFriendsSource();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            FriendsSource.Clear();
            updateFriendsSource();
        }

        private void updateFriendsSource() {
            DataExchanger dataExchanger = new DataExchanger();
            User[] friends = dataExchanger.getFriends(AuthProvider.Uuid);
            if (friends.Length > 0) {
                foreach (User friend in friends) {
                    FriendsSource.Add(friend);
                }
            }
            FriendsList.ItemsSource = FriendsSource;
            BindingContext = FriendsSource;
        }

        private void AddFriends_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddContacts());
        }

        private void RemoveFriend_Clicked(object sender, EventArgs e) {
            ImageButton imgButton = sender as ImageButton;
            string friendUuid = imgButton.CommandParameter as string;
            DataExchanger de = new DataExchanger();
            if (de.removeFriend(AuthProvider.Uuid, friendUuid)) {
                FriendsSource.Remove(FriendsSource.First(x => x.uuid == friendUuid));
                return;
            }

            DisplayAlert("Ops!", "Não foi possivel defazer a amizede, tente mais tarde", "Ok");

        }
    }
}