# 📚 EJEMPLOS DE INTEGRACIÓN - MÓDULO DE PRODUCTOS

## Cómo usar ProductoDAL en otros formularios

---

## 1️⃣ MOSTRAR TODOS LOS PRODUCTOS EN UN DataGridView

### Código:
```csharp
private void CargarCatalogo()
{
    try
    {
        DataTable productos = ProductoDAL.ObtenerTodos();
        dataGridViewProductos.DataSource = productos;

        // Personalizar columnas (opcional)
        dataGridViewProductos.Columns["id_producto"].HeaderText = "ID";
        dataGridViewProductos.Columns["codigo_barras"].HeaderText = "Código";
        dataGridViewProductos.Columns["nombre"].HeaderText = "Nombre";
        dataGridViewProductos.Columns["precio_costo"].HeaderText = "Costo";
        dataGridViewProductos.Columns["precio_venta"].HeaderText = "Venta";
        dataGridViewProductos.Columns["existencia"].HeaderText = "Stock";

        dataGridViewProductos.AutoResizeColumns();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error al cargar catálogo: {ex.Message}");
    }
}
```

### Dónde usar:
- En el evento `Load` del formulario
- En un botón "Actualizar Catálogo"
- Después de crear/editar/eliminar un producto

---

## 2️⃣ BUSCAR PRODUCTO POR CÓDIGO (búsqueda rápida)

### Código:
```csharp
private void BuscarPorCodigo()
{
    try
    {
        string codigo = textBoxCodigo.Text.Trim();
        
        if (string.IsNullOrEmpty(codigo))
        {
            MessageBox.Show("Ingrese un código");
            return;
        }

        DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

        if (producto != null)
        {
            // Encontrado
            string nombre = producto["nombre"].ToString();
            decimal precio = (decimal)producto["precio_venta"];
            MessageBox.Show($"Producto: {nombre}\nPrecio: ${precio}");
        }
        else
        {
            // No encontrado
            MessageBox.Show("Producto no encontrado");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Uso típico:
- Venta de productos
- Búsqueda en punto de venta
- Validación de productos

---

## 3️⃣ BUSCAR PRODUCTOS POR NOMBRE (búsqueda general)

### Código:
```csharp
private void BuscarPorNombre(string nombre)
{
    try
    {
        if (string.IsNullOrEmpty(nombre))
        {
            dataGridViewBusqueda.DataSource = null;
            return;
        }

        DataTable resultados = ProductoDAL.BuscarPorNombre(nombre);
        dataGridViewBusqueda.DataSource = resultados;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}

// Conectar a evento TextChanged de TextBox
private void textBoxBuscar_TextChanged(object sender, EventArgs e)
{
    BuscarPorNombre(textBoxBuscar.Text.Trim());
}
```

### Usa:
- Búsqueda en tiempo real (como escribe)
- Filtros en catálogo de productos
- Autocompletado

---

## 4️⃣ OBTENER UN PRODUCTO POR ID

### Código:
```csharp
private void CargarProductoParaEditar(int idProducto)
{
    try
    {
        DataRow producto = ProductoDAL.ObtenerPorId(idProducto);

        if (producto != null)
        {
            // Llenar controles
            textBoxCodigo.Text = producto["codigo_barras"].ToString();
            textBoxNombre.Text = producto["nombre"].ToString();
            textBoxCosto.Text = producto["precio_costo"].ToString();
            numericGanancia.Value = (decimal)producto["porcentaje_ganancia"];
            textBoxPrecioVenta.Text = producto["precio_venta"].ToString();
            textBoxStock.Text = producto["existencia"].ToString();
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

### Uso:
- Cargar producto al hacer doble clic en DataGridView
- Edición de producto seleccionado
- Ver detalles de producto

---

## 5️⃣ CREAR UN NUEVO PRODUCTO

### Código:
```csharp
private void GuardarProductoNuevo()
{
    try
    {
        // Validaciones
        if (string.IsNullOrWhiteSpace(textBoxCodigo.Text))
        {
            MessageBox.Show("Código requerido");
            textBoxCodigo.Focus();
            return;
        }

        // Verificar código duplicado ANTES de crear
        if (ProductoDAL.CodigoExiste(textBoxCodigo.Text.Trim()))
        {
            MessageBox.Show("Este código ya existe en la base de datos", 
                "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBoxCodigo.Focus();
            return;
        }

        // Crear producto
        bool resultado = ProductoDAL.CrearProducto(
            codigo: textBoxCodigo.Text.Trim(),
            nombre: textBoxNombre.Text.Trim(),
            costo: decimal.Parse(textBoxCosto.Text),
            porcentajeGanancia: (decimal)numericGanancia.Value,
            precioVenta: decimal.Parse(textBoxPrecioVenta.Text),
            existencia: 0,
            departamentoId: 0
        );

        if (resultado)
        {
            MessageBox.Show("Producto creado exitosamente");
            LimpiarFormulario();
            CargarCatalogo(); // Actualizar lista
        }
        else
        {
            MessageBox.Show("Error al crear producto");
        }
    }
    catch (FormatException)
    {
        MessageBox.Show("Verifique los valores numéricos");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Validaciones incluidas:
- ✓ Código no duplicado
- ✓ Campos obligatorios
- ✓ Valores numéricos válidos

---

## 6️⃣ ACTUALIZAR UN PRODUCTO EXISTENTE

### Código:
```csharp
private void ActualizarProductoActual(int idProducto)
{
    try
    {
        // El código NO se puede cambiar (está en BD)
        string codigoActual = textBoxCodigo.Text;

        bool resultado = ProductoDAL.ActualizarProducto(
            idProducto: idProducto,
            codigo: codigoActual,
            nombre: textBoxNombre.Text.Trim(),
            costo: decimal.Parse(textBoxCosto.Text),
            porcentajeGanancia: (decimal)numericGanancia.Value,
            precioVenta: decimal.Parse(textBoxPrecioVenta.Text),
            existencia: decimal.Parse(textBoxStock.Text),
            departamentoId: 0
        );

        if (resultado)
        {
            MessageBox.Show("Producto actualizado correctamente");
            CargarCatalogo();
        }
        else
        {
            MessageBox.Show("Error al actualizar");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

---

## 7️⃣ ELIMINAR UN PRODUCTO

### Código:
```csharp
private void EliminarProducto(int idProducto, string nombreProducto)
{
    // Confirmar eliminación
    DialogResult respuesta = MessageBox.Show(
        $"¿Eliminar producto: {nombreProducto}?\n\nEsta acción no se puede deshacer.",
        "Confirmar eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

    if (respuesta == DialogResult.Yes)
    {
        try
        {
            bool resultado = ProductoDAL.EliminarProducto(idProducto);

            if (resultado)
            {
                MessageBox.Show("Producto eliminado correctamente");
                CargarCatalogo(); // Actualizar lista
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }
}

// Uso típico: evento Click de botón Eliminar en DataGridView
private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.ColumnIndex == columnaBorrar.Index && e.RowIndex >= 0)
    {
        int idProducto = (int)dataGridViewProductos.Rows[e.RowIndex].Cells["id_producto"].Value;
        string nombre = dataGridViewProductos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
        EliminarProducto(idProducto, nombre);
    }
}
```

---

## 8️⃣ VALIDAR CÓDIGO DUPLICADO EN TIEMPO REAL

### Código:
```csharp
private void textBoxCodigo_TextChanged(object sender, EventArgs e)
{
    string codigo = textBoxCodigo.Text.Trim();

    if (string.IsNullOrEmpty(codigo))
    {
        labelValidacion.Text = "";
        return;
    }

    if (ProductoDAL.CodigoExiste(codigo))
    {
        labelValidacion.Text = "⚠ Código ya existe";
        labelValidacion.ForeColor = Color.Red;
        buttonGuardar.Enabled = false;
    }
    else
    {
        labelValidacion.Text = "✓ Código disponible";
        labelValidacion.ForeColor = Color.Green;
        buttonGuardar.Enabled = true;
    }
}
```

---

## 9️⃣ VERIFICAR EXISTENCIA EN VENTAS

### Código:
```csharp
private void AgregarAlCarrito(string codigo, decimal cantidad)
{
    try
    {
        DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

        if (producto == null)
        {
            MessageBox.Show("Producto no encontrado");
            return;
        }

        decimal existencia = (decimal)producto["existencia"];
        decimal precioVenta = (decimal)producto["precio_venta"];
        string nombre = producto["nombre"].ToString();

        // Validar existencia
        if (existencia <= 0)
        {
            MessageBox.Show("Producto sin existencia", 
                "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cantidad > existencia)
        {
            MessageBox.Show($"Stock insuficiente.\nDisponible: {existencia}", 
                "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Agregar al carrito
        dataGridViewCarrito.Rows.Add(
            codigo,
            nombre,
            cantidad,
            precioVenta,
            cantidad * precioVenta
        );
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

---

## 🔟 REPORTE DE PRODUCTOS CON MÁRGENES

### Código:
```csharp
private void GenerarReporteProductos()
{
    try
    {
        DataTable productos = ProductoDAL.ObtenerTodos();

        // Agregar columna de margen calculado
        productos.Columns.Add("Margen", typeof(decimal));
        productos.Columns.Add("Margen%", typeof(decimal));

        decimal totalCosto = 0;
        decimal totalVenta = 0;

        foreach (DataRow row in productos.Rows)
        {
            decimal costo = (decimal)row["precio_costo"];
            decimal venta = (decimal)row["precio_venta"];
            decimal margen = venta - costo;
            decimal margenPorcentaje = costo > 0 ? (margen / costo) * 100 : 0;

            row["Margen"] = margen;
            row["Margen%"] = margenPorcentaje;

            totalCosto += costo;
            totalVenta += venta;
        }

        dataGridViewReporte.DataSource = productos;

        // Mostrar totales
        labelTotalCosto.Text = $"Costo Total: ${totalCosto:N2}";
        labelTotalVenta.Text = $"Venta Total: ${totalVenta:N2}";
        labelTotalMargen.Text = $"Margen Total: ${(totalVenta - totalCosto):N2}";
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

---

## 1️⃣1️⃣ USAR FORMULARIO PRINCIPAL PARA EDITAR

### Desde otro formulario:
```csharp
// Opción 1: Como formulario modal
private void AbrirFormularioProductos()
{
    FormularioProductos formulario = new FormularioProductos();
    formulario.ShowDialog();
}

// Opción 2: Cargar producto específico
private void EditarProductoSeleccionado(int idProducto)
{
    FormularioProductos formulario = new FormularioProductos();
    formulario.CargarProducto(idProducto);
    formulario.ShowDialog();
}

// Opción 3: Desde doble clic en DataGridView
private void dataGridViewProductos_DoubleClick(object sender, EventArgs e)
{
    if (dataGridViewProductos.SelectedRows.Count > 0)
    {
        int idProducto = (int)dataGridViewProductos.SelectedRows[0].Cells["id_producto"].Value;
        FormularioProductos formulario = new FormularioProductos();
        formulario.CargarProducto(idProducto);
        formulario.ShowDialog();
    }
}
```

---

## ✨ CHECKLIST DE IMPLEMENTACIÓN

- [ ] Importar `using ProyectoEleventa.Data;`
- [ ] Importar `using ProyectoEleventa.Models;`
- [ ] Importar `using System.Data;`
- [ ] Probar búsqueda por código
- [ ] Probar búsqueda por nombre
- [ ] Probar crear producto
- [ ] Probar validación de código duplicado
- [ ] Probar edición de producto
- [ ] Probar eliminación
- [ ] Probar cálculo automático de precio
- [ ] Cargar en DataGridView

---

**¡Listo para integrar en tus formularios! 🚀**
