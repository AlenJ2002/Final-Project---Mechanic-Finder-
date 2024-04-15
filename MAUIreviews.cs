using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
// Convert this into an XAML.cs file for the MAUI APP
namespace MechanicFinder
{
    public partial class MainPage : ContentPage
    {
        private ReviewManager reviewManager;

        public MainPage()
        {
            InitializeComponent();
            reviewManager = new ReviewManager();
        }

        private void DisplayMechanicShopDetails(string mechanicShopName)
        {
            // Display mechanic shop details and reviews
            List<Review> shopReviews = reviewManager.GetReviewsForMechanicShop(mechanicShopName);

            // Clear existing reviews
            ReviewsStackLayout.Children.Clear();

            // Display reviews
            foreach (var review in shopReviews)
            {
                Label reviewLabel = new Label();
                reviewLabel.Text = $"{review.ReviewerName} - Rating: {review.Rating}, Comments: {review.Comments}";
                ReviewsStackLayout.Children.Add(reviewLabel);
            }

            // Display average rating
            double averageRating = reviewManager.GetAverageRatingForMechanicShop(mechanicShopName);
            AverageRatingLabel.Text = $"Average Rating: {averageRating}";
        }

        private void SubmitReviewButton_Clicked(object sender, EventArgs e)
        {
            // Get user inputs
            string reviewerName = ReviewerNameEntry.Text;
            int rating = Convert.ToInt32(RatingPicker.SelectedItem);
            string comments = CommentsEntry.Text;
            string mechanicShopName = SelectedMechanicShopLabel.Text;

            // Add review
            Review review = new Review(reviewerName, rating, comments, mechanicShopName);
            reviewManager.AddReview(review);

            // Refresh UI
            DisplayMechanicShopDetails(mechanicShopName);

            // Clear input fields
            ReviewerNameEntry.Text = "";
            RatingPicker.SelectedIndex = -1;
            CommentsEntry.Text = "";
        }

        // Other event handlers for displaying mechanic shop list, selecting a mechanic shop, etc.
    }
}
