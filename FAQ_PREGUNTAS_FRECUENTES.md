# Preguntas Frecuentes (FAQ)

## ❓ Preguntas sobre Funcionalidad

### P1: ¿Cómo busco un producto?
**R**: Escribe el código de barras en `txtCodigoProducto` y presiona **Enter**. El sistema automáticamente buscará en la base de datos.

---

### P2: ¿Qué pasa si el código no existe?
**R**: Aparecerá un mensaje diciendo "El producto con código 'XXX' no fue encontrado en la base de datos" y el panel se ocultará.

---

### P3: ¿El panel está siempre visible?
**R**: No. El panel comienza **oculto** al cargar el formulario y solo se muestra cuando encuentras un producto válido.

---

### P4: ¿Puedo modificar el código después de buscarlo?
**R**: Sí. Después de buscar un producto puedes cambiar el código y presionar Enter nuevamente para buscar otro producto.

---

### P5: ¿Es obligatorio presionar Enter?
**R**: Sí, es el método para disparar la búsqueda. No hay botón de búsqueda (puedes agregar uno si lo deseas).

---

## ❓ Preguntas sobre Cálculos

### P6: ¿Cómo se calcula el precio de venta?
**R**: Usa la fórmula:
```
PrecioVenta = PrecioCosto + (PrecioCosto × PorcentajeGanancia ÷ 100)
```
Ejemplo: Costo $100, Ganancia 30% → Venta = 100 + 30 = **$130**

---

### P7: ¿Cuándo se recalcula el precio?
**R**: Automáticamente cada vez que cambias:
- Precio de Costo, O
- Porcentaje de Ganancia

---

### P8: ¿Puedo editar directamente el Precio de Venta?
**R**: Sí, el campo está editable. Pero se sobrescribirá si cambias el Costo o la Ganancia.

---

### P9: ¿Qué pasa si escribo letras en un campo de precio?
**R**: El sistema las ignora. Solo procesa valores numéricos válidos.

---

### P10: ¿Puedo usar decimales?
**R**: Sí. Puedes usar números como 100.50 o 99.99. El formato se mantiene a 2 decimales.

---

## ❓ Preguntas sobre Base de Datos

### P11: ¿De dónde obtiene los datos?
**R**: De la tabla `productos` en SQL Server. Específicamente estos campos:
- `codigo_barras` - Identificador único
- `nombre` - Descripción del producto
- `existencia` - Stock actual
- `precio_compra` - Costo
- `porcentaje_ganancia` - Margen
- `precio_venta` - Precio final

---

### P12: ¿Qué pasa con productos eliminados?
**R**: El sistema filtra automáticamente productos con `estado = 0`. No aparecerán en búsquedas.

---

### P13: ¿Es segura la búsqueda contra inyección SQL?
**R**: Sí, totalmente. Usa **parámetros SQL** (`@codigo`) que escapan automáticamente caracteres especiales.

---

### P14: ¿Necesito un usuario/contraseña para la BD?
**R**: Depende. La configuración actual usa `Integrated Security = true` (autenticación de Windows).
En `DBConnection.cs` puedes cambiarla si necesitas SQL Authentication.

---

### P15: ¿Dónde está la cadena de conexión?
**R**: En `ProyectoEleventa\Data\DBConnection.cs`, línea 14:
```csharp
private static readonly string _connectionString =
    @"Server=DESKTOP-6QV8JQ9\SQLEXPRESS;Database=sistema_ventas;Integrated Security=true;";
```

---

## ❓ Preguntas sobre Errores

### P16: ¿Qué hago si aparece "Error al buscar el producto"?
**R**: Posibles causas:
1. **Conexión a BD cerrada** - Verifica que SQL Server esté corriendo
2. **Tabla no existe** - Verifica la tabla `productos`
3. **Campos mal nombrados** - Verifica los nombres en `ProductoDAL.cs`

---

### P17: ¿Por qué el panel no aparece?
**R**: Posibles razones:
1. El código no existe en la BD
2. El producto existe pero con estado = 0
3. Hay un error de conexión

**Solución**: Verifica el mensaje de error que aparece.

---

### P18: El recálculo de precio no funciona
**R**: Verifica que:
1. Ambos campos (Costo y Ganancia) tengan números válidos
2. No hay caracteres no numéricos
3. El campo de Precio Venta no está en modo solo lectura

---

### P19: ¿Qué significan los mensajes de error?
**R**:
- "Por favor, ingrese un código de producto" - Escribiste vacío
- "no fue encontrado en la base de datos" - Código no existe
- "Error al buscar el producto: ..." - Problema técnico en BD

---

### P20: ¿Cómo reporto un bug?
**R**: Anota:
1. El código que buscaste
2. El mensaje de error exacto
3. Qué campo modificaste (si corresponde)
4. Los valores que escribiste

---

## ❓ Preguntas sobre Personalización

### P21: ¿Puedo agregar un botón de búsqueda?
**R**: Sí. Agrega un Button y en su evento Click llama:
```csharp
private void btnBuscar_Click(object sender, EventArgs e)
{
    BuscarProducto(txtCodigoProducto.Text);
}
```

---

### P22: ¿Puedo cambiar el formato de decimales?
**R**: Sí. En el método `BuscarProducto`, cambia:
```csharp
// De esto:
.ToString("F2")  // 2 decimales

// A esto:
.ToString("F3")  // 3 decimales
.ToString("C")   // Formato moneda
```

---

### P23: ¿Puedo ocultar el campo de Precio de Venta?
**R**: Sí. En el diseñador:
1. Selecciona `txtPrecioVenta`
2. En Propiedades → `Visible = false`

---

### P24: ¿Puedo hacer el Precio de Venta solo lectura?
**R**: Sí. En `FormularioDeInventario_Load`:
```csharp
txtPrecioVenta.ReadOnly = true;
```

---

### P25: ¿Puedo cambiar la tabla de donde busca?
**R**: Sí. Modifica `ProductoDAL.BuscarPorCodigo()` en `ProyectoEleventa\Data\ProductoDAL.cs`.

---

## ❓ Preguntas sobre Performance

### P26: ¿Es lenta la búsqueda?
**R**: No. La búsqueda es muy rápida porque:
- Usa un índice en `codigo_barras` (probablemente)
- Solo devuelve 1 fila
- Consulta directa (no JOIN complejo)

---

### P27: ¿Cuántos productos puedo tener?
**R**: Teóricamente ilimitados. SQL Server maneja millones de registros sin problema.

---

### P28: ¿Mejorará el recálculo si hay muchos usuarios?
**R**: El recálculo es local (no toca BD), así que es instantáneo. No hay delay.

---

### P29: ¿Hay caché?
**R**: No. Cada búsqueda consulta la BD en tiempo real. Es lo más seguro.

---

### P30: ¿Puedo agregar caché?
**R**: Sí, pero no recomendado. Los datos podrían estar desactualizados.

---

## ❓ Preguntas sobre Seguridad

### P31: ¿Es seguro contra hackers?
**R**: Sí, porque:
- ✅ Usa parámetros SQL
- ✅ Filtra por estado
- ✅ Valida entrada

---

### P32: ¿Pueden ver mis datos?
**R**: Depende de permisos SQL Server. Si el usuario Windows tiene acceso a la BD, verá los datos.

---

### P33: ¿Qué datos se guardan?
**R**: Solo los que escribes en `txtAgregar`. El recálculo es local, no se guarda automáticamente.

---

### P34: ¿Puedo auditar cambios?
**R**: No en este código. Necesitarías agregar logging personalizado.

---

### P35: ¿Es compliant con GDPR?
**R**: Este código no toca datos personales, así que no es aplicable.

---

## ❓ Preguntas sobre Integración

### P36: ¿Cómo lo integro con mi sistema?
**R**: Ya está integrado. Solo asegúrate de:
1. Que `ProductoDAL.cs` esté disponible
2. Que `DBConnection.cs` esté configurado
3. Que la tabla `productos` exista

---

### P37: ¿Puedo usar este código en otro proyecto?
**R**: Sí. Copia:
- `FormularioDeInventario.cs`
- `FormularioDeInventario.Designer.cs`
- Y asegúrate que `ProductoDAL` esté disponible

---

### P38: ¿Funciona con otras bases de datos?
**R**: Sí, pero necesitas:
1. Cambiar la cadena de conexión
2. Adaptar los nombres de campos si son diferentes

---

### P39: ¿Puedo usarlo en Azure?
**R**: Sí. Solo cambia la cadena de conexión en `DBConnection.cs`:
```csharp
Server=servidor.database.windows.net;Database=bd;
User ID=usuario;Password=contraseña;
```

---

### P40: ¿Puedo sincronizar con múltiples usuarios?
**R**: Sí, pero cada usuario verá lo que hay en BD en ese momento. Si 2 usuarios modifican el mismo precio simultáneamente, el último gana.

---

## ❓ Preguntas sobre Debugging

### P41: ¿Cómo debuggeo si algo va mal?
**R**: Agrega puntos de quiebre (breakpoints):
1. En Visual Studio, haz clic en el margen izquierdo de la línea
2. Presiona F5 para ejecutar con debug
3. Las variables se mostrarán en la ventana Locals

---

### P42: ¿Dónde veo los errores de BD?
**R**: En el `MessageBox` que aparece. Si necesitas más detalles, agrega:
```csharp
System.Diagnostics.Debug.WriteLine(ex.StackTrace);
```

---

### P43: ¿Puedo loguear las búsquedas?
**R**: Sí. Agrega al inicio de `BuscarProducto`:
```csharp
System.Diagnostics.Debug.WriteLine("Buscando: " + codigo);
```

---

### P44: ¿Cómo sé si la BD está conectada?
**R**: Si no aparece error al buscar, está conectada. Si quieres verificar activamente:
```csharp
using (var conn = DBConnection.GetConnection())
{
    conn.Open(); // Si llega aquí, está conectado
}
```

---

### P45: ¿Qué hace `SuppressKeyPress = true`?
**R**: Evita que Windows emita el sonido de "beep" al presionar Enter. Es solo cosmetología.

---

## 📞 ¿No encontraste tu respuesta?

Si tu pregunta no está aquí, verifica:
1. **Documentación Técnica** - `DOCUMENTACION_TECNICA.md`
2. **Guía de Uso** - `GUIA_USO_PRACTICO.md`
3. **Resumen de Implementación** - `IMPLEMENTACION_INVENTARIO_RESUMEN.md`

---

**Última actualización**: Incluye 45 preguntas frecuentes ✅
