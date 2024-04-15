namespace FinalAssignment.Classes {
    internal class Customer {
        internal Int32 customerId { get; set; }
        internal String customerFirstName { get; set; }
        internal String customerLastName { get; set; }
        internal String customerEmail { get; set; }
        internal String customerPhone { get; set; }
        internal String customerAddress { get; set; }
        internal Vehicle customerVehicle { get; set; }
        internal List<ServiceEnum>? serviceHistory { get; set; }

        internal Customer(Int32 customerIdIn,
            String customerFirstNameIn,
            String customerLastNameIn,
            String customerEmailIn,
            String customerPhoneIn,
            String customerAddressIn,
            String customerVehicleIn,
            String customerServiceHistoryIn) {
            this.customerId = customerIdIn;
            this.customerFirstName = customerFirstNameIn;
            this.customerLastName = customerLastNameIn;
            this.customerEmail = customerEmailIn;
            this.customerPhone = customerPhoneIn;
            this.customerAddress = customerAddressIn;
            this.customerVehicle = Vehicle.getVehicleFromDatabaseString(customerVehicleIn);
            List<ServiceEnum> history = new List<ServiceEnum>();
            foreach (String s in customerServiceHistoryIn.Split(DatabaseCommunicator.DATABASE_LIST_DELIMITER)) {
                ServiceEnum theService = Service.getServiceFromString(s);
                history.Add(theService);
            }
            this.serviceHistory = history;
        }

        internal Customer(String customerFirstNameIn,
            String customerLastNameIn,
            String customerEmailIn,
            String customerPhoneIn,
            String customerAddressIn,
            String customerVehicleIn,
            String customerServiceHistoryIn) : this(
                new Random().Next(1000, 9999),
                customerFirstNameIn,
                customerLastNameIn,
                customerEmailIn,
                customerPhoneIn,
                customerAddressIn,
                customerVehicleIn,
                customerServiceHistoryIn) {
        }
    }
}
