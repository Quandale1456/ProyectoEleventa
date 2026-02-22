# 📊 GUÍA DE INTEGRACIÓN RÁPIDA - MÓDULO DE PRODUCTOS

## 🎯 DÓNDE PEGAR CADA COMPONENTE

### 1️⃣ CLASE MODELO (YA CREADA)
**Archivo:** `ProyectoEleventa/Models/Producto.cs`

Contiene:
- Propiedades del producto
- Método `CalcularPrecioVenta()`
- Método `Validar()`

**Usar en:** Cualquier formulario que necesite manipular datos de productos

```csharp
using ProyectoEleventa.Models;

// Ejemplo de uso
Producto producto = new Producto 
{
    CodigoBarras = "ABC123",
    Nombre = "Arroz",
    PrecioCosto = 100,
    PorcentajeGanancia = 30
};

decimal precioCalculado = producto.CalcularPrecioVenta(); // 130
```

---

### 2️⃣ CAPA DE DATOS (YA MEJORADA)
**Archivo:** `ProyectoEleventa/Data/ProductoDAL.cs`

**Métodos disponibles:**

| Método | Parámetros | Retorna | Uso |
|--------|-----------|---------|-----|
| `CrearProducto` | código, nombre, costo, ganancia, precioVenta, existencia, depto | bool | Crear nuevo producto |
| `ActualizarProducto` | id, código, nombre, costo, ganancia, precioVenta, existencia, depto | bool | Editar producto |
| `EliminarProducto` | id | bool | Borrar producto (lógico) |
| `BuscarPorCodigo` | código | DataRow | Buscar por código exacto |
| `BuscarPorNombre` | nombre | DataTable | Buscar por nombre (LIKE) |
| `ObtenerPorId` | id | DataRow | Obtener un producto |
| `ObtenerTodos` | - | DataTable | Listar todos activos |
| `ObtenerExistencia` | id | decimal | Ver stock |
| `CodigoExiste` | código | bool | Validar duplicado |

**Importar siempre:**
```csharp
using ProyectoEleventa.Data;
using ProyectoEleventa.Models;
```

---

### 3️⃣ FORMULARIO PRINCIPAL (YA MEJORADO)
**Archivo:** `ProyectoEleventa/FormularioProductos.cs`

**Funcionalidades:**
✅ Crear producto nuevo
✅ Editar producto existente
✅ Eliminar producto
✅ Cálculo automático de precio
✅ Validaciones completas

**Eventos que disparan:**
- `textBoxPrecioCosto.TextChanged` → Recalcula precio
- `numericGanancia.ValueChanged` → Recalcula precio
- `btnGuardar.Click` → Guarda o actualiza

**Método clave para otros formularios:**
```csharp
// Cargar un producto para edición
FormularioProductos formulario = new FormularioProductos();
formulario.CargarProducto(idProducto);
formulario.ShowDialog();
```

---

## 🔄 FLUJOS DE TRABAJO

### CREAR PRODUCTO
```
Usuario → Botón "Nuevo" 
→ LimpiarFormulario()
→ Ingresa datos
→ Cambia Costo/Ganancia → Precio recalcula AUTOMÁTICAMENTE
→ Botón "Guardar"
→ ValidarFormulario()
→ ProductoDAL.CrearProducto()
→ BD actualizada
```

### EDITAR PRODUCTO  
```
Usuario → Botón "Modificar"
→ Selecciona producto
→ CargarProducto(id)
→ Formulario se llena
→ Edita campos
→ Precio se recalcula automáticamente
→ Botón "Actualizar"
→ ValidarFormulario()
→ ProductoDAL.ActualizarProducto()
→ BD actualizada
```

### ELIMINAR PRODUCTO
```
Usuario → Botón "Eliminar"
→ Selecciona producto
→ Confirma eliminación
→ ProductoDAL.EliminarProducto(id)
→ Estado = 0 en BD (no se borra realmente)
```

---

## 💻 CÓDIGO RÁPIDO PARA COPIAR Y PEGAR

### En un DataGridView mostrar todos los productos:
```csharp
private void CargarProductos()
{
    try
    {
        DataTable productos = ProductoDAL.ObtenerTodos();
        dataGridView1.DataSource = productos;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Buscar producto por código:
```csharp
private void BuscarProducto(string codigo)
{
    try
    {
        DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);
        if (producto != null)
        {
            MessageBox.Show($"Encontrado: {producto["nombre"]}");
        }
        else
        {
            MessageBox.Show("Producto no encontrado");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Buscar productos por nombre:
```csharp
private void BuscarPorNombre(string nombre)
{
    try
    {
        DataTable resultados = ProductoDAL.BuscarPorNombre(nombre);
        dataGridView1.DataSource = resultados;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Verificar si código ya existe:
```csharp
private void ValidarCodigoDuplicado()
{
    string codigo = textBoxCodigo.Text.Trim();
    
    if (ProductoDAL.CodigoExiste(codigo))
    {
        MessageBox.Show("Este código ya existe en la base de datos");
        textBoxCodigo.Focus();
    }
}
```

### Calcular precio de venta manualmente (si necesitas):
```csharp
private decimal CalcularPrecio(decimal costo, decimal porcentajeGanancia)
{
    if (costo <= 0) return 0;
    return costo + (costo * porcentajeGanancia / 100);
}

// Uso:
decimal precio = CalcularPrecio(100, 30); // Resultado: 130
```

---

## 📱 EVENTOS PARA CONECTAR

### En FormularioProductos.Designer.cs (ya hecho):
```csharp
// En el método InitializeComponent()
this.textBoxPrecioCosto.TextChanged += CalcularPrecioVenta_Changed;
this.numericGanancia.ValueChanged += CalcularPrecioVenta_Changed;
this.btnGuardar.Click += btnGuardar_Click;
this.btnCancelar.Click += btnCancelar_Click;
```

**Estos eventos YA ESTÁN implementados en el código actual.**

---

## 🧪 PRUEBAS RECOMENDADAS

**Prueba 1: Cálculo Automático**
- Ingresa costo: 100
- Cambiar ganancia: 30%
- Verificar que precio = 130 ✓

**Prueba 2: Código Duplicado**
- Crear producto con código "ABC"
- Intentar crear otro con código "ABC"
- Debe rechazar y mostrar error ✓

**Prueba 3: Validaciones**
- Intentar crear sin código → Error ✓
- Intentar crear con costo = 0 → Error ✓
- Intentar crear sin nombre → Error ✓

**Prueba 4: Edición**
- Crear un producto
- Cargar con CargarProducto(id)
- Cambiar datos
- Guardar y verificar en BD ✓

---

## ⚙️ CONFIGURACIÓN PREVIA

**Asegúrate de tener:**
1. Tabla `productos` en SQL Server ✓
2. Conexión en `DBConnection.cs` configurada ✓
3. Namespaces importados:
   ```csharp
   using ProyectoEleventa.Data;
   using ProyectoEleventa.Models;
   using System.Data;
   ```

---

## 🚀 PRÓXIMOS PASOS

1. **Probar creación de producto** → Ir a FormularioProductos
2. **Probar búsqueda** → Hacer clic en "Nuevo" e ingresar datos
3. **Probar cálculo** → Cambiar Costo/Ganancia, ver Precio cambiar automático
4. **Integrar en otros módulos** → Usar métodos de ProductoDAL
5. **Crear reportes** → Usar `ObtenerTodos()` y mostrar en DataGridView

---

## ❓ PREGUNTAS FRECUENTES

**P: ¿Cómo edito un producto desde otro formulario?**
R: Llama a `formulario.CargarProducto(idProducto)` donde `formulario` es instancia de `FormularioProductos`

**P: ¿Puedo usar ProductoDAL directamente sin FormularioProductos?**
R: Sí, todos los métodos son públicos y estáticos. Úsalos directamente.

**P: ¿El precio se calcula en BD o en la aplicación?**
R: Se calcula en la aplicación (C#) y se guarda ya calculado en BD.

**P: ¿Qué pasa si elimino un producto?**
R: No se borra realmente, solo cambia `estado = 0`. Los registros quedan en BD.

**P: ¿Puedo cambiar la fórmula de cálculo?**
R: Sí, edita `CalcularPrecioVenta()` en `Producto.cs` y `CalcularPrecioVenta_Changed()` en `FormularioProductos.cs`

---

**¡Sistema listo para usar! 🎉**
