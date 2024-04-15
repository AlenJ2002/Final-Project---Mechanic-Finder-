namespace FinalAssignment.Pages {
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
        }


        private async void ReviewsClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ReviewsPage());
        }
    }
}