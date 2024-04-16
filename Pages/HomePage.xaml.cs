namespace FinalAssignment.Pages {
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
        }

        private async void onServicesButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ServicesPage());
        }
        private async void onBookingsButtonClicked(object sender, EventArgs e) {
            if (MauiProgram.getIsLoggedIn()) {
                await Navigation.PushAsync(new BookingPage());
            } else {
                await Navigation.PushAsync(new UnknownUserPage());
            }
        }

        private async void onLocationButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new LocationPage());
        }
        private async void onReviewsButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ReviewsPage());
        }

        private async void onDashboardButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new DashboardPage());
        }

        private async void onProfileButtonClicked(object sender, EventArgs e) {
            if (MauiProgram.getIsLoggedIn()) {
                await Navigation.PushAsync(new ProfilePage());
            } else {
                await Navigation.PushAsync(new UnknownUserPage());
            }
        }
    }
}