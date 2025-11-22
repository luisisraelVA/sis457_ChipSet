CREATE DATABASE LabChipSet;
GO
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

DROP TABLE IF EXISTS DetallePedido;
DROP TABLE IF EXISTS Pedido;
DROP TABLE IF EXISTS Producto;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Proveedor;
DROP TABLE IF EXISTS Usuario;

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
CREATE TABLE Usuario (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    usuario VARCHAR(50) UNIQUE NOT NULL,
    clave VARCHAR(255) NOT NULL,
    );


    ALTER TABLE DetallePedido 
DROP CONSTRAINT fk_DetallePedido_Pedido;
GO

ALTER TABLE Cliente
ALTER COLUMN email VARCHAR(100) NULL;
GO

ALTER TABLE DetallePedido
ADD CONSTRAINT fk_DetallePedido_Pedido 
    FOREIGN KEY (idPedido) 
    REFERENCES Pedido(id) 
    ON DELETE CASCADE; 
GO




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

ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1; 


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



DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(100)
AS
SELECT
    c.id,
    c.nombre,
    c.email,
    c.telefono,
    c.usuarioRegistro,
    c.fechaRegistro,
    c.estado
FROM
    Cliente c
WHERE
    c.estado > -1

    AND (c.nombre + ISNULL(c.email, '') + ISNULL(c.telefono, '')) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
ORDER BY
    c.estado DESC, c.nombre ASC;
GO

Go
DROP PROC IF EXISTS paPedidoListar;
GO
CREATE PROC paPedidoListar @parametro VARCHAR(100) 
AS
SELECT  
    pe.id,
    pe.idCliente,
   c.nombre AS nombreCliente,
    pe.fechaPedido,
    pe.total,
    pe.usuarioRegistro,
    pe.fechaRegistro, 
    pe.estado
FROM 
    Pedido pe
INNER JOIN 
    Cliente c ON c.id = pe.idCliente
WHERE 
    pe.estado > -1 
   AND c.nombre LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
ORDER BY 
    pe.estado DESC, pe.fechaPedido DESC;
GO



GO
DROP PROC IF EXISTS paDetallePedidoListar;
GO
CREATE PROC paDetallePedidoListar @idPedido INT
AS
SELECT 
    d.id,
    d.idPedido,
    d.idProducto,
    p.nombre AS nombreProducto,
    d.cantidad,
    d.precioUnitario
FROM 
    DetallePedido d
INNER JOIN 
    Producto p ON d.idProducto = p.id
WHERE 
    d.estado = 1 AND d.idPedido = @idPedido;









INSERT INTO Usuario(usuario,clave)
VALUES ('chipset', 'i0hcoO/nssY6WOs9pOp5Xw=='); -- Clave: hola123



INSERT INTO Proveedor (nombre, telefono, usuarioRegistro) VALUES
('TechMayorista S.A.', '555-1000', 'chipset'),
('Global Hardware Corp.', '555-2000', 'chipset'),
('Importaciones PC-Sucre', '555-3000', 'chipset'),
('Componentes Bolivia', '555-4000', 'chipset'),
('Periféricos Pro', '555-5000', 'chipset');
GO


INSERT INTO Cliente (nombre, email, telefono, usuarioRegistro) VALUES
('Ana Torres', 'ana.t@email.com', '999-1111', 'chipset'),
('Carlos Ruiz', 'carlos.r@email.com', '999-2222', 'chipset'),
('Bartolomé "Bartolito" Diaz', 'barto@email.com', '999-3333', 'chipset'),
('Luisa Mendoza', 'luisa.m@email.com', '999-4444', 'chipset'),
('Miguel Cervantes', 'miguel.c@email.com', '999-5555', 'chipset'),
('Javier Fernandez', 'javi.f@email.com', '999-6666', 'chipset'),
('Sofia Castro', 'sofia.c@email.com', '999-7777', 'chipset'),
('David Vargas', 'david.v@email.com', '999-8888', 'chipset'),
('Elena Paredes', 'elena.p@email.com', '999-9999', 'chipset'),
('Pedro Infante', 'pedro.i@email.com', '999-0000', 'chipset');
GO


INSERT INTO Producto (idProveedor, nombre, descripcion, precioVenta, stock, usuarioRegistro) VALUES
(1, 'Memoria RAM DDR4 16GB', 'Módulo de 16GB, 3200MHz', 45.50, 150, 'chipset'),
(1, 'Disco SSD M.2 500GB', 'Unidad de estado sólido NVMe, 500GB', 35.99, 80, 'chipset'),
(2, 'Tarjeta Gráfica RTX 4060', '8GB GDDR6, ideal para gaming', 349.99, 45, 'chipset'),
(2, 'Procesador Ryzen 5 5600', 'CPU de 6 núcleos y 12 hilos', 125.00, 60, 'chipset'),
(3, 'Placa Madre B550M', 'Placa base AM4, mATX, PCIe 4.0', 95.00, 75, 'chipset'),
(4, 'Fuente de Poder 650W', 'Certificación 80+ Bronze, modular', 75.50, 100, 'chipset'),
(5, 'Monitor Curvo 27"', 'Panel VA, 165Hz, 1ms, Full HD', 210.00, 30, 'chipset'),
(5, 'Teclado Mecánico RGB', 'Switches Blue, layout español', 55.00, 200, 'chipset'),
(5, 'Mouse Gamer Inalámbrico', 'Sensor óptico 16000 DPI, 6 botones', 65.00, 150, 'chipset'),
(1, 'Disco Duro Externo 2TB', 'USB 3.0, portátil', 60.00, 50, 'chipset'),
(3, 'Gabinete ATX Mid-Tower', 'Panel lateral de vidrio templado, 3 ventiladores ARGB', 85.00, 40, 'chipset'),
(4, 'Refrigeración Líquida 240mm', 'Doble ventilador, ARGB, compatible Intel/AMD', 110.00, 35, 'chipset'),
(2, 'Procesador Core i5 13600K', '14 núcleos, 20 hilos, LGA1700', 310.00, 55, 'chipset'),
(1, 'Memoria RAM DDR5 32GB Kit', 'Kit 2x16GB, 6000MHz, CL36', 115.00, 90, 'chipset'),
(5, 'Auriculares Gamer 7.1', 'Sonido envolvente, micrófono retráctil', 49.99, 120, 'chipset');
GO


INSERT INTO Pedido (idCliente, fechaPedido, total, usuarioRegistro) VALUES
(1, '2025-10-01', 81.49, 'chipset'),  
(2, '2025-10-05', 349.99, 'chipset'),
(3, '2025-10-10', 265.00, 'chipset'),
(4, '2025-10-12', 126.99, 'chipset'), 
(5, '2025-10-15', 295.50, 'chipset'), 
(6, '2025-10-20', 195.00, 'chipset'), 
(7, '2025-10-22', 114.99, 'chipset'), 
(1, '2025-10-25', 425.00, 'chipset'); 
GO


INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioUnitario, usuarioRegistro) VALUES
(1, 2, 1, 35.99, 'chipset'), 
(1, 1, 1, 45.50, 'chipset'), 


(2, 3, 1, 349.99, 'chipset'), 


(3, 7, 1, 210.00, 'chipset'),
(3, 8, 1, 55.00, 'chipset'),

(4, 1, 2, 45.50, 'chipset'), 
(4, 2, 1, 35.99, 'chipset'), 


(5, 4, 1, 125.00, 'chipset'),
(5, 5, 1, 95.00, 'chipset'),
(5, 6, 1, 75.50, 'chipset'), 


(6, 11, 1, 85.00, 'chipset'),
(6, 12, 1, 110.00, 'chipset'),


(7, 9, 1, 65.00, 'chipset'), 
(7, 15, 1, 49.99, 'chipset'), 


(8, 13, 1, 310.00, 'chipset'), 
(8, 14, 1, 115.00, 'chipset'); 
GO


DELETE FROM DetallePedido;
DELETE FROM Pedido;
DELETE FROM Producto;
DELETE FROM Cliente;
DELETE FROM Proveedor;
GO

-- 2. REINICIAR CONTADORES DE IDENTIDAD
DBCC CHECKIDENT ('DetallePedido', RESEED, 0);
DBCC CHECKIDENT ('Pedido', RESEED, 0);
DBCC CHECKIDENT ('Producto', RESEED, 0);
DBCC CHECKIDENT ('Cliente', RESEED, 0);
DBCC CHECKIDENT ('Proveedor', RESEED, 0);
GO

-- 3. INSERTAR DATOS (Este es tu script)

INSERT INTO Proveedor (nombre, telefono, usuarioRegistro) VALUES
('TechMayorista S.A.', '555-1000', 'chipset'),
('Global Hardware Corp.', '555-2000', 'chipset'),
('Importaciones PC-Sucre', '555-3000', 'chipset'),
('Componentes Bolivia', '555-4000', 'chipset'),
('Periféricos Pro', '555-5000', 'chipset');
GO

INSERT INTO Cliente (nombre, email, telefono, usuarioRegistro) VALUES
('Ana Torres', 'ana.t@email.com', '999-1111', 'chipset'),
('Carlos Ruiz', 'carlos.r@email.com', '999-2222', 'chipset'),
('Bartolomé "Bartolito" Diaz', 'barto@email.com', '999-3333', 'chipset'),
('Luisa Mendoza', 'luisa.m@email.com', '999-4444', 'chipset'),
('Miguel Cervantes', 'miguel.c@email.com', '999-5555', 'chipset'),
('Javier Fernandez', 'javi.f@email.com', '999-6666', 'chipset'),
('Sofia Castro', 'sofia.c@email.com', '999-7777', 'chipset'),
('David Vargas', 'david.v@email.com', '999-8888', 'chipset'),
('Elena Paredes', 'elena.p@email.com', '999-9999', 'chipset'),
('Pedro Infante', 'pedro.i@email.com', '999-0000', 'chipset');
GO

INSERT INTO Producto (idProveedor, nombre, descripcion, precioVenta, stock, usuarioRegistro) VALUES
(1, 'Memoria RAM DDR4 16GB', 'Módulo de 16GB, 3200MHz', 45.50, 150, 'chipset'),
(1, 'Disco SSD M.2 500GB', 'Unidad de estado sólido NVMe, 500GB', 35.99, 80, 'chipset'),
(2, 'Tarjeta Gráfica RTX 4060', '8GB GDDR6, ideal para gaming', 349.99, 45, 'chipset'),
(2, 'Procesador Ryzen 5 5600', 'CPU de 6 núcleos y 12 hilos', 125.00, 60, 'chipset'),
(3, 'Placa Madre B550M', 'Placa base AM4, mATX, PCIe 4.0', 95.00, 75, 'chipset'),
(4, 'Fuente de Poder 650W', 'Certificación 80+ Bronze, modular', 75.50, 100, 'chipset'),
(5, 'Monitor Curvo 27"', 'Panel VA, 165Hz, 1ms, Full HD', 210.00, 30, 'chipset'),
(5, 'Teclado Mecánico RGB', 'Switches Blue, layout español', 55.00, 200, 'chipset'),
(5, 'Mouse Gamer Inalámbrico', 'Sensor óptico 16000 DPI, 6 botones', 65.00, 150, 'chipset'),
(1, 'Disco Duro Externo 2TB', 'USB 3.0, portátil', 60.00, 50, 'chipset'),
(3, 'Gabinete ATX Mid-Tower', 'Panel lateral de vidrio templado, 3 ventiladores ARGB', 85.00, 40, 'chipset'),
(4, 'Refrigeración Líquida 240mm', 'Doble ventilador, ARGB, compatible Intel/AMD', 110.00, 35, 'chipset'),
(2, 'Procesador Core i5 13600K', '14 núcleos, 20 hilos, LGA1700', 310.00, 55, 'chipset'),
(1, 'Memoria RAM DDR5 32GB Kit', 'Kit 2x16GB, 6000MHz, CL36', 115.00, 90, 'chipset'),
(5, 'Auriculares Gamer 7.1', 'Sonido envolvente, micrófono retráctil', 49.99, 120, 'chipset');
GO

INSERT INTO Pedido (idCliente, fechaPedido, total, usuarioRegistro) VALUES
(1, '2025-10-01', 81.49, 'chipset'),  
(2, '2025-10-05', 349.99, 'chipset'), 
(3, '2025-10-10', 265.00, 'chipset'), 
(4, '2025-10-12', 126.99, 'chipset'), 
(5, '2025-10-15', 295.50, 'chipset'), 
(6, '2025-10-20', 195.00, 'chipset'), 
(7, '2025-10-22', 114.99, 'chipset'), 
(1, '2025-10-25', 425.00, 'chipset'); 
GO

INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioUnitario, usuarioRegistro) VALUES
(1, 2, 1, 35.99, 'chipset'), 
(1, 1, 1, 45.50, 'chipset'), 
(2, 3, 1, 349.99, 'chipset'), 
(3, 7, 1, 210.00, 'chipset'),
(3, 8, 1, 55.00, 'chipset'),
(4, 1, 2, 45.50, 'chipset'), 
(4, 2, 1, 35.99, 'chipset'), 
(5, 4, 1, 125.00, 'chipset'),
(5, 5, 1, 95.00, 'chipset'),
(5, 6, 1, 75.50, 'chipset'), 
(6, 11, 1, 85.00, 'chipset'),
(6, 12, 1, 110.00, 'chipset'),
(7, 9, 1, 65.00, 'chipset'), 
(7, 15, 1, 49.99, 'chipset'), 
(8, 13, 1, 310.00, 'chipset'), 
(8, 14, 1, 115.00, 'chipset'); 
GO
select * from Usuario;