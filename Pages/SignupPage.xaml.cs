namespace FinalAssignment.Pages {

    public partial class SignupPage : ContentPage {

        public SignupPage() {
            InitializeComponent();
        }

        private async void SignupContinue(object sender, EventArgs e) {
            try {
                await Navigation.PushAsync(new HomePage());
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}