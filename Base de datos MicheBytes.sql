CREATE DATABASE MicheBytes;

USE MicheBytes;


CREATE TABLE Usuarios(
usuario_id  INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR (50) NOT NULL,
apellido VARCHAR (50) NOT NULL, 
telefono VARCHAR(20) UNIQUE NOT NULL,
email VARCHAR(50) UNIQUE NOT NULL,
contraseña VARCHAR (20) UNIQUE NOT NULL,
imagen_perfil BLOB,
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
imagen_receta BLOB,
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
cantidad INT NOT NULL,
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
fecha_borrado DATE,
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
tipo_modificacion VARCHAR (50),
fecha_modificacion TIMESTAMP NULL,
usuario_id INT,
receta_id INT,
FOREIGN KEY(receta_id) REFERENCES Recetas(receta_id),
FOREIGN KEY(usuario_id)REFERENCES Usuarios(usuario_id)
);

-- USUARIOS
INSERT INTO Usuarios (nombre, apellido, telefono, email, contraseña, imagen_perfil, fecha_registro, fecha_baja) VALUES
('Juan', 'Pérez', '111111111', 'juanperez@mail.com', 'passJuan', NULL, CURDATE(), NULL),
('María', 'Gómez', '222222222', 'mariagomez@mail.com', 'passMaria', NULL, CURDATE(), NULL),
('Carlos', 'Ruiz', '333333333', 'carlosruiz@mail.com', 'passCarlos', NULL, CURDATE(), NULL),
('Ana', 'Torres', '444444444', 'anatorres@mail.com', 'passAna', NULL, CURDATE(), NULL),
('Lucía', 'Martínez', '555555555', 'luciamartinez@mail.com', 'passLucia', NULL, CURDATE(), NULL);

INSERT INTO Usuarios (nombre, apellido, telefono, email, contraseña, imagen_perfil, fecha_registro, fecha_baja) VALUES
('Franco', 'Lopez', '344567', 'francolopez@gmial.com', 'passFranco', NULL, '2024-06-4', '2025-08-3');

-- Roles
INSERT INTO Roles(nombre) VALUES
('Administrador'),
('Usuario');


-- ROLES X USUARIO
INSERT INTO Roles_X_Usuario (rol_id, usuario_id) VALUES
(1, 1), 
(2, 2), 
(2, 3), 
(2, 4), 
(2, 5); 

-- PAISES
INSERT INTO Paises (nombre) VALUES
('Argentina'),
('Brasil'),
('Chile'),
('Uruguay'),
('Paraguay'),
('Bolivia'),
('Perú'),
('Colombia'),
('Venezuela'),
('México'),
('España'),
('Italia'),
('Francia'),
('Alemania'),
('Estados Unidos');


-- CATEGORIAS
INSERT INTO Categorias (nombre, descripcion) VALUES
('Postres', 'Recetas dulces como tortas, tartas, flanes y helados.'),
('Pastas', 'Platos a base de pastas frescas o secas con diferentes salsas.'),
('Carnes', 'Recetas con carne vacuna, cerdo, pollo o cordero.'),
('Veganas', 'Preparaciones libres de ingredientes de origen animal.'),
('Vegetarianas', 'Platos sin carne, pero que pueden incluir lácteos y huevos.'),
('Ensaladas', 'Recetas frescas y saludables a base de vegetales y otros ingredientes.'),
('Sopas y Cremas', 'Platos calientes como sopas, caldos y cremas.'),
('Panadería', 'Recetas de panes, facturas, galletas y bollería en general.'),
('Comida Rápida', 'Platos fáciles y rápidos como hamburguesas, pizzas y tacos.');

-- RECETAS 
INSERT INTO Recetas (nombre, descripcion, instrucciones, imagen_receta, tiempo_preparacion, dificultad, fecha_baja, pais_id, categoria_id, usuario_id) VALUES
('Torta de Chocolate', 'Un clásico postre húmedo y delicioso.', 'Mezclar ingredientes, hornear 45 minutos.', NULL, '01:00:00', 'Media', NULL, 1, 1, 1),
('Tacos al Pastor', 'Tacos mexicanos con carne adobada.', 'Marinar carne, cocinar y servir en tortillas.', NULL, '00:40:00', 'Media', NULL, 2, 2, 1),
('Pizza Margarita', 'Pizza italiana con tomate, queso y albahaca.', 'Preparar masa, colocar ingredientes y hornear.', NULL, '01:30:00', 'Fácil', NULL, 3, 2, 1),
('Paella', 'Plato español con arroz, mariscos y verduras.', 'Cocinar arroz con caldo, añadir ingredientes.', NULL, '02:00:00', 'Difícil', NULL, 4, 2, 1),
('Sushi Roll', 'Rolls japoneses de arroz y pescado.', 'Enrollar arroz con pescado y alga nori.', NULL, '01:20:00', 'Difícil', NULL, 5, 5, 1);

INSERT INTO Recetas (nombre, descripcion, instrucciones, imagen_receta, tiempo_preparacion, dificultad, fecha_baja, pais_id, categoria_id, usuario_id) VALUES
('Bizcochuelo de vainilla', 'Un rico bizcochuelo para compartir', 'Mezclar huevos, leche y al horno', NULL, '00:45:00', 'Fácil', '2025-09-21', 3, 4, 1);

-- TIPO INGREDIENTE
INSERT INTO Tipos_de_ingredientes (nombre) VALUES
('Lácteos'),
('Carnes'),
('Vegetales'),
('Cereales'),
('Especias');

-- UNIDADES DE MEDIDAS
INSERT INTO Unidades_de_medidas (nombre) VALUES
('Gramos'),
('Litros'),
('Cucharadas'),
('Tazas'),
('Unidades');


-- INGREDIENTES
INSERT INTO Ingredientes (nombre, tipo_ingrediente_id, unidad_de_medida_id) VALUES
('Leche', 1, 2),
('Pollo', 2, 1),
('Zanahoria', 3, 1),
('Arroz', 4, 1),
('Sal', 5, 3);

-- INGREDIENTES POR RECETA
INSERT INTO Ingredientes_X_Receta (cantidad, ingrediente_id, receta_id) VALUES
(200, 1, 1), -- Leche en Torta de Chocolate
(300, 2, 2), -- Pollo en Tacos
(100, 3, 4), -- Zanahoria en Paella
(250, 4, 4), -- Arroz en Paella
(1, 5, 3);   -- Sal en Pizza Margarita

INSERT INTO Ingredientes_X_Receta (cantidad, ingrediente_id, receta_id) VALUES
(120, 3, 2); 

-- ME GUSTAS
INSERT INTO Me_gustas (fecha_me_gusta, receta_id, usuario_id) VALUES
(CURDATE(), 1, 2),
(CURDATE(), 2, 3),
(CURDATE(), 3, 4),
(CURDATE(), 4, 5),
(CURDATE(), 5, 1);

INSERT INTO Me_gustas (fecha_me_gusta, receta_id, usuario_id) VALUES
(CURDATE(), 2, 4);


-- COMENTARIOS
INSERT INTO Comentarios (descripcion, fecha_comentario, fecha_borrado, receta_id, usuario_id) VALUES
('Muy rica la torta, me salió genial.', CURDATE(), NULL, 1, 2),
('Los tacos estuvieron espectaculares.', CURDATE(), NULL, 2, 3),
('La pizza estaba un poco salada.', CURDATE(), NULL, 3, 4),
('La paella me resultó complicada, pero deliciosa.', CURDATE(), NULL, 4, 5),
('El sushi fue todo un éxito en casa.', CURDATE(), NULL, 5, 1);

-- FAVORITAS
INSERT INTO Favoritas (usuario_id, receta_id) VALUES
(1, 3), -- Juan -> Pizza Margarita
(2, 1), -- María -> Torta de Chocolate
(3, 5), -- Carlos -> Sushi
(4, 2), -- Ana -> Tacos
(5, 4); -- Lucía -> Paella

-- HISTORIAL
INSERT INTO Historiales (fecha_visita, usuario_id, receta_id) VALUES
(CURDATE(), 1, 1),
(CURDATE(), 2, 2),
(CURDATE(), 3, 3),
(CURDATE(), 4, 4),
(CURDATE(), 5, 5);

-- AUDITORIA
INSERT INTO Auditorias (tipo_modificacion, fecha_modificacion, usuario_id, receta_id) VALUES
('Inserción', CURRENT_TIMESTAMP, 1, 1),
('Modificación', CURRENT_TIMESTAMP, 2, 2),
('Eliminación', CURRENT_TIMESTAMP, 3, 3),
('Inserción', CURRENT_TIMESTAMP, 4, 4),
('Modificación', CURRENT_TIMESTAMP, 5, 5);


-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------- STORE PROCEDURE -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------
Select * from usuarios;
-- 1) INSERTAR A UN USUARIO
DELIMITER $$
CREATE PROCEDURE Insertar_usuario(
IN p_nombre VARCHAR (50), 
IN p_apellido VARCHAR (50), 
IN p_telefono VARCHAR (20), 
IN p_email VARCHAR (50), 
IN p_contraseña VARCHAR (20), 
IN p_imagen_perfil BLOB)
BEGIN 
	DECLARE var_usuario_id INT;
    
	INSERT INTO Usuarios(nombre, apellido, telefono, email, contraseña, imagen_perfil, fecha_registro)VALUES
    (p_nombre, p_apellido, p_telefono, p_email, p_contraseña, p_imagen_perfil, CURDATE());
    
    SET var_usuario_id = last_insert_id();
    
    IF(var_usuario_id = 1)THEN
		
        INSERT INTO Roles_X_Usuario(rol_id, usuario_id)VALUES
        (1, var_usuario_id);
    ELSE
			INSERT INTO Roles_X_Usuario(rol_id, usuario_id)VALUES
            (2, var_usuario_id);
    END IF;
END$$
DELIMITER ;

-- CALL Insertar_usuario('Julian', 'Alvarez', '2234575790', 'julianalvarez@gmail.com', 654321, null);
SELECT * FROM Usuarios;

-- 2) INSERTAR UNA RECETA
DELIMITER $$
CREATE PROCEDURE Insertar_receta(
IN p_nombre VARCHAR(50), 
IN p_descripcion TEXT, 
IN p_instrucciones TEXT,
IN p_imagen_receta BLOB, 
IN p_tiempo_preparacion TIME,
IN p_dificultad ENUM ('Fácil', 'Media', 'Difícil'),
IN p_pais_id INT, 
IN p_categoria_id INT, 
IN p_usuario_id INT)
BEGIN
	IF(p_usuario_id = 1)THEN
		INSERT INTO Recetas(nombre, descripcion, instrucciones, imagen_receta, tiempo_preparacion, dificultad, pais_id, categoria_id, usuario_id)VALUES
		(p_nombre, p_descripcion, p_instrucciones, p_imagen_receta, p_tiempo_preparacion, p_dificultad, p_pais_id, p_categoria_id, p_usuario_id);
	ELSE
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Para insertar una receta tienes que ser un administrador';
	END IF;
END $$
DELIMITER ;

CALL Insertar_receta('Papas fritas ricas', 'Papitas sabrosas', 'pelar, cortar y freir la papita', null, '00:10:00', 'Fácil', 4, 3, 1);
SELECT * FROM Recetas;


-- 3) INSERTAR CATEGORIA NUEVA ADMINISTRADOR
DELIMITER $$
CREATE PROCEDURE Insertar_categoria(
IN p_nombre VARCHAR(50),
IN p_descripcion TEXT
)
BEGIN
	INSERT INTO Categorias(nombre, descripcion)VALUES
    (p_nombre, p_descripcion);
END $$
DELIMITER ;

CALL Insertar_categoria('helados', 'helados ricos');
SELECT * FROM Categorias;


-- 4) INSERTAR DE TIPO DE INGREDIENTE
DELIMITER $$
CREATE PROCEDURE Insertar_tipo_ingrediente(
IN p_nombre VARCHAR (50)
)
BEGIN
	INSERT INTO Tipos_de_ingredientes(nombre)VALUES
    (p_nombre);
END$$
DELIMITER ;

CALL Insertar_tipo_ingrediente('Vegano');
SELECT * FROM Tipos_de_ingredientes;

-- 5) INSERT UNIDADES DE MEDIDAS
DELIMITER $$
CREATE PROCEDURE Insertar_unidad_de_medida(
IN p_nombre VARCHAR(50)
)
BEGIN
	INSERT INTO Unidades_de_medidas(nombre)VALUES
    (p_nombre);
END$$
DELIMITER ;

CALL Insertar_unidad_de_medida('JARRON');
SELECT * FROM Unidades_de_medidas;

-- 6) INSERTAR INGREDIENTES
DELIMITER $$
CREATE PROCEDURE Insertar_ingrediente(
IN p_nombre VARCHAR(50),
IN p_tipo_ingrediente_id INT,
IN p_unidad_de_medida_id INT
)
BEGIN
	INSERT INTO Ingredientes(nombre, tipo_ingrediente_id, unidad_de_medida_id)VALUES
    (p_nombre, p_tipo_ingrediente_id, p_unidad_de_medida_id);
END$$
DELIMITER ;

CALL Insertar_ingrediente('Kiwi', 2, 5);
SELECT * FROM Ingredientes;

-- 7) INSERTAR INGREDIENTES POR RECETAS
DELIMITER $$
CREATE PROCEDURE Insertar_ingrediente_por_receta(
IN p_cantidad VARCHAR(50),
IN p_ingrediente_id INT,
IN p_receta_id INT
)
BEGIN
	INSERT INTO Ingredientes_X_Receta(cantidad, ingrediente_id, receta_id)VALUES
    (p_cantidad, p_ingrediente_id, p_receta_id);
END$$
DELIMITER ;

CALL Insertar_ingrediente_por_receta('7', 2, 4);
SELECT * FROM Ingredientes_X_Receta;

-- 8) INSERTAR ME GUSTAS
DELIMITER $$
CREATE PROCEDURE Insertar_me_gusta(
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
		INSERT INTO Me_gustas(fecha_me_gusta, receta_id, usuario_id)VALUES
        (CURDATE(), p_receta_id, p_usuario_id);
END $$
DELIMITER ;

CALL Insertar_me_gusta(3,2);
SELECT * FROM Me_gustas;


-- 9) INSERTAR COMENTARIOS
DELIMITER $$
CREATE PROCEDURE Insertar_comentario(
IN p_descripcion TEXT,
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
		INSERT INTO Comentarios(descripcion, fecha_comentario, fecha_borrado, receta_id, usuario_id)VALUES
        (p_descripcion, CURDATE(), CURDATE(), p_receta_id, p_usuario_id);
END$$
DELIMITER ;

CALL Insertar_comentario('Muy buena la receta, la hice y me encantó', 5, 1);
SELECT * FROM Comentarios;


-- 10) INSERTAR RECETA FAVORITA
DELIMITER $$
CREATE PROCEDURE Insertar_favorita(
IN p_usuario_id INT,
IN p_receta_id INT
)
BEGIN
	INSERT INTO Favoritas(usuario_id, receta_id)VALUES
    (p_usuario_id, p_receta_id);
END$$
DELIMITER ;

CALL Insertar_favorita(2,4);
SELECT * FROM Favoritas; 


-- 11) INSERTAR HISTORIAL
DELIMITER $$
CREATE PROCEDURE Insertar_historial(
IN p_usuario_id INT,
IN p_receta_id INT
)
BEGIN
		INSERT INTO Historiales(fecha_visita, usuario_id, receta_id)VALUES
        (CURDATE(), p_usuario_id, p_receta_id);
END$$

CALL Insertar_historial(5, 4);
SELECT * FROM Historiales;

-- 12) INSERT AUDITORIA
DELIMITER $$
CREATE PROCEDURE Insertar_auditoria(
IN p_tipo_modificacion VARCHAR(50),
IN p_usuario_id INT,
IN p_receta_id INT
)
BEGIN
	INSERT INTO Auditorias(tipo_modificacion, fecha_modificacion, usuario_id, receta_id)VALUES
    (p_tipo_modificacion, CURDATE(), p_usuario_id, p_receta_id);
END$$
DELIMITER ;

CALL Insertar_auditoria('Agregar',1,2);
SELECT * FROM Auditorias;


-- 13) MÉTRICAS PARA EL ADMINISTRADOR

DELIMITER $$
CREATE PROCEDURE Metricas_administrador(
IN p_usuario_id INT, OUT cantidad_me_gustas INT, OUT cantidad_comentarios INT, OUT cantidad_de_vistas INT 
)
BEGIN
	IF(p_usuario_id = 1)THEN
    
		SELECT
				funcion_cantidad_me_gustas(3),
				funcion_cantidad_de_comentarios(3),
				funcion_cantidad_de_vistas(3) 
                INTO cantidad_me_gustas, cantidad_comentarios, cantidad_de_vistas;
	ELSE
				SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'El usuario debe ser de aministrador';
	END IF;
END $$
DELIMITER ;

SET @megustas = 0;
SET @comentario = 0;
SET @vistas = 0;

CALL Metricas_administrador(1, @megustas, @comentario, @vistas) ;
select @megustas,@comentario, @vistas

-- 14) STORE QUE DEVUELVE UN USUARIO
DELIMITER $$
CREATE PROCEDURE Procedimiento_que_busca_usuario(
INOUT p_email VARCHAR(50), 
OUT p_usuario_id INT,
OUT p_nombre VARCHAR(50), 
OUT p_apellido VARCHAR(50), 
OUT p_telefono VARCHAR(20),
OUT p_imagen_perfil BLOB,
OUT p_rol_id INT
)
BEGIN
		SELECT
				 U.email, U.usuario_id, U.nombre, U.apellido, U.telefono, U.imagen_perfil, R.rol_id AS ID_rol
                
                INTO p_email, p_usuario_id, p_nombre, p_apellido, p_telefono, p_imagen_perfil, p_rol_id
                
		FROM
				Usuarios AS U
                INNER JOIN Roles_X_Usuario AS RXU ON U.usuario_id = RXU.usuario_id
                INNER JOIN Roles AS R ON RXU.rol_id = R.rol_id
                
		WHERE 
				email = p_email;
END $$
DELIMITER ;

SET @email = 'mariagomez@mail.com';
SET @usuario_id = 0;
SET @nombre = '';
SET @apellido = '';
SET @telefono = '';
SET @imagen_perfil = NULL;
SET @rol_id = 0;

CALL Procedimiento_que_busca_usuario(@email, @usuario_id, @nombre, @apellido, @telefono, @imagen_perfil, @rol_id);
SELECT @email, @usuario_id, @nombre, @apellido, @telefono, @imagen_perfil, @rol_id;


-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------- VISTAS -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------

-- 1) Vista de todos los usuarios 
CREATE VIEW Vista_todos_los_usuarios AS
SELECT
		nombre, apellido, telefono, email, imagen_perfil
FROM
		Usuarios;
SELECT * FROM Vista_todos_los_usuarios;

-- 2) Vista de todas las recetas
CREATE VIEW Vista_todas_las_recetas AS
SELECT
		R.nombre, R.descripcion, R.instrucciones, R.imagen_receta, R.tiempo_preparacion, R.dificultad, C.nombre AS Categoria, P.nombre AS Pais
FROM
		Recetas AS R
        INNER JOIN Categorias AS C ON R.categoria_id = C.categoria_id
        INNER JOIN Paises AS P ON R.pais_id = P.pais_id;
        
SELECT * FROM Vista_todas_las_recetas;


-- 3) Vista de todas los paises
CREATE VIEW Vista_de_todos_los_paises AS
SELECT
		nombre AS Nombre
FROM
		Paises;
SELECT * FROM Vista_de_todos_los_paises;

-- 4) vista de todos los ingredientes
CREATE VIEW Vista_de_todos_los_ingredientes AS
SELECT
		nombre AS Nombre
FROM
		Ingredientes;
SELECT * FROM Vista_de_todos_los_ingredientes;

-- 5) Vista de todas las unidades de medida
CREATE VIEW Vista_de_todas_las_unidades_de_medida AS
SELECT
		nombre AS Nombre
FROM
		Unidades_de_medidas;
SELECT * FROM Vista_de_todas_las_unidades_de_medida;
        
-- 6) Vista de todos los tipos de ingredientes
CREATE VIEW Vista_de_todas_los_tipos_de_ingredientes AS
SELECT
		nombre AS Nombre
FROM
		Tipos_de_ingredientes;
SELECT * FROM Vista_de_todas_los_tipos_de_ingredientes;

-- 7) Vista de todos los ingredientes con el tipo de ingrediente y la unidad de medida
CREATE VIEW Vista_de_todos_los_ingredientes_tipo_y_unidad AS
SELECT
		I.nombre AS Nombre, T.nombre AS Tipo_ingrediente, U.nombre AS Unidad
FROM
		Ingredientes  AS I
        INNER JOIN Tipos_de_ingredientes AS T ON I.tipo_ingrediente_id = T.tipo_ingrediente_id
        INNER JOIN Unidades_de_medidas AS U ON I.unidad_de_medida_id = U.unidad_de_medida_id;

SELECT * FROM Vista_de_todos_los_ingredientes_tipo_y_unidad;

-- 8) Vista de todos los usuarios activos
CREATE VIEW Vista_de_todos_los_usuarios_activos AS
SELECT
		nombre, apellido, telefono, email, imagen_perfil
FROM
		Usuarios
WHERE
		fecha_baja IS NULL;

SELECT * FROM Vista_de_todos_los_usuarios_activos;

-- 9) vista de todos los usuarios inactivos
CREATE VIEW Vista_de_todos_los_usuarios_inactivos AS
SELECT
		nombre, apellido, telefono, email, imagen_perfil
FROM
		Usuarios
WHERE
		fecha_baja IS NOT NULL;
        
SELECT * FROM Vista_de_todos_los_usuarios_inactivos;

-- 10) Vista de todas las recetas activas
CREATE VIEW Vista_de_todas_las_recetas_activas AS
SELECT
		R.nombre, R.descripcion, R.instrucciones, R.imagen_receta, R.tiempo_preparacion, R.dificultad, C.nombre AS Categoria, P.nombre AS Pais
FROM
		Recetas AS R
        INNER JOIN Categorias AS C ON R.categoria_id = C.categoria_id
        INNER JOIN Paises AS P ON R.pais_id = P.pais_id
WHERE
		fecha_baja IS NULL;
        
SELECT * FROM Vista_de_todas_las_recetas_activas;

-- 11) Vista de todas las recetas inactivas 
CREATE VIEW Vista_de_todas_las_recetas_inactivas AS
SELECT 
		R.nombre, R.descripcion, R.instrucciones, R.imagen_receta, R.tiempo_preparacion, R.dificultad, C.nombre AS Categoria, P.nombre AS Pais
FROM
		Recetas AS R
        INNER JOIN Categorias AS C ON R.categoria_id = C.categoria_id
        INNER JOIN Paises AS P ON R.pais_id = P.pais_id
WHERE
		fecha_baja IS NOT NULL;

SELECT * FROM Vista_de_todas_las_recetas_inactivas;

-- 12) Vista de los comentarios
CREATE VIEW Vista_de_los_comentarios AS
SELECT
		C.descripcion, C.fecha_comentario, R.nombre AS Nombre_receta, U.nombre AS Nombre_usuario
FROM
		Comentarios AS C
        INNER JOIN Recetas AS R ON C.receta_id = R.receta_id
        INNER JOIN Usuarios AS U ON C.usuario_id = U.usuario_id;
        
 SELECT * FROM  Vista_de_los_comentarios;      
        
-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------- FUNCIONES -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------

-- 1)Función para contar me gustas
DELIMITER $$
CREATE FUNCTION funcion_cantidad_me_gustas(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_me_gustas INT;
	SELECT
			COUNT(me_gusta_id) INTO cantidad_me_gustas
	FROM
			Me_gustas
	WHERE
			receta_id = p_receta_id;
	RETURN cantidad_me_gustas;
END $$
DELIMITER ;

SELECT funcion_cantidad_me_gustas(2);

-- 2) Función cantidad de vistas
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_vistas(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_vistas INT;
	SELECT
			COUNT(historial_id) INTO cantidad_de_vistas
	FROM
			Historiales
	WHERE
			receta_id = p_receta_id;
	RETURN cantidad_de_vistas;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_vistas(3);

-- 3) Función cantidad de comentarios
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_comentarios(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_comentarios INT;
	SELECT
			COUNT(comentario_id) INTO cantidad_de_comentarios
	FROM
			Comentarios
	WHERE
			receta_id = p_receta_id;
	RETURN cantidad_de_comentarios;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_comentarios(3);

-- 4) Función cantidad de recetas
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_recetas()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_recetas INT;
	SELECT
			COUNT(receta_id) INTO cantidad_de_recetas
	FROM
			Recetas;
            
	RETURN cantidad_de_recetas;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_recetas();

-- 5) Función cantidad de usuarios
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_usuarios()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_usuarios INT;
	SELECT
			COUNT(usuario_id) INTO cantidad_de_usuarios
	FROM
			Usuarios;
            
	RETURN cantidad_de_usuarios;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_usuarios();

-- 6) Función cantidad de usuarios comunes
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_usuarios_comunes()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_usuarios_comunes INT;
	SELECT
			COUNT(usuario_id) INTO cantidad_de_usuarios_comunes
	FROM
			Usuarios
	WHERE 
			usuario_id <> 1;
            
	RETURN cantidad_de_usuarios_comunes;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_usuarios_comunes();


-- 7) Función cantidad de administradores
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_usuarios_administradores()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_usuarios_administradores INT;
	SELECT
			COUNT(usuario_id) INTO cantidad_de_usuarios_administradores
	FROM
			Usuarios
	WHERE 
			usuario_id = 1;
            
	RETURN cantidad_de_usuarios_administradores;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_usuarios_administradores();

-- 8) Función cantidad de favoritas segun id de la receta
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_favoritas(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_recetas_favoritas INT;
	SELECT
			COUNT(favorita_id) INTO cantidad_de_recetas_favoritas
	FROM
			Favoritas
	WHERE
			p_receta_id = receta_id;
            
	RETURN cantidad_de_recetas_favoritas;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_favoritas(3);

-- 9) Función cantidad de paises
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_paises()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_paises INT;
	SELECT
			COUNT(pais_id) INTO cantidad_de_paises
	FROM
			Paises;
            
	RETURN cantidad_de_paises;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_paises();

-- 10) Función cantidad de categorias
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_categorias()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_categorias INT;
	SELECT
			COUNT(categoria_id) INTO cantidad_de_categorias
	FROM
			Categorias;
            
	RETURN cantidad_de_categorias;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_categorias();


-- 11) Función cantidad de ingredientes

DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_ingredientes()
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_ingredientes INT;
	SELECT
			COUNT(ingrediente_id) INTO cantidad_de_ingredientes
	FROM
			Ingredientes;
            
	RETURN cantidad_de_ingredientes;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_ingredientes();

-- 12) Función cantidad de ingredientes por receta
DELIMITER $$
CREATE FUNCTION funcion_cantidad_de_ingredientes_x_receta(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
	DECLARE cantidad_de_ingredientes_x_receta INT;
	SELECT
			COUNT(ingrediente_id) INTO cantidad_de_ingredientes_x_receta
	FROM
			Ingredientes_X_Receta 
     WHERE
			receta_id = p_receta_id;
	RETURN cantidad_de_ingredientes_x_receta;
END $$
DELIMITER ;

SELECT funcion_cantidad_de_ingredientes_x_receta(2);

-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------- ÍNDICES -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------








