namespace FinalAssignment.Classes {
    internal class Vehicle {
        internal String vehicleMake {
            get {
                return this.vehicleMake;
            } set {
                this.vehicleMake = value;
            }
        }
        internal String vehicleModel {
            get {
                return this.vehicleModel;
            } set {
                this.vehicleModel = value;
            }
        }
        internal Int32 vehicleModelYear {
            get {
                return this.vehicleModelYear;
            } set {
                this.vehicleModelYear = value;
            }
        }

        internal Vehicle(String vehicleMakeIn, String vehicleModelIn, Int32 vehicleModelYearIn) {
            this.vehicleMake = vehicleMakeIn;
            this.vehicleModel = vehicleModelIn;
            this.vehicleModelYear = vehicleModelYearIn;
        }

        public string toStringForDatabase() {
            return this.vehicleMake + DatabaseCommunicator.DATABASE_LIST_DELIMITER +
                this.vehicleModel + DatabaseCommunicator.DATABASE_LIST_DELIMITER +
                this.vehicleModelYear.ToString();
        }

        public static Vehicle getVehicleFromDatabaseString(String vehicleStringIn) {
            String[] s = vehicleStringIn.Split(DatabaseCommunicator.DATABASE_LIST_DELIMITER);
            return new Vehicle(s[0], s[1], Int32.Parse(s[2]));
        }
    }
}
