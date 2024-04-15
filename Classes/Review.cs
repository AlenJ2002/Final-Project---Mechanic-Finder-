namespace FinalAssignment.Classes {
    // Class to represent a user review
    internal class Review {
        internal String reviewCustomer { get; set; }
        internal Int32 reviewRating { get; set; } // Rating on a scale of 1 to 5
        internal String reviewComment { get; set; }
        internal string reviewShopName { get; set; }

        internal Review(String reviewCustomerIn, Int32 reviewRatingIn, String reviewCommentIn, String reviewShopNameIn) {
            this.reviewCustomer = reviewCustomerIn;
            this.reviewRating = reviewRatingIn;
            this.reviewComment = reviewCommentIn;
            this.reviewShopName = reviewShopNameIn;
        }
    }

}
