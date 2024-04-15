
using MechanicFinder;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
// Convert this into an XAML.cs file for the MAUI APP
namespace MechanicFinder
{
    public partial class MainPage : ContentPage
    {
        private PricingModel pricingModel;

        public MainPage()
        {
            InitializeComponent();
            pricingModel = new PricingModel();
        }

        private void CalculatePriceButton_Clicked(object sender, EventArgs e)
        {
            string selectedService = ServicePicker.SelectedItem?.ToString();

            if (selectedService != null)
            {
                Dictionary<string, string> userInputs = new Dictionary<string, string>();

                // Get user inputs from input fields
                userInputs["OilType"] = OilTypeEntry.Text;
                userInputs["FilterType"] = FilterTypeEntry.Text;
                userInputs["VehicleMake"] = VehicleMakeEntry.Text; // Include vehicle make input
                userInputs["VehicleModel"] = VehicleModelEntry.Text; // Include vehicle model input
                userInputs["VehicleModelYear"] = VehicleModelYear.Text; // Include vehicle year input

                try
                {
                    double price = pricingModel.GetServicePrice(selectedService, userInputs);
                    PriceLabel.Text = $"Price: ${price}";
                }
                catch (ArgumentException ex)
                {
                    // Handle service not found error
                    PriceLabel.Text = "Service not found.";
                }
            }
            else
            {
                // Handle no service selected error
                PriceLabel.Text = "Please select a service.";
            }
        }
    }
}

