using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class ReviewsPage : ContentPage {

        public ReviewsPage() {
            InitializeComponent();
            this.DisplayMechanicShopDetails();
        }

        private void DisplayMechanicShopDetails() {
            // Clear existing reviews
            this.reviewList.Clear();

            Label spacer1 = new Label();
            spacer1.HeightRequest = 20;
            this.reviewList.Add(spacer1);

            // Display reviews
            foreach (var review in MauiProgram.getDatabaseCommunicator().getReviewsFromDatabase()) {
                Frame reviewFrame = new Frame();
                reviewFrame.BackgroundColor = new Utils().getPrimaryColor();
                reviewFrame.MinimumHeightRequest = 100;
                reviewFrame.WidthRequest = 500;
                reviewFrame.Padding = 0;
                reviewFrame.CornerRadius = 8;

                HorizontalStackLayout body = new HorizontalStackLayout();
                body.MinimumHeightRequest = 100;
                body.WidthRequest = 500;

                VerticalStackLayout content = new VerticalStackLayout();
                content.WidthRequest = 400;
                content.MinimumHeightRequest = 100;
                content.VerticalOptions = LayoutOptions.Center;
                content.Spacing = 2;

                Label nameLabel = new Label();
                nameLabel.HeightRequest = 50;
                nameLabel.WidthRequest = 400;
                nameLabel.Padding = 10;
                nameLabel.TextColor = Color.FromRgb(255, 255, 255);
                nameLabel.FontAttributes = FontAttributes.Bold;
                nameLabel.FontSize = 18;
                nameLabel.Text = review.reviewCustomer;

                Editor commentEditor = new Editor();
                commentEditor.MinimumHeightRequest = 50;
                commentEditor.WidthRequest = 400;
                commentEditor.Margin = 2;
                commentEditor.IsEnabled = false;
                commentEditor.TextColor = Color.FromRgb(192, 192, 192);
                commentEditor.Text = review.reviewComment;

                content.Add(nameLabel);
                content.Add(commentEditor);

                body.Add(content);

                Label ratingLabel = new Label();
                ratingLabel.HeightRequest = 100;
                ratingLabel.WidthRequest = 100;
                ratingLabel.TextColor = Color.FromRgb(255, 255, 255);
                ratingLabel.VerticalTextAlignment = TextAlignment.Center;
                ratingLabel.FontAttributes = FontAttributes.Bold;
                ratingLabel.FontSize = 36;
                ratingLabel.Text = review.reviewRating.ToString() + " / 5";

                body.Add(ratingLabel);

                reviewFrame.Content = body;

                this.reviewList.Add(reviewFrame);
            }

            Label spacer2 = new Label();
            spacer2.HeightRequest = 20;
            this.reviewList.Add(spacer2);

            // Display average rating
            double averageRating = this.GetAverageRatingForMechanicShop();
            averageRatingLabel.Text = "Average Rating: " + averageRating.ToString("N1") + " / 5.0";
        }

        public void onRatingSliderChanged(object sender, EventArgs e) {
            this.ratingLabel.Text = "Rating: " + Math.Round(ratingSlider.Value).ToString();
        }

        public async void onSubmitButtonClicked(object sender, EventArgs e) {
            if (new Utils().validatePage(this) == false) return;

            // TODO: Add review to DB
            String reviewName = ReviewerNameEntry.Text;
            Int32 reviewRating = Convert.ToInt32(Math.Round(ratingSlider.Value));
            String reviewComment = CommentsEntry.Text;

            // Add review
            String result = MauiProgram.getDatabaseCommunicator().addToReviewDatabase(new Review(reviewName, reviewRating, reviewComment));
            if (result.Length > 0) {
                await this.DisplayAlert("Error", result, "oops");
                new Utils().setErrorColor(this.ReviewerNameEntry);
            } else {
                this.resetForm();
                await this.DisplayAlert("Success", "Thanks for your review!", "noice");
            }

            this.DisplayMechanicShopDetails();
        }

        // Other event handlers for displaying mechanic shop list, selecting a mechanic shop, etc.
        private double GetAverageRatingForMechanicShop() {
            List<Review> reviews = MauiProgram.getDatabaseCommunicator().getReviewsFromDatabase();

            if (reviews.Count == 0) {
                return 0; // No reviews yet
            }

            int totalRating = 0;
            foreach (var review in reviews) {
                totalRating += review.reviewRating;
            }

            return (double)totalRating / reviews.Count;
        }

        private void resetForm() {
            this.ReviewerNameEntry.BackgroundColor = Color.FromRgb(255, 255, 255);
            this.ReviewerNameEntry.Text = "";
            this.ratingSlider.Value = 1;
            this.CommentsEntry.Text = "";
        }
    }
}
