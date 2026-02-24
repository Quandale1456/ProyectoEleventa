# Formulario de Login - Guía de Uso Rápido

## ¿Qué es?
El formulario de login es la pantalla de inicio de sesión de la aplicación **eleventa**. Debe ser lo primero que ve el usuario al abrir la aplicación.

## ¿Cómo se ve?
```
┌──────────────────────────────────────┐
│  eleventa - Comenzar Nuevo Turno  ✕  │  ← Barra superior gris
├──────────────────────────────────────┤
│                                      │
│  🔒    Comenzar nuevo turno          │  ← Icono + Título azul
│        Por favor ingresa tu usuario  │
│        y contraseña para continuar.  │  ← Descripción
│                                      │
│  Usuario:                            │
│  [ComboBox con lista de usuarios  ▼]│  ← Selecciona usuario
│                                      │
│  Contraseña:                         │
│  [●●●●●●●●]  Olvide mi contraseña   │  ← TextBox oculto + Link
│                                      │
│  [🔒 Acceder]    [Salir]             │  ← Botones
│                                      │
└──────────────────────────────────────┘
```

## Cómo Usar

### Paso 1: Iniciar la Aplicación
- Abre la aplicación
- Se muestra automáticamente el formulario de login

### Paso 2: Seleccionar Usuario
1. Haz click en el ComboBox "Usuario:"
2. Se despliega la lista de usuarios disponibles
3. Selecciona tu usuario

### Paso 3: Ingresar Contraseña
1. Haz click en el campo "Contraseña:"
2. Escribe tu contraseña
3. Los caracteres aparecen como **●●●●●●** (ocultos por seguridad)

### Paso 4: Acceder
Tienes dos opciones:
- **Opción A**: Haz click en el botón "🔒 Acceder"
- **Opción B**: Presiona Enter en el teclado

### Paso 5: Resultado
- ✅ **Si es correcto**: Se abre la aplicación
- ❌ **Si es incorrecto**: Aparece un mensaje de error

## Casos de Uso

### Caso 1: Inicio de Sesión Exitoso
```
1. Selecciono "admin" del ComboBox
2. Escribo contraseña: admin123
3. Presiono Enter o click en Acceder
4. ✅ Se abre la aplicación
```

### Caso 2: Contraseña Incorrecta
```
1. Selecciono "admin" del ComboBox
2. Escribo contraseña: contraseña_incorrecta
3. Presiono Enter o click en Acceder
4. ❌ Aparece: "Usuario o contraseña incorrectos. Intenta de nuevo."
5. El campo de contraseña se limpia
6. Puedo intentar de nuevo
```

### Caso 3: No Selecciono Usuario
```
1. Dejo el ComboBox vacío
2. Presiono Enter o click en Acceder
3. ❌ Aparece: "Por favor selecciona un usuario."
4. Debo seleccionar un usuario primero
```

### Caso 4: No Ingreso Contraseña
```
1. Selecciono "admin" del ComboBox
2. Dejo el campo de contraseña vacío
3. Presiono Enter o click en Acceder
4. ❌ Aparece: "Por favor ingresa la contraseña."
5. Debo escribir la contraseña
```

## Botones Disponibles

| Botón | Acción |
|-------|--------|
| **🔒 Acceder** | Inicia sesión con las credenciales ingresadas |
| **Salir** | Cierra la aplicación |
| **✕** (superior) | Cierra la aplicación |

## Atajos de Teclado

| Tecla | Acción |
|-------|--------|
| **Tab** | Navega entre campos |
| **Enter** (en contraseña) | Inicia sesión (igual a hacer click en Acceder) |
| **Alt+F4** | Cierra la aplicación |

## Datos para Prueba

Usa estos usuarios para probar:

| Usuario | Contraseña | Rol |
|---------|-----------|-----|
| admin | admin123 | Administrador |
| vendedor1 | pass123 | Vendedor |
| gerente | ger123 | Gerente |

## Preguntas Frecuentes

### ¿Qué pasa si olvido mi contraseña?
Haz click en "Olvide mi contraseña" (función futuro - aún en desarrollo)

### ¿Puedo cambiar mi contraseña?
Por ahora no. Contacta al administrador para cambiarla en la base de datos.

### ¿Cuántos intentos tengo?
Actualmente, puedes intentar cuantas veces quieras. (Limitación futura a implementar)

### ¿Es segura mi contraseña?
Los caracteres se ocultan mientras escribes. Sin embargo, se almacenan en texto plano en la BD. Se recomienda usar contraseñas diferentes a otros sistemas.

### ¿Qué pasa si cierro la ventana?
Se cierra la aplicación completamente.

## Solución de Problemas

### Problema: "No veo el ComboBox con usuarios"
**Solución**: Verifica que la base de datos esté conectada y tenga usuarios registrados.

### Problema: "Dice 'Usuario o contraseña incorrectos' pero estoy seguro que son correctos"
**Solución**: 
- Las contraseñas son sensibles a mayúsculas/minúsculas
- Verifica que el usuario esté **activo** en la BD (estado = 1)
- No debe haber espacios en blanco

### Problema: "No puedo presionar Enter"
**Solución**: Asegúrate de que el cursor esté en el campo de contraseña, no en el ComboBox.

### Problema: "La aplicación no abre después de iniciar sesión"
**Solución**: Verifica que Form1 esté disponible y compilado correctamente.

## Notas de Seguridad

⚠️ **Importante**:
- No compartas tus credenciales de login
- Las contraseñas NO se deben escribir en código
- Usa contraseñas complejas
- Después de usar, cierra sesión apropiadamente

## Resumen

1. ✅ Selecciona usuario del ComboBox
2. ✅ Escribe contraseña (aparece como ●●●●)
3. ✅ Presiona Enter o click en "Acceder"
4. ✅ Se abre la aplicación si todo es correcto
5. ✅ Se muestra error si hay un problema

¡Listo! Ahora puedes usar el formulario de login.

