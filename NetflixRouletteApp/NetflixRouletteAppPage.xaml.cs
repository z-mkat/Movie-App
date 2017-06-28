using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace NetflixRouletteApp
{
    public partial class NetflixRouletteAppPage : ContentPage
    {
        private MovieService _service = new MovieService();

        private BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(NetflixRouletteAppPage), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;


            await FindMovies(actor: e.NewTextValue);
        }

        async Task FindMovies(string actor)
        {
            try
            {
                IsSearching = true;

                var movies = await _service.FindMoviesByActor(actor);
                listView.ItemsSource = movies;
                listView.IsVisible = movies.Any();
                notFound.IsVisible = !listView.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "Ok");
            }
            finally
            {
                IsSearching = false;
            }
        }

        async void OnMovieSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;

            listView.SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailPage(movie));
        }

        public NetflixRouletteAppPage()
        {
            BindingContext = this;

            InitializeComponent();
        }
    }
}
