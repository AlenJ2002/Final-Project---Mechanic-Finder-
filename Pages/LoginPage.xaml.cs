using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private async void ContinueClicked(object sender, EventArgs e) {
            if (!new Utils().validatePage(this)) return;

            // check email/pass against database
            Int32 result = MauiProgram.getDatabaseCommunicator().validateCustomerLogin(this.emailEntry.Text, this.passwordEntry.Text);
            switch (result) {
                case 0:
                    // success
                    new Utils().setPrimaryColor(this.emailEntry);
                    MauiProgram.setProfile(MauiProgram.getDatabaseCommunicator().getCustomerByEmail(this.emailEntry.Text));
                    break;
                case 1:
                    new Utils().setErrorColor(this.emailEntry);
                    await this.DisplayAlert("Error", "Your e-mail does not exist in our system. Please try again.", "oops");
                    return;
                case 2:
                    new Utils().setErrorColor(this.passwordEntry);
                    await this.DisplayAlert("Error", "Your password is incorrect. Please try again.", "oops");
                    return;
            }

            await Navigation.PushAsync(new HomePage());
        }
    }
}
