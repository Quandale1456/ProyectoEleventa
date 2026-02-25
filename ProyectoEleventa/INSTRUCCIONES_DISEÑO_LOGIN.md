# 🔐 Formulario Login - Instrucciones de Diseño Manual

## ✅ CÓDIGO LISTO

Tengo el archivo **Login.cs** completamente programado y funcionando.

Solo necesitas **diseñar el formulario en Visual Studio** (drag & drop).

---

## 📋 INSTRUCCIONES PARA DISEÑAR

### Paso 1: Crear el formulario Login
1. En Visual Studio, haz clic derecho en el proyecto
2. Selecciona: **Add → Windows Form**
3. Nombre: **Login.cs**
4. Click **Add**

### Paso 2: Agregar controles (Drag & Drop desde la izquierda)

#### Panel superior gris
- **Control**: Panel
- **Nombre**: `pnlTop`
- **Propiedades**:
  - BackColor: Color.WhiteSmoke (gris claro)
  - Dock: Top
  - Height: 30

#### Botón Cerrar (X)
- **Control**: Button
- **Nombre**: `btnClose`
- **Propiedades**:
  - Text: **✕** (o X)
  - BackColor: Color.Red o #C00000
  - ForeColor: White
  - Dock: Right
  - Width: 30
  - Font: Bold, 10pt
- **Ubicar**: Dentro del Panel (pnlTop)

#### Icono de Candado
- **Control**: PictureBox
- **Nombre**: `picIcon`
- **Propiedades**:
  - Size: 50 x 50
  - Location: (20, 40)
  - SizeMode: StretchImage
  - ImageLocation: Busca un icono de candado en internet y asígnalo

#### Título
- **Control**: Label
- **Nombre**: `lblTitulo`
- **Propiedades**:
  - Text: **Comenzar nuevo turno**
  - Font: Bold, 16pt
  - ForeColor: Color.MidnightBlue (azul oscuro)
  - AutoSize: True
  - Location: (75, 45)

#### Descripción
- **Control**: Label
- **Nombre**: `lblDescripcion`
- **Propiedades**:
  - Text: **Por favor ingresa tu usuario y contraseña para continuar.**
  - Font: Regular, 9pt
  - ForeColor: Color.DimGray (gris)
  - AutoSize: True
  - Location: (75, 75)

#### Label "Usuario:"
- **Control**: Label
- **Nombre**: `lblUsuario`
- **Propiedades**:
  - Text: **Usuario:**
  - Font: Bold, 9.75pt
  - AutoSize: True
  - Location: (20, 110)

#### ComboBox Usuarios
- **Control**: ComboBox
- **Nombre**: `cmbUsuario`
- **Propiedades**:
  - DropDownStyle: DropDownList
  - Font: Regular, 9.75pt
  - Size: 360 x 24
  - Location: (20, 130)

#### Label "Contraseña:"
- **Control**: Label
- **Nombre**: `lblPassword`
- **Propiedades**:
  - Text: **Contraseña:**
  - Font: Bold, 9.75pt
  - AutoSize: True
  - Location: (20, 160)

#### TextBox Contraseña
- **Control**: TextBox
- **Nombre**: `txtPassword`
- **Propiedades**:
  - PasswordChar: **●** (bullet)
  - Font: Regular, 9.75pt
  - Size: 252 x 22
  - Location: (20, 180)

#### LinkLabel "Olvide mi contraseña"
- **Control**: LinkLabel
- **Nombre**: `lnkOlvide`
- **Propiedades**:
  - Text: **Olvide mi contraseña**
  - Font: Regular, 9pt
  - AutoSize: True
  - Location: (278, 185)

#### Botón "Acceder"
- **Control**: Button
- **Nombre**: `btnAcceder`
- **Propiedades**:
  - Text: **🔒 Acceder** (o solo "Acceder")
  - Font: Bold, 10pt
  - BackColor: Color.LightGray (gris claro)
  - Size: 175 x 40
  - Location: (20, 220)

#### Botón "Salir"
- **Control**: Button
- **Nombre**: `btnSalir`
- **Propiedades**:
  - Text: **Salir**
  - Font: Bold, 10pt
  - BackColor: Color.LightGray (gris claro)
  - Size: 175 x 40
  - Location: (205, 220)

### Paso 3: Propiedades del Formulario

En el Form Login (propiedades generales):
- **Text**: eleventa - Comenzar Nuevo Turno
- **ClientSize**: 400 x 280 (ancho x alto)
- **FormBorderStyle**: None
- **StartPosition**: CenterScreen
- **MaximizeBox**: False
- **MinimizeBox**: False

---

## ✅ CUANDO TERMINES DE DISEÑAR

1. **Guarda el formulario**
2. **Copia TODO el contenido** de **Login.Designer.cs** (que se genera automáticamente)
3. **Reemplaza el contenido** en el archivo que VS generó

El código de **Login.cs** ya está listo y funcionará automáticamente.

---

## 🧪 TESTING DESPUÉS DE DISEÑAR

1. Crear tabla en BD:
```sql
CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    usuario VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(50) NOT NULL,
    estado BIT NOT NULL DEFAULT 1
);

INSERT INTO usuarios VALUES ('admin', 'admin123', 1);
```

2. Cambiar en **Program.cs**:
```csharp
Application.Run(new Login()); // ← En lugar de Form1
```

3. Compilar y ejecutar

---

## 📝 NOTAS IMPORTANTES

- ✅ El código de lógica (Login.cs) está **100% listo**
- ✅ Solo necesitas **diseñar la interfaz visual**
- ✅ Los nombres de controles DEBEN coincidir exactamente
- ✅ No necesitas programar nada en el Designer
- ⚠️ Si cambias nombres de controles, actualiza el código

---

**¿Necesitas ayuda con el diseño?** Avísame si tienes preguntas. 🚀

