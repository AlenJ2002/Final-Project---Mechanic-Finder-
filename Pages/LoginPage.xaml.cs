namespace FinalAssignment.Pages {

    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private void OnUsernameTextClicked(object sender, EventArgs e) {
            string usernameOrEmail = UsernameEntry.Text; // Used to access the text

            // Validation 
            if (string.IsNullOrEmpty(usernameOrEmail)) {
                // Alert the user 
                DisplayAlert("Wrong Username or Email. Please try again");

            }
        }

        private void DisplayAlert(string v) {
            throw new NotImplementedException();
        }

        private async void ContinueClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new HomePage());
        }
    }
}