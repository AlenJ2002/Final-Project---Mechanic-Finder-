
namespace FinalAssignment.Classes {
    // Class to manage reviews and ratings for mechanic shops
    internal class ReviewManager {
        internal List<Review> reviews;

        internal ReviewManager() {
            reviews = new List<Review>();
        }

        internal void AddReview(Review review) {
            reviews.Add(review);
        }

        internal List<Review> getReviews() {
            return this.reviews;
        }

        // Method to calculate the average rating for a mechanic shop
        internal double GetAverageRatingForMechanicShop() {
            if (this.reviews.Count == 0) {
                return 0; // No reviews yet
            }

            int totalRating = 0;
            foreach (var review in this.reviews) {
                totalRating += review.reviewRating;
            }

            return (double)totalRating / this.reviews.Count;
        }
    }

}
