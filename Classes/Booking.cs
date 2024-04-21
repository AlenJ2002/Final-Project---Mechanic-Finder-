namespace FinalAssignment.Classes {

    // the booking class
    // bookingId = primary key
    // bookingEmail
    // bookingDateTime
    // bookingType
    internal class Booking {
        internal Int32 bookingId { get; set; }
        internal String bookingEmail { get; set; }
        internal DateTime bookingDateTime { get; set; }
        internal ServiceEnum bookingType { get; set; }


        internal Booking(Int32 bookingIdIn,
            String bookingEmailIn,
            DateTime bookingDateTimeIn,
            ServiceEnum bookingTypeIn) {
            this.bookingId = bookingIdIn;
            this.bookingEmail = bookingEmailIn;
            this.bookingDateTime = bookingDateTimeIn;
            this.bookingType = bookingTypeIn;
        }
    }
}

