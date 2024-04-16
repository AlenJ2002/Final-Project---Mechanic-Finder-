using MySqlConnector;

namespace FinalAssignment.Classes {
    internal class DatabaseCommunicator() {
        private List<Customer> customerList = initializeCustomerDatabase();
        private List<Review> reviews = initializeReviewDatabase();
        internal static readonly String DATABASE_LIST_DELIMITER = "|";

        private static List<Customer> initializeCustomerDatabase() {
            List<Customer> output = new List<Customer>();

            try {
                MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder().ConnectionString);
                connection.Open();
                string sql = "SELECT id, firstname, lastname, email, phone, address, vehicle, servicehistory FROM customers";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Int32 customerId = reader.GetInt32(0);
                    String customerFirstName = reader.GetString(1);
                    String customerLastName = reader.GetString(2);
                    String customerEmail = reader.GetString(3);
                    String customerPhone = reader.GetString(4);
                    String customerAddress = reader.GetString(5);
                    String customerVehicle = reader.GetString(6);
                    String customerServiceHistory = reader.GetString(7);
                    Customer c = new Customer(customerId, customerFirstName, customerLastName, customerEmail, customerPhone, customerAddress, customerVehicle, customerServiceHistory);
                    output.Add(c);
                }
                connection.Close();
            } catch (Exception e) {
            }

            return output;
        }

        private static List<Review> initializeReviewDatabase() {
            List<Review> output = new List<Review>();
            // load reviews from db and add to list

            // sample reviews:
            output.Add(new Review("Ken Ough", 5, "Amazing."));
            output.Add(new Review("Tonald Drump", 1, "Worst deal EVER. Will NOT come back. #vote4me"));
            output.Add(new Review("Name", 2, "Comment."));
            output.Add(new Review("Name", 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."));
            output.Add(new Review("Name", 1, "Comment."));
            output.Add(new Review("Name", 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et tortor at risus viverra adipiscing at. Massa tempor nec feugiat nisl pretium. Fermentum posuere urna nec tincidunt praesent semper feugiat nibh sed. Mattis molestie a iaculis at erat pellentesque adipiscing commodo. Semper eget duis at tellus at urna. Ut tortor pretium viverra suspendisse potenti. Urna nec tincidunt praesent semper feugiat. Iaculis at erat pellentesque adipiscing commodo elit. Tortor at risus viverra adipiscing at in tellus integer feugiat. Eu ultrices vitae auctor eu augue ut. Enim ut tellus elementum sagittis vitae. Mauris augue neque gravida in fermentum et sollicitudin. Sit amet dictum sit amet justo donec enim diam. A lacus vestibulum sed arcu non. Hac habitasse platea dictumst quisque sagittis. Quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci. Aliquet lectus proin nibh nisl condimentum id venenatis a. Elit pellentesque habitant morbi tristique senectus et. Aliquet sagittis id consectetur purus ut faucibus pulvinar elementum integer."));
            output.Add(new Review("Name", 2, "Comment."));
            output.Add(new Review("Name", 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."));
            return output;
        }

        internal void addToCustomerDatabase(Customer customerIn) {
            try {
                MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder().ConnectionString);
                connection.Open();
                string sql = "INSERT into customers (id, firstname, lastname, email. phone, address, vehicle, servicehistory) VALUES ";
                sql += customerIn.customerId.ToString() + ",";
                sql += customerIn.customerFirstName + ",";
                sql += customerIn.customerLastName + ",";
                sql += customerIn.customerEmail + ",";
                sql += customerIn.customerPhone + ",";
                sql += customerIn.customerAddress + ",";
                sql += customerIn.customerVehicle.toStringForDatabase() + ",";
                String serviceHistory = "";
                foreach (ServiceEnum service in customerIn.serviceHistory) {
                    if (serviceHistory.Length > 0) {
                        serviceHistory += DATABASE_LIST_DELIMITER + Service.getStringFromService(service);
                    } else {
                        serviceHistory += Service.getStringFromService(service);
                    }
                }
                sql += serviceHistory;
                sql += ")";
                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand command = new MySqlCommand(sql, connection, transaction);
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            } catch (Exception e) {
            }
        }

        internal Customer? getCustomerFromDatabase(String email) {
            foreach (Customer c in this.customerList) {
                if (c.customerEmail == email) {
                    return c;
                }
            }

            return null;
        }

        internal void addReview(Review r) {
            // add a review to DB
        }

        internal List<Review> getReviews() {
            return this.reviews;
        }

        private static MySqlConnectionStringBuilder getSqlConnectionBuilder() {
            return new MySqlConnectionStringBuilder {
                Server = "localhost",
                UserID = "SYSTEM",
                Password = "password",
                Database = "customer"
            };
        }
    }
}