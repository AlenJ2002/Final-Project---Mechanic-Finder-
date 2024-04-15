using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicFinder
{
    // Class to represent a user review
    public class Review
    {
        public string ReviewerName { get; set; }
        public int Rating { get; set; } // Rating on a scale of 1 to 5
        public string Comments { get; set; }
        public string MechanicShopName { get; set; }

        public Review(string reviewerName, int rating, string comments, string mechanicShopName)
        {
            ReviewerName = reviewerName;
            Rating = rating;
            Comments = comments;
            MechanicShopName = mechanicShopName;
        }
    }

}
