namespace FinalAssignment.Classes {
    internal class Customer {
        internal Int32 customerId {
            get {
                return this.customerId;
            } set {
                this.customerId = value;
            }
        }

        internal String customerFirstName {
            get {
                return this.customerFirstName;
            } set {
                this.customerFirstName = value;
            }
        }
        internal String customerLastName {
            get {
                return this.customerLastName;
            } set {
                this.customerLastName = value;
            }
        }
        internal String customerEmail {
            get {
                return this.customerEmail;
            } set {
                this.customerEmail = value;
            }
        }
        internal String customerPhone {
            get {
                return this.customerPhone;
            } set {
                this.customerPhone = value;
            }
        }
        internal String customerAddress {
            get {
                return this.customerAddress;
            } set {
                this.customerAddress = value;
            }
        }

        internal Vehicle customerVehicle {
            get {
                return this.customerVehicle;
            } set {
                this.customerVehicle = value;
            }
        }

        internal List<ServiceEnum> serviceHistory {
            get {
                if (this.serviceHistory.Count == 0) {
                    return new List<ServiceEnum>();
                } else {
                    return this.serviceHistory;
                }
            } set {
                this.serviceHistory = value;
            }
        }
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
                serviceHistory.Add(theService);
            }
            this.serviceHistory = history;
        }

        internal Customer(String customerFirstNameIn,
            String customerLastNameIn,
            String customerEmailIn,
            String customerPhoneIn,
            String customerAddressIn,
            String customerVehicleIn,
            String customerServiceHistoryIn) {
            this.customerId = new Random().Next(1000, 9999);
            this.customerFirstName = customerFirstNameIn;
            this.customerLastName = customerLastNameIn;
            this.customerEmail = customerEmailIn;
            this.customerPhone = customerPhoneIn;
            this.customerAddress = customerAddressIn;
            this.customerVehicle = Vehicle.getVehicleFromDatabaseString(customerVehicleIn);
            List<ServiceEnum> history = new List<ServiceEnum>();
            foreach (String s in customerServiceHistoryIn.Split(DatabaseCommunicator.DATABASE_LIST_DELIMITER)) {
                ServiceEnum theService = Service.getServiceFromString(s);
                serviceHistory.Add(theService);
            }
            this.serviceHistory = history;
        }
    }
}
