# Documentación Técnica - Detalles de Implementación

## 📝 Código Fuente Completo

### FormularioDeInventario.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FormularioDeInventario : Form
    {
        public FormularioDeInventario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se dispara cuando el formulario se carga en memoria.
        /// Inicializa todos los eventos y el estado visual del formulario.
        /// </summary>
        private void FormularioDeInventario_Load(object sender, EventArgs e)
        {
            // Ocultar el panel al cargar el formulario
            panelProducto.Visible = false;

            // Suscribir al evento KeyDown del txtCodigoProducto
            txtCodigoProducto.KeyDown += new KeyEventHandler(this.txtCodigoProducto_KeyDown);

            // Suscribir a los eventos TextChanged para recalcular precio
            txtPrecioCosto.TextChanged += new EventHandler(this.RecalcularPrecioVenta);
            txtPorcentajeDeGanancia.TextChanged += new EventHandler(this.RecalcularPrecioVenta);

            // Hacer los campos de precio de venta y ganancia solo lectura si es necesario
            txtPrecioVenta.ReadOnly = false;
        }

        /// <summary>
        /// Evento KeyDown para detectar cuando se presiona Enter en txtCodigoProducto.
        /// Permite buscar el producto presionando Enter sin necesidad de botón.
        /// </summary>
        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true; // Prevenir el sonido del beep
                
                string codigo = txtCodigoProducto.Text.Trim();
                
                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Por favor, ingrese un código de producto.", "Validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    panelProducto.Visible = false;
                    return;
                }

                // Buscar el producto
                BuscarProducto(codigo);
            }
        }

        /// <summary>
        /// Busca un producto en la base de datos por su código de barras.
        /// Si lo encuentra, carga los datos en los controles y muestra el panel.
        /// Si no lo encuentra, oculta el panel y muestra un mensaje.
        /// </summary>
        /// <param name="codigo">Código de barras del producto a buscar</param>
        private void BuscarProducto(string codigo)
        {
            try
            {
                // Usar el DAL existente para buscar
                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                if (producto != null)
                {
                    // Cargar los datos en los controles
                    txtDescripcion.Text = producto["nombre"].ToString();
                    txtStock.Text = producto["existencia"].ToString();
                    txtPrecioCosto.Text = Convert.ToDecimal(producto["precio_compra"]).ToString("F2");
                    txtPorcentajeDeGanancia.Text = Convert.ToDecimal(producto["porcentaje_ganancia"]).ToString("F2");
                    txtPrecioVenta.Text = Convert.ToDecimal(producto["precio_venta"]).ToString("F2");
                    txtAgregar.Clear();

                    // Mostrar el panel
                    panelProducto.Visible = true;
                }
                else
                {
                    // Producto no encontrado
                    MessageBox.Show("El producto con código '" + codigo + "' no fue encontrado en la base de datos.", 
                        "Producto no existe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Limpiar los campos
                    LimpiarPanel();
                    panelProducto.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelProducto.Visible = false;
            }
        }

        /// <summary>
        /// Recalcula el precio de venta basado en precio de costo y porcentaje de ganancia.
        /// Se ejecuta automáticamente cada vez que cambia txtPrecioCosto o txtPorcentajeDeGanancia.
        /// 
        /// Fórmula: PrecioVenta = PrecioCosto + (PrecioCosto * PorcentajeGanancia / 100)
        /// </summary>
        private void RecalcularPrecioVenta(object sender, EventArgs e)
        {
            try
            {
                // Validar que tengamos valores válidos
                if (decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) &&
                    decimal.TryParse(txtPorcentajeDeGanancia.Text, out decimal porcentajeGanancia))
                {
                    // Aplicar la fórmula
                    decimal precioVenta = precioCosto + (precioCosto * porcentajeGanancia / 100);
                    
                    // Actualizar el campo de precio venta sin disparar el evento recursivamente
                    txtPrecioVenta.Text = precioVenta.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                // Si hay error, simplemente no actualizar
                System.Diagnostics.Debug.WriteLine("Error al recalcular precio: " + ex.Message);
            }
        }

        /// <summary>
        /// Limpia todos los campos del panel.
        /// Se utiliza cuando no se encuentra un producto o se necesita resetear la interfaz.
        /// </summary>
        private void LimpiarPanel()
        {
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioCosto.Clear();
            txtPorcentajeDeGanancia.Clear();
            txtPrecioVenta.Clear();
            txtAgregar.Clear();
        }
    }
}
```

---

## 🔌 Integración con ProductoDAL

### Método Utilizado: `BuscarPorCodigo`

```csharp
public static DataRow BuscarPorCodigo(string codigo)
{
    string query = @"
        SELECT id_producto, codigo_barras, nombre, precio_compra, 
               porcentaje_ganancia, precio_venta, existencia, departamento
        FROM productos
        WHERE codigo_barras = @codigo AND estado = 1";

    SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@codigo", codigo)
    };

    DataTable dt = DBConnection.ExecuteQuery(query, parameters);
    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
}
```

### Características de Seguridad

✅ **Parámetro Nombrado**: `@codigo`
- Evita inyección SQL
- Automáticamente escapea caracteres especiales

✅ **Filtro de Estado**: `AND estado = 1`
- Solo retorna productos activos
- Previene acceso a productos eliminados

✅ **Try-Catch en BuscarProducto()**
- Captura excepciones de conexión
- Muestra mensajes al usuario

---

## 🎯 Arquitectura de Eventos

### 1. Form Load Chain
```
FormularioDeInventario aparece
        ↓
Windows.Forms.Form_Load evento
        ↓
FormularioDeInventario_Load() ejecuta
        ↓
├─ panelProducto.Visible = false
├─ Suscribe txtCodigoProducto.KeyDown
├─ Suscribe txtPrecioCosto.TextChanged
└─ Suscribe txtPorcentajeDeGanancia.TextChanged
```

### 2. Búsqueda Chain
```
Usuario presiona Enter en txtCodigoProducto
        ↓
txtCodigoProducto_KeyDown(e) dispara
        ↓
e.KeyCode == Keys.Return ?
        ├─ SÍ → BuscarProducto(codigo)
        │        ├─ ProductoDAL.BuscarPorCodigo()
        │        │  └─ DBConnection.ExecuteQuery()
        │        ├─ Cargar datos en controles
        │        └─ panelProducto.Visible = true
        │
        └─ NO → No hacer nada
```

### 3. Cálculo Chain
```
Usuario escribe en txtPrecioCosto o txtPorcentajeDeGanancia
        ↓
TextChanged evento dispara
        ↓
RecalcularPrecioVenta() ejecuta
        ↓
decimal.TryParse() ambos campos
        ├─ Válidos → Aplicar fórmula
        │            └─ txtPrecioVenta.Text = resultado
        │
        └─ Inválidos → Ignorar (catch silencioso)
```

---

## 🔐 Manejo de Errores

### Validación de Entrada

```csharp
// 1. Validar código no vacío
if (string.IsNullOrEmpty(codigo))
{
    MessageBox.Show("Por favor, ingrese un código de producto.");
    return;
}

// 2. Validar formato numérico (precio)
if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
{
    // No actualizar, valor inválido
    return;
}
```

### Manejo de Excepciones

```csharp
try
{
    // Lógica principal
    DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);
}
catch (Exception ex)
{
    // Mostrar error al usuario
    MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error");
    // Resetear interfaz
    panelProducto.Visible = false;
}
```

---

## 📊 Mapeo de Controles ↔ Campos BD

| Control WinForms | Campo BD | Tipo | Formato |
|---|---|---|---|
| `txtCodigoProducto` | `codigo_barras` | NVARCHAR | - |
| `txtDescripcion` | `nombre` | NVARCHAR | - |
| `txtStock` | `existencia` | DECIMAL | Número entero |
| `txtPrecioCosto` | `precio_compra` | DECIMAL | 2 decimales |
| `txtPorcentajeDeGanancia` | `porcentaje_ganancia` | DECIMAL | 2 decimales |
| `txtPrecioVenta` | `precio_venta` | DECIMAL | 2 decimales |
| `txtAgregar` | - | - | Entrada del usuario |

---

## 🧮 Fórmula Matemática

### Cálculo de Precio de Venta

```
PrecioVenta = PrecioCosto + (PrecioCosto × PorcentajeGanancia ÷ 100)

Equivalente:
PrecioVenta = PrecioCosto × (1 + PorcentajeGanancia ÷ 100)
```

### Ejemplos

**Ejemplo 1**: Margen conservador
```
PrecioCosto = $100
PorcentajeGanancia = 15%
PrecioVenta = 100 + (100 × 15 ÷ 100)
PrecioVenta = 100 + 15
PrecioVenta = $115
```

**Ejemplo 2**: Margen alto
```
PrecioCosto = $50
PorcentajeGanancia = 100%
PrecioVenta = 50 + (50 × 100 ÷ 100)
PrecioVenta = 50 + 50
PrecioVenta = $100
```

**Ejemplo 3**: Margen muy bajo
```
PrecioCosto = $1000
PorcentajeGanancia = 5%
PrecioVenta = 1000 + (1000 × 5 ÷ 100)
PrecioVenta = 1000 + 50
PrecioVenta = $1050
```

---

## ⚙️ Componentes Utilizados

### Namespaces Requeridos
```csharp
using System;                              // Tipo base
using System.Collections.Generic;          // Colecciones
using System.ComponentModel;               // Componentes
using System.Data;                         // DataTable, DataRow
using System.Drawing;                      // Colores, Fonts
using System.Linq;                         // LINQ
using System.Text;                         // StringBuilder
using System.Threading.Tasks;              // Async
using System.Windows.Forms;                // Controles WinForms
using ProyectoEleventa.Data;              // ← IMPORTANTE: ProductoDAL
```

### Clases Utilizadas
- `ProductoDAL` - Data Access Layer
- `DBConnection` - Gestor de conexiones
- `MessageBox` - Diálogos
- `DataRow` - Fila de datos
- `KeyEventArgs` - Evento de teclado

---

## 🚀 Optimizaciones

### 1. Lazy Loading
Los datos se cargan solo cuando el usuario busca, no al iniciar el formulario.

### 2. SQL Parameterizado
Previene inyección SQL y mejora seguridad.

### 3. Try-Parse
Valida entradas numéricas sin excepciones costosas.

### 4. Early Return
Termina ejecución tempranamente si validaciones fallan.

```csharp
if (string.IsNullOrEmpty(codigo))
{
    return; // ← Early return, no continúa innecesariamente
}
```

---

## 📋 Checklist de Verificación

- ✅ Evento `FormularioDeInventario_Load` implementado
- ✅ Evento `txtCodigoProducto_KeyDown` implementado
- ✅ Método `BuscarProducto` implementado
- ✅ Método `RecalcularPrecioVenta` implementado
- ✅ Método `LimpiarPanel` implementado
- ✅ Suscripción de eventos en Load
- ✅ Manejo de errores con try-catch
- ✅ Validación de entrada de usuario
- ✅ Formato de decimales (2 posiciones)
- ✅ Panel se oculta/muestra correctamente
- ✅ Compilación sin errores
- ✅ Usando ProductoDAL existente
- ✅ SQL parameterizado
- ✅ Mensajes de usuario apropiados

---

## 🔗 Relaciones de Dependencia

```
FormularioDeInventario.cs
    ├─ System.Windows.Forms
    │   ├─ TextBox (txtCodigoProducto, etc.)
    │   ├─ Panel (panelProducto)
    │   ├─ MessageBox
    │   └─ Keys, KeyEventArgs
    │
    ├─ System.Data
    │   ├─ DataRow
    │   └─ DataTable
    │
    └─ ProyectoEleventa.Data
        └─ ProductoDAL
            └─ DBConnection
                └─ SqlConnection (SQL Server)
```

---

## 📈 Complejidad Computacional

| Operación | Complejidad | Notas |
|---|---|---|
| Búsqueda de producto | O(log n) | Índice en `codigo_barras` |
| Recálculo de precio | O(1) | Operación matemática simple |
| Carga de controles | O(1) | Número fijo de campos |
| Validación de entrada | O(1) | String.IsNullOrEmpty |
| Parsing decimal | O(n) | n = longitud de string |

**Conclusión**: La solución es muy eficiente, sin bucles complejos.

---

**Documentación técnica completada** ✅
