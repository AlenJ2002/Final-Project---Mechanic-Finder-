using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class ServicesPage : ContentPage {

        public ServicesPage() {
            InitializeComponent();
        }

        private async void onMaintenanceButtonClicked(object sender, EventArgs e) {
            this.redirect(ServiceEnum.MAINTENANCE);
        }

        private async void onDiagnosticsButtonClicked(object sender, EventArgs e) {
            this.redirect(ServiceEnum.DIAGNOSTICS);
        }

        private async void onRepairButtonClicked(object sender, EventArgs e) {
            this.redirect(ServiceEnum.REPAIR);
        }

        private async void onContactButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new LocationPage());
        }

        private async void redirect(ServiceEnum serviceIn) {
            if (MauiProgram.getIsLoggedIn()) {
                await Navigation.PushAsync(new BookingPage(serviceIn));
            } else {
                await Navigation.PushAsync(new UnknownUserPage());
            }
        }
    }

}
