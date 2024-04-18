-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    documento VARCHAR(20),
    direccion VARCHAR(200),
    mail VARCHAR(100),
    celular VARCHAR(20),
    estado VARCHAR(50)
);

-- Crear la tabla Factura
CREATE TABLE Factura (
    Id SERIAL PRIMARY KEY,
    IdCliente INT REFERENCES Cliente(Id),
    nroFactura VARCHAR(20),
    fechaHora TIMESTAMP,
    total INT,
    totalIva5 INT,
    totalIva10 INT,
    totalIva INT,
    totalLetras VARCHAR(200),
    sucursal INT
);