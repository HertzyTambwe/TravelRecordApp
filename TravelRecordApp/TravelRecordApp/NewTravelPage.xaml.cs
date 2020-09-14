using System;
using Plugin.Geolocator;
using TravelRecordApp.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);

            venueListView.ItemsSource = venues;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}