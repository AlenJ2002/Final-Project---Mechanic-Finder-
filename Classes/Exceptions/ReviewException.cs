namespace FinalAssignment.Classes.Exceptions {
    internal class ReviewException : Exception {
        public ReviewException(string message) : base(message) {
        }
    }

    public class ReviewValidator {
        // Checks the validity of the name, throws an exception if there is an error
        public void ValidateName(string name) {
            // Check to see if the name contains whitespaces or is null
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or contain white spaces.");

        }

        // Checks the validity of the rating, must be between 1-5
        public void ValidateRating(double rating) {
            // Check to see if the rating is within the range
            if (rating < 1 || rating > 5)
                throw new ArgumentException("Rating Must be between 1-5.");
        }

        // Submits the review after checking the user inputs
        public void SubmitReview(string name, double rating) {
            try {
                // Validating the review
                ValidateName(name);
                ValidateRating(rating);
            } catch (Exception ex) {
                throw new ArgumentException("Failed to submit review. Please try again. ");

            }
        }
    }
}
