using orkut2x.model;
using orkut2x.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace orkut2x
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPost : ContentPage
	{
        private DataExchanger dataExchanger;
        private string postImageSrc;

        public NewPost ()
		{
			InitializeComponent ();
            username.Text = AuthProvider.Username;
            userPic.Source = AuthProvider.Pic;
		}

        private void PublishPost_Clicked(object sender, EventArgs e) {
            if(postText.Text == null && postImage.Source == null) {
                DisplayAlert("Ops!", "Você esqueceu de adicionar conteúdo", "Ok!");
            }
            Post post = new Post(username.Text, AuthProvider.Uuid, postText.Text, postImageSrc, visibility.IsToggled);
            DataExchanger dataExchanger = new DataExchanger();
            if (!dataExchanger.publishPost(post)) {
                DisplayAlert("Ouch!", "Ocorreu um probleminha ao publicar \nTente postar mais tarde", "Ok");
                return;
            }

            Navigation.PopAsync();
            
        }

        private void setPostImage(string image) {
            postImageSrc = image;
            postImage.Source = image;
        }

        private void SaturnSelected_Clicked(object sender, EventArgs e) {
            setPostImage("saturno.jpg");
        }

        private void CapybaraSelected_Clicked(object sender, EventArgs e) {
            setPostImage("capivara.jpg");
        }

        private void BeachSelected_Clicked(object sender, EventArgs e) {
            setPostImage("praia.jpg");
        }

        private void SuricatoSelected_Clicked(object sender, EventArgs e) {
            setPostImage("suricato.jpg");
        }

        private void HorseSelected_Clicked(object sender, EventArgs e) {
            setPostImage("cavalo.jpg");
        }

        private void CapySelected_Clicked(object sender, EventArgs e) {
            setPostImage("capi.png");
        }

        private void Visibility_Toggled(object sender, ToggledEventArgs e) {
            if (visibility.IsToggled) {
                visibilityText.Text = "público";
            } else {
                visibilityText.Text = "privado";
            }

        }
    }
}