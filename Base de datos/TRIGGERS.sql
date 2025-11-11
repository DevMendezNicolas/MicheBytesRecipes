USE MicheBytes;
-- EJECUTAR QUINTO
-- -----------------------------------------------------------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------- TRIGGERS -------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------------------------------------------------


-- 1) INSERTAR RECETA

DELIMITER $$
CREATE TRIGGER Auditoria_insertar_receta
AFTER INSERT
ON Recetas
FOR EACH ROW 
BEGIN
		DECLARE v_usuario_id INT;
        
        SELECT R.usuario_id INTO v_usuario_id FROM Recetas as R WHERE receta_id = NEW.Receta_id;
        
		INSERT INTO Auditorias(Tipo_modificacion, usuario_id, receta_id)VALUES
        ('INSERT', v_usuario_id, NEW.receta_id);
END $$
DELIMITER ;

DROP TRIGGER IF EXISTS Auditoria_actualizar_receta;


-- 2) ACTUALIZAR RECETA

DELIMITER $$
CREATE TRIGGER Auditoria_actualizar_receta
AFTER UPDATE 
ON Recetas
FOR EACH ROW
BEGIN

		DECLARE v_usuario_id INT;
        
        SELECT usuario_id INTO v_usuario_id FROM Recetas WHERE receta_id = OLD.receta_id;
        
		INSERT INTO Auditorias(Tipo_modificacion, usuario_id, receta_id)VALUES
        ('UPDATE', v_usuario_id, NEW.receta_id);
END $$
DELIMITER ;

-- CALL Modificar_receta (18, 'Torta de coco', 'Un clásico postre con MAGNESIO', 'Mezclar ingredientes', NULL, '00:45:00', 'Fácil', 1, 1, 1);

SELECT * FROM Recetas;

-- SELECT * FROM Auditorias;


-- 3) Baja de la receta 
DELIMITER $$
CREATE TRIGGER Auditoria_baja_receta
AFTER UPDATE
ON Recetas
FOR EACH ROW
BEGIN
        IF OLD.fecha_baja IS NULL AND NEW.fecha_baja IS NOT NULL THEN
			INSERT INTO Auditorias(Tipo_modificacion, usuario_id, receta_id)VALUES
			('BAJA', OLD.usuario_id, OLD.receta_id);
		END IF;
END $$
DELIMITER ;

-- 3) Alta de la receta 
DELIMITER $$
CREATE TRIGGER Auditoria_alta_receta
AFTER UPDATE
ON Recetas
FOR EACH ROW
BEGIN
        IF NEW.fecha_baja IS NULL AND OLD.fecha_baja IS NOT NULL THEN
            INSERT INTO Auditorias(Tipo_modificacion, usuario_id, receta_id)VALUES
            ('ALTA', NEW.usuario_id, NEW.receta_id);
        END IF;
END $$
DELIMITER ;







