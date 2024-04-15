using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class SignupPage : ContentPage {

        public SignupPage() {
            InitializeComponent();
        }

        private async void SignupContinue(object sender, EventArgs e) {
            String customerFirstName = this.FirstNameEntry.Text;
            String customerLastName = this.LastNameEntry.Text;
            String customerEmail = this.emailEntry.Text;
            String customerPhone = this.phoneNumberEntry.Text;
            String customerAddress = this.addressEntry.Text;
            String vehicleMake = this.vehicleMakeEntry.Text;
            String vehicleModel = this.vehicleModelEntry.Text;
            Int32 vehicleYear = Int32.Parse(this.vehicleYearEntry.Text);
            Customer c = new Customer(customerFirstName,
                customerLastName,
                customerEmail,
                customerPhone,
                customerAddress,
                vehicleMake + DatabaseCommunicator.DATABASE_LIST_DELIMITER + vehicleModel + DatabaseCommunicator.DATABASE_LIST_DELIMITER + vehicleYear.ToString(),
                ""
            );
            // TODO: Add back in when database is created
            //MauiProgram.getDatabaseCommunicator().addToCustomerDatabase(c);
            MauiProgram.setProfile(c);
            await Navigation.PushAsync(new HomePage());
        }
    }
}