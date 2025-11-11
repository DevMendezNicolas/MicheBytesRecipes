USE MicheBytes;
-- EJECUTAR SEPTIMO MENOS LAS RECETAS
-- INSERTAR LAS RECETAS DESPUES DE HABERSE CREADO UN USUARIO ADMINISTRADOR
-- ROLES
INSERT INTO Roles(nombre) VALUES
('Administrador'),
('Usuario');

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

-- TIPO INGREDIENTE
INSERT INTO Tipos_de_ingredientes (nombre) VALUES
('Lácteos'),
('Carnes'),
('Vegetales'),
('Cereales'),
('Especias'),
('Frutas'),
('Aceites');

-- UNIDADES DE MEDIDAS
INSERT INTO Unidades_de_medidas (nombre) VALUES
('Gramos'),
('Litros'),
('Cucharadas'),
('Mililitros'),
('Tazas'),
('Unidades');

-- INGREDIENTES
INSERT INTO Ingredientes (nombre, tipo_ingrediente_id, unidad_de_medida_id) VALUES
('Leche', 1, 2),            -- Lácteos, Litros - id 1
('Pollo', 2, 1),            -- Carnes, Gramos - id 2
('Zanahoria', 3, 1),        -- Vegetales, Gramos - id 3
('Arroz', 4, 1),            -- Cereales, Gramos - id 4
('Sal', 5, 3),              -- Especias, Cucharadas - id 5
('Manzana', 6, 1),          -- Frutas, Gramos - id 6
('Azúcar', 5, 3),           -- Especias, Cucharadas - id 7
('Carne picada', 2, 1),     -- Carnes, Gramos - id 8
('Harina', 4, 1),           -- Cereales, Gramos - id 9
('Levadura', 5, 3),         -- Especias, Cucharadas - id 10
('Lechuga', 3, 1),          -- Vegetales, Gramos - id 11
('Tomate', 3, 5),           -- Vegetales, Unidades - id 12
('Café', 5, 3),             -- Especias, Cucharadas - id 13
('Pepino', 3, 5),           -- Vegetales, Unidades - id 14
('Yogur natural', 1, 2),    -- Lácteos, Litros - id 15
('Pasta', 4, 1),            -- Cereales, Gramos - id 16
('Albahaca fresca', 3, 5),  -- Vegetales, Unidades - id 17
('Aceite de oliva', 7, 4),  -- Aceites, Tazas - id 18
('Queso rallado', 1, 1),    -- Lácteos, Gramos - id 19
('Cebolla', 3, 5),          -- Vegetales, Unidades - id 20
('Ajo', 5, 5),              -- Especias, Unidades - id 21
('Papa', 3, 5),             -- Vegetales, Unidades - id 22
('Huevo', 1, 5),            -- Lácteos, Unidades - id 23
('Banana', 6, 5),           -- Frutas, Unidades - id 24
('Albahaca', 3, 1),--  - id 25
('Piñones', 6, 1),--  - id 26
('Queso parmesano', 1, 1),--  - id 27
('Pan', 4, 6),--  - id 28
('Arroz arborio', 4, 1),--  - id 29
('Hongos', 3, 1),--  - id 30
('Caldo de verduras', 6, 4),--  - id 31
('Jarrete de ternera', 2, 6),--  - id 32
('Apio', 3, 6),--  - id 33
('Vino blanco', 6, 4),--  - id 34
('Caldo de carne', 6, 4),--  - id 35
('Perejil', 3, 1),--  - id 36
('Limón', 3, 6),--  - id 37
('Ricotta', 1, 1),--  - id 38
('Espinaca', 3, 1),--  - id 39
('Nuez moscada', 5, 2),--  - id 40
('Pimiento rojo', 3, 5),     -- Vegetales, Unidades - id 41
('Pimiento verde', 3, 5),    -- Vegetales, Unidades - id 42
('Azafrán', 5, 2),           -- Especias, Cucharaditas - id 43
('Mariscos', 2, 1),          -- Carnes, Gramos - id 44
('Guisantes', 3, 1),         -- Vegetales, Gramos - - id 45
('Pescado fresco', 2, 1),       -- Carnes, Gramos - id 46
('Pimienta', 5, 2),             -- Especias, Cucharaditas - id 47
('Cebolla morada', 3, 5),       -- Vegetales, Unidades - id 48
('Cilantro', 3, 1),             -- Vegetales, Gramos - id 49
('Ají picante', 5, 5),          -- Especias, Unidades - id 50
('Camote', 3, 5),               -- Vegetales, Unidades - id 51
('Maíz chulpe', 4, 5),          -- Cereales, Unidades - id 52
('Hierbas italianas', 5, 2), -- id 53
('Canela', 5, 2); -- Especias, Cucharaditas - id 54

select * from categorias;
