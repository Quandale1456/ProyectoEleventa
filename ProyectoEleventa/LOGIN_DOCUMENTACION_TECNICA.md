# Formulario de Login - Documentación Técnica

## Descripción General
El formulario de login es la puerta de entrada a la aplicación **eleventa**. Permite a los usuarios autenticarse proporcionando sus credenciales (usuario y contraseña).

## Estructura del Formulario

### Componentes Visuales

1. **Panel Superior (pnlTop)**
   - Barra gris con botón de cerrar (X)
   - Color de fondo: WhiteSmoke (#F5F5F5)

2. **Icono de Candado (picIcon)**
   - Representa seguridad
   - Ubicado en la parte superior izquierda
   - Tamaño: 50x50 píxeles

3. **Título Principal (lblTitulo)**
   - Texto: "Comenzar nuevo turno"
   - Fuente: 16pt, Negrita
   - Color: MidnightBlue

4. **Descripción (lblDescripcion)**
   - Texto: "Por favor ingresa tu usuario y contraseña para continuar."
   - Fuente: 9pt
   - Color: DimGray

5. **Campo de Usuario (cmbUsuario)**
   - ComboBox de solo lectura (DropDownList)
   - Cargado dinámicamente desde la base de datos
   - Contiene lista de usuarios activos

6. **Campo de Contraseña (txtPassword)**
   - TextBox con PasswordChar = '●'
   - Oculta los caracteres ingresados
   - Acepta Enter para enviar

7. **LinkLabel (lnkOlvide)**
   - Texto: "Olvide mi contraseña"
   - Usado para recuperación de contraseña (puede implementarse)

8. **Botones**
   - **Acceder**: Inicia sesión (175x40 píxeles)
   - **Salir**: Cierra la aplicación (175x40 píxeles)

## Flujo Funcional

### 1. Carga del Formulario (FormLoad)
```
Login_Load()
  ├── Suscribir eventos de botones
  ├── Suscribir evento KeyPress del TextBox
  ├── CargarUsuarios() - Consulta BD
  └── Enfocar en ComboBox
```

### 2. Carga de Usuarios desde BD
```
CargarUsuarios()
  ├── Ejecuta: SELECT id_usuario, usuario FROM usuarios 
  │   WHERE estado = 1 ORDER BY usuario
  ├── Llena ComboBox con DataSource
  └── DisplayMember = "usuario"
  └── ValueMember = "id_usuario"
```

**SQL de ejemplo:**
```sql
SELECT id_usuario, usuario 
FROM usuarios 
WHERE estado = 1 
ORDER BY usuario
```

### 3. Validación de Credenciales
```
btnAcceder_Click()
  ├── Validar que ComboBox tenga selección
  ├── Validar que txtPassword no esté vacío
  ├── Obtener usuario y contraseña
  ├── Llamar ValidarCredenciales()
  └── Si es correcto:
      ├── Crear FormPrincipal
      ├── Mostrar FormPrincipal
      ├── Cerrar Login
      └── Si es incorrecto:
          ├── Mostrar MessageBox de error
          └── Limpiar contraseña
```

### 4. Consulta de Validación
```
ValidarCredenciales(usuario, password)
  ├── SQL: SELECT COUNT(*) FROM usuarios 
  │   WHERE usuario = @usuario 
  │   AND password = @password 
  │   AND estado = 1
  ├── Usa SqlParameters para evitar inyección SQL
  └── Retorna True si COUNT(*) > 0
```

**SQL de ejemplo:**
```sql
SELECT COUNT(*) 
FROM usuarios 
WHERE usuario = @usuario 
AND password = @password 
AND estado = 1
```

### 5. Presionar Enter
- El evento `txtPassword_KeyPress` detecta cuando se presiona Enter (código ASCII 13)
- Llama automáticamente a `Acceder()`
- Esto mejora la experiencia de usuario

## Métodos Principales

### CargarUsuarios()
- **Propósito**: Poblar el ComboBox con usuarios desde BD
- **Llamado en**: FormLoad
- **Excepciones**: Maneja errores de conexión

### ValidarCredenciales(string usuario, string password)
- **Propósito**: Verificar credenciales contra la BD
- **Parámetros**: Usuario y contraseña sin encriptar
- **Retorno**: bool (true si son válidas)
- **Seguridad**: Usa SqlParameters para evitar inyección SQL

### Acceder()
- **Propósito**: Ejecutar todo el flujo de inicio de sesión
- **Validaciones**:
  1. Usuario seleccionado
  2. Contraseña ingresada
  3. Credenciales válidas en BD
- **Acción**: Abre FormPrincipal si es exitoso

## Base de Datos

### Tabla: usuarios
```sql
CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    usuario VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(50) NOT NULL,
    estado BIT NOT NULL DEFAULT 1
)
```

### Datos de Ejemplo
```sql
INSERT INTO usuarios (usuario, password, estado) 
VALUES 
('admin', 'admin123', 1),
('vendedor1', 'pass123', 1),
('gerente', 'ger123', 1)
```

## Seguridad

### Implementado
✅ **SqlParameters**: Previene inyección SQL
✅ **PasswordChar**: Oculta caracteres mientras se escriben
✅ **Estado = 1**: Solo permite usuarios activos
✅ **Validación dual**: Cliente + BD

### NO Implementado (Consideraciones Futuras)
⚠️ **Encriptación de contraseña**: Las contraseñas se almacenan en texto plano
⚠️ **Hash**: Usar bcrypt o SHA256
⚠️ **Logs de acceso**: No registra intentos fallidos
⚠️ **Bloqueo de cuenta**: No bloquea después de N intentos fallidos
⚠️ **HTTPS/SSL**: No aplica si es local

## Eventos Principales

| Evento | Método | Acción |
|--------|--------|--------|
| Form Load | Login_Load | Inicializa componentes |
| Click Acceder | btnAcceder_Click | Inicia sesión |
| Click Salir | btnSalir_Click | Cierra aplicación |
| Click Cerrar | btnClose_Click | Cierra aplicación |
| KeyPress Password | txtPassword_KeyPress | Permite Enter para enviar |

## Integración con la Aplicación

### Punto de Entrada
El archivo `Program.cs` debe ejecutar este formulario como el primero:

```csharp
[STAThread]
static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Login()); // Aquí inicia el login
}
```

### Flujo Completo
```
Program.cs (Main)
  ↓
Login.cs (FormLogin)
  ├── Usuario y contraseña correctos
  │   ↓
  └── Form1.cs (FormPrincipal)
      └── Aplicación completa
```

## Mejoras Recomendadas

1. **Encriptación**: Hash las contraseñas en BD
   ```csharp
   // Usar bcrypt
   BCrypt.Net.BCrypt.HashPassword(password);
   BCrypt.Net.BCrypt.Verify(password, hash);
   ```

2. **Registro de Intentos**:
   ```sql
   CREATE TABLE login_logs (
       id INT PRIMARY KEY IDENTITY,
       usuario VARCHAR(50),
       fecha_intento DATETIME,
       exitoso BIT
   )
   ```

3. **Bloqueo de Cuenta**:
   ```csharp
   // Después de 3 intentos fallidos, bloquear por 15 minutos
   ```

4. **Recuperación de Contraseña**:
   - LinkLabel "Olvide mi contraseña"
   - Abrir formulario de recuperación
   - Validar por email o pregunta de seguridad

5. **Recordar Usuario**:
   - CheckBox "Recordar usuario"
   - Guardar en registro local
   - Cargar al abrir

## Conclusión

El formulario de login proporciona una autenticación básica pero funcional. Para producción, se recomienda implementar las mejoras de seguridad mencionadas, especialmente la encriptación de contraseñas y el bloqueo de intentos fallidos.

