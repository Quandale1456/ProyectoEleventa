# ✅ FORMULARIO AJUSTES INV - Modificador de Productos con Ajuste de Inventario

## 🎯 Funcionalidad Implementada

Se ha implementado el formulario `AjustesInv` como un **modificador de productos** que también permite **ajustar el inventario** sumando o restando cantidades.

---

## 📋 Características Principales

### 1. ✅ Búsqueda de Productos
- Escribe un código de producto
- Presiona **Enter**
- Se cargan automáticamente los datos del producto

### 2. ✅ Visualización de Datos
- Descripción del producto
- Stock actual
- Precio de costo
- Porcentaje de ganancia
- Precio de venta (se calcula automáticamente)

### 3. ✅ Modificación de Precios
- Cambiar precio de costo
- Cambiar porcentaje de ganancia
- El precio de venta se recalcula automáticamente

### 4. ✅ **AJUSTE DE INVENTARIO** (Lo Nuevo)
- **txtMasOMenos**: Ingresa cantidad positiva o negativa
  - Número positivo (+10) = suma al inventario
  - Número negativo (-5) = resta del inventario
- **txtMotivo**: Explica por qué se hace el ajuste
- **Botón "Realizar ajuste"**: Aplica el cambio

---

## 🎯 Cómo Funciona

### Flujo de Uso

```
1. BÚSQUEDA
   Usuario escribe código de producto
        ↓
   Presiona Enter
        ↓
   Se carga el producto con todos sus datos
        ↓
   Panel se habilita para edición

2. EDICIÓN DE PRECIOS (Opcional)
   Usuario puede cambiar:
   - Precio de costo
   - Porcentaje de ganancia
   - Precio de venta se recalcula automáticamente

3. AJUSTE DE INVENTARIO
   Usuario ingresa cantidad en txtMasOMenos:
   - Cantidad positiva: suma al stock
   - Cantidad negativa: resta del stock
        ↓
   Usuario escribe motivo (opcional pero recomendado)
        ↓
   Hace clic en "Realizar ajuste"
        ↓
   Sistema valida:
   ├─ ¿Hay cantidad a ajustar?
   ├─ ¿Es un número válido?
   ├─ ¿El nuevo stock será negativo?
   └─ Muestra confirmación
        ↓
   Si el usuario confirma (Sí):
   ├─ Se actualiza en la BD
   ├─ Se actualiza visualmente
   ├─ Se muestra confirmación
   └─ Campos se limpian para nuevo ajuste
```

---

## 💻 Código Implementado

### Variables Privadas

```csharp
private int _idProductoActual = -1;           // ID del producto actual
private string _codigoProductoActual = "";    // Código del producto
private bool _actualizando = false;           // Bandera para evitar recursión
```

### Método de Búsqueda: `BuscarProducto()`

```csharp
private void BuscarProducto(string codigo)
{
    // 1. Busca en BD usando ProductoDAL
    DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);
    
    if (producto != null)
    {
        // 2. Guarda el ID
        _idProductoActual = Convert.ToInt32(producto["id_producto"]);
        
        // 3. Carga los datos en los controles
        txtDescripcion.Text = producto["nombre"].ToString();
        txtStock.Text = Convert.ToDecimal(producto["existencia"]).ToString("F2");
        // ... carga otros datos
        
        // 4. Habilita el panel
        panelProducto.Enabled = true;
    }
    else
    {
        // Producto no encontrado
        panelProducto.Enabled = false;
    }
}
```

### Método de Ajuste: `btnRealizarAjuste_Click()`

```csharp
private void btnRealizarAjuste_Click(object sender, EventArgs e)
{
    // 1. Valida que haya producto
    if (_idProductoActual == -1) return;
    
    // 2. Obtiene la cantidad a ajustar
    decimal cantidadAjuste = decimal.Parse(txtMasOMenos.Text);
    
    // 3. Calcula el nuevo stock
    decimal nuevoStock = stockActual + cantidadAjuste;
    
    // 4. Valida que no sea negativo
    if (nuevoStock < 0) 
        MessageBox.Show("Stock no puede ser negativo");
    
    // 5. Muestra confirmación
    // 6. Si usuario confirma:
    //    - Actualiza en BD
    //    - Actualiza visualmente
    //    - Limpia campos
}
```

### Método de Cálculo: `RecalcularPrecioVenta()`

```csharp
private void RecalcularPrecioVenta(object sender, EventArgs e)
{
    // Fórmula: PrecioVenta = PrecioCosto + (PrecioCosto × % ÷ 100)
    decimal precioVenta = precioCosto + (precioCosto * porcentajeGanancia / 100);
    txtPrecioVenta.Text = precioVenta.ToString("F2");
}
```

---

## 🧪 Ejemplo Práctico: Ajustar Inventario

### Escenario: Producto dañado, falta cantidad

**Paso 1: Busca el producto**
```
txtCodigoProducto: LAPTOP-001
Presiona: Enter
```

**Paso 2: Se cargan los datos**
```
✓ Descripción: Laptop Dell XPS 15
✓ Stock: 10 unidades
✓ Precio Costo: $800
✓ Porcentaje: 20%
✓ Precio Venta: $960
```

**Paso 3: Ajusta el inventario**
```
txtMasOMenos: -2  (falta 2 unidades por daño)
txtMotivo: Productos dañados durante traslado
```

**Paso 4: Hace clic en "Realizar ajuste"**

**Paso 5: Sistema valida y muestra confirmación**
```
¿Desea ajustar el inventario de 'Laptop Dell XPS 15'?

Stock Actual: 10
Ajuste: -2
Nuevo Stock: 8
Motivo: Productos dañados durante traslado

[Sí] [No]
```

**Paso 6: Usuario hace clic en "Sí"**

**Paso 7: Se realiza el ajuste**
```
✅ Ajuste realizado exitosamente.
Nuevo stock: 8

- Se actualiza en BD
- txtStock: 10 → 8
- txtNuevaCantidad: 8
- Campos se limpian
```

---

## 📊 Validaciones Implementadas

### Validación 1: Código de Producto
```
¿Está vacío?
  ❌ Sí → Muestra error
  ✅ No → Continúa
```

### Validación 2: Cantidad a Ajustar
```
¿Está vacía?
  ❌ Sí → Muestra error
  ✅ No → Continúa

¿Es número válido?
  ❌ No → Muestra error
  ✅ Sí → Continúa
```

### Validación 3: Stock Negativo
```
¿Nuevo Stock < 0?
  ❌ Sí → Muestra error, no permite ajuste
  ✅ No → Continúa con confirmación
```

### Validación 4: Confirmación del Usuario
```
¿Usuario confirma (Sí)?
  ❌ No → Cancela el ajuste
  ✅ Sí → Actualiza en BD
```

---

## 🎯 Casos de Uso

### Caso 1: Agregar Inventario (Cantidad Positiva)
```
Stock Actual: 5 unidades
txtMasOMenos: +10
Nuevo Stock: 5 + 10 = 15 ✅
```

### Caso 2: Restar Inventario (Cantidad Negativa)
```
Stock Actual: 20 unidades
txtMasOMenos: -3
Nuevo Stock: 20 - 3 = 17 ✅
```

### Caso 3: Prevención de Stock Negativo
```
Stock Actual: 5 unidades
txtMasOMenos: -10
Nuevo Stock: 5 - 10 = -5 ❌
Error: "El ajuste haría que el stock sea negativo"
```

---

## 🔧 Campos del Formulario

| Campo | Tipo | Propósito |
|---|---|---|
| **txtCodigoProducto** | TextBox | Entrada de código para buscar |
| **txtDescripcion** | TextBox (Read-only) | Nombre del producto |
| **txtStock** | TextBox (Read-only) | Stock actual |
| **txtPrecioCosto** | TextBox | Precio de compra (editable) |
| **txtPorcentajeDeGanancia** | TextBox | % de margen (editable) |
| **txtPrecioVenta** | TextBox (Read-only) | Se calcula automáticamente |
| **txtMasOMenos** | TextBox | Cantidad a ajustar (+/-) |
| **txtMotivo** | TextBox | Razón del ajuste |
| **txtNuevaCantidad** | TextBox (Read-only) | Stock resultante |
| **btnRealizarAjuste** | Button | Ejecuta el ajuste |

---

## 🔐 Seguridad

✅ **Validación de Entrada**: Valida que sean números válidos
✅ **Prevención de Negativo**: No permite stock negativo
✅ **Confirmación**: Pide confirmación antes de aplicar
✅ **Parámetros SQL**: Usa ProductoDAL (parameterizado)
✅ **Manejo de Errores**: Try-catch en puntos críticos

---

## 💡 Flujo Resumido

```
Búsqueda (Enter) → Valida → Carga Datos → Habilita Panel
                                              ↓
                                    Usuario Edita Precios (Opcional)
                                    Precio se Recalcula
                                              ↓
                                    Usuario Ingresa Ajuste
                                    (cantidad en txtMasOMenos)
                                              ↓
                                    Clic en "Realizar ajuste"
                                              ↓
                                    Validación Completa
                                              ↓
                                    Confirmación del Usuario
                                              ↓
                                    Actualización en BD
                                    Actualización Visual
                                    Limpieza de Campos
```

---

## ✨ Características Especiales

1. **Enter para Buscar**: No necesitas botón, solo presiona Enter en el código
2. **Cálculo Automático**: El precio se recalcula sin hacer nada
3. **Confirmación**: Muestra qué va a cambiar antes de aplicar
4. **Cantidad Flexible**: Positivo o negativo en un solo campo
5. **Registro de Motivo**: Documenta por qué se hace el ajuste
6. **Validación Integral**: Verifica todo antes de actualizar

---

## 📝 Casos de Ajuste Real

### Compra de Nuevo Stock
```
Stock Actual: 10
Compré: 25 unidades nuevas
txtMasOMenos: +25
Motivo: Compra a proveedor XYZ
Nuevo Stock: 35
```

### Devolución de Cliente
```
Stock Actual: 50
Cliente devolvió: 3 unidades
txtMasOMenos: +3
Motivo: Devolución de cliente
Nuevo Stock: 53
```

### Productos Dañados
```
Stock Actual: 100
Productos dañados: 5 unidades
txtMasOMenos: -5
Motivo: Productos dañados en almacén
Nuevo Stock: 95
```

### Ajuste por Inventario
```
Stock en Sistema: 30
Stock Físico: 28
Diferencia: -2
txtMasOMenos: -2
Motivo: Ajuste por diferencia en conteo físico
Nuevo Stock: 28
```

---

## 🎉 Conclusión

El formulario `AjustesInv` ahora es un **modificador completo de productos** que permite:

✅ Buscar productos por código
✅ Ver y editar precios
✅ Ajustar el inventario (+/-)
✅ Validar antes de aplicar
✅ Confirmar cambios
✅ Registrar motivos

**¡Completamente funcional!** 🚀

---

**Implementación: AjustesInv Completo**
**Status: COMPLETADO** ✅
**Build: EXITOSO** ✅

