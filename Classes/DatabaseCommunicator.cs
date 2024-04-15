using MySqlConnector;

namespace FinalAssignment.Classes {
    internal class DatabaseCommunicator() {
        private List<Customer> customerList = initializeCustomerDatabase();
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

        private void addToCustomerDatabase(Customer customerIn) {
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