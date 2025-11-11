USE MicheBytes;
-- EJECUTAR TERCERO
-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------- VISTAS -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------

-- 1) Vista de todos los usuarios 
CREATE VIEW Vista_todos_los_usuarios AS
SELECT
		U.usuario_id, U.nombre, U.apellido, U.telefono, U.email, U.imagen_perfil, U.fecha_registro, U.fecha_baja, R.rol_id
FROM
		Usuarios AS U
        INNER JOIN Roles_X_Usuario RXU ON U.usuario_id = RXU.usuario_id
        INNER JOIN Roles AS R ON RXU.rol_id = R.rol_id;
	
-- 2) Vista de todas las recetas
CREATE VIEW Vista_resumen_recetas AS
SELECT
		R.receta_id, R.nombre, R.tiempo_preparacion, R.dificultad, R.fecha_baja, R.categoria_id, R.pais_id
FROM
		Recetas AS R;

-- 2B)Vista historial de recetas
CREATE VIEW Vista_resumen_receta_historial AS
SELECT
		R.receta_id, R.nombre, R.tiempo_preparacion, R.dificultad, R.fecha_baja, R.categoria_id, R.pais_id, H.usuario_id, H.fecha_visita, H.historial_id
FROM
		Recetas AS R
        INNER JOIN Historiales AS H ON R.receta_id = H.receta_id;

-- 3) Vista de todas los paises
CREATE VIEW Vista_de_todos_los_paises AS
SELECT
		pais_id, nombre
FROM
		Paises;


-- 4) vista de todos los ingredientes
CREATE VIEW Vista_de_todos_los_ingredientes AS
SELECT
		ingrediente_id, nombre
FROM
		Ingredientes;

-- 5) Vista de todas las unidades de medida
CREATE VIEW Vista_de_todas_las_unidades_de_medida AS
SELECT
    unidad_de_medida_id AS ID,
    nombre AS Nombre
FROM
    Unidades_de_medidas;

-- 6) Vista de todos los tipos de ingredientes
CREATE VIEW Vista_de_todos_los_tipos_de_ingredientes AS
SELECT
    tipo_ingrediente_id AS ID,
    nombre AS Nombre
FROM
    Tipos_de_ingredientes;

-- 7) Vista de todos los ingredientes con el tipo de ingrediente, unidad de medida y receta
CREATE VIEW Vista_de_todos_los_ingredientes_tipo_y_unidad_x_receta AS
SELECT
		I.ingrediente_id, I.nombre, T.tipo_ingrediente_id, T.nombre AS Tipo_ingrediente, U.unidad_de_medida_id, U.nombre AS Unidad,
        R.receta_id
FROM
		Ingredientes  AS I
        INNER JOIN Tipos_de_ingredientes AS T ON I.tipo_ingrediente_id = T.tipo_ingrediente_id
        INNER JOIN Unidades_de_medidas AS U ON I.unidad_de_medida_id = U.unidad_de_medida_id
		INNER JOIN Ingredientes_x_receta AS IXR ON I.ingrediente_id = IXR.ingrediente_id
        INNER JOIN Recetas AS R ON R.receta_id = IXR.receta_id;

-- 8) Vista de todos los usuarios activos
CREATE VIEW Vista_de_todos_los_usuarios_activos AS
SELECT
		U.usuario_id, U.nombre, U.apellido, U.telefono, U.email, U.fecha_registro, U.fecha_baja, R.nombre as rol
FROM
		Usuarios as U
        INNER JOIN roles_x_usuario as RS on U.usuario_id = RS.usuario_id
        INNER JOIN Roles as R on R.rol_id = RS.rol_id
WHERE
		fecha_baja IS NULL;

-- 9) vista de todos los usuarios inactivos
CREATE VIEW Vista_de_todos_los_usuarios_inactivos AS
SELECT
		U.usuario_id, U.nombre, U.apellido, U.telefono, U.email, U.fecha_registro, U.fecha_baja, R.nombre as rol
FROM
		Usuarios as U
        INNER JOIN roles_x_usuario as RS on U.usuario_id = RS.usuario_id
        INNER JOIN Roles as R on R.rol_id = RS.rol_id
WHERE
		fecha_baja IS NOT NULL;
        
-- 10) Vista de los comentarios
CREATE VIEW Vista_de_los_comentarios AS
SELECT
		C.comentario_id, C.descripcion, C.fecha_comentario, R.receta_id, U.nombre AS Nombre_usuario
FROM
		Comentarios AS C
        INNER JOIN Recetas AS R ON C.receta_id = R.receta_id
        INNER JOIN Usuarios AS U ON C.usuario_id = U.usuario_id;
 
 -- 11) Vista de las categorias
CREATE VIEW Vista_de_las_categorias AS
SELECT
		categoria_id, nombre
FROM
		Categorias;
      
      
-- 12) Vista de los me gustas
CREATE VIEW Vista_de_los_me_gustas AS
SELECT
		me_gusta_id
FROM
		Me_gustas;

-- 13) Vista de metricas
CREATE VIEW vista_metricas_recetas AS
SELECT
  r.receta_id,
  r.nombre,
  c.nombre AS Categoria,
  funcion_cantidad_favoritos(r.receta_id) AS CantidadFavoritos,
  funcion_cantidad_de_comentarios(r.receta_id) AS CantidadComentarios,
  funcion_cantidad_me_gustas(r.receta_id) AS CantidadLikes,
  funcion_cantidad_de_vistas(r.receta_id) AS CantidadVisualizaciones,
  r.fecha_baja AS fechaBaja
FROM
  Recetas r
INNER JOIN
  Categorias c ON r.categoria_id = c.categoria_id;
  
-- 14) Vista de toda la receta completa
CREATE VIEW Vista_de_receta_completa AS
SELECT
		R.receta_id, R.nombre, R.descripcion, R.instrucciones, R.imagen_receta, R.tiempo_preparacion, R.dificultad, R.fecha_baja, R.pais_id, 
        R.categoria_id, R.usuario_id
FROM
		Recetas as R;

-- 15) Vista de contraseña y email de los usuarios
CREATE VIEW Vista_de_contraseña_email_del_usuario AS
SELECT
      contraseña, email
FROM
      Usuarios;
        
CREATE VIEW vista_favoritas AS
SELECT F.usuario_id, R.receta_id, R.nombre, R.descripcion, 
       R.instrucciones, R.imagen_receta, R.tiempo_preparacion,
       R.dificultad, R.pais_id, R.categoria_id, R.usuario_id AS autor_id
FROM Favoritas F
INNER JOIN Recetas R ON F.receta_id = R.receta_id;

CREATE OR REPLACE VIEW vista_me_gusta AS
SELECT 
    mg.me_gusta_id,
    r.receta_id,
    r.Nombre AS nombre_receta,
    u.usuario_id,
    u.Nombre AS nombre_usuario,
    mg.fecha_me_gusta
FROM Me_gustas mg
INNER JOIN Recetas r ON mg.receta_id = r.receta_id
INNER JOIN Usuarios u ON mg.usuario_id = u.usuario_id;
-- prueba
CREATE OR REPLACE VIEW vista_me_gustas AS
SELECT 
    mg.me_gusta_id,
    r.receta_id,
    r.Nombre AS nombre_receta,
    mg.usuario_id,
    u.Nombre AS nombre_usuario,
    mg.fecha_me_gusta
FROM Me_gustas mg
INNER JOIN Recetas r ON mg.receta_id = r.receta_id
INNER JOIN Usuarios u ON mg.usuario_id = u.usuario_id;
