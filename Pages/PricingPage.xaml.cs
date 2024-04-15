using FinalAssignment.Classes;

namespace FinalAssignment.Pages {
    public partial class PricingPage : ContentPage {

        public PricingPage() {
            InitializeComponent();
        }

        private void CalculatePriceButton_Clicked(object sender, EventArgs e) {
            string selectedService = ServicePicker.SelectedItem?.ToString();

            if (selectedService != null) {
                double price = Service.GetServicePrice(selectedService);
                PriceLabel.Text = $"Price: ${price}";
            } else {
                // Handle no service selected error
                PriceLabel.Text = "Please select a service.";
            }
        }
    }
}

