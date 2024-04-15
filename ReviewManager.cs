using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicFinder
{
    // Class to manage reviews and ratings for mechanic shops
    public class ReviewManager
    {
        private List<Review> reviews;

        public ReviewManager()
        {
            reviews = new List<Review>();
        }

        public void AddReview(Review review)
        {
            reviews.Add(review);
        }

        public List<Review> GetReviewsForMechanicShop(string mechanicShopName)
        {
            return reviews.FindAll(review => review.MechanicShopName.Equals(mechanicShopName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to calculate the average rating for a mechanic shop
        public double GetAverageRatingForMechanicShop(string mechanicShopName)
        {
            List<Review> shopReviews = GetReviewsForMechanicShop(mechanicShopName);
            if (shopReviews.Count == 0)
            {
                return 0; // No reviews yet
            }

            int totalRating = 0;
            foreach (var review in shopReviews)
            {
                totalRating += review.Rating;
            }

            return (double)totalRating / shopReviews.Count;
        }
    }

}
