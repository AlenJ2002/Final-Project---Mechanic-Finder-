CREATE DATABASE reviews_db;

USE reviews_db;

DROP TABLE IF EXISTS reviews;

CREATE TABLE IF NOT EXISTS reviews (
	customer VARCHAR(255) PRIMARY KEY,
	rating int,
	comments VARCHAR(255)
);

INSERT INTO reviews (customer, rating, comments) VALUES
	('John Doe', 2, 'Average experience.'),
	('Jane Smith', 4, 'Pretty good experience.')
;
