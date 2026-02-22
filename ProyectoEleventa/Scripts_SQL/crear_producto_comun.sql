-- ===============================================
-- CREAR PRODUCTO ESPECIAL PARA PRODUCTOS COMUNES
-- ===============================================

USE sistema_ventas;
GO

-- Verificar si el producto especial ya existe
IF NOT EXISTS (SELECT * FROM productos WHERE nombre = 'PRODUCTO COMÚN')
BEGIN
    INSERT INTO productos (codigo_barras, nombre, precio_compra, porcentaje_ganancia, precio_venta, existencia, estado, fecha_creacion)
    VALUES ('PC', 'PRODUCTO COMÚN', 0, 0, 0, 999999, 1, GETDATE());
    
    PRINT '✓ Producto especial COMÚN creado con éxito';
END
ELSE
BEGIN
    PRINT '✓ Producto especial COMÚN ya existe';
END

-- Mostrar el producto creado
SELECT id_producto, codigo_barras, nombre FROM productos WHERE nombre = 'PRODUCTO COMÚN';
