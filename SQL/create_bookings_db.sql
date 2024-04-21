CREATE DATABASE bookings_db;

USE bookings_db;

DROP TABLE IF EXISTS bookings;

CREATE TABLE IF NOT EXISTS bookings (
	id INT PRIMARY KEY,
	email VARCHAR(255),
	day VARCHAR(255),
	timeslot VARCHAR(255),
	service VARCHAR(255)
);

INSERT INTO bookings (id, email, day, timeslot, service) VALUES
	(1, 'john@example.com', '2024-04-20', '11:00', 'REPAIR'),
	(2, 'jane@test.com', '2024-05-01', '09:00', 'MISC')
;
