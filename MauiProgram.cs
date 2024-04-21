using FinalAssignment.Classes;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace FinalAssignment {
    public static class MauiProgram {
        private static DatabaseManager databaseCommunicator = new DatabaseManager();
        private static Boolean isLoggedIn;
        private static Customer? customerProfile;

        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        internal static DatabaseManager getDatabaseCommunicator() {
            return databaseCommunicator;
        }

        internal static void setProfile(Customer customerIn) {
            isLoggedIn = (customerIn != null);
            customerProfile = customerIn;
        }

        internal static Boolean getIsLoggedIn() {
            return isLoggedIn;
        }

        internal static Customer? getCustomerProfile() {
            return customerProfile;
        }
    }
}

