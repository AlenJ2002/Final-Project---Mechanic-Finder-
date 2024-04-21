using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    // page is never loaded without a signin first

    public partial class ProfilePage : ContentPage {

        public ProfilePage() {
            InitializeComponent();

            // update profile page using current customer profile
            Customer c = MauiProgram.getCustomerProfile();
            if (c != null) {
                this.customerName.Text = c.customerFirstName + " " + c.customerLastName;
                this.customerEmail.Text = c.customerEmail;
                this.customerPhone.Text = c.customerPhone;
                this.customerAddress.Text = c.customerAddress;
                Vehicle v = c.customerVehicle;
                this.customerVehicle.Text = v.vehicleModelYear + " " + v.vehicleMake + " " + v.vehicleModel;
            }
        }
    }
}

