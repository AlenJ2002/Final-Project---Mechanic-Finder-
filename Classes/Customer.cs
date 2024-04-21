namespace FinalAssignment.Classes {
    // the customer class
    // customerFirstName
    // customerLastName
    // customerEmail = PRIMARY KEY
    // customerPhone
    // customerPassword
    // customer address
    // customervehicle
    // serviceHistory
    internal class Customer {
        internal String customerFirstName { get; set; }
        internal String customerLastName { get; set; }
        internal String customerEmail { get; set; }
        internal String customerPhone { get; set; }
        internal String customerPassword { get; set; } // normally you would hash this
        internal String customerAddress { get; set; }
        internal Vehicle customerVehicle { get; set; }
        internal List<ServiceEnum>? serviceHistory { get; set; }

        internal Customer(String customerFirstNameIn,
            String customerLastNameIn,
            String customerEmailIn,
            String customerPhoneIn,
            String customerPasswordIn,
            String customerAddressIn,
            String customerVehicleIn,
            String customerServiceHistoryIn) {
            this.customerFirstName = customerFirstNameIn;
            this.customerLastName = customerLastNameIn;
            this.customerEmail = customerEmailIn;
            this.customerPhone = customerPhoneIn;
            this.customerPassword = customerPasswordIn;
            this.customerAddress = customerAddressIn;
            this.customerVehicle = Vehicle.getVehicleFromDatabaseString(customerVehicleIn);
            
            // iterate over all service history
            List<ServiceEnum> history = new List<ServiceEnum>();
            foreach (String s in customerServiceHistoryIn.Split("|")) {
                if (!String.IsNullOrEmpty(s) && !String.IsNullOrWhiteSpace(s)) {
                    ServiceEnum theService = Service.getServiceFromString(s);
                    history.Add(theService);
                }
            }

            this.serviceHistory = history;
        }
    }
}

