# 📦 CONFIGURACIÓN DE INVENTARIO - BASE DE DATOS

## ⚠️ REQUISITO: Crear columnas en BD

Para que el sistema de inventario funcione completamente, ejecuta estas sentencias en **SQL Server**:

---

## 🔧 PASO 1: Crear columnas de existencia mínima y máxima

```sql
-- Si las columnas no existen, crearlas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='productos' AND COLUMN_NAME='existencia_minima')
BEGIN
    ALTER TABLE productos ADD existencia_minima DECIMAL(18,4) DEFAULT 0 NOT NULL;
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='productos' AND COLUMN_NAME='existencia_maxima')
BEGIN
    ALTER TABLE productos ADD existencia_maxima DECIMAL(18,4) DEFAULT 0 NOT NULL;
END
```

**O si prefieres sentencias simples:**

```sql
ALTER TABLE productos ADD existencia_minima DECIMAL(18,4) DEFAULT 0 NOT NULL;
ALTER TABLE productos ADD existencia_maxima DECIMAL(18,4) DEFAULT 0 NOT NULL;
```

---

## ✅ PASO 2: Verificar que las columnas se crearon

```sql
-- Verifica que todas las columnas existan
SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'productos'
ORDER BY ORDINAL_POSITION;

-- Deberías ver: existencia_minima, existencia_maxima
```

---

## 📋 PASO 3: Estructura completa de la tabla

Tu tabla `productos` debe tener estas columnas:

```
id_producto          INT          PRIMARY KEY
codigo_barras        VARCHAR(50)  UNIQUE
nombre               VARCHAR(255)
precio_compra        DECIMAL(18,2)
porcentaje_ganancia  DECIMAL(18,2)
precio_venta         DECIMAL(18,2)
existencia           DECIMAL(18,4)
departamento         INT
existencia_minima    DECIMAL(18,4) ← NUEVA ✅
existencia_maxima    DECIMAL(18,4) ← NUEVA ✅
estado               BIT
fecha_creacion       DATETIME
```

---

## 🎯 ¿CÓMO FUNCIONA?

### En el formulario de productos:

```
1. Usuario marca "Este Producto SI utiliza inventario"
   ↓
2. Se habilitan los campos:
   - Existencia actual (txtExistencia)
   - Existencia mínima (txtExistenciaMinima)
   - Existencia máxima (txtExistenciaMaxima)
   ↓
3. Usuario ingresa los valores:
   - Existencia: 50
   - Mínima: 10
   - Máxima: 100
   ↓
4. Al hacer clic "Guardar Producto"
   ↓
5. El sistema guarda:
   - existencia = 50 (en columna existencia)
   - existencia_minima = 10 (en columna existencia_minima)
   - existencia_maxima = 100 (en columna existencia_maxima)

   NOTA: NO se guarda nada sobre el checkbox
```

---

## 📝 EJEMPLO DE SENTENCIA COMPLETA

```sql
-- Crear tabla productos con inventario
CREATE TABLE productos (
    id_producto INT PRIMARY KEY IDENTITY(1,1),
    codigo_barras VARCHAR(50) UNIQUE NOT NULL,
    nombre VARCHAR(255) NOT NULL,
    precio_compra DECIMAL(18,2) NOT NULL,
    porcentaje_ganancia DECIMAL(18,2) DEFAULT 0,
    precio_venta DECIMAL(18,2) NOT NULL,
    existencia DECIMAL(18,4) DEFAULT 0,
    departamento INT,
    existencia_minima DECIMAL(18,4) DEFAULT 0 NOT NULL,
    existencia_maxima DECIMAL(18,4) DEFAULT 0 NOT NULL,
    estado BIT DEFAULT 1,
    fecha_creacion DATETIME DEFAULT GETDATE()
);
```

---

## 🔍 VERIFICACIÓN

Después de ejecutar las sentencias, prueba el sistema:

### Crear producto con inventario:
```
1. Código: TEST-INV
2. Nombre: Producto con Inventario
3. Costo: 100
4. Ganancia: 30%
   → Precio: 130 (automático)
5. Marcar: ✓ Este Producto SI utiliza inventario
   → Se habilitan los campos de existencia
6. Existencia: 50
7. Mínima: 10
8. Máxima: 100
9. Guardar

Resultado esperado:
✅ Producto guardado correctamente
✅ Se guarda existencia = 50
✅ Se guarda existencia_minima = 10
✅ Se guarda existencia_maxima = 100
```

---

## 🛡️ NOTAS IMPORTANTES

1. **Checkbox solo habilita/deshabilita:**
   - No se guarda el estado del checkbox en BD
   - Solo habilita los campos para que el usuario ingrese valores

2. **Valores guardados:**
   - Solo se guardan: existencia, existencia_minima, existencia_maxima
   - Si el usuario no ingresa valores, se guardan como 0

3. **Tipos de dato:**
   - `existencia_minima`: DECIMAL(18,4) (permite decimales)
   - `existencia_maxima`: DECIMAL(18,4) (permite decimales)

4. **Campos de entrada:**
   - Si checkbox está DESMARCADO → campos deshabilitados y vacios
   - Si checkbox está MARCADO → campos habilitados para edición
   - Al editar, si hay valores en mínima o máxima → checkbox se marca automáticamente

---

## 📊 RESUMEN

- **Columna usa_inventario:** NO NECESARIA ❌
- **Columna existencia_minima:** NECESARIA ✅
- **Columna existencia_maxima:** NECESARIA ✅

El checkbox solo es un control de interfaz para habilitar/deshabilitar campos.

---

## ⚡ PRÓXIMOS PASOS

1. ✅ Ejecutar sentencias SQL
2. ✅ Verificar que las columnas se crearon
3. ✅ Compilar el proyecto (ya compilado)
4. ✅ Probar creando un producto con inventario
5. ✅ Verificar que se guarden los datos en BD

---

**¿Lista para activar inventario?** 🚀

Ejecuta las 2 sentencias SQL y luego prueba el sistema.

