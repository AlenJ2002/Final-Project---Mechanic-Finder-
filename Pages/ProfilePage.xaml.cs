using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class ProfilePage : ContentPage {

        public ProfilePage() {
            InitializeComponent();

            Customer c = MauiProgram.getCustomerProfile();
            this.customerName.Text = c.customerFirstName + " " + c.customerLastName;
            this.customerEmail.Text = c.customerEmail;
            this.customerPhone.Text = c.customerPhone;
            this.customerAddress.Text = c.customerAddress;
            Vehicle v = c.customerVehicle;
            this.customerVehicle.Text = v.vehicleModelYear + " " + v.vehicleMake + " " + v.vehicleModel;
        }
    }
}
