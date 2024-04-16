// AppShell.xaml.cs
using Microsoft.Maui.Controls;

namespace MechanicFinder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Registering routes is done in XAML in this case, but can also be done here.
        }
    }
}
