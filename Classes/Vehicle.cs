namespace FinalAssignment.Classes {
    internal class Vehicle {
        internal String vehicleMake { get; set; }
        internal String vehicleModel { get; set; }
        internal Int32 vehicleModelYear { get; set; }

        internal Vehicle(String vehicleMakeIn, String vehicleModelIn, Int32 vehicleModelYearIn) {
            this.vehicleMake = vehicleMakeIn;
            this.vehicleModel = vehicleModelIn;
            this.vehicleModelYear = vehicleModelYearIn;
        }

        public string toStringForDatabase() {
            return this.vehicleMake + DatabaseManager.DATABASE_LIST_DELIMITER +
                this.vehicleModel + DatabaseManager.DATABASE_LIST_DELIMITER +
                this.vehicleModelYear.ToString();
        }

        public static Vehicle getVehicleFromDatabaseString(String vehicleStringIn) {
            String[] s = vehicleStringIn.Split(DatabaseManager.DATABASE_LIST_DELIMITER);
            return new Vehicle(s[0], s[1], Int32.Parse(s[2]));
        }
    }
}
