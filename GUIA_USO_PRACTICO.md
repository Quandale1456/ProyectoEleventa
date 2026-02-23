# Guía de Uso - Funcionalidad de Búsqueda y Cálculo de Inventario

## 🚀 Cómo Funciona en Práctica

### Escenario 1: Búsqueda Exitosa de Producto

**Paso 1**: Usuario escribe un código válido
```
txtCodigoProducto: LAPTOP-001
```

**Paso 2**: Presiona Enter

**Paso 3**: Sistema busca en BD
- Consulta: `SELECT ... FROM productos WHERE codigo_barras = 'LAPTOP-001'`
- Resultado: ✅ Producto encontrado

**Paso 4**: Interfaz se actualiza automáticamente
```
Panel se MUESTRA (Visible = true)

┌─ panelProducto ──────────────────────────────┐
│                                               │
│ Descripción:    Laptop Dell XPS 15           │
│ Stock:          5                             │
│ Agregar:        [___]                         │
│ Precio Costo:   $800.00                       │
│ Precio Venta:   $960.00                       │
│ % Ganancia:     20                            │
│                                               │
│ [Agregar Cantidad a Inventario]              │
└───────────────────────────────────────────────┘
```

---

### Escenario 2: Producto No Encontrado

**Paso 1**: Usuario escribe código inválido
```
txtCodigoProducto: CODIGO-INEXISTENTE
```

**Paso 2**: Presiona Enter

**Paso 3**: Sistema busca en BD
- Resultado: ❌ No encontrado (0 registros)

**Paso 4**: Interfaz responde
```
MessageBox:
┌─────────────────────────────────────────┐
│ El producto con código 'CODIGO-INEXISTENTE' │
│ no fue encontrado en la base de datos.  │
│                                         │
│                           [OK]          │
└─────────────────────────────────────────┘

Panel se OCULTA (Visible = false)
```

---

### Escenario 3: Recálculo Automático de Precio

**Paso 1**: Producto está cargado en el panel
```
Precio Costo: $100
% Ganancia:   30
Precio Venta: $130 (calculado automáticamente)
```

**Paso 2**: Usuario modifica el precio de costo
```
Usuario escribe: 150

┌─ Evento TextChanged ─────────────────┐
│ RecalcularPrecioVenta() se ejecuta   │
│                                      │
│ Fórmula: 150 + (150 × 30 ÷ 100)     │
│ Resultado: 150 + 45 = 195             │
│                                      │
│ txtPrecioVenta se actualiza a $195.00│
└──────────────────────────────────────┘
```

**Resultado**:
```
Precio Costo: $150.00 ← (usuario cambió)
% Ganancia:   30
Precio Venta: $195.00 ← (recalculado automáticamente)
```

---

### Escenario 4: Modificar Porcentaje de Ganancia

**Paso 1**: Estado actual
```
Precio Costo: $100
% Ganancia:   20
Precio Venta: $120
```

**Paso 2**: Usuario cambia porcentaje a 50%
```
Usuario escribe: 50

┌─ Evento TextChanged ─────────────────────┐
│ RecalcularPrecioVenta() se ejecuta       │
│                                          │
│ Fórmula: 100 + (100 × 50 ÷ 100)        │
│ Resultado: 100 + 50 = 150                 │
│                                          │
│ txtPrecioVenta se actualiza a $150.00   │
└─────────────────────────────────────────┘
```

**Resultado**:
```
Precio Costo: $100.00
% Ganancia:   50 ← (usuario cambió)
Precio Venta: $150.00 ← (recalculado automáticamente)
```

---

### Escenario 5: Campo Vacío o Inválido

**Paso 1**: Usuario borra el código
```
txtCodigoProducto: [vacío]
```

**Paso 2**: Presiona Enter

**Paso 3**: Sistema valida
```
if (string.IsNullOrEmpty(codigo))
    MessageBox: "Por favor, ingrese un código de producto."
    panelProducto.Visible = false
```

---

## 🔄 Flujo Completo de Entrada de Datos

```
┌─────────────────────────────────────────────────────┐
│                  INICIO                             │
│  FormularioDeInventario_Load ejecuta               │
│  panelProducto.Visible = false                      │
└──────────────┬──────────────────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────────────────┐
│ Usuario ingresa código en txtCodigoProducto        │
│ Ejemplo: "LAPTOP-001"                              │
└──────────────┬──────────────────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────────────────┐
│ Usuario presiona Enter                             │
│ txtCodigoProducto_KeyDown se ejecuta               │
└──────────────┬──────────────────────────────────────┘
               │
               ↓
        ┌──────────────────┐
        │ ¿Código válido?  │
        └────┬─────────┬───┘
             │         │
          SÍ │         │ NO
             ↓         ↓
        ┌────────┐  ┌──────────┐
        │Buscar  │  │Mostrar   │
        │en BD   │  │Mensaje   │
        └────┬───┘  │Ocultar   │
             │      │Panel     │
             ↓      └──────────┘
        ┌──────────────┐
        │ ¿Encontrado? │
        └────┬────┬───┘
           SÍ │    │ NO
             ↓    ↓
         ┌──────┐┌───────────┐
         │Cargar││MessageBox │
         │datos ││"No existe"│
         │al    ││Limpiar    │
         │panel ││panel      │
         └─┬────┘└───┬───────┘
           │         │
           ↓         │
        ┌─────────┐  │
        │Mostrar  │  │
        │panel    │  │
        │(visible)│  │
        └────┬────┘  │
             │       │
             └───┬───┘
                 ↓
         ┌──────────────────┐
         │Usuario modifica  │
         │campos de precio  │
         └────┬─────────────┘
              │
              ↓
      ┌─────────────────────┐
      │ txtPrecioCosto o    │
      │ txtPorcentajeGanancia
      │ TextChanged         │
      └────┬────────────────┘
           │
           ↓
    ┌──────────────────────┐
    │RecalcularPrecioVenta()
    │Aplica fórmula:       │
    │PV = PC + (PC * % ÷100)
    │Actualiza txtPrecioVenta
    └──────┬───────────────┘
           │
           ↓
    ┌──────────────────────┐
    │Interfaz actualizada  │
    │Usuario ve cambios    │
    │en tiempo real        │
    └──────────────────────┘
```

---

## 💡 Casos de Uso Comunes

### Caso 1: Agregar Nuevo Lote de Productos
```
1. Escribir código del producto
2. Presionar Enter
3. Ver datos del inventario actual
4. Cambiar % de ganancia si es necesario
5. Ver precio de venta recalculado automáticamente
6. Agregar cantidad en txtAgregar
7. Clic en "Agregar Cantidad a Inventario"
```

### Caso 2: Actualizar Precio por Cambio de Costo
```
1. Escribir código del producto
2. Presionar Enter
3. Modificar "Precio Costo" (proveedores aumentaron precios)
4. Ver automáticamente el "Precio Venta" actualizado
5. Guardar cambios
```

### Caso 3: Ajustar Margen de Ganancia
```
1. Escribir código del producto
2. Presionar Enter
3. Modificar "% Ganancia" (cambio de política de precios)
4. Ver automáticamente el "Precio Venta" actualizado
5. Guardar cambios
```

---

## 📊 Ejemplo de Cálculo Detallado

**Escenario**: Nuevo costo de laptop

```
Datos originales en BD:
  Precio Costo: $1000
  % Ganancia: 25%
  Precio Venta: $1250

Usuario recibe noticia: El distribuidor bajó precios a $900

Acciones:
  1. Ingresa código: LAPTOP-PREMIUM-001
  2. Presiona Enter
  3. Sistema carga datos
  4. Usuario modifica Precio Costo: 900

Cálculo automático:
  Fórmula: PV = PC + (PC × % ÷ 100)
  PV = 900 + (900 × 25 ÷ 100)
  PV = 900 + 225
  PV = 1125

Resultado en interfaz:
  Precio Costo: $900.00
  % Ganancia: 25
  Precio Venta: $1125.00 ← Actualizado automáticamente

Beneficio:
  - Antes: Ganancia de $250 por unidad
  - Ahora: Ganancia de $225 por unidad
  - Pero precio más competitivo
```

---

## ⚠️ Validaciones

| Validación | Comportamiento |
|---|---|
| Código vacío | ❌ Muestra mensaje de error |
| Código inválido | ❌ Muestra "Producto no encontrado" |
| Campo de precio inválido | ⚠️ No actualiza (ignora silenciosamente) |
| Producto inactivo (estado = 0) | ❌ Tratado como no encontrado |

---

## 🎯 Tips de Uso

✅ **Hacer**:
- Presionar Tab para ir al siguiente campo
- Usar números decimales con punto (100.50)
- Enter para buscar, no hacer clic manual

❌ **Evitar**:
- Escribir letras en campos de precio
- Usar porcentajes negativos (excepto si deseas descuentos)
- Buscar sin presionar Enter

---

**Última actualización**: Implementación completada ✅
