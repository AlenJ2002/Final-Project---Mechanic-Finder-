using System.Text.RegularExpressions;
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

        // Check to see if email follows the proper format. 
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) 
               return false;

            // Email validation using Regex 
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPassword(string password)
        {
            // Password length is longer then 8 characters
            return password != null && password.Length >= 8;
        }
    }
}