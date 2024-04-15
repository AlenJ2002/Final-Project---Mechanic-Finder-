namespace MechanicFinder
{
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Instantiate the pricing model
            PricingModel pricingModel = new PricingModel();

            // Example usage: Get price for an oil change with specific oil and filter types
            Dictionary<string, string> userInputs = new Dictionary<string, string>();
            userInputs["OilType"] = "Synthetic";
            userInputs["FilterType"] = "Standard";

            string serviceName = "Oil Change";
            try
            {
                double price = pricingModel.GetServicePrice(serviceName, userInputs);

                // Display the calculated price
                Console.WriteLine($"Price for {serviceName}: ${price}");
            }
            catch (ArgumentException ex)
            {
                // Handle exception (e.g., service not found or invalid input)
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Create a review manager
            ReviewManager reviewManager = new ReviewManager();

            // Example: Adding a review for a mechanic shop
            Review review1 = new Review("John Doe", 4, "Great service!", "Joe's Garage");
            reviewManager.AddReview(review1);

            // Example: Getting reviews for a mechanic shop
            List<Review> shopReviews = reviewManager.GetReviewsForMechanicShop("Joe's Garage");
            foreach (var review in shopReviews)
            {
                Console.WriteLine($"{review.ReviewerName} - Rating: {review.Rating}, Comments: {review.Comments}");
            }

            // Example: Getting the average rating for a mechanic shop
            double averageRating = reviewManager.GetAverageRatingForMechanicShop("Joe's Garage");
            Console.WriteLine($"Average Rating for Joe's Garage: {averageRating}");

        }
    }




}
