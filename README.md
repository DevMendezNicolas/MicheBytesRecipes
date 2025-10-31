# 📖 Recetario Digital - Michebytes

Recetario Digital es una aplicación de escritorio desarrollada en **C# con Windows Forms** que permite gestionar un catálogo de recetas de cocina.  
El sistema cuenta con dos tipos de perfiles: **Administrador** y **Usuario común**, cada uno con funcionalidades específicas.

---

## ✨ Funcionalidades

### 👤 Usuario Común
- Consultar el catálogo de recetas aplicando filtros (categoría, ingrediente, tipo de plato, etc.).
- Marcar recetas como **favoritas**.
- Llevar un **historial personal** de recetas preparadas.
- Dejar **calificaciones y comentarios** en las recetas.
- Exportar su historial a **PDF**.

### 🛠️ Administrador
- Gestión completa de **recetas**, **ingredientes** y **usuarios** (CRUD).
- Subir imágenes para cada receta.
- Modera y elimina comentarios inapropiados.
- Importar y exportar recetas en **JSON**.
- Generar **reportes en PDF** con estadísticas (recetas más populares, más valoradas, etc.).

---

## 🏗️ Tecnologías utilizadas
- **Lenguaje**: C#  
- **Framework**: Windows Forms  
- **Base de Datos**: MySQL  
- **Persistencia adicional**: Archivos JSON  
- **Reportes**: PDF con librerías de .NET  
- **Entorno**: Visual Studio  

---

## 🗄️ Modelo de Datos (tablas principales)
- **Usuarios**
- **Recetas**
- **Ingredientes**
- **Receta_Ingredientes** (relación N:N)
- **Comentarios**
- **Calificaciones**
- **Favoritos**
- **Historial**

---

## ⚙️ Instalación y Configuración

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/DevMendezNicolas/Michebytes.git
