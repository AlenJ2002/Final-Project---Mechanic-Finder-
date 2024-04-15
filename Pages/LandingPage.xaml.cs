using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class LandingPage : ContentPage {

        public LandingPage() {
            InitializeComponent();
        }

        private async void LogInClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void SignUpClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SignupPage());
        }

        public async void ContinueWithoutLogin(object sender, EventArgs e) {
            MauiProgram.setProfile(null);
            await Navigation.PushAsync(new HomePage());
        }
    }

}
