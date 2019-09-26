using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CRUD_Operations
{
    public partial class NewEmployee : ContentPage
    {
        private const string Url = "";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<TimeLogger> _loggedEvent;
        public NewEmployee()
        {
            InitializeComponent();
        }

        protected async void newEmployeeDetails(object sender, System.EventArgs e)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                try
                {
                    TimeLogger newEmpObject = new TimeLogger
                    {
                        FirstName = lbl_fName.Text,
                        LastName = lbl_lName.Text,
                        LoggedDate = lbl_date.Date
                    };
                    var inputRequest = JsonConvert.SerializeObject(newEmpObject);
                    var content = new StringContent(inputRequest, Encoding.UTF8, "application/json");
                    var response = await _client.PostAsync(Url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Success", "New Employee added", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Employee Not Added", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Ok");
                }
            }

        }

       
    }
}
