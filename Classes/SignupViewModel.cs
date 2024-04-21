using System;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;

public class SignupViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
            ValidatePassword();
        }
    }

    private bool _isPasswordValid;
    public bool IsPasswordValid
    {
        get => _isPasswordValid;
        private set
        {
            _isPasswordValid = value;
            OnPropertyChanged(nameof(IsPasswordValid));
        }
    }

    public bool HasErrors => throw new NotImplementedException();

    private void ValidatePassword()
    {
        // Check if password is null/whitespace or less than or equal to 8 characters
        if (string.IsNullOrWhiteSpace(_password) || _password.Length <= 8)
        {
            IsPasswordValid = false;
        }
        else
        {
            // Check for uppercase, lowercase, numbers, and special characters
            var hasUpper = Regex.IsMatch(_password, @"[A-Z]+");
            var hasLower = Regex.IsMatch(_password, @"[a-z]+");
            var hasNumber = Regex.IsMatch(_password, @"\d+");
            var hasSpecial = Regex.IsMatch(_password, @"[!@#$%^&*]+");

            // Set the validity based on all conditions
            IsPasswordValid = hasUpper && hasLower && hasNumber && hasSpecial;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        throw new NotImplementedException();
    }
}