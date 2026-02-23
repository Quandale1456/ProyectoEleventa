# 📚 GUÍA RÁPIDA - Formulario AjustesInv

## 🎯 En 30 Segundos

El formulario `AjustesInv` es un modificador de productos que permite:
1. **Buscar** productos por código
2. **Editar** precios (costo, ganancia)
3. **Ajustar** inventario con cantidad positiva o negativa

---

## 🚀 Cómo Usar

### Paso 1: Escribe código
```
Código: LAPTOP-001
```

### Paso 2: Presiona Enter
```
Se cargan los datos automáticamente
```

### Paso 3: Ajusta inventario (opcional edita precios)
```
txtMasOMenos: -2  (restar 2 unidades)
o
txtMasOMenos: +5  (sumar 5 unidades)
```

### Paso 4: Agrega motivo (opcional pero recomendado)
```
Motivo: Productos dañados
```

### Paso 5: Clic en "Realizar ajuste"
```
Confirma → Se actualiza en BD
```

---

## 📊 Ejemplo: Stock -2 (Dañados)

```
Stock Actual:        10 unidades
Cantidad a Ajustar: -2 unidades (dañadas)
Nuevo Stock:         8 unidades ✅
```

---

## 📊 Ejemplo: Stock +5 (Compra)

```
Stock Actual:        20 unidades
Cantidad a Ajustar: +5 unidades (compra)
Nuevo Stock:         25 unidades ✅
```

---

## ✅ Qué Valida

| Validación | Resultado |
|---|---|
| ¿Código vacío? | ❌ Muestra error |
| ¿Cantidad vacía? | ❌ Muestra error |
| ¿Cantidad no es número? | ❌ Muestra error |
| ¿Stock sería negativo? | ❌ Muestra error |
| ¿Todo correcto? | ✅ Pide confirmación |

---

## 🎯 Campos Importantes

| Campo | Acción |
|---|---|
| **txtCodigoProducto** | Escribe código + Enter |
| **txtMasOMenos** | Cantidad a ajustar (+/-) |
| **txtMotivo** | Razón del ajuste |
| **Botón Realizar Ajuste** | Aplica el cambio |

---

## 💡 Tips

✅ Puedes editar precios mientras ajustas inventario
✅ Presiona Enter en el código para buscar
✅ El precio de venta se calcula automáticamente
✅ Siempre revisa la confirmación antes de aplicar
✅ El motivo te ayuda a tener un registro

---

## 🔄 Flujo Visual

```
┌─────────────┐
│  Código +   │
│  Enter      │
└─────────────┘
      ↓
┌─────────────┐
│  Carga      │
│  Datos      │
└─────────────┘
      ↓
┌─────────────┐
│  Ajusta     │
│  Inventario │
│  (txtMasOMenos)
└─────────────┘
      ↓
┌─────────────┐
│  Confirma   │
│  Cambio     │
└─────────────┘
      ↓
┌─────────────┐
│  Actualiza  │
│  en BD ✅   │
└─────────────┘
```

---

## ❌ Errores Comunes

### Error: "Ingrese un código"
✅ Solución: Escribe un código válido

### Error: "Ingrese cantidad a ajustar"
✅ Solución: Llena txtMasOMenos

### Error: "Stock sería negativo"
✅ Solución: Ajusta a cantidad menor

### Error: "Producto no encontrado"
✅ Solución: Verifica código en BD

---

## 🎉 Listo

El formulario está completamente funcional.

¡Úsalo para ajustar tu inventario! 🚀

