using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class BookingPage : ContentPage {
        public BookingPage() {
            InitializeComponent();
            foreach (ServiceEnum s in new Service().getAllServices().Keys) {
                this.serviceTypePicker.Items.Add(Service.getStringFromService(s));
            }
        }

        internal BookingPage(ServiceEnum serviceIn) : this() {
            foreach (String s in this.serviceTypePicker.Items) {
                if (s == Service.getStringFromService(serviceIn)) {
                    this.serviceTypePicker.SelectedIndex = this.serviceTypePicker.Items.IndexOf(s);
                    this.serviceCostLabel.Text = "$" + new Service().GetServicePrice(serviceIn).ToString("N2");
                }
            }
        }

        private void onServicePickerChanged(object sender, EventArgs e) {
            if (this.serviceTypePicker.SelectedItem != null) {
                Service s = new Service();
                ServiceEnum se = Service.getServiceFromString(this.serviceTypePicker.SelectedItem.ToString());
                this.serviceCostLabel.Text = "$" + s.GetServicePrice(se).ToString("N2");
            }
        }

        private async void onSubmitButtonClicked(object sender, EventArgs e) {
            if (new Utils().validatePage(this) == false) return;
            // TODO: add to db
            await this.DisplayAlert("Success", "You have created a booking!", "noice");
            await Navigation.PushAsync(new HomePage());
        }
    }
}