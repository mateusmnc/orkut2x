using orkut2x.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace orkut2x {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }
        private void SignInButton_Clicked(object sender, EventArgs e) {
            DataExchanger dataService = new DataExchanger();
            if (userField.Text == null || passwordField.Text == null ) {
                DisplayAlert("Erro", "Preencha todos os campos", "Ok");
                return;
            }

            if (dataService.signInUser(userField.Text, passwordField.Text)) {
                if (loadUser()) { 
                    App.Current.MainPage = new View.TabContainer();
                    return;
                }
            }

            DisplayAlert("Ops!", "Dados de acesso incorretos, tente novamente", "Ok");
        }

        private bool loadUser() {

            DataExchanger dataExchanger = new DataExchanger();
            return dataExchanger.getUser(AuthProvider.Token);
        }

        private void SignUpButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SignUp());
        }


        
    }
}
