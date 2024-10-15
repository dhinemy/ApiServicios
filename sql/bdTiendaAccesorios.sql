CREATE DATABASE bdTiendaAccesorios;
GO 

USE bdTiendaAccesorios;
GO

CREATE TABLE tblTipoProducto (
id INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL, 
Activo BIT NOT NULL
); 
GO

CREATE TABLE tblTipoDocumento (
id INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL, 
Activo BIT NOT NULL
); 
GO

CREATE TABLE tblProveedor (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
id_tipo_documento INT  NOT NULL,
documento NVARCHAR(50) NOT NULL,
razon_social NVARCHAR(100) NOT NULL,
activo BIT NOT NULL DEFAULT 1
);
GO

ALTER TABLE tblProveedor
ADD CONSTRAINT FK_TipoDocumento_Proveedor
FOREIGN KEY (id_tipo_documento)
REFERENCES tblTipoDocumento(id)
GO

CREATE TABLE tblTelefonoProveedor (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
id_proveedor INT NOT NULL,
telefono NVARCHAR(50) NOT NULL, 
activo BIT NOT NULL DEFAULT 1
);
GO

ALTER TABLE tblTelefonoProveedor
ADD CONSTRAINT FK_Proveedor_TelefonoProveedor 
FOREIGN KEY (id_proveedor)
REFERENCES tblProveedor(id)
GO

CREATE TABLE tblCiudad (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
nombre VARCHAR(50) NOT NULL,
activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE tblDireccionProveedor (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
id_proveedor INT  NOT NULL,
id_ciudad INT NOT NULL,
direccion NVARCHAR(50) NOT NULL, 
activo BIT NOT NULL DEFAULT 1
);
GO

ALTER TABLE tblDireccionProveedor 
ADD CONSTRAINT FK_Proveedor_DireccionProveedor
FOREIGN KEY (id_proveedor)
REFERENCES tblProveedor(id)
GO

ALTER TABLE tblDireccionProveedor
ADD CONSTRAINT FK_Ciudad_DireccionProveedor 
FOREIGN KEY (id_ciudad)
REFERENCES tblCiudad(id)
GO

CREATE TABLE tblProducto (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
nombre NVARCHAR(50) NOT NULL,
codigo NVARCHAR(50) NOT NULL,
valor_unitario DECIMAL NOT NULL, 
id_proveedor INT NOT NULL,
id_tipo_producto INT NOT NULL,
tiempo_garantia INT NOT NULL, 
descuento FLOAT DEFAULT 1
);
GO

ALTER TABLE tblProducto 
ADD CONSTRAINT FK_Proveedor_Producto
FOREIGN KEY (id_proveedor)
REFERENCES tblProveedor(id)
GO

ALTER TABLE tblProducto 
ADD CONSTRAINT FK_TipoProducto_Producto
FOREIGN KEY (id_tipo_producto)
REFERENCES tblTipoProducto(id)
GO

CREATE TABLE tblFormaEntrega (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
nombre NVARCHAR(50) NOT NULL, 
activo BIT NOT NULL DEFAULT 1
); 
GO

CREATE TABLE tblFormaPago (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
nombre NVARCHAR(50),
activo BIT DEFAULT 1
);
GO

CREATE TABLE tblCliente (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
nombre NVARCHAR(50) NOT NULL, 
id_tipo_documento INT NOT NULL,
nro_documento NVARCHAR(50) NOT NULL,
activo BIT DEFAULT 1 NOT NULL
);
GO

ALTER TABLE tblCliente 
ADD CONSTRAINT FK_TipoDocumento_Cliente 
FOREIGN KEY (id_tipo_documento)
REFERENCES tblTipoDocumento(id)
GO


CREATE TABLE tblTelefonoCliente (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
id_cliente INT NOT NULL,
telefono NVARCHAR(50) NOT NULL, 
activo BIT DEFAULT 1 NOT NULL
);
GO

ALTER TABLE tblTelefonoCliente
ADD CONSTRAINT FK_Cliente_TelefonoCliente
FOREIGN KEY (id_cliente)
REFERENCES tblCliente(id)
GO


CREATE TABLE tblDireccionCliente (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
id_cliente INT NOT NULL,
id_ciudad INT NOT NULL,
direccion NVARCHAR(100) NOT NULL,
activo BIT DEFAULT 1 NOT NULL
);
GO

ALTER TABLE tblDireccionCliente
ADD CONSTRAINT FK_Cliente_DireccionCliente
FOREIGN KEY (id_cliente)
REFERENCES tblCliente(id)
GO

ALTER TABLE tblDireccionCliente
ADD CONSTRAINT FK_Ciudad_DireccionCliente
FOREIGN KEY (id_ciudad)
REFERENCES tblCiudad(id)
GO

CREATE TABLE tblPedido (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
id_cliente INT  NOT NULL, 
id_direccion INT NOT NULL, 
id_forma_entrega INT  NOT NULL, 
id_forma_pago INT  NOT NULL, 
fecha_pedido DATETIME DEFAULT GETDATE() NOT NULL,
fecha_entrega DATETIME NULL,
total FLOAT NOT NULL, 
descuento FLOAT NULL
);
GO

ALTER TABLE tblPedido 
ADD CONSTRAINT FK_FormaPago_Pedido
FOREIGN KEY (id_forma_pago)
REFERENCES tblFormaPago(id)
GO

ALTER TABLE tblPedido
ADD CONSTRAINT FK_FormaEntrega_Pedido
FOREIGN KEY (id_forma_entrega)
REFERENCES tblFormaEntrega(id)
GO

ALTER TABLE tblPedido
ADD CONSTRAINT FK_Direccion_Pedido
FOREIGN KEY (id_direccion)
REFERENCES tblDireccionCliente(id)
GO


ALTER TABLE tblPedido
ADD CONSTRAINT FK_Cliente_Pedido
FOREIGN KEY (id_cliente)
REFERENCES tblCliente(id)
GO


CREATE TABLE tblDetallePedido(
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
id_pedido INT NOT NULL,
id_producto INT NOT NULL,
descuento FLOAT, 
vr_unitario FLOAT NOT NULL,
cantidad INT NOT NULL, 
iva FLOAT NULL, 
fecha_fin_garantia DATETIME NULL, 
total FLOAT NOT NULL
);
GO

ALTER TABLE tblDetallePedido
ADD CONSTRAINT FK_Pedido_DetallePedido 
FOREIGN KEY (id_pedido)
REFERENCES tblPedido(id)
GO

ALTER TABLE tblDetallePedido
ADD CONSTRAINT FK_Producto_DetallePedido
FOREIGN KEY (id_producto)
REFERENCES tblProducto(id)
GO

CREATE TABLE tblGarantia (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
id_detalle_pedido INT NOT NULL,
observacion NVARCHAR(100) NULL, 
activo BIT DEFAULT 1
);
GO

ALTER TABLE tblGarantia
ADD CONSTRAINT FK_DetallePedido_Garantia
FOREIGN KEY (id_detalle_pedido)
REFERENCES tblDetallePedido(id)
GO

-- INGRESO DE REGISTROS 

-- tblTipoProducto
INSERT INTO tblTipoProducto (Nombre, Activo) VALUES ('Collar', 1);
INSERT INTO tblTipoProducto (Nombre, Activo) VALUES ('Pulsera', 1);
INSERT INTO tblTipoProducto (Nombre, Activo) VALUES ('Anillo', 1);
INSERT INTO tblTipoProducto (Nombre, Activo) VALUES ('Aretes', 1);
GO

-- tblTipoDocumento
INSERT INTO tblTipoDocumento (Nombre, Activo) VALUES ('Cédula de Ciudadanía', 1);
INSERT INTO tblTipoDocumento (Nombre, Activo) VALUES ('NIT', 1);
INSERT INTO tblTipoDocumento (Nombre, Activo) VALUES ('Pasaporte', 1);
GO

-- tblProveedor
INSERT INTO tblProveedor (id_tipo_documento, documento, razon_social, activo) 
VALUES (2, '900123456-7', 'Joyas del Norte S.A.', 1);
INSERT INTO tblProveedor (id_tipo_documento, documento, razon_social, activo) 
VALUES (2, '900987654-3', 'Arte en Oro Ltda.', 1);
INSERT INTO tblProveedor (id_tipo_documento, documento, razon_social, activo) 
VALUES (1, '12345678', 'Diamantes del Sur', 1);
GO
-- tblTelefonoProveedor
INSERT INTO tblTelefonoProveedor (id_proveedor, telefono, activo) 
VALUES (1, '3001234567', 1);
INSERT INTO tblTelefonoProveedor (id_proveedor, telefono, activo) 
VALUES (2, '3009876543', 1);
INSERT INTO tblTelefonoProveedor (id_proveedor, telefono, activo) 
VALUES (3, '3101234567', 1);
GO
-- tblCiudad
INSERT INTO tblCiudad (nombre, activo) VALUES ('Medellín', 1);
INSERT INTO tblCiudad (nombre, activo) VALUES ('Bogotá', 1);
INSERT INTO tblCiudad (nombre, activo) VALUES ('Cali', 1);
INSERT INTO tblCiudad (nombre, activo) VALUES ('Barranquilla', 1);
GO
-- tblDireccionProveedor
INSERT INTO tblDireccionProveedor (id_proveedor, id_ciudad, direccion, activo) 
VALUES (1, 1, 'Calle 123 #45-67', 1);
INSERT INTO tblDireccionProveedor (id_proveedor, id_ciudad, direccion, activo) 
VALUES (2, 2, 'Carrera 89 #12-34', 1);
INSERT INTO tblDireccionProveedor (id_proveedor, id_ciudad, direccion, activo) 
VALUES (3, 3, 'Avenida 45 #67-89', 1);
GO
-- tblProducto
INSERT INTO tblProducto (nombre, codigo, valor_unitario, id_proveedor, id_tipo_producto, tiempo_garantia, descuento) 
VALUES ('Collar de Perlas', 'COL-001', 250000, 1, 1, 12, 0.05);
INSERT INTO tblProducto (nombre, codigo, valor_unitario, id_proveedor, id_tipo_producto, tiempo_garantia, descuento) 
VALUES ('Pulsera de Oro', 'PUL-002', 300000, 2, 2, 24, 0.10);
INSERT INTO tblProducto (nombre, codigo, valor_unitario, id_proveedor, id_tipo_producto, tiempo_garantia, descuento) 
VALUES ('Anillo de Diamante', 'ANI-003', 500000, 3, 3, 36, 0.15);
INSERT INTO tblProducto (nombre, codigo, valor_unitario, id_proveedor, id_tipo_producto, tiempo_garantia, descuento) 
VALUES ('Aretes de Plata', 'ARE-004', 150000, 1, 4, 12, 0.10);
GO
-- tblFormaEntrega
INSERT INTO tblFormaEntrega (nombre, activo) VALUES ('Entrega a Domicilio', 1);
INSERT INTO tblFormaEntrega (nombre, activo) VALUES ('Recoger en Tienda', 1);
INSERT INTO tblFormaEntrega (nombre, activo) VALUES ('Envio Nacional', 1);
GO
-- tblFormaPago
INSERT INTO tblFormaPago (nombre, activo) VALUES ('Tarjeta de Crédito', 1);
INSERT INTO tblFormaPago (nombre, activo) VALUES ('Efectivo', 1);
INSERT INTO tblFormaPago (nombre, activo) VALUES ('Transferencia Bancaria', 1);
GO
-- tblCliente
INSERT INTO tblCliente (nombre, id_tipo_documento, nro_documento, activo) 
VALUES ('Carlos López', 1, '1012345678', 1);
INSERT INTO tblCliente (nombre, id_tipo_documento, nro_documento, activo) 
VALUES ('Ana Martínez', 1, '1098765432', 1);
INSERT INTO tblCliente (nombre, id_tipo_documento, nro_documento, activo) 
VALUES ('Laura García', 1, '1045678901', 1);
GO
-- tblTelefonoCliente
INSERT INTO tblTelefonoCliente (id_cliente, telefono, activo) 
VALUES (1, '3216549870', 1);
INSERT INTO tblTelefonoCliente (id_cliente, telefono, activo) 
VALUES (2, '9873216540', 1);
INSERT INTO tblTelefonoCliente (id_cliente, telefono, activo) 
VALUES (3, '3123456789', 1);
GO
-- tblDireccionCliente
INSERT INTO tblDireccionCliente (id_cliente, id_ciudad, direccion, activo) 
VALUES (1, 1, 'Calle 50 #20-30', 1);
INSERT INTO tblDireccionCliente (id_cliente, id_ciudad, direccion, activo) 
VALUES (2, 2, 'Avenida 10 #5-15', 1);
INSERT INTO tblDireccionCliente (id_cliente, id_ciudad, direccion, activo) 
VALUES (3, 3, 'Carrera 25 #15-10', 1);
GO
-- tblPedido
INSERT INTO tblPedido (id_cliente, id_direccion, id_forma_entrega, id_forma_pago, total, descuento) 
VALUES (1, 1, 1, 1, 250000, 0.05);
INSERT INTO tblPedido (id_cliente, id_direccion, id_forma_entrega, id_forma_pago, total, descuento) 
VALUES (2, 2, 2, 2, 300000, 0.10);
INSERT INTO tblPedido (id_cliente, id_direccion, id_forma_entrega, id_forma_pago, total, descuento) 
VALUES (3, 3, 3, 3, 500000, 0.15);
GO
-- tblDetallePedido
INSERT INTO tblDetallePedido (id_pedido, id_producto, vr_unitario, cantidad, total) 
VALUES (1, 1, 250000, 1, 250000);
INSERT INTO tblDetallePedido (id_pedido, id_producto, vr_unitario, cantidad, total) 
VALUES (2, 2, 300000, 1, 300000);
INSERT INTO tblDetallePedido (id_pedido, id_producto, vr_unitario, cantidad, total) 
VALUES (3, 3, 500000, 1, 500000);
GO
-- tblGarantia
INSERT INTO tblGarantia (id_detalle_pedido, observacion, activo) 
VALUES (1, 'Garantía de 12 meses', 1);
INSERT INTO tblGarantia (id_detalle_pedido, observacion, activo) 
VALUES (2, 'Garantía de 24 meses', 1);
INSERT INTO tblGarantia (id_detalle_pedido, observacion, activo) 
VALUES (3, 'Garantía de 36 meses', 1);
GO