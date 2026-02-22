# ✅ MODIFICAR PRODUCTO - GUÍA DE USO

## 🎯 ¿CÓMO FUNCIONA?

### Paso 1: Acceder a Modificar
```
1. En FormularioProductos, haz clic en botón "Modificar"
2. Se abre un panel con:
   - Campo de entrada: "Código del producto"
   - Botón: "Aceptar"
```

### Paso 2: Buscar Producto
```
1. Digita el código del producto que quieres modificar
   Ejemplo: ABC-001
2. Haz clic en "Aceptar" (o presiona Enter)
```

### Paso 3: Editar Campos
```
Se abre FormularioProductos con TODOS los campos llenos:
✓ Código (bloqueado, no se puede editar)
✓ Nombre
✓ Precio Costo
✓ Porcentaje Ganancia
✓ Precio Venta (se recalcula automático)
✓ Existencia
✓ Existencia Mínima
✓ Existencia Máxima
✓ Departamento

Puedes editar TODOS excepto el código.
```

### Paso 4: Guardar
```
1. Haz clic en "Actualizar Producto"
2. Aparece mensaje: "Producto actualizado correctamente"
3. Los cambios se guardan en BD ✓
```

---

## 📊 EJEMPLO PRÁCTICO

### Escenario: Modificar existencia de un producto

```
Usuario abre ModificarProducto
        ↓
Digita código: PROD-001
        ↓
Hace clic "Aceptar"
        ↓
Se cargan los datos:
  Nombre: Mi Producto
  Costo: 100
  Ganancia: 30%
  Precio: 130
  Existencia: 50    ← Quiero cambiar esto
  Mínima: 10
  Máxima: 100
        ↓
Usuario edita Existencia: 50 → 75
        ↓
Hace clic "Actualizar Producto"
        ↓
Se guarda: Existencia = 75
        ↓
Mensaje: "Producto actualizado correctamente" ✓
```

---

## 🎨 INTERFAZ

### Buscar Producto:
```
┌──────────────────────────────────────┐
│    Modificar Producto                │
├──────────────────────────────────────┤
│                                      │
│ Ingrese código del producto:         │
│ [PROD-001________________]            │
│                                      │
│    [Aceptar]                         │
│                                      │
└──────────────────────────────────────┘
```

### Formulario Cargado:
```
┌──────────────────────────────────────┐
│    EDITAR PRODUCTO                   │
├──────────────────────────────────────┤
│ Código:           [PROD-001] 🔒       │
│ Nombre:           [Mi Producto]       │
│ Precio Costo:     [100.00]            │
│ Ganancia %:       [30]                │
│ Precio Venta:     [130.00] (automático)
│ Existencia:       [75]  ← Modificado  │
│ ☑ Usa Inventario                      │
│ Existencia Min:   [10]                │
│ Existencia Max:   [100]               │
│ Departamento:     [Sin categoría]     │
│                                      │
│ [Actualizar Producto] [Cancelar]      │
└──────────────────────────────────────┘
```

---

## ⌨️ ATAJOS DE TECLADO

| Acción | Tecla |
|--------|-------|
| Buscar producto | Enter (en textbox) |
| Aceptar busca | Clic en botón o Enter |
| Cancelar edición | Botón Cancelar |

---

## ❓ PREGUNTAS FRECUENTES

### ¿Qué pasa si ingreso un código que no existe?
```
Aparece mensaje: "Producto no encontrado"
El textbox se limpia y puedes intentar con otro código.
```

### ¿Puedo cambiar el código del producto?
```
NO. El campo de código está bloqueado (ReadOnly).
Esto evita cambios accidentales.
Si necesitas cambiar código, deberías crear producto nuevo.
```

### ¿Se recalcula el precio automáticamente?
```
SÍ. Si cambias:
- Costo: El precio se recalcula
- Ganancia %: El precio se recalcula
Fórmula: Precio = Costo + (Costo * Ganancia / 100)
```

### ¿Qué campos son obligatorios?
```
✓ Código (automático, bloqueado)
✓ Nombre
✓ Precio Costo (> 0)
✓ Ganancia % (≥ 0)
✓ Precio Venta (> 0)

Campos opcionales:
- Existencia
- Existencia Mínima/Máxima (solo si usas inventario)
- Departamento
```

### ¿Puedo cancelar los cambios?
```
SÍ. Antes de guardar:
1. Haz clic en "Cancelar"
2. Se limpia el formulario
3. Los cambios NO se guardan
```

---

## 🔒 VALIDACIONES

El sistema valida:
- ✅ Código no vacío (al buscar)
- ✅ Producto existe (en BD)
- ✅ Nombre no vacío
- ✅ Costo > 0
- ✅ Precio venta > 0
- ✅ Ganancia ≥ 0

Si hay error, aparece mensaje y no guarda.

---

## 🚀 CASOS DE USO

### Caso 1: Actualizar existencia
```
1. Modificar → PROD-001
2. Cambiar Existencia: 50 → 75
3. Actualizar ✓
```

### Caso 2: Cambiar precio de venta
```
1. Modificar → PROD-002
2. Cambiar Precio Costo: 200 → 250
3. Ganancia se mantiene
4. Precio se recalcula automáticamente ✓
5. Actualizar ✓
```

### Caso 3: Agregar límites de inventario
```
1. Modificar → PROD-003
2. Marcar checkbox "Usa Inventario"
3. Existencia Mínima: 10
4. Existencia Máxima: 100
5. Actualizar ✓
```

### Caso 4: Búsqueda fallida
```
1. Modificar → XYZ-999 (no existe)
2. Aparece error: "Producto no encontrado"
3. Textbox se limpia
4. Intentar con otro código ✓
```

---

## 📌 RESUMEN RÁPIDO

| Acción | Resultado |
|--------|-----------|
| Buscar válido | ✅ Abre formulario con datos |
| Buscar inválido | ❌ Mensaje de error |
| Código vacío | ❌ Mensaje de validación |
| Editar datos | ✅ Campos activos para edición |
| Guardar cambios | ✅ Se actualizan en BD |
| Cancelar | ✅ Descarta cambios |

---

**¡Listo para modificar productos! 🎉**

Cualquier duda, consulta FUNCIONALIDAD_MODIFICAR_PRODUCTO.md
