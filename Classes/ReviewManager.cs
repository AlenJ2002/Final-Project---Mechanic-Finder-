
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

        internal List<Review> GetReviewsForMechanicShop(string mechanicShopName) {
            return reviews.FindAll(review => review.reviewShopName.Equals(mechanicShopName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to calculate the average rating for a mechanic shop
        internal double GetAverageRatingForMechanicShop(string mechanicShopName) {
            List<Review> shopReviews = GetReviewsForMechanicShop(mechanicShopName);
            if (shopReviews.Count == 0) {
                return 0; // No reviews yet
            }

            int totalRating = 0;
            foreach (var review in shopReviews) {
                totalRating += review.reviewRating;
            }

            return (double)totalRating / shopReviews.Count;
        }
    }

}
