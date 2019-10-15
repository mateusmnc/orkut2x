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
	public partial class Feed : ContentPage
	{
        ObservableCollection<Post> PostsSource { get; set; }
        public Feed ()
		{
			InitializeComponent ();
            PostsSource = new ObservableCollection<Post>();
            updatePostsSource();
		}

        private void updatePostsSource() {

            DataExchanger dataExchanger = new DataExchanger();
            Post[] posts = dataExchanger.getPosts();
            if (posts.Length > 0) {
                foreach (Post post in posts) {
                    PostsSource.Add(post);
                }
            }
            Posts.ItemsSource = PostsSource;
            BindingContext = PostsSource;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            PostsSource.Clear();
            updatePostsSource();
        }
        private void NewPost_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new NewPost());
        }

        private void ShareBtn_Clicked(object sender, EventArgs e) {
            ImageButton imgButton = sender as ImageButton;
            string postUuid = imgButton.CommandParameter as string;
            DataExchanger de = new DataExchanger();
            if (de.sharePost(postUuid)) {
                PostsSource.Clear();
                updatePostsSource();
                return;
            }
            DisplayAlert("Ops!", "Não foi possivel compartilhar esse post, tente mais tarde", "Ok");
        }

    }
}