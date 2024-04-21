using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class SignupPage : ContentPage {

        public SignupPage() {
            InitializeComponent();
        }

        private async void SignupContinue(object sender, EventArgs e) {
            if (new Utils().validatePage(this) == false) return;

            String customerEmail = this.emailEntry.Text;
            if (MauiProgram.getDatabaseCommunicator().getCustomerByEmail(customerEmail) != null) {
                this.DisplayAlert("Error", "This e-mail is already registed! Try again.", "oops");
                new Utils().setErrorColor(this.emailEntry);
                return;
            }

            // create a customer using the fields
            String customerFirstName = this.FirstNameEntry.Text;
            String customerLastName = this.LastNameEntry.Text;
            String customerPhone = this.phoneNumberEntry.Text;
            String customerPassword = this.passwordEntry.Text;
            String customerAddress = this.addressEntry.Text;
            String vehicleMake = this.vehicleMakeEntry.Text;
            String vehicleModel = this.vehicleModelEntry.Text;
            Int32 vehicleYear = Int32.Parse(this.vehicleYearEntry.Text);
            Customer c = new Customer(customerFirstName,
                customerLastName,
                customerEmail,
                customerPhone,
                customerPassword,
                customerAddress,
                vehicleMake + "|" + vehicleModel + "|" + vehicleYear.ToString(),
                ""
            );

            // add to db
            MauiProgram.getDatabaseCommunicator().addToCustomerDatabase(c);
            // set the global user profile
            MauiProgram.setProfile(c);
            // redirect
            await Navigation.PushAsync(new HomePage());
        }
    }
}
