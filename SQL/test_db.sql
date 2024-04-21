USE customers_db;
SELECT firstname, lastname, email, phone, password, address, vehicle, servicehistory FROM customers;

USE reviews_db;
SELECT customer, rating, comments FROM reviews;

USE bookings_db;
SELECT id, email, day, timeslot, service FROM bookings;