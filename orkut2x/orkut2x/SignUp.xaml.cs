using orkut2x.service;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace orkut2x
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
		public SignUp ()
		{
			InitializeComponent ();
		}

        private void SignUpButton_Clicked(object sender, EventArgs e) {
            if(userField.Text == null || passwordField.Text == null || confirmPasswordField.Text == null) {
                DisplayAlert("Erro", "Preencha todos os campos", "Ok");
                return;
            }

            if(!passwordField.Text.Equals(confirmPasswordField.Text)) {
                DisplayAlert("Erro", "Senhas não são iguais, digite novamente", "Ok");
                return;
            }

            DataExchanger dataService = new DataExchanger();
            string[] pics = {
                "suricato.jpg", "adeni.jpg", "capi.png",
                "capivara.jpg", "cavalo.jpg", "dna.jpg",
                "dnapolimerase.jpg", "saturno.jpg"
            };
            string pic = pics[new Random().Next(pics.Length)];
            if (dataService.signUpNewUser(userField.Text, passwordField.Text, pic)) {
                DisplayAlert("Tudo certo!", "Usuário criado com sucesso", "ir para login");
                Navigation.PopAsync();
            }

        }

        //private async void ProfilePicture_Clicked(object sender, EventArgs e) {

        //    await CrossMedia.Current.Initialize();

        //    if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable) {
        //        await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

        //        return;
        //    }

        //    var file = await CrossMedia.Current.TakePhotoAsync(
        //        new StoreCameraMediaOptions {
        //            SaveToAlbum = true,
        //            Directory = "orkut2x"
        //        });

        //    if (file == null)
        //        return;

        //    profilePicture.Source = ImageSource.FromStream(() => {
        //        var stream = file.GetStream();
        //        file.Dispose();
        //        return stream;

        //    });
        //}

    }
}