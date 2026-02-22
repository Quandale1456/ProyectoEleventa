-- ===============================================
-- SCRIPT COMPLETO DE ACTUALIZACIÓN - TABLA CLIENTES
-- Elimina columnas antiguas y configura las nuevas
-- ===============================================

USE sistema_ventas;
GO

-- PASO 1: ELIMINAR COLUMNAS INNECESARIAS
BEGIN TRY
    -- Eliminar columnas que no se usan
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'email')
    BEGIN
        ALTER TABLE clientes DROP COLUMN email;
        PRINT '✓ Columna email eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'direccion')
    BEGIN
        ALTER TABLE clientes DROP COLUMN direccion;
        PRINT '✓ Columna direccion eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'limite_credito')
    BEGIN
        ALTER TABLE clientes DROP COLUMN limite_credito;
        PRINT '✓ Columna limite_credito eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'credito_usado')
    BEGIN
        ALTER TABLE clientes DROP COLUMN credito_usado;
        PRINT '✓ Columna credito_usado eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'folio')
    BEGIN
        ALTER TABLE clientes DROP COLUMN folio;
        PRINT '✓ Columna folio eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'estado_registro')
    BEGIN
        ALTER TABLE clientes DROP COLUMN estado_registro;
        PRINT '✓ Columna estado_registro eliminada';
    END
    
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'fecha_registro')
    BEGIN
        ALTER TABLE clientes DROP COLUMN fecha_registro;
        PRINT '✓ Columna fecha_registro eliminada';
    END

END TRY
BEGIN CATCH
    PRINT 'Error eliminando columnas: ' + ERROR_MESSAGE();
END CATCH

-- PASO 2: AGREGAR O VERIFICAR COLUMNAS NECESARIAS
BEGIN TRY
    
    -- Verificar que apellidos existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'apellidos')
    BEGIN
        ALTER TABLE clientes ADD apellidos NVARCHAR(100);
        PRINT '✓ Columna apellidos agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna apellidos ya existe';
    END
    
    -- Verificar que telefono existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'telefono')
    BEGIN
        ALTER TABLE clientes ADD telefono NVARCHAR(20);
        PRINT '✓ Columna telefono agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna telefono ya existe';
    END
    
    -- Verificar que domicilio1 existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'domicilio1')
    BEGIN
        ALTER TABLE clientes ADD domicilio1 NVARCHAR(255);
        PRINT '✓ Columna domicilio1 agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna domicilio1 ya existe';
    END
    
    -- Verificar que domicilio2 existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'domicilio2')
    BEGIN
        ALTER TABLE clientes ADD domicilio2 NVARCHAR(255);
        PRINT '✓ Columna domicilio2 agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna domicilio2 ya existe';
    END
    
    -- Verificar que colonia existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'colonia')
    BEGIN
        ALTER TABLE clientes ADD colonia NVARCHAR(100);
        PRINT '✓ Columna colonia agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna colonia ya existe';
    END
    
    -- Verificar que municipio existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'municipio')
    BEGIN
        ALTER TABLE clientes ADD municipio NVARCHAR(100);
        PRINT '✓ Columna municipio agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna municipio ya existe';
    END
    
    -- Verificar que codigo_postal existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'codigo_postal')
    BEGIN
        ALTER TABLE clientes ADD codigo_postal NVARCHAR(20);
        PRINT '✓ Columna codigo_postal agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna codigo_postal ya existe';
    END
    
    -- Verificar que estado existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'estado')
    BEGIN
        ALTER TABLE clientes ADD estado NVARCHAR(100);
        PRINT '✓ Columna estado agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna estado ya existe';
    END
    
    -- Verificar que notas existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'notas')
    BEGIN
        ALTER TABLE clientes ADD notas NVARCHAR(MAX);
        PRINT '✓ Columna notas agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna notas ya existe';
    END
    
    -- Verificar que tiene_credito_autorizado existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'tiene_credito_autorizado')
    BEGIN
        ALTER TABLE clientes ADD tiene_credito_autorizado BIT DEFAULT 0;
        PRINT '✓ Columna tiene_credito_autorizado agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna tiene_credito_autorizado ya existe';
    END
    
    -- Verificar que fecha_creacion existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'fecha_creacion')
    BEGIN
        ALTER TABLE clientes ADD fecha_creacion DATETIME DEFAULT GETDATE();
        PRINT '✓ Columna fecha_creacion agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna fecha_creacion ya existe';
    END
    
    -- Verificar que fecha_actualizacion existe
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes' AND COLUMN_NAME = 'fecha_actualizacion')
    BEGIN
        ALTER TABLE clientes ADD fecha_actualizacion DATETIME DEFAULT GETDATE();
        PRINT '✓ Columna fecha_actualizacion agregada';
    END
    ELSE
    BEGIN
        PRINT '✓ Columna fecha_actualizacion ya existe';
    END

END TRY
BEGIN CATCH
    PRINT 'Error agregando columnas: ' + ERROR_MESSAGE();
END CATCH

-- PASO 3: MOSTRAR ESTRUCTURA FINAL DE LA TABLA
PRINT '';
PRINT '===============================================';
PRINT 'ESTRUCTURA FINAL DE LA TABLA clientes';
PRINT '===============================================';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'clientes'
ORDER BY ORDINAL_POSITION;

PRINT '';
PRINT '✓ Script completado correctamente';
