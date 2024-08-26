CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
    Brand NVARCHAR(50),
    Model NVARCHAR(50),
    
);

INSERT INTO Cars (CarId, Brand, Model, BasePrice)
VALUES
    (C1, 'Toyota', 'Corolla',599),
    (C2, 'Ford', 'Focus',799),
    (C3, 'Honda', 'Civic',798),
    (C4, 'Nissan', 'Sentra',998),
    (C5, 'Chevrolet', 'Cruze',899);