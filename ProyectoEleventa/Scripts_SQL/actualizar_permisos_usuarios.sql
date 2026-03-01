SET NOCOUNT ON;

IF OBJECT_ID('dbo.usuarios', 'U') IS NULL
BEGIN
    RAISERROR('No existe la tabla dbo.usuarios', 16, 1);
    RETURN;
END

DECLARE @cols TABLE (col sysname NOT NULL);

INSERT INTO @cols(col) VALUES
('ventas_producto_comun'),
('ventas_aplicar_mayoreo'),
('ventas_aplicar_descuento'),
('ventas_revisar_historial'),
('ventas_entradas_efectivo'),
('ventas_salidas_efectivo'),
('ventas_cobrar_ticket'),
('ventas_cobrar_credito'),
('ventas_cancelar_tickets'),
('ventas_eliminar_articulos'),
('ventas_facturar'),
('ventas_ver_facturas'),
('ventas_vender_pago_servicio'),
('ventas_vender_recargas'),
('ventas_usar_buscador'),
('clientes_abc'),
('clientes_asignar_venta'),
('clientes_asignar_credito'),
('clientes_ver_cuenta'),
('productos_crear'),
('productos_modificar'),
('productos_eliminar'),
('productos_ver_reporte_ventas'),
('productos_crear_promociones'),
('productos_modificar_varios'),
('inventario_agregar_mercancia'),
('inventario_ver_reportes'),
('inventario_ver_movimientos'),
('inventario_ajustar'),
('otros_corte_turno'),
('otros_corte_todos_turnos'),
('otros_corte_dia'),
('otros_ver_ganancia_dia'),
('otros_cambiar_configuracion'),
('otros_acceder_reportes'),
('otros_crear_ordenes_compra'),
('otros_recibir_ordenes_compra');

DECLARE @c sysname;
DECLARE cur CURSOR LOCAL FAST_FORWARD FOR SELECT col FROM @cols;
OPEN cur;
FETCH NEXT FROM cur INTO @c;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF COL_LENGTH('dbo.usuarios', @c) IS NULL
    BEGIN
        DECLARE @sql nvarchar(max) = N'ALTER TABLE dbo.usuarios ADD ' + QUOTENAME(@c) + N' BIT NOT NULL CONSTRAINT ' + QUOTENAME('DF_usuarios_' + @c) + N' DEFAULT(0);';
        EXEC sp_executesql @sql;
    END
    FETCH NEXT FROM cur INTO @c;
END
CLOSE cur;
DEALLOCATE cur;

PRINT 'Columnas de permisos verificadas/creadas correctamente.';
