using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class ReviewsPage : ContentPage {
        private ReviewManager reviewManager;

        public ReviewsPage() {
            InitializeComponent();
            reviewManager = new ReviewManager();
        }

        private void DisplayMechanicShopDetails() {
            // Display mechanic shop details and reviews
            List<Review> shopReviews = reviewManager.getReviews();

            // Clear existing reviews
            this.ClearLogicalChildren();

            // Display reviews
            foreach (var review in shopReviews) {
                Label reviewLabel = new Label();
                reviewLabel.Text = $"{review.reviewCustomer} - Rating: {review.reviewRating}, Comments: {review.reviewComment}";
                this.AddLogicalChild(reviewLabel);
            }

            // Display average rating
            double averageRating = reviewManager.GetAverageRatingForMechanicShop();
            averageRatingLabel.Text = $"Average Rating: {averageRating}";
        }

        private void SubmitReviewButton_Clicked(object sender, EventArgs e) {
            // Get user inputs
            string reviewerName = ReviewerNameEntry.Text;
            int rating = Convert.ToInt32(Math.Round(ratingSlider.Value));
            string comments = CommentsEntry.Text;

            // Add review
            Review review = new Review(reviewerName, rating, comments);
            reviewManager.AddReview(review);

            // Clear input fields
            ReviewerNameEntry.Text = "";
            CommentsEntry.Text = "";
        }

        public void onRatingSliderChanged(object sender, EventArgs e) {
            this.ratingLabel.Text = "Rating: " + Math.Round(ratingSlider.Value).ToString();
        }

        public async void onSubmitButtonClicked(object sender, EventArgs e) {
            // TODO: Add review to DB
            await this.DisplayAlert("Success", "Thanks for your review!", "noice");
            await Navigation.PushAsync(new HomePage());
        }

        // Other event handlers for displaying mechanic shop list, selecting a mechanic shop, etc.
    }
}
