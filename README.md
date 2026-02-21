# 🛒 SISTEMA DE PUNTO DE VENTA (POS) - C# WINDOWS FORMS

## ✨ Sistema Profesional de Venta tipo Eleventa

Sistema completo de Punto de Venta para Windows Forms con SQL Server, optimizado para uso rápido con teclado y lector de código de barras.

---

## 🚀 INICIO RÁPIDO

### 1️⃣ Configurar Base de Datos (5 minutos)
```sql
-- Ejecutar en SQL Server Management Studio:
-- Archivo: SQL_CREAR_TABLAS.sql
```

### 2️⃣ Cambiar Conexión (1 minuto)
```csharp
// Archivo: ProyectoEleventa/Data/DBConnection.cs
// Línea ~12: Cambiar si tu servidor no es localhost
```

### 3️⃣ Compilar (1 minuto)
```
Ctrl+Shift+B (o Build → Build Solution)
```

### 4️⃣ Ejecutar (1 minuto)
```
F5 (o Debug → Start Debugging)
```

### 5️⃣ Probar
```
- Escanea código: 7891234567890 (Laptop)
- Presiona AGREGAR
- Prueba COBRAR
```

**⏱️ Total: 15 minutos para tener el sistema funcionando**

---

## 📦 ¿QUÉ INCLUYE?

### ✅ Código Fuente (6 archivos)
```
ProyectoEleventa/
├── Data/
│   ├── DBConnection.cs       (Conexión centralizada a BD)
│   ├── ProductoDAL.cs        (Métodos de productos)
│   ├── ClienteDAL.cs         (Métodos de clientes)
│   └── VentaDAL.cs           (Registro de ventas)
├── BusquedaProductos.cs      (Formulario de búsqueda)
└── FormularioVentas.cs       (Pantalla principal - POS)
```

### ✅ Base de Datos
```
7 tablas:
├── productos (10 artículos de prueba)
├── clientes (4 clientes de prueba)
├── ventas (transacciones)
├── detalle_ventas (líneas de venta)
├── movimientos_inventario (trazabilidad)
├── usuarios (cuentas de usuario)
└── departamentos (categorías)

+ Índices + Integridad Referencial
```

### ✅ Documentación Completa
```
├── 📋 INDICE_MAESTRO.txt           (Navega toda la doc)
├── 🚀 INICIO_RAPIDO.txt            (5 pasos para comenzar)
├── 📖 GUIA_SISTEMA_POS.txt         (Arquitectura completa)
├── ⚡ REFERENCIA_RAPIDA.txt        (Métodos disponibles)
├── 🛠️ EXTENSIONES_Y_CUSTOMIZACION.txt (Agregar funciones)
├── ✅ CHECKLIST_IMPLEMENTACION.txt (Verificación QA)
├── 📊 RESUMEN_FINAL.txt            (Visión general)
└── 💾 SQL_CREAR_TABLAS.sql         (Script de BD)
```

---

## 🎯 CARACTERÍSTICAS PRINCIPALES

### ✅ Escaneo de Código de Barras
- Ingreso rápido con lector de código de barras
- Validación automática de existencia
- Búsqueda visual alternativa

### ✅ Gestión de Tickets
- Agregar/eliminar productos
- Modificar cantidades
- Descuentos por línea y global
- Cálculo automático de impuestos (16%)

### ✅ Métodos de Pago
- **Efectivo** (directo)
- **Tarjeta** (validación de saldo)
- **Crédito** (validación de límite)

### ✅ Control de Inventario
- Validación de stock antes de venta
- Actualización automática después de cobrar
- Registro de movimientos de inventario

### ✅ Seguridad
- Transacciones atómicas (todo o nada)
- Parámetros SQL (sin inyección)
- Integridad referencial garantizada

### ✅ Optimizado para Teclado
- Teclas de atajo para funciones
- Enfoque automático entre campos
- Uso sin ratón

---

## 📋 CONTROLES DEL FORMULARIO

### Entrada
- `txtCodigoProducto` - Escaneo de código de barras
- `nudCantidad` - Cantidad a vender
- `txtDescuentoLinea` - Descuento por línea
- `txtDescuentoGlobal` - Descuento general
- `cmbClientes` - Selección de cliente
- `cmbMetodoPago` - Método de pago

### Salida
- `dgvTicket` - DataGridView del ticket
- `lblSubtotal` - Subtotal calculado
- `lblImpuesto` - Impuesto (16%)
- `lblTotal` - Total a cobrar

### Botones
- `btnAgregar` - Agregar producto al ticket
- `btnEliminar` - Eliminar producto del ticket
- `btnBuscar` - Abrir búsqueda visual
- `btnCobrar` - Registrar la venta
- `btnCancelar` - Cancelar venta

---

## 🔄 FLUJO DE UNA VENTA

```
1. ESCANEAR PRODUCTO
   ↓
2. VALIDAR (código existe, stock disponible)
   ↓
3. AGREGAR AL TICKET
   ↓
4. RECALCULAR TOTALES
   ↓
5. (Opcional) AGREGAR MÁS PRODUCTOS
   ↓
6. SELECCIONAR CLIENTE
   ↓
7. ELEGIR MÉTODO DE PAGO
   ↓
8. PRESIONAR COBRAR
   ↓
9. TRANSACCIÓN COMPLETA:
   ├─ INSERT en VENTAS
   ├─ INSERT en DETALLE_VENTAS
   ├─ UPDATE en PRODUCTOS (inventario)
   ├─ INSERT en MOVIMIENTOS_INVENTARIO
   └─ UPDATE en CLIENTES (si es crédito)
   ↓
10. ÉXITO - TICKET LIMPIADO, LISTO PARA SIGUIENTE
```

---

## 🏗️ ARQUITECTURA

```
┌─────────────────────────────────┐
│ PRESENTACIÓN (FormularioVentas) │
└────────────────┬────────────────┘
                 │
┌────────────────▼────────────────┐
│ ACCESO A DATOS (ProductoDAL,   │
│ ClienteDAL, VentaDAL)           │
└────────────────┬────────────────┘
                 │
┌────────────────▼────────────────┐
│ CONEXIÓN (DBConnection)         │
└────────────────┬────────────────┘
                 │
┌────────────────▼────────────────┐
│ BASE DE DATOS (SQL Server)      │
└─────────────────────────────────┘
```

---

## 🔐 VALIDACIONES IMPLEMENTADAS

### En Agregar Producto
✓ Código no está vacío
✓ Producto existe en BD
✓ Stock disponible ≥ cantidad
✓ Cantidad es válida (> 0)

### En Realizar Cobro
✓ Hay al menos 1 producto
✓ Cliente existe
✓ Si crédito: límite disponible ≥ total

### En Transacción
✓ Todas las operaciones se ejecutan o ninguna
✓ ROLLBACK automático si falla algo
✓ Integridad referencial garantizada

---

## 💻 REQUISITOS

- **Sistema Operativo**: Windows 7+
- **Visual Studio**: 2015 o superior
- **.NET Framework**: 4.7.2
- **SQL Server**: 2012 o superior (LocalDB también funciona)
- **RAM**: 2GB mínimo

---

## 📖 DOCUMENTACIÓN

| Documento | Para | Tiempo |
|-----------|------|--------|
| **INDICE_MAESTRO.txt** | Navegar toda la doc | 5 min |
| **INICIO_RAPIDO.txt** | Configurar rápido | 15 min |
| **GUIA_SISTEMA_POS.txt** | Entender arquitectura | 30 min |
| **REFERENCIA_RAPIDA.txt** | Consultar métodos | On-demand |
| **EXTENSIONES_Y_CUSTOMIZACION.txt** | Agregar funciones | 1-2 h/ext |
| **CHECKLIST_IMPLEMENTACION.txt** | Verificar para produción | 1-2 h |
| **RESUMEN_FINAL.txt** | Visión general | 10 min |

---

## 🎓 EMPEZAR

### Opción 1: Lectura Rápida (30 minutos)
1. Este README.md
2. INICIO_RAPIDO.txt
3. Implementar

### Opción 2: Aprendizaje Completo (2 horas)
1. Este README.md
2. INDICE_MAESTRO.txt
3. GUIA_SISTEMA_POS.txt
4. REFERENCIA_RAPIDA.txt
5. Implementar

### Opción 3: Para Producción (1 día)
1. Leer toda la documentación
2. Seguir CHECKLIST_IMPLEMENTACION.txt
3. Entrenar usuarios
4. Lanzar

---

## 🐛 SOPORTE RÁPIDO

### Error: "Cannot open database 'sistema_ventas'"
✓ Ejecutar `SQL_CREAR_TABLAS.sql` en SQL Server

### Error: "Login failed"
✓ Verificar servidor SQL en `DBConnection.cs`

### Error: "Producto no encontrado"
✓ Verificar código de barras exacto
✓ Verificar estado = 1 en productos

### Otros errores
→ Ver GUIA_SISTEMA_POS.txt (sección "Errores Comunes")

---

## 📊 ESTADÍSTICAS

- **Líneas de código**: ~1,300
- **Archivos de código**: 6
- **Tablas de BD**: 7
- **Métodos públicos**: 25+
- **Documentación**: 8 archivos

---

## 🎯 PRÓXIMOS PASOS

1. **Lectura**: Lee `INICIO_RAPIDO.txt`
2. **Setup**: Ejecuta `SQL_CREAR_TABLAS.sql`
3. **Config**: Ajusta `DBConnection.cs`
4. **Compilación**: `Ctrl+Shift+B`
5. **Ejecución**: `F5`
6. **Verificación**: Sigue `CHECKLIST_IMPLEMENTACION.txt`

---

## 📝 NOTAS IMPORTANTES

- ✅ Sistema completamente funcional
- ✅ Compila sin errores
- ✅ Documentación completa
- ✅ Código limpio y comentado
- ✅ Listo para producción
- ✅ Fácil de extender

---

## 🚀 ¡LISTO PARA USAR!

```
┌─────────────────────────────────┐
│  Tu Sistema POS está COMPLETO   │
│  y LISTO PARA USAR              │
│                                 │
│  Tiempo para implementar: 1h    │
│  Usuarios a entrenar: Variable  │
│  Tiempo en producción: Ya!      │
└─────────────────────────────────┘
```

---

## 📞 CONTACTO

- **Documentación**: Ver archivos .txt
- **Código**: Está comentado y documentado
- **SQL**: Ver SQL_CREAR_TABLAS.sql

---

**Versión**: 1.0  
**Estado**: ✅ Producción  
**Última actualización**: 2024

---

> *"Un sistema de ventas profesional, rápido y confiable."*

---

## 📄 Licencia

Código y documentación incluidos en este proyecto.

---

## ¡ÉXITO CON TU SISTEMA POS! 🎉

Para empezar: Lee `INICIO_RAPIDO.txt`
