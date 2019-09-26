using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CRUD_Operations.Persistence;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace CRUD_Operations
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class TimeLogger : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int EmployeeID { get; set; }

        private string _fName;
        public string FirstName 
        { 
            get { return _fName; } 
            set{
                if (_fName == value)
                    return;

                _fName = value;

                if (PropertyChanged != null)
                    onPropertyChanged(nameof(FirstName));
            } 
        }
        private string _lName;
        public string LastName
        {
            get { return _lName; }
            set{
                if (_lName == value)
                    return;

                _lName = value;

                if (PropertyChanged != null)
                    onPropertyChanged(nameof(LastName));
            } 
        }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        private DateTime _loggedDate;
        public DateTime LoggedDate {
            get { return _loggedDate; } 

            set
            {
                if (_loggedDate == value)
                    return;

                _loggedDate = value;

                if (PropertyChanged != null)
                {
                    onPropertyChanged(nameof(LoggedDate));

                }
            }
        }

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void onPropertyChanged (DateTime propertyName){
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                                new PropertyChangedEventArgs(
                                    propertyName.ToShortDateString()
                                   )
                               );
                propertyName = Convert.ToDateTime(propertyName);
            }

        }

    }



    public partial class MainPage : ContentPage
    {
        private const string Url = "";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<TimeLogger> _loggedEvent;
                                                                                                                          
        public MainPage(TimeLogger logger)
        {

            if (logger == null)
                throw new ArgumentException();
            BindingContext = logger;

            InitializeComponent();
        }

        async void EmpDetails(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var employee = e.SelectedItem as TimeLogger;
            await Navigation.PushAsync(new LoggedTimeDetails(employee));
        }

        protected override async void OnAppearing()
        {
            var response = await _client.GetAsync(Url);
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<TimeLogger>>(content);
            _loggedEvent = new ObservableCollection<TimeLogger>(items);
            postsListView.ItemsSource = _loggedEvent;


            base.OnAppearing();
        }


        private void listViewChanged(LoggedTimeDetails source, TimeLogger logger)
        {
            postsListView.ItemsSource = logger.ToString();
        }

        async void newEmployee(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewEmployee());
        }

    }
}
