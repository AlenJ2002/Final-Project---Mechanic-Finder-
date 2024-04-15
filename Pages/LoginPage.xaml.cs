using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private void OnUsernameTextClicked(object sender, EventArgs e) {
            string email = emailEntry.Text; // Used to access the text

            // Validation 
            if (string.IsNullOrEmpty(email)) {
                // Alert the user 
                DisplayAlert("Email cannot be empty. Please try again");

            }
        }

        private void DisplayAlert(string v) {
            throw new NotImplementedException();
        }

        private async void ContinueClicked(object sender, EventArgs e) {
            // TODO: Add back in when database is created
            /*
            Customer? c = MauiProgram.getDatabaseCommunicator().getCustomerFromDatabase(emailEntry.Text);
            if (c != null) {
                MauiProgram.setProfile(c);
            }*/
            MauiProgram.setProfile(new Customer("First", "Last", "test@test.com", "123-456-7890", "123 Bob St.", "Kar|Modle|2019", "DIAGNOSTICS|REPAIR|REPAIR|MISC|REPAIR"));
            await Navigation.PushAsync(new HomePage());
        }
    }
}