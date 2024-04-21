CREATE DATABASE customers_db;

USE customers_db;

DROP TABLE IF EXISTS customers;

CREATE TABLE IF NOT EXISTS customers (
	id INT PRIMARY KEY,
	firstname VARCHAR(255),
	lastname VARCHAR(255),
	email VARCHAR(255),
	phone VARCHAR(255),
	address VARCHAR(255),
	vehicle VARCHAR(255),
	servicehistory VARCHAR(255)
);

INSERT INTO customers (id, firstname, lastname, email, phone, address, vehicle, servicehistory) VALUES
	(1000, 'John', 'Doe', 'john@example.com', '123-456-7890', '123 Main St', 'Toyota|Prius|2016', 'MAINTENANCE|REPAIR|REPAIR|MISC'),
	(1001, 'Jane', 'Smith', 'jane@test.com', '111-222-3333', '123 2nd Ave', 'Honda|CRV|2002', 'REPAIR|REPAIR|REPAIR|REPAIR')
;
