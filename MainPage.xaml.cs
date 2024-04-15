namespace FinalAssignment
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LogInClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void SignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        public async void ContinueWithoutLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }

}
