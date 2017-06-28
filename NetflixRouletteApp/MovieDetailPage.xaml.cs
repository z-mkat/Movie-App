using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NetflixRouletteApp
{
    public partial class MovieDetailPage : ContentPage
    {
        private MovieService _service = new MovieService();
        private Movie _movie;

        public MovieDetailPage(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movie = movie;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = await _service.GetMovie(_movie.Title);

            base.OnAppearing();
        }
    }
}
