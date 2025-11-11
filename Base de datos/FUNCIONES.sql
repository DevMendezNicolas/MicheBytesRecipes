USE MicheBytes;
-- EJECUTAR SEGUNDO
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

-- 3 bis) Funcion cantidad de favoritos
DELIMITER $$
CREATE FUNCTION funcion_cantidad_favoritos(p_receta_id INT)
RETURNS INT
NOT DETERMINISTIC
READS SQL DATA
BEGIN
  DECLARE cantidad_favoritos INT;
  SELECT COUNT(favorita_id) INTO cantidad_favoritos
  FROM Favoritas
  WHERE receta_id = p_receta_id;
  RETURN cantidad_favoritos;
END $$
DELIMITER ;

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


-- 11) Función cantidad de ingredientes por receta
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

-- 12) Funcion de devolver el nombre de pais en base al id
DELIMITER $$
CREATE FUNCTION Devolver_nombre_pais(p_pais_id INT)
RETURNS VARCHAR(50)
DETERMINISTIC
BEGIN
		DECLARE devolver_pais VARCHAR(50);
        
		SELECT
				nombre INTO devolver_pais
		FROM
				Paises
		WHERE
				pais_id = p_pais_id;
		RETURN devolver_pais;
END$$
DELIMITER ;

-- 13)Tipo ingrediente
DELIMITER $$
CREATE FUNCTION Devolver_tipo_ingrediente(p_tipo_ingrediente_id INT)
RETURNS VARCHAR(50)
DETERMINISTIC
BEGIN
	DECLARE devolver_ingrediente VARCHAR(50);
	SELECT
			nombre INTO devolver_ingrediente
	FROM
			Tipos_de_ingredientes
	WHERE
			tipo_ingrediente_id = p_tipo_ingrediente_id;
            
	RETURN devolver_ingrediente;

END$$
DELIMITER ;

-- 14) Funcion devolver el nombre de la categoria 
DELIMITER $$
CREATE FUNCTION devolver_nombre_categoria(p_categoria_id INT)
RETURNS VARCHAR(50)
DETERMINISTIC
BEGIN
	DECLARE devolver_categoria VARCHAR(50);
	SELECT
			nombre INTO devolver_categoria
	FROM
			Categorias
	WHERE
			categoria_id = p_categoria_id;

	RETURN devolver_categoria;

END $$
DELIMITER ;

-- 15) Funcion de devolver el nombre y apellido del usuarios pasandole el id 
DELIMITER $$
CREATE FUNCTION Devolver_nombre_usuario(p_usuario_id INT)
RETURNS VARCHAR(50)
DETERMINISTIC
BEGIN

		DECLARE v_nombre_usuario VARCHAR(50);
		SELECT
				CONCAT(nombre, ' ' , apellido) INTO v_nombre_usuario
		FROM
				Usuarios
		WHERE
				usuario_id = p_usuario_id;
		RETURN v_nombre_usuario;		
END$$
DELIMITER ;

-- 16) encontrar si existe o no usuario con ese mail
DELIMITER $$
CREATE FUNCTION Encontrar_usuario_por_email(p_email VARCHAR(50))
RETURNS INT
DETERMINISTIC
BEGIN
        DECLARE v_existe_usuario INT;

        SELECT 
                COUNT(*) INTO v_existe_usuario
        FROM
                Usuarios
        WHERE
                email = p_email;

        IF(v_existe_usuario > 0)THEN
            RETURN 1;
        ELSE
            RETURN 0;
        END IF;

END$$
DELIMITER ;