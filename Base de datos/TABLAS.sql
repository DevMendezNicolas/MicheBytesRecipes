CREATE DATABASE MicheBytes;

USE MicheBytes;
-- EJECUTAR PRIMERO

CREATE TABLE Usuarios(
usuario_id  INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL,
apellido VARCHAR (50) NOT NULL, 
telefono VARCHAR(20) UNIQUE NOT NULL,
email VARCHAR(50) UNIQUE NOT NULL,
contraseña VARCHAR (255) NOT NULL,
imagen_perfil LONGBLOB,
fecha_registro DATE NOT NULL,
fecha_baja DATE DEFAULT NULL
);

CREATE TABLE Roles(
rol_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL
);

CREATE TABLE Roles_X_Usuario(
rol_x_usuario_id INT AUTO_INCREMENT PRIMARY KEY,
rol_id INT,
usuario_id INT,
FOREIGN KEY(rol_id) REFERENCES Roles(rol_id),
FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Paises(
pais_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL
);

CREATE TABLE Categorias(
categoria_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL,
descripcion TEXT NOT NULL
);

CREATE TABLE Recetas(
receta_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (100) NOT NULL,
descripcion TEXT NOT NULL,
instrucciones TEXT NOT NULL,
imagen_receta LONGBLOB,
tiempo_preparacion TIME,
dificultad ENUM ('Fácil', 'Media', 'Difícil'),
fecha_baja DATE DEFAULT NULL,
pais_id INT,
categoria_id INT,
usuario_id INT,
FOREIGN KEY (pais_id) REFERENCES Paises(pais_id),
FOREIGN KEY (categoria_id)REFERENCES Categorias(categoria_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Tipos_de_ingredientes(
tipo_ingrediente_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL
);

CREATE TABLE Unidades_de_medidas(
unidad_de_medida_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL
);

CREATE TABLE Ingredientes(
ingrediente_id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL,
tipo_ingrediente_id INT,
unidad_de_medida_id INT,
FOREIGN KEY (tipo_ingrediente_id) REFERENCES Tipos_de_ingredientes(tipo_ingrediente_id),
FOREIGN KEY (unidad_de_medida_id) REFERENCES Unidades_de_medidas(unidad_de_medida_id)
);

CREATE TABLE Ingredientes_X_Receta(
ingrediente_x_receta_id INT AUTO_INCREMENT PRIMARY KEY,
ingrediente_id INT,
receta_id INT,
FOREIGN KEY (ingrediente_id) REFERENCES Ingredientes(ingrediente_id),
FOREIGN KEY (receta_id) REFERENCES Recetas(receta_id)
);

CREATE TABLE Me_gustas(
me_gusta_id INT AUTO_INCREMENT PRIMARY KEY,
fecha_me_gusta DATE NOT NULL,
receta_id INT,
usuario_id INT,
FOREIGN KEY(receta_id) REFERENCES Recetas(receta_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Comentarios(
comentario_id INT AUTO_INCREMENT PRIMARY KEY,
descripcion TEXT,
fecha_comentario DATE NOT NULL,
receta_id INT,
usuario_id INT,
FOREIGN KEY(receta_id) REFERENCES Recetas(receta_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Favoritas(
favorita_id INT AUTO_INCREMENT PRIMARY KEY,
usuario_id INT,
receta_id INT,
FOREIGN KEY(receta_id) REFERENCES Recetas(receta_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Historiales(
historial_id INT AUTO_INCREMENT PRIMARY KEY,
fecha_visita DATE NOT NULL,
usuario_id INT,
receta_id INT,
FOREIGN KEY(receta_id) REFERENCES Recetas(receta_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

CREATE TABLE Auditorias(
auditoria_id INT AUTO_INCREMENT PRIMARY KEY,
tipo_modificacion VARCHAR (50) NOT NULL,
fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
usuario_id INT NOT NULL,
receta_id INT NOT NULL
);

select * from usuarios;