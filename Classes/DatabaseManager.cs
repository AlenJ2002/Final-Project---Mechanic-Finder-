﻿using MySqlConnector;

namespace FinalAssignment.Classes {
    internal class DatabaseManager() {
        private static readonly String CUSTOMERS_DATABASE_NAME = "customers_db";
        private static readonly String REVIEWS_DATABASE_NAME = "reviews_db";
        private static readonly String DATABASE_ADDRESS = "localhost";
        private static readonly String DATABASE_USER = "root";
        private static readonly String DATABASE_PASS = "password";

        internal List<Customer> getCustomersFromDatabase() {
            List<Customer> output = new List<Customer>();

            //try {
            MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder(CUSTOMERS_DATABASE_NAME).ConnectionString);
            connection.Open();
            string sql = "SELECT firstname, lastname, email, phone, password, address, vehicle, servicehistory FROM customers";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                String customerFirstName = reader.GetString(0);
                String customerLastName = reader.GetString(1);
                String customerEmail = reader.GetString(2);
                String customerPhone = reader.GetString(3);
                String customerPassword = reader.GetString(4);
                String customerAddress = reader.GetString(5);
                String customerVehicle = reader.GetString(6);
                String customerServiceHistory = reader.GetString(7);
                output.Add(new Customer(customerFirstName, customerLastName, customerEmail, customerPhone, customerPassword, customerAddress, customerVehicle, customerServiceHistory));
            }
            connection.Close();
            //} catch (Exception e) {
            //}

            return output;
        }

        internal List<Review> getReviewsFromDatabase() {
            List<Review> output = new List<Review>();
            MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder(REVIEWS_DATABASE_NAME).ConnectionString);
            connection.Open();
            string sql = "SELECT customer, rating, comments FROM reviews";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                String reviewCustomer = reader.GetString(0);
                Int32 reviewRating = reader.GetInt32(1);
                String reviewComment = reader.GetString(2);
                output.Add(new Review(reviewCustomer, reviewRating, reviewComment));
            }
            connection.Close();
            return output;
        }

        internal void addToCustomerDatabase(Customer customerIn) {
            //try {
            MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder(CUSTOMERS_DATABASE_NAME).ConnectionString);
            connection.Open();
            string sql = "INSERT INTO customers VALUES ('";
            sql += customerIn.customerFirstName + "','";
            sql += customerIn.customerLastName + "','";
            sql += customerIn.customerEmail + "','";
            sql += customerIn.customerPhone + "','";
            sql += customerIn.customerPassword + "','";
            sql += customerIn.customerAddress + "','";
            sql += customerIn.customerVehicle.toStringForDatabase() + "','";
            String serviceHistory = "";
            if (customerIn.serviceHistory != null && customerIn.serviceHistory.Count > 0) {
                foreach (ServiceEnum service in customerIn.serviceHistory) {
                    if (serviceHistory.Length > 0) {
                        serviceHistory += "|" + Service.getStringFromService(service);
                    } else {
                        serviceHistory += Service.getStringFromService(service);
                    }
                }
            } else {
                serviceHistory += "NONE";
            }
            sql += serviceHistory;
            sql += "');";
            MySqlTransaction transaction = connection.BeginTransaction();
            MySqlCommand command = new MySqlCommand(sql, connection, transaction);
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
            //} catch (Exception e) {
            //}
        }

        internal String addToReviewDatabase(Review reviewIn) {
            foreach (Review r in this.getReviewsFromDatabase()) {
                if (r.reviewCustomer == reviewIn.reviewCustomer) {
                    return "You have already written a review!";
                }
            }
            MySqlConnection connection = new MySqlConnection(getSqlConnectionBuilder(REVIEWS_DATABASE_NAME).ConnectionString);
            connection.Open();
            string sql = "INSERT INTO reviews VALUES ('";
            sql += reviewIn.reviewCustomer + "','";
            sql += reviewIn.reviewRating.ToString() + "','";
            sql += reviewIn.reviewComment + "');";
            MySqlTransaction transaction = connection.BeginTransaction();
            MySqlCommand command = new MySqlCommand(sql, connection, transaction);
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
            return "";
        }

        internal Int32 validateCustomerLogin(String emailIn, String passwordIn) {
            // 0 = success
            // 1 = email error
            // 2 = pw error
            foreach (Customer c in this.getCustomersFromDatabase()) {
                if (c.customerEmail == emailIn) {
                    if (c.customerPassword == passwordIn) {
                        return 0;
                    } else {
                        return 2;
                    }
                }
            }

            return 1;
        }

        internal Customer? getCustomerByEmail(String emailIn) {
            foreach (Customer c in this.getCustomersFromDatabase()) {
                if (c.customerEmail == emailIn) {
                    return c;
                }
            }

            return null;
        }

        private static MySqlConnectionStringBuilder getSqlConnectionBuilder(String databaseNameIn) {
            return new MySqlConnectionStringBuilder {
                Server = DATABASE_ADDRESS,
                UserID = DATABASE_USER,
                Password = DATABASE_PASS,
                Database = databaseNameIn
            };
        }
    }
}