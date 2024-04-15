using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace FinalAssignment;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

	private async void SignupContinue (object sender, EventArgs e)
	{
        try
        {
            await Navigation.PushAsync(new HomePage());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}