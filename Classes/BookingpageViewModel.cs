using System;
using System.ComponentModel;

public class BookingPageViewModel : INotifyPropertyChanged
{
    private DateTime _minimumDate;
    private DateTime _selectedDate;
    private TimeSpan _selectedTime;
    private bool _isTimePickerEnabled;

    public DateTime MinimumDate
    { get => _minimumDate;
    set
        {
            _minimumDate = value;
            OnPropertyChanged(nameof(_minimumDate));
        }
    }

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate));
            CheckTimePickerAvailability();
        }
    }
    
    public TimeSpan SelectedTime
    {
        get => _selectedTime;
        set
        {
            _selectedTime = value;
            OnPropertyChanged(nameof(SelectedTime));
        }
    }

    public bool IsTimePickerEnabled
    {
        get => _isTimePickerEnabled;
        set
        {
            _isTimePickerEnabled = value;
            OnPropertyChanged(nameof(IsTimePickerEnabled));
        }
    }

    public BookingPageViewModel()
    {
        MinimumDate = DateTime.Today;
        SelectedDate = DateTime.Today;
        CheckTimePickerAvailability();
    }   

    private void CheckTimePickerAvailability()
    {
        if (SelectedDate.Date > DateTime.Today)
        {
            // If the selected date is not today or later 
            IsTimePickerEnabled = true;
        }
        else
        {
            IsTimePickerEnabled = SelectedDate.Date == DateTime.Today;
            if (IsTimePickerEnabled)
            {
                // Ensure that the date is not in the past
                if (SelectedTime < DateTime.Now.TimeOfDay)
                {
                    SelectedTime = DateTime.Now.TimeOfDay;
                }
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
