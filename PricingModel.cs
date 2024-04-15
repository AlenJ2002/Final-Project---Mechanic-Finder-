using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicFinder
{
    using System;

    // Define a class to manage the pricing model and services
    public class PricingModel
    {
        private List<Service> services;

        // Constructor to initialize the pricing model with example services
        public PricingModel()
        {
            services = new List<Service>();

            // Add example services with placeholder values
            services.Add(new Service("Oil Change", ServiceCategory.MAINTENANCE, 50.0, new string[] { "OilType", "FilterType" }));
            services.Add(new Service("Brake Pad Replacement", ServiceCategory.REPAIR, 150.0, new string[] { "VehicleMake", "VehicleModel", "VehicleModelYear" }));
            services.Add(new Service("Annual Inspection", ServiceCategory.DIAGNOSTICS, 80.0, new string[] { "InspectionType" }));
            services.Add(new Service("Miscellanous", ServiceCategory.MISC, 30.0, new string[] { "ServiceType" }));
        }

        // Method to get the price of a specific service based on user inputs
        public double GetServicePrice(string serviceName, Dictionary<string, string> userInputs)
        {
            // Check if service name exists
            var service = services.Find(s => s.Name.Equals(serviceName, StringComparison.OrdinalIgnoreCase));
            if (service == null)
            {
                throw new ArgumentException("Service not found.");
            }

            // Validate user inputs
            foreach (var factor in service.FactorsAffectingPrice)
            {
                if (!userInputs.ContainsKey(factor))
                {
                    throw new ArgumentException($"Missing input for {factor}.");
                }
            }

            // Calculate and return the service price
            return service.CalculatePrice(userInputs);
        }
    }

}
