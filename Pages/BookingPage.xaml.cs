using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    // page is never loaded without a signin first

    public partial class BookingPage : ContentPage {
        public BookingPage() {
            InitializeComponent();
            
            // add service types to picker
            foreach (ServiceEnum s in new Service().getAllServices().Keys) {
                this.serviceTypePicker.Items.Add(Service.getStringFromService(s));
            }
        }

        // constructor for pre-selected service
        internal BookingPage(ServiceEnum serviceIn) : this() {
            foreach (String s in this.serviceTypePicker.Items) {
                if (s == Service.getStringFromService(serviceIn)) {
                    this.serviceTypePicker.SelectedIndex = this.serviceTypePicker.Items.IndexOf(s);
                    this.serviceCostLabel.Text = "$" + new Service().GetServicePrice(serviceIn).ToString("N2");
                }
            }
        }

        private void onServicePickerChanged(object sender, EventArgs e) {
            // update estimated price on picker change
            if (this.serviceTypePicker.SelectedItem != null) {
                Service s = new Service();
                ServiceEnum se = Service.getServiceFromString(this.serviceTypePicker.SelectedItem.ToString());
                this.serviceCostLabel.Text = "$" + s.GetServicePrice(se).ToString("N2");
            }
        }

        private async void onSubmitButtonClicked(object sender, EventArgs e) {
            if (new Utils().validatePage(this) == false) return;
            
            // turn all fields into a booking object
            DateTime dt = this.serviceDatePicker.Date;
            dt = dt.AddHours(this.serviceTimePicker.Time.Hours).AddMinutes(this.serviceTimePicker.Time.Minutes);

            // add the booking to the database
            String result = MauiProgram.getDatabaseCommunicator().addBookingToDatabase(new Booking(
                MauiProgram.getDatabaseCommunicator().getBookingsFromDatabase().Count + 1,
                MauiProgram.getCustomerProfile().customerEmail,
                dt,
                Service.getServiceFromString(this.serviceTypePicker.SelectedItem.ToString())
            ));

            // print errors if present
            if (result.Length > 0) {
                await this.DisplayAlert("Error", result, "oops");
            } else {
                await this.DisplayAlert("Success", "You have created a booking!", "noice");
                await Navigation.PushAsync(new HomePage());
            }
            
        }
    }
}
