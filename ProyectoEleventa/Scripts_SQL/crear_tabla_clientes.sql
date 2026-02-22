-- ===============================================
-- CREAR TABLA CLIENTES - SCRIPT COMPLETO
-- ===============================================

USE sistema_ventas;
GO

-- PASO 1: VERIFICAR Y ELIMINAR TABLA SI EXISTE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'clientes')
BEGIN
    PRINT 'Eliminando tabla clientes existente...';
    DROP TABLE clientes;
    PRINT '✓ Tabla eliminada';
END

-- PASO 2: CREAR TABLA CLIENTES CON TODAS LAS COLUMNAS
BEGIN TRY
    CREATE TABLE clientes (
        id_cliente INT PRIMARY KEY IDENTITY(1,1),
        nombre NVARCHAR(100) NOT NULL,
        apellidos NVARCHAR(100),
        telefono NVARCHAR(20),
        domicilio1 NVARCHAR(255),
        domicilio2 NVARCHAR(255),
        colonia NVARCHAR(100),
        codigo_postal NVARCHAR(20),
        municipio NVARCHAR(100),
        estado NVARCHAR(100),
        notas NVARCHAR(MAX),
        tiene_credito_autorizado BIT DEFAULT 0,
        fecha_creacion DATETIME DEFAULT GETDATE(),
        fecha_actualizacion DATETIME DEFAULT GETDATE()
    );
    
    PRINT '✓ Tabla clientes creada correctamente';
    
END TRY
BEGIN CATCH
    PRINT 'ERROR creando tabla: ' + ERROR_MESSAGE();
    RETURN;
END CATCH

-- PASO 3: AGREGAR CLIENTES POR DEFECTO
BEGIN TRY
    INSERT INTO clientes (nombre, apellidos, fecha_creacion, fecha_actualizacion)
    VALUES 
        ('MOSTRADOR', '', GETDATE(), GETDATE()),
        ('CONSUMIDOR FINAL', '', GETDATE(), GETDATE());
    
    PRINT '✓ Clientes por defecto agregados';
    
END TRY
BEGIN CATCH
    PRINT 'ERROR insertando clientes: ' + ERROR_MESSAGE();
END CATCH

-- PASO 4: CREAR ÍNDICES PARA OPTIMIZACIÓN
BEGIN TRY
    CREATE INDEX idx_clientes_nombre ON clientes(nombre);
    CREATE INDEX idx_clientes_apellidos ON clientes(apellidos);
    CREATE INDEX idx_clientes_telefono ON clientes(telefono);
    
    PRINT '✓ Índices creados';
    
END TRY
BEGIN CATCH
    PRINT 'ERROR creando índices: ' + ERROR_MESSAGE();
END CATCH

-- PASO 5: MOSTRAR ESTRUCTURA Y DATOS
PRINT '';
PRINT '===============================================';
PRINT 'ESTRUCTURA DE LA TABLA clientes';
PRINT '===============================================';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'clientes'
ORDER BY ORDINAL_POSITION;

PRINT '';
PRINT '===============================================';
PRINT 'DATOS INICIALES EN LA TABLA clientes';
PRINT '===============================================';
SELECT * FROM clientes;

PRINT '';
PRINT '✓ Script completado correctamente';
PRINT '✓ La tabla clientes está lista para usar';
