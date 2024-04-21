using FinalAssignment.Classes;

namespace FinalAssignment.Pages {

    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private async void ContinueClicked(object sender, EventArgs e) {
            if (new Utils().validatePage(this) == false) return;

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
