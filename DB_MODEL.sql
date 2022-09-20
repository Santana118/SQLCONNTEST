--CREATE DATABASE TokoKelontong;

CREATE TABLE Customer(
	id int IDENTITY(1,1) PRIMARY KEY,
	nama varchar(50) NOT NULL

);

CREATE TABLE Stock(
	id int IDENTITY(1,1) PRIMARY KEY,
	namaBarang varchar(50) NOT NULL,

)

-- CREATE TABLE OrderList(
-- 	id int IDENTITY(1,1) PRIMARY KEY,
-- 	idConsumer int NOT NULL,
-- 	idStock int NOT NULL,
-- 	quantity int,

-- 	CONSTRAINT FK_Consumer FOREIGN KEY (idCOnsumer) REFERENCES Customer(id),
-- 	CONSTRAINT FK_Stock FOREIGN KEY (idStock) REFERENCES Stock(id)
-- )


INSERT INTO Customer VALUES ('Giri Atma Santana');
INSERT INTO Customer VALUES ('Stefanus');
INSERT INTO Customer VALUES ('Miftahuddin');
INSERT INTO Customer VALUES ('Suu Kyi');

INSERT INTO Stock VALUES ('Sepeda Listrik GESITS');
INSERT INTO Stock VALUES ('Motor Supra X');
INSERT INTO Stock VALUES ('Mobil AILA');

INSERT INTO OrderList VALUES (1,1,3);
INSERT INTO OrderList VALUES (3,1,10);
INSERT INTO OrderList VALUES (4,3,1);
INSERT INTO OrderList VALUES (4,2,2);
INSERT INTO OrderList VALUES (3,3,1);

-- SELECT * FROM OrderList 
-- JOIN Customer ON (Customer.id = OrderList.idConsumer)
-- JOIN Stock ON (Stock.id = OrderList.idStock);


