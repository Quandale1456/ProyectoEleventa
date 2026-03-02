SET NOCOUNT ON;

IF OBJECT_ID('dbo.movimientos_efectivo', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.movimientos_efectivo (
        id_movimiento INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        tipo NVARCHAR(20) NOT NULL,
        cantidad DECIMAL(10,2) NOT NULL,
        comentario NVARCHAR(250) NULL,
        fecha DATETIME NOT NULL CONSTRAINT DF_movimientos_efectivo_fecha DEFAULT (GETDATE()),
        id_usuario INT NULL
    );

    CREATE INDEX IX_movimientos_efectivo_fecha ON dbo.movimientos_efectivo(fecha);
    CREATE INDEX IX_movimientos_efectivo_tipo ON dbo.movimientos_efectivo(tipo);
END
