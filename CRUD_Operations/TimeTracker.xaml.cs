using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CRUD_Operations
{
    public class TimeLogger2
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LoggedDate { get; set; }
    }

    public partial class TimeTracker : ContentPage
    {
        private const string Url = "";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<TimeLogger2> _loggedEvent2;


        public TimeTracker()
        {

            //InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            var response = await _client.GetAsync(Url);
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<TimeLogger2>>(content);
            _loggedEvent2 = new ObservableCollection<TimeLogger2>(items);

            //myListView.ItemsSource = _loggedEvent2;
            base.OnAppearing();
        }

    }
}
