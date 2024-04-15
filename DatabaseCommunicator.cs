using MySqlConnector;
using System.Security.Cryptography.X509Certificates;

namespace MechanicDatabaseCommunicator {
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
                foreach (Service service in customerIn.serviceHistory) {
                    if (serviceHistory.Length > 0) {
                        serviceHistory += DATABASE_LIST_DELIMITER + getStringFromService(service);
                    } else {
                        serviceHistory += getStringFromService(service);
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

        internal Service getRecommendedService(String searchTermIn) {
            switch (searchTermIn) {
                case "oil":
                    return Service.MAINTENANCE;
                case "wheel":
                    return Service.MAINTENANCE;
                case "tire":
                    return Service.MAINTENANCE;
                case "brakes":
                    return Service.MAINTENANCE;
                case "wipers":
                    return Service.MAINTENANCE;


                case "lights":
                    return Service.DIAGNOSTICS;
                case "electrical":
                    return Service.DIAGNOSTICS;
                case "battery":
                    return Service.DIAGNOSTICS;
                case "sound":
                    return Service.DIAGNOSTICS;


                case "broken":
                    return Service.REPAIR;
                case "cracked":
                    return Service.DIAGNOSTICS;
                case "bent":
                    return Service.DIAGNOSTICS;


                default:
                    return Service.MISC;
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

        internal static Service getServiceFromString(String serviceNameIn) {
            switch (serviceNameIn) {
                case "MAINTENANCE":
                    return Service.MAINTENANCE;
                case "DIAGNOSTICS":
                    return Service.DIAGNOSTICS;
                case "REPAIR":
                    return Service.REPAIR;
                default:
                    return Service.MISC;
            }
        }

        internal static String getStringFromService(Service serviceIn) {
            switch (serviceIn) {
                case Service.MAINTENANCE:
                    return "MAINTENANCE";
                case Service.DIAGNOSTICS:
                    return "DIAGNOSTICS";
                case Service.REPAIR:
                    return "REPAIR";
                default:
                    return "MISC";
            }
        }
    }
}