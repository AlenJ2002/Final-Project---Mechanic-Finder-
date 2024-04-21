namespace FinalAssignment.Classes.Exceptions {
    
    public class InvalidPasswordException : Exception
    {
        // Throws an exception for invalid password. 
        public InvalidPasswordException() : base("The password is invalid, please try again.")
        {
        }
    }

    public class InvalidEmailException : Exception
    {
        // Throws an exception for invalid email. 
        public InvalidEmailException() : base("The email is invalid. Please try again.") 
        { 
        }
    }
}
