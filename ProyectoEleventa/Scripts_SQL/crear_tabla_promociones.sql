-- ===============================================
-- CREAR TABLA PROMOCIONES
-- ===============================================

USE sistema_ventas;
GO

-- PASO 1: VERIFICAR Y ELIMINAR TABLA SI EXISTE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'promociones')
BEGIN
    PRINT 'Eliminando tabla promociones existente...';
    DROP TABLE promociones;
    PRINT '✓ Tabla eliminada';
END

-- PASO 2: CREAR TABLA PROMOCIONES
BEGIN TRY
    CREATE TABLE promociones (
        id_promocion INT PRIMARY KEY IDENTITY(1,1),
        nombre_promocion NVARCHAR(150) NOT NULL,
        id_producto INT NOT NULL,
        cantidad_desde INT NOT NULL,
        cantidad_hasta INT NOT NULL,
        precio_promocion DECIMAL(10, 2) NOT NULL,
        estado BIT DEFAULT 1,
        fecha_creacion DATETIME DEFAULT GETDATE(),
        fecha_actualizacion DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_promociones_productos FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
    );
    
    PRINT '✓ Tabla promociones creada correctamente';
    
END TRY
BEGIN CATCH
    PRINT 'ERROR creando tabla: ' + ERROR_MESSAGE();
    RETURN;
END CATCH

-- PASO 3: CREAR ÍNDICES PARA OPTIMIZACIÓN
BEGIN TRY
    CREATE INDEX idx_promociones_producto ON promociones(id_producto);
    CREATE INDEX idx_promociones_estado ON promociones(estado);
    CREATE INDEX idx_promociones_nombre ON promociones(nombre_promocion);
    
    PRINT '✓ Índices creados';
    
END TRY
BEGIN CATCH
    PRINT 'ERROR creando índices: ' + ERROR_MESSAGE();
END CATCH

-- PASO 4: MOSTRAR ESTRUCTURA DE LA TABLA
PRINT '';
PRINT '===============================================';
PRINT 'ESTRUCTURA DE LA TABLA promociones';
PRINT '===============================================';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'promociones'
ORDER BY ORDINAL_POSITION;

PRINT '';
PRINT '✓ Script completado correctamente';
PRINT '✓ La tabla promociones está lista para usar';
