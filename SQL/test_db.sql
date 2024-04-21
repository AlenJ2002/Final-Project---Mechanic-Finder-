USE customers_db;
SELECT id, firstname, lastname, email, phone, address, vehicle, servicehistory FROM customers;

USE reviews_db;
SELECT customer, rating, comments FROM reviews;