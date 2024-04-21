CREATE DATABASE customers_db;

USE customers_db;

DROP TABLE IF EXISTS customers;

CREATE TABLE IF NOT EXISTS customers (
	firstname VARCHAR(255),
	lastname VARCHAR(255),
	email VARCHAR(255) PRIMARY KEY,
	phone VARCHAR(255),
	password VARCHAR(255),
	address VARCHAR(255),
	vehicle VARCHAR(255),
	servicehistory VARCHAR(255)
);

INSERT INTO customers (firstname, lastname, email, phone, password, address, vehicle, servicehistory) VALUES
	('John', 'Doe', 'john@example.com', '123-456-7890', '123456', '123 Main St', 'Toyota|Prius|2016', 'MAINTENANCE|REPAIR|REPAIR|MISC'),
	('Jane', 'Smith', 'jane@test.com', '111-222-3333', 'password', '123 2nd Ave', 'Honda|CRV|2002', 'REPAIR|REPAIR|REPAIR|REPAIR')
;
