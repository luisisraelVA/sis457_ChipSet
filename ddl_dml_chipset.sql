CREATE DATABASE LabChipSet;
USE master
GO 
CREATE LOGIN usrchipset WITH PASSWORD = '123456',
CHECK_POLICY = ON,
CHECK_EXPIRATION= OFF,
DEFAULT_DATABASE = LabChipSet
GO 
USE LabChipSet 
GO
CREATE USER usrchipset FOR LOGIN usrchipset
GO
ALTER ROLE db_owner ADD MEMBER usrchipset
GO

DROP TABLE IF EXISTS Producto;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Proveedor;
DROP TABLE IF EXISTS Pedido;
DROP TABLE IF EXISTS DetallePedido;

CREATE TABLE Proveedor (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(20)
);
CREATE TABLE Cliente (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telefono VARCHAR(20)
);
CREATE TABLE Producto (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    idProveedor INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(200) NOT NULL,
    precioVenta DECIMAL NOT NULL CHECK(precioVenta>0),
    stock INT NOT NULL CHECK(stock >= 0),
    CONSTRAINT fk_Producto_Proveedor FOREIGN KEY (idProveedor) REFERENCES Proveedor(id)
);
CREATE TABLE Pedido (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    idCliente INT NOT NULL,
    fechaPedido DATE NOT NULL,
    total DECIMAL NOT NULL DEFAULT 0,
    CONSTRAINT fk_Pedido_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(id)
);
CREATE TABLE DetallePedido (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    idPedido INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precioUnitario DECIMAL NOT NULL  CHECK(precioUnitario>0),

    CONSTRAINT fk_DetallePedido_Pedido FOREIGN KEY (idPedido) REFERENCES Pedido(id),
    CONSTRAINT fk_DetallePedido_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);

ALTER TABLE Proveedor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Proveedor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Proveedor ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Pedido ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Pedido ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Pedido ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE DetallePedido ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE DetallePedido ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE DetallePedido ADD estado SMALLINT NOT NULL DEFAULT 1;





GO
DROP PROC IF EXISTS paProductoListar;
GO
CREATE PROC paProductoListar @parametro VARCHAR(50) 
AS
SELECT  p.id,p.idProveedor,p.nombre,pr.nombre as nombreProveedor,p.descripcion,p.precioVenta, p.stock,
        p.usuarioRegistro,
        p.fechaRegistro, 
        p.estado
    FROM 
        Producto p
    INNER JOIN 
        Proveedor pr ON pr.id = p.idProveedor 
    WHERE 
        p.estado >- 1
       AND p.nombre+p.descripcion+pr.nombre LIKE '%'+REPLACE(@parametro,' ','%')+'%'
    ORDER BY 
        p.estado DESC, p.nombre ASC;

EXEC paProductoListar '';



-- DML 
INSERT INTO Proveedor (nombre, telefono) VALUES
('TechMayorista S.A.', '555-1000'),
('Global Hardware Corp.', '555-2000');

-- 2. Insertar Clientes
INSERT INTO Cliente (nombre, email, telefono) VALUES
('Ana Torres', 'ana.t@email.com', '999-1111'),
('Carlos Ruiz', 'carlos.r@email.com', '999-2222');

-- 3. Insertar Productos
INSERT INTO Producto (idProveedor, nombre, descripcion, precioVenta, stock) VALUES
(1, 'Memoria RAM DDR4 16GB', 'Módulo de 16GB, 3200MHz', 45.50, 150),
(1, 'Disco SSD M.2 500GB', 'Unidad de estado sólido NVMe, 500GB', 35.99, 80),
(2, 'Tarjeta Gráfica RTX 4060', '8GB GDDR6, ideal para gaming', 349.99, 45),
(2, 'Procesador Ryzen 5 5600', 'CPU de 6 núcleos y 12 hilos', 125.00, 60);

select * from Producto;

EXEC paProductoListar '';

EXEC paProductoListar 'SSD';