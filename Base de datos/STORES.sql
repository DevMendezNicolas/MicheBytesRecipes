USE MicheBytes;
-- EJECUTAR SEXTO
-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------- STORE PROCEDURE -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE Insertar_usuario(
IN p_nombre VARCHAR (50), 
IN p_apellido VARCHAR (50), 
IN p_telefono VARCHAR (20), 
IN p_email VARCHAR (50), 
IN p_contraseña VARCHAR (200), 
IN p_imagen_perfil LONGBLOB)
BEGIN 
	DECLARE var_usuario_id INT;
    
		DECLARE EXIT HANDLER FOR SQLEXCEPTION 
		BEGIN
			ROLLBACK;
			
			SELECT 'Ocurrio un error, no se puede insertar' AS Mensaje_de_error;
		END;
		
    START TRANSACTION;
	
	INSERT INTO Usuarios(nombre, apellido, telefono, email, contraseña, imagen_perfil, fecha_registro)VALUES
    (p_nombre, p_apellido, p_telefono, p_email, p_contraseña, p_imagen_perfil, CURDATE());
    
    SET var_usuario_id = LAST_INSERT_ID();
    
    IF(var_usuario_id = 1)THEN
		
        INSERT INTO Roles_X_Usuario(rol_id, usuario_id)VALUES
        (1, var_usuario_id);
    ELSE
			INSERT INTO Roles_X_Usuario(rol_id, usuario_id)VALUES
            (2, var_usuario_id);
    END IF;
    
    COMMIT;
    
    SELECT 'Usuario insertado con exito' AS Mensaje_de_exito;
END$$
DELIMITER ;

-- 2) INSERTAR UNA RECETA
DELIMITER $$
CREATE PROCEDURE Insertar_receta(
IN p_nombre VARCHAR(50), 
IN p_descripcion TEXT, 
IN p_instrucciones TEXT,
IN p_imagen_receta LONGBLOB, 
IN p_tiempo_preparacion TIME,
IN p_dificultad ENUM ('Fácil', 'Media', 'Difícil'),
IN p_pais_id INT, 
IN p_categoria_id INT, 
IN p_usuario_id INT,
OUT p_receta_id INT)
BEGIN
		
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    
		BEGIN
			ROLLBACK;
			SELECT 'Ocurrio un error, no se pudo insertar la receta' AS Mensaje_de_error;
		END ;

	
    START TRANSACTION;
    
		IF(p_usuario_id = 1)THEN
			INSERT INTO Recetas(nombre, descripcion, instrucciones, imagen_receta, tiempo_preparacion, dificultad, pais_id, categoria_id, usuario_id)VALUES
			(p_nombre, p_descripcion, p_instrucciones, p_imagen_receta, p_tiempo_preparacion, p_dificultad, p_pais_id, p_categoria_id, p_usuario_id);
			
			SET p_receta_id = LAST_INSERT_ID();

		ELSE
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Para insertar una receta tienes que ser un administrador';
		END IF;
        
        COMMIT;
        SELECT 'La receta fue insertada con éxito' AS Mensaje_de_exito;
END $$
DELIMITER ;

-- SET @receta_id = 0;

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

-- 7) INSERTAR INGREDIENTES POR RECETAS
DELIMITER $$
CREATE PROCEDURE Insertar_ingrediente_por_receta(
IN p_ingrediente_id INT,
IN p_receta_id INT
)
BEGIN
	INSERT INTO Ingredientes_X_Receta(ingrediente_id, receta_id)VALUES
    (p_ingrediente_id, p_receta_id);
END$$
DELIMITER ;

-- 8) INSERTAR ME GUSTAS 
DELIMITER $$
CREATE PROCEDURE Insertar_me_gusta(
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
		DECLARE v_rol VARCHAR(50);
        
		SELECT
				R.nombre INTO v_rol 
		FROM
				Roles AS R
                INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
                INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
		WHERE
				U.usuario_id = p_usuario_id;
                
                
		IF(v_rol = 'Administrador')THEN
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Los administradores no pueden dar "me gusta".';
		ELSE
			INSERT INTO Me_gustas(fecha_me_gusta, receta_id, usuario_id)VALUES
			(CURDATE(), p_receta_id, p_usuario_id);
        END IF;
END $$
DELIMITER ;

-- 9) INSERTAR COMENTARIOS
DELIMITER $$
CREATE PROCEDURE Insertar_comentario(
IN p_descripcion TEXT,
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
		INSERT INTO Comentarios(descripcion, fecha_comentario, receta_id, usuario_id)VALUES
        (p_descripcion, CURDATE(), p_receta_id, p_usuario_id);
END$$
DELIMITER ;


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
DELIMTER ;

DELIMITER $$
CREATE PROCEDURE Metricas_administrador(
IN p_rol_id INT, 
OUT cantidad_me_gustas INT, 
OUT cantidad_comentarios INT, 
OUT cantidad_de_vistas INT 
)
BEGIN
	IF(p_rol_id = 1)THEN
    
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

-- SET @megustas = 0;
-- SET @comentario = 0;
-- SET @vistas = 0;

-- 14) STORE QUE DEVUELVE UN USUARIO
DELIMITER $$
CREATE PROCEDURE Buscar_usuario(
INOUT p_email VARCHAR(50), 
OUT p_usuario_id INT,
OUT p_nombre VARCHAR(50), 
OUT p_apellido VARCHAR(50), 
OUT p_telefono VARCHAR(20),
OUT p_imagen_perfil LONGBLOB,
OUT p_rol_id INT, 
OUT p_fecha_registro DATE, 
OUT p_fecha_baja DATE
)
BEGIN
		SELECT
				 U.email, U.usuario_id, U.nombre, U.apellido, U.telefono, U.imagen_perfil, R.rol_id AS ID_rol, U.fecha_registro, U.fecha_baja
                
                INTO p_email, p_usuario_id, p_nombre, p_apellido, p_telefono, p_imagen_perfil, p_rol_id, p_fecha_registro, p_fecha_baja
                
		FROM
				Usuarios AS U
                INNER JOIN Roles_X_Usuario AS RXU ON U.usuario_id = RXU.usuario_id
                INNER JOIN Roles AS R ON RXU.rol_id = R.rol_id
                
		WHERE 
				email = p_email;
END $$
DELIMITER ;

-- SET @email = 'mariagomez@mail.com';
-- SET @usuario_id = 0;
-- SET @nombre = '';
-- SET @apellido = '';
-- SET @telefono = '';
-- SET @imagen_perfil = NULL;
-- SET @rol_id = 0;
-- SET @fecha_registro = '';
-- SET @fecha_baja = '';




-- 15) Procedimiento que inserta paises
DELIMITER $$
CREATE PROCEDURE Insertar_paises (
    IN p_nombre_pais VARCHAR(100)
)
BEGIN
    INSERT INTO Paises (nombre) VALUES 
    (p_nombre_pais);
END$$
DELIMITER ;

-- 16) Procedimiento que devuelva la receta 

DELIMITER $$
CREATE PROCEDURE Devolver_receta(
IN p_receta_id INT,
OUT p_nombre VARCHAR(50),
OUT p_descripcion TEXT,
OUT p_instrucciones TEXT,
OUT p_imagen_receta LONGBLOB,
OUT p_tiempo_preparacion TIME,
OUT p_dificultad VARCHAR(50),
OUT p_pais_id INT,
OUT p_categoria_id INT,
OUT p_usuario_id INT
)
BEGIN
		SELECT
				R.nombre, R.descripcion, R.instrucciones, R.imagen_receta, R.tiempo_preparacion, R.dificultad, R.pais_id, R.categoria_id, R.usuario_id
                
                
                INTO p_nombre, p_descripcion, p_instrucciones, p_imagen_receta, p_tiempo_preparacion, p_dificultad, p_pais_id, 
                p_categoria_id, p_usuario_id
		FROM
				Recetas AS R
		WHERE 
				R.receta_id = p_receta_id
		GROUP BY
				R.receta_id;
END$$
DELIMITER ;

-- SET @receta_id = 2;
-- SET @nombre = '';
-- SET @descripcion = '';
-- SET @instrucciones = '';
-- SET @imagen_receta = NULL;
-- SET @tiempo_preparacion = '';
-- SET @dificultad = '';
-- SET @pais_id = 0;
-- SET @categoria = 0;
-- SET @usuario = 0;


-- 17) Procedimiento para modificar receta 
DELIMITER $$
CREATE PROCEDURE Modificar_receta(
IN p_receta_id INT,
IN p_nombre VARCHAR(50),
IN p_descripcion TEXT,
IN p_instrucciones TEXT,
IN p_imagen_receta LONGBLOB,
IN p_tiempo_preparacion TIME,
IN p_dificultad VARCHAR(50),
IN p_pais_id INT,
IN p_categoria_id INT,
IN p_usuario_modificador_id INT
)
BEGIN
		DECLARE v_nombre_rol VARCHAR(50);
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
			SELECT 'ERROR.Ocurrio un error al modificar'AS Mensaje_de_error;
        END;

		START TRANSACTION;
        
        SELECT
				R.nombre INTO v_nombre_rol
		FROM
				Roles AS R
                INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
                INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
		WHERE 
				U.usuario_id = p_usuario_modificador_id;
        
        IF v_nombre_rol <> 'Administrador' THEN
        
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'El usuario debe ser administrador';
        ELSE
					DELETE 
						Ingredientes_X_Receta.*
					FROM
						Ingredientes_X_Receta
					WHERE
						receta_id = p_receta_id;
				
					UPDATE 
						Recetas
					SET 
						nombre = p_nombre,
						descripcion = p_descripcion,
						instrucciones = p_instrucciones,
						imagen_receta = p_imagen_receta,
						tiempo_preparacion = p_tiempo_preparacion,
						dificultad = p_dificultad,
						pais_id = p_pais_id,
						categoria_id = p_categoria_id,
						usuario_id = p_usuario_modificador_id
					WHERE 
						receta_id = p_receta_id;
						
						
				IF ROW_COUNT() = 0 THEN -- ROW_COUNT ES PARA VERIFICAR SI HUBO ALGUNA FILA AFECTADA POR EL UPDATE, SI ES = 0, NO SE ACTUALIZÓ NINGUNA Y VUELVE PARA ATRAS, SI SE AFECTO ALGUNA FILA DEVUELVE > 0 Y HACE COMMIT
					ROLLBACK;
				ELSE
					COMMIT;
					SELECT 'Modificación exitosa' AS Mensaje_de_exito;
				END IF;
        END IF;	
END$$
DELIMITER ;

-- 18) Dar de baja receta 
DELIMITER $$
CREATE PROCEDURE Dar_de_baja_receta (
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
       DECLARE v_nombre_rol VARCHAR(50);
       DECLARE EXIT HANDLER FOR SQLEXCEPTION
            BEGIN
                SELECT 'ERROR.Ocurrio un error al modificar'AS Mensaje_de_error;
            END;
    
       START TRANSACTION;
    
           SELECT
                    R.nombre INTO v_nombre_rol
           FROM
                    Roles AS R
                    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
                    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
            WHERE 
                    RXU.usuario_id = p_usuario_id;

           IF v_nombre_rol <> 'Administrador' THEN
                SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'El usuario debe ser administrador';
            ELSE
                -- Verificamos que exista la receta y no esté dada de baja ya
                IF EXISTS (
                    SELECT
                            1
                    FROM 
                            Recetas 
                    WHERE 
                        receta_id = p_receta_id AND fecha_baja IS NULL
                ) THEN
                    -- Se actualiza la fecha de baja
                    UPDATE 
                            Recetas
                    SET 
                            fecha_baja = CURDATE()
                    WHERE
                            receta_id = p_receta_id;
                    COMMIT;
                    SELECT 'Receta dada de baja con exito'AS Mensaje_de_exito;
                ELSE
                    
                    -- Si no existe o ya está dada de baja, se lanza un mensaje
                    SIGNAL SQLSTATE '45000'
                    SET MESSAGE_TEXT = 'La receta no existe o ya fue dada de baja.';

                END IF;
            END IF;
END$$
DELIMITER ;


-- 19) Dar de alta receta. Verificar que el que la de de alta sea admin, y agregar esta modificacion a auditoria
DELIMITER $$
CREATE PROCEDURE Reactivar_receta (
IN p_receta_id INT,
IN p_usuario_id INT
)
BEGIN
       DECLARE v_nombre_rol VARCHAR(50);
       
       DECLARE EXIT HANDLER FOR SQLEXCEPTION
            BEGIN
                SELECT 'ERROR.Ocurrio un error al modificar'AS Mensaje_de_error;
            END;

       START TRANSACTION;
       
           SELECT
                    R.nombre INTO v_nombre_rol
           FROM
                    Roles AS R
                    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
                    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
           WHERE 
                    RXU.usuario_id = p_usuario_id;

           IF v_nombre_rol <> 'Administrador' THEN
            
                SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'El usuario debe ser administrador';
           ELSE
                -- Verificamos si la receta existe y está dada de baja
                IF EXISTS (
                    SELECT 
                            1
                    FROM
                            Recetas
                    WHERE receta_id = p_receta_id AND fecha_baja IS NOT NULL
                ) THEN
                    -- Si está dada de baja, la reactivamos
                    UPDATE 
                            Recetas
                    SET 
                            fecha_baja = NULL
                            
                    WHERE receta_id = p_receta_id;
                    COMMIT;
                    SELECT 'Receta reactivada con exito'AS Mensaje_de_exito;
                ELSE
                    SIGNAL SQLSTATE '45000'
                    SET MESSAGE_TEXT = 'La receta no existe o ya está activa.';
                    
                END IF;
           END IF;
END$$
DELIMITER ;

-- 20) ELIMINAR FAVORITAS

DELIMITER $$
CREATE PROCEDURE Eliminar_favorita(
IN p_usuario_id INT,
IN p_receta_id INT
)
BEGIN
    DELETE 
    FROM 
		Favoritas
    WHERE usuario_id = p_usuario_id AND receta_id = p_receta_id;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE Eliminar_comentario(
IN p_usuario_id INT,
IN p_receta_id INT,
IN p_descripcion text
)
BEGIN
    DELETE 
    FROM 
		Comentarios
    WHERE usuario_id = p_usuario_id AND receta_id = p_receta_id AND descripcion = p_descripcion;
END$$
DELIMITER ;

-- 21) CAMBIAR CONTRASEÑA

DELIMITER $$
CREATE PROCEDURE Cambiar_contraseña(
IN p_usuario_id INT,
IN p_contraseña_actual VARCHAR(255),
IN p_nueva_contraseña VARCHAR(255)
)
BEGIN
		DECLARE v_contraseña_actual VARCHAR(255);
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
				ROLLBACK;
                SELECT 'Error. No se pudo cambiar contraseña';
        END;
		
		START TRANSACTION;
        
			SELECT
					contraseña INTO v_contraseña_actual
			FROM
					Usuarios
			WHERE 
					usuario_id = p_usuario_id;
			
			IF v_contraseña_actual IS NULL THEN
				SIGNAL SQLSTATE '45000'
				SET MESSAGE_TEXT = 'Error. Contraseña nula.';
			END IF;
			
			IF v_contraseña_actual <> p_contraseña_actual THEN
				SIGNAL SQLSTATE '45000'
				SET MESSAGE_TEXT = 'Contraseña incorrecta no puede cambiarla';	
			END IF;

			IF p_nueva_contraseña = v_contraseña_actual THEN
				SIGNAL SQLSTATE '45000'
				SET MESSAGE_TEXT = 'Contraseña invalida. No puede usuar la misma contraseña';	
			END IF;
		
        
			UPDATE
					Usuarios
			SET
					contraseña = p_nueva_contraseña
			WHERE
					usuario_id = p_usuario_id;
		COMMIT;
        
        SELECT 'Contraseña cambiada exitosamente';	
END$$
DELIMITER ;

-- 22) Dar de baja usuario
DELIMITER $$
CREATE PROCEDURE Dar_de_baja_usuario(
    IN p_usuario_id INT,
    IN p_admin_id INT
)
BEGIN
    DECLARE v_nombre_rol VARCHAR(50);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'ERROR. Ocurrió un error al modificar' AS Mensaje_de_error;
    END;

    START TRANSACTION;

    -- Verificamos que el usuario que ejecuta sea administrador
    SELECT R.nombre INTO v_nombre_rol
    FROM Roles AS R
    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
    WHERE U.usuario_id = p_admin_id
    LIMIT 1;

    IF v_nombre_rol <> 'Administrador' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario debe ser administrador';
    ELSE
        -- Verificamos que el usuario a dar de baja exista y no esté dado de baja
        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE usuario_id = p_usuario_id AND fecha_baja IS NULL
        ) THEN
            -- Se actualiza la fecha de baja
            UPDATE Usuarios
            SET fecha_baja = CURDATE()
            WHERE usuario_id = p_usuario_id;

            COMMIT;
            SELECT 'Usuario dado de baja con éxito' AS Mensaje_de_exito;
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'El usuario no existe o ya fue dado de baja.';
        END IF;
    END IF;
END$$
DELIMITER ;


-- 23) Dar de alta usuario
DELIMITER $$
CREATE PROCEDURE Dar_de_alta_usuario(
    IN p_usuario_id INT,
    IN p_admin_id INT
)
BEGIN
    DECLARE v_nombre_rol VARCHAR(50);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'ERROR. Ocurrió un error al modificar' AS Mensaje_de_error;
    END;

    START TRANSACTION;

    -- Verificamos que el usuario que ejecuta sea administrador
    SELECT R.nombre INTO v_nombre_rol
    FROM Roles AS R
    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
    WHERE U.usuario_id = p_admin_id
    LIMIT 1;

    IF v_nombre_rol <> 'Administrador' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario debe ser administrador';
    ELSE
        -- Verificamos que el usuario exista y esté dado de baja
        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE usuario_id = p_usuario_id AND fecha_baja IS NOT NULL
        ) THEN
            -- Se actualiza la fecha de baja a NULL para reactivarlo
            UPDATE Usuarios
            SET fecha_baja = NULL
            WHERE usuario_id = p_usuario_id;

            COMMIT;
            SELECT 'Usuario dado de alta con éxito' AS Mensaje_de_exito;
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'El usuario no existe o ya está activo.';
        END IF;
    END IF;
END$$

DELIMITER ;


-- 24) Asignar Permisos
DELIMITER $$
CREATE PROCEDURE Asignar_rol_administrador(
    IN p_usuario_id INT,
    IN p_admin_id INT
)
BEGIN
    DECLARE v_nombre_rol VARCHAR(50);
    DECLARE v_rol_admin_id INT;
    DECLARE v_rol_usuario_id INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'ERROR. Ocurrió un error al modificar el rol' AS Mensaje_de_error;
    END;

    START TRANSACTION;

    -- Verificamos que el usuario que ejecuta sea administrador
    SELECT R.nombre INTO v_nombre_rol
    FROM Roles AS R
    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
    WHERE U.usuario_id = p_admin_id
    LIMIT 1;

    IF v_nombre_rol <> 'Administrador' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario debe ser administrador';
    ELSE
        -- Obtenemos los IDs de los roles "Administrador" y "Usuario"
        SELECT rol_id INTO v_rol_admin_id FROM Roles WHERE nombre = 'Administrador' LIMIT 1;
        SELECT rol_id INTO v_rol_usuario_id FROM Roles WHERE nombre = 'Usuario' LIMIT 1;

        -- Verificamos que el usuario tenga el rol "Usuario"
        IF EXISTS (
            SELECT 1
            FROM Roles_X_Usuario
            WHERE usuario_id = p_usuario_id AND rol_id = v_rol_usuario_id
        ) THEN
            -- Eliminamos el rol "Usuario"
            DELETE FROM Roles_X_Usuario
            WHERE usuario_id = p_usuario_id AND rol_id = v_rol_usuario_id;

            -- Asignamos el rol "Administrador"
            INSERT INTO Roles_X_Usuario (rol_id, usuario_id)
            VALUES (v_rol_admin_id, p_usuario_id);

            COMMIT;
            SELECT 'Rol actualizado a Administrador con éxito' AS Mensaje_de_exito;
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'El usuario no tiene rol Usuario o ya es Administrador.';
        END IF;
    END IF;
END$$
DELIMITER ;



-- 25) Sacar permisos
DELIMITER $$
CREATE PROCEDURE Asignar_rol_usuario(
    IN p_usuario_id INT,
    IN p_admin_id INT
)
BEGIN
    DECLARE v_nombre_rol VARCHAR(50);
    DECLARE v_rol_admin_id INT;
    DECLARE v_rol_usuario_id INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'ERROR. Ocurrió un error al modificar el rol' AS Mensaje_de_error;
    END;

    START TRANSACTION;

    -- Verificamos que el usuario que ejecuta sea administrador
    SELECT R.nombre INTO v_nombre_rol
    FROM Roles AS R
    INNER JOIN Roles_X_Usuario AS RXU ON R.rol_id = RXU.rol_id
    INNER JOIN Usuarios AS U ON RXU.usuario_id = U.usuario_id
    WHERE U.usuario_id = p_admin_id
    LIMIT 1;

    IF v_nombre_rol <> 'Administrador' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario debe ser administrador';
    ELSE
        -- Obtenemos los IDs de los roles "Administrador" y "Usuario"
        SELECT rol_id INTO v_rol_admin_id FROM Roles WHERE nombre = 'Administrador' LIMIT 1;
        SELECT rol_id INTO v_rol_usuario_id FROM Roles WHERE nombre = 'Usuario' LIMIT 1;

        -- Verificamos que el usuario tenga el rol "Administrador"
        IF EXISTS (
            SELECT 1
            FROM Roles_X_Usuario
            WHERE usuario_id = p_usuario_id AND rol_id = v_rol_admin_id
        ) THEN
            -- Eliminamos el rol "Administrador"
            DELETE FROM Roles_X_Usuario
            WHERE usuario_id = p_usuario_id AND rol_id = v_rol_admin_id;

            -- Asignamos el rol "Usuario"
            INSERT INTO Roles_X_Usuario (rol_id, usuario_id)
            VALUES (v_rol_usuario_id, p_usuario_id);

            COMMIT;
            SELECT 'Rol actualizado a Usuario con éxito' AS Mensaje_de_exito;
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'El usuario no tiene rol Administrador o ya es Usuario.';
        END IF;
    END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE Actualizar_Usuario(
    IN p_usuario_id INT,
    IN p_email VARCHAR(50),
    IN p_nombre VARCHAR(50),
    IN p_apellido VARCHAR(50),
    IN p_telefono VARCHAR(20),
    IN p_imagen_perfil LONGBLOB
)
BEGIN
    DECLARE v_email_owner_id INT DEFAULT NULL;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el email ya lo tiene OTRO usuario DIFERENTE
    SELECT usuario_id INTO v_email_owner_id
    FROM Usuarios
    WHERE email = p_email
      AND usuario_id != p_usuario_id
    LIMIT 1;

    IF v_email_owner_id IS NOT NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El email ya pertenece a otro usuario';
    END IF;

    -- Si llegamos acá, actualizar el usuario
    UPDATE Usuarios
    SET
        email = p_email,
        nombre = p_nombre,
        apellido = p_apellido,
        telefono = p_telefono,
        imagen_perfil = p_imagen_perfil
    WHERE usuario_id = p_usuario_id;

    COMMIT;
    
    SELECT 'Usuario actualizado exitosamente' AS mensaje;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE Encontrar_usuario_por_email_contraseña(
IN p_email VARCHAR(50),
IN p_contraseña VARCHAR(50), 
OUT p_num INT
)
BEGIN

        SELECT
                COUNT(*) INTO p_num
        FROM
                Usuarios
        WHERE
                email = p_email AND contraseña = p_contraseña;

        IF(p_num > 0)THEN
            SELECT '1'AS Usuario_encontrado;
        ELSE
            SELECT '0'AS No_se_encontro_usuario;
        END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE Eliminar_MeGusta(
    IN p_receta_id INT,
    IN p_usuario_id INT
)
BEGIN
    DELETE FROM Me_gustas
    WHERE receta_id = p_receta_id
      AND usuario_id = p_usuario_id;
END $$
DELIMITER ;

-- 21) Obtener las recetas favoritas por usuario
DELIMITER $$
CREATE PROCEDURE Obtener_recetas_favoritas(
    IN p_usuario_id INT
)
BEGIN
    SELECT R.receta_id, R.nombre, R.descripcion, R.instrucciones,
           R.imagen_receta, R.tiempo_preparacion, R.dificultad,
           R.pais_id, R.categoria_id, R.usuario_id
    FROM Recetas AS R
    INNER JOIN Favoritas AS F ON R.receta_id = F.receta_id
    WHERE F.usuario_id = p_usuario_id;

END$$

DELIMITER ;

DELIMITER $$
CREATE PROCEDURE Olvide_mi_contraseña(
IN p_email VARCHAR(50),
IN p_nueva_contraseña VARCHAR(255)
)
BEGIN
        DECLARE v_contraseña_actual VARCHAR(255);
        DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
                ROLLBACK;
                SELECT 'Error. No se pudo cambiar la contraseña'AS Mensaje_de_error;
        END;

        START TRANSACTION;

            SELECT 
                    contraseña INTO  v_contraseña_actual
            FROM
                    Usuarios
            WHERE
                    email = p_email;

            IF p_nueva_contraseña = v_contraseña_actual THEN
                    SIGNAL SQLSTATE '45000'
                    SET MESSAGE_TEXT = 'Contraseña invalida. No puede usuar la misma contraseña';
            END IF;

            UPDATE
                    Usuarios
            SET 
                    contraseña = p_nueva_contraseña
            WHERE
                    email = p_email;

        COMMIT;
        SELECT 'Contraseña reestablecida exitosamente';
END$$
DELIMITER ;