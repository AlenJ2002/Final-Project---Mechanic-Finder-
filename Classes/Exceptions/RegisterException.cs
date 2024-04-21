using Microsoft.Extensions.Options;

namespace FinalAssignment.Classes.Exceptions {
    internal class RegisterException : Exception {
        public RegisterException(string message) : base(message) {
        }

        public static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is required. Please enter a valid first name");
            }
        }

        public static void ValidateLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace (lastname))
            {
                throw new ArgumentException("Last name is required. Please enter a valid last name.");
            }
        }

        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Address is required. Please enter a valid address.");
            }
            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }
        }
    }
}
