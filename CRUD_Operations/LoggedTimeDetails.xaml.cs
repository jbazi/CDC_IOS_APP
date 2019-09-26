using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CRUD_Operations
{
    public partial class LoggedTimeDetails : ContentPage
    {
        private const string Url = "https://cloudtimetrackerapi.azurewebsites.net/api/timetracker";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<TimeLogger> _loggedEvent;

        
        public LoggedTimeDetails(TimeLogger logger)
        {
            if (logger == null)
                throw new ArgumentException();
            BindingContext = logger;

            InitializeComponent();
        }


        protected async void editEmployee(TimeLogger logger, object sender, System.EventArgs e)
        {
            var id = lbl_id.Text;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                try
                {
                    TimeLogger editEmpObj = new TimeLogger
                    {
                        FirstName = lbl_fName.Text,
                        LastName = lbl_lName.Text,
                        LoggedDate = lbl_date.Date
                    };
                    var inputRequest = JsonConvert.SerializeObject(editEmpObj);
                    var content = new StringContent(inputRequest, Encoding.UTF8, "application/json");
                    var response = await _client.PutAsync(Url + "/" + id, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Success", "Record Has Been Updated", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Record Not Updated", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Ok");
                }
            }


        }

        async void deleteEmployee(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            else
            {
                var id = lbl_id.Text;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Url);
                    try
                    {
                        var response = await _client.DeleteAsync(Url + "/" + id);
                        var deletedItem = e.SelectedItem as TimeLogger;
                        if (response.IsSuccessStatusCode)
                        {
                            await DisplayAlert("Success", "Record Has Been Deleted.", "Ok");
                            await Navigation.PopToRootAsync();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Record Not Deleted. Contact Dev team.", "Ok");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
    }
}
