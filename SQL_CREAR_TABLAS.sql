-- ================================================================================
-- SCRIPT DE CREACIÓN DE TABLAS - BASE DE DATOS SISTEMA_VENTAS
-- ================================================================================
-- Ejecutar este script en SQL Server para crear todas las tablas necesarias
-- para el Sistema de Punto de Venta

-- ================================================================================
-- 1. CREAR TABLA DE CLIENTES
-- ================================================================================
IF OBJECT_ID('clientes', 'U') IS NOT NULL DROP TABLE clientes;

CREATE TABLE clientes (
    id_cliente INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(150) NOT NULL,
    email NVARCHAR(100),
    telefono NVARCHAR(20),
    direccion NVARCHAR(250),
    limite_credito DECIMAL(10, 2) DEFAULT 0,
    credito_usado DECIMAL(10, 2) DEFAULT 0,
    estado INT DEFAULT 1, -- 1 = Activo, 0 = Inactivo
    fecha_creacion DATETIME DEFAULT GETDATE()
);

-- ÍNDICES
CREATE INDEX idx_clientes_nombre ON clientes(nombre);
CREATE INDEX idx_clientes_estado ON clientes(estado);

-- DATOS DE PRUEBA
INSERT INTO clientes (nombre, limite_credito, estado) VALUES 
('MOSTRADOR', 0, 1),
('CONSUMIDOR FINAL', 0, 1),
('EMPRESA A', 50000, 1),
('EMPRESA B', 30000, 1);

-- ================================================================================
-- 2. CREAR TABLA DE DEPARTAMENTOS (OPCIONAL)
-- ================================================================================
IF OBJECT_ID('departamentos', 'U') IS NOT NULL DROP TABLE departamentos;

CREATE TABLE departamentos (
    id_departamento INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    estado INT DEFAULT 1
);

INSERT INTO departamentos (nombre, estado) VALUES 
('Electrónica', 1),
('Alimentos', 1),
('Bebidas', 1),
('Higiene', 1),
('Ropa', 1);

-- ================================================================================
-- 3. CREAR TABLA DE PRODUCTOS
-- ================================================================================
IF OBJECT_ID('productos', 'U') IS NOT NULL DROP TABLE productos;

CREATE TABLE productos (
    id_producto INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(200) NOT NULL,
    codigo_barras NVARCHAR(50) UNIQUE NOT NULL,
    precio_venta DECIMAL(10, 2) NOT NULL,
    precio_compra DECIMAL(10, 2),
    existencia DECIMAL(10, 2) DEFAULT 0,
    existencia_minima DECIMAL(10, 2) DEFAULT 10,
    departamento NVARCHAR(100),
    estado INT DEFAULT 1, -- 1 = Activo, 0 = Inactivo
    fecha_creacion DATETIME DEFAULT GETDATE()
);

-- ÍNDICES
CREATE INDEX idx_productos_codigo ON productos(codigo_barras);
CREATE INDEX idx_productos_nombre ON productos(nombre);
CREATE INDEX idx_productos_estado ON productos(estado);

-- DATOS DE PRUEBA
INSERT INTO productos (nombre, codigo_barras, precio_venta, precio_compra, existencia, departamento, estado) VALUES 
('Laptop HP 15', '7891234567890', 899.99, 700.00, 5, 'Electrónica', 1),
('Mouse Logitech', '7891234567891', 29.99, 15.00, 50, 'Electrónica', 1),
('Teclado USB', '7891234567892', 49.99, 30.00, 30, 'Electrónica', 1),
('Monitor LG 24"', '7891234567893', 199.99, 140.00, 8, 'Electrónica', 1),
('Café Premium 1kg', '7891234567894', 15.99, 10.00, 100, 'Alimentos', 1),
('Arroz x 2kg', '7891234567895', 8.99, 5.50, 80, 'Alimentos', 1),
('Coca Cola 2L', '7891234567896', 4.99, 2.50, 200, 'Bebidas', 1),
('Jabón Líquido', '7891234567897', 5.99, 3.00, 60, 'Higiene', 1),
('Toalla de Mano', '7891234567898', 12.99, 7.00, 40, 'Higiene', 1),
('Camiseta Hombre L', '7891234567899', 25.99, 15.00, 25, 'Ropa', 1);

-- ================================================================================
-- 4. CREAR TABLA DE VENTAS
-- ================================================================================
IF OBJECT_ID('detalle_ventas', 'U') IS NOT NULL DROP TABLE detalle_ventas;
IF OBJECT_ID('ventas', 'U') IS NOT NULL DROP TABLE ventas;

CREATE TABLE ventas (
    id_venta INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    fecha_venta DATETIME DEFAULT GETDATE(),
    subtotal DECIMAL(10, 2) NOT NULL,
    impuesto DECIMAL(10, 2) NOT NULL,
    descuento DECIMAL(10, 2) DEFAULT 0,
    total DECIMAL(10, 2) NOT NULL,
    metodo_pago NVARCHAR(50) NOT NULL, -- Efectivo, Tarjeta, Crédito
    id_usuario INT,
    estado NVARCHAR(50) DEFAULT 'Completada', -- Completada, Cancelada, Devuelto
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

-- ÍNDICES
CREATE INDEX idx_ventas_fecha ON ventas(fecha_venta);
CREATE INDEX idx_ventas_cliente ON ventas(id_cliente);
CREATE INDEX idx_ventas_estado ON ventas(estado);

-- ================================================================================
-- 5. CREAR TABLA DE DETALLE DE VENTAS
-- ================================================================================
CREATE TABLE detalle_ventas (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad DECIMAL(10, 2) NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    descuento DECIMAL(10, 2) DEFAULT 0,
    subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES ventas(id_venta),
    FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);

-- ÍNDICES
CREATE INDEX idx_detalle_venta ON detalle_ventas(id_venta);
CREATE INDEX idx_detalle_producto ON detalle_ventas(id_producto);

-- ================================================================================
-- 6. CREAR TABLA DE MOVIMIENTOS DE INVENTARIO
-- ================================================================================
IF OBJECT_ID('movimientos_inventario', 'U') IS NOT NULL DROP TABLE movimientos_inventario;

CREATE TABLE movimientos_inventario (
    id_movimiento INT PRIMARY KEY IDENTITY(1,1),
    id_producto INT NOT NULL,
    tipo_movimiento NVARCHAR(50) NOT NULL, -- Entrada, Salida, Ajuste
    cantidad DECIMAL(10, 2) NOT NULL,
    fecha_movimiento DATETIME DEFAULT GETDATE(),
    referencia NVARCHAR(100), -- Ej: VENTA_123, COMPRA_456
    FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);

-- ÍNDICES
CREATE INDEX idx_movimiento_producto ON movimientos_inventario(id_producto);
CREATE INDEX idx_movimiento_tipo ON movimientos_inventario(tipo_movimiento);
CREATE INDEX idx_movimiento_fecha ON movimientos_inventario(fecha_movimiento);

-- ================================================================================
-- 7. CREAR TABLA DE COMPRAS (OPCIONAL)
-- ================================================================================
IF OBJECT_ID('compras', 'U') IS NOT NULL DROP TABLE compras;

CREATE TABLE compras (
    id_compra INT PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT,
    fecha_compra DATETIME DEFAULT GETDATE(),
    total DECIMAL(10, 2) NOT NULL,
    estado NVARCHAR(50) DEFAULT 'Completada',
    fecha_pago DATETIME
);

-- ================================================================================
-- 8. CREAR TABLA DE USUARIOS (OPCIONAL)
-- ================================================================================
IF OBJECT_ID('usuarios', 'U') IS NOT NULL DROP TABLE usuarios;

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre_usuario NVARCHAR(100) NOT NULL,
    contraseña NVARCHAR(255),
    nombre_completo NVARCHAR(150),
    email NVARCHAR(100),
    rol NVARCHAR(50) DEFAULT 'Vendedor', -- Admin, Vendedor, Gerente
    estado INT DEFAULT 1,
    fecha_creacion DATETIME DEFAULT GETDATE()
);

INSERT INTO usuarios (nombre_usuario, nombre_completo, email, rol, estado) VALUES 
('admin', 'Administrador', 'admin@empresa.com', 'Admin', 1),
('vendedor1', 'Vendedor Uno', 'vendedor1@empresa.com', 'Vendedor', 1);

-- ================================================================================
-- 9. VERIFICAR INTEGRIDAD
-- ================================================================================
-- Ejecutar estas queries para verificar que todo está bien:

/*
SELECT 'Clientes' AS Tabla, COUNT(*) AS Cantidad FROM clientes
UNION ALL
SELECT 'Productos', COUNT(*) FROM productos
UNION ALL
SELECT 'Ventas', COUNT(*) FROM ventas
UNION ALL
SELECT 'Detalle Ventas', COUNT(*) FROM detalle_ventas
UNION ALL
SELECT 'Movimientos Inventario', COUNT(*) FROM movimientos_inventario;

SELECT * FROM productos ORDER BY id_producto;
SELECT * FROM clientes ORDER BY id_cliente;
*/

-- ================================================================================
-- SCRIPT COMPLETADO
-- ================================================================================
-- Base de datos lista para usar el Sistema de Punto de Venta
-- Total de tablas creadas: 7
-- Total de registros de prueba: 13 productos + 4 clientes
