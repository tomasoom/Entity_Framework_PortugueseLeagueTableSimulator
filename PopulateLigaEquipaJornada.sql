-- Start the transaction
BEGIN TRANSACTION;

-- 1. Insert into Ligas table
INSERT INTO Ligas (Nome) VALUES ('Primeira Liga');

-- 2. Insert into Equipas table
INSERT INTO Equipas (Nome, Estadio, IdLiga) VALUES
('Sporting CP', 'Est�dio Jos� Alvalade', 1),
('Rio Ave FC', 'Est�dio do Rio Ave Futebol Clube', 1),
('AVS', 'Est�dio do AVS Futebol Clube', 1),
('CD Nacional', 'Est�dio da Madeira', 1),
('Casa Pia AC', 'Est�dio Pina Manique', 1),
('Boavista FC', 'Est�dio do Bessa', 1),
('FC Porto', 'Est�dio do Drag�o', 1),
('Gil Vicente FC', 'Est�dio Cidade de Barcelos', 1),
('Estoril Praia', 'Est�dio Ant�nio Coimbra da Mota', 1),
('Santa Clara', 'Est�dio de S�o Miguel', 1),
('SC Farense', 'Est�dio S�o Lu�s', 1),
('Moreirense FC', 'Est�dio Comendador Joaquim de Almeida Freitas', 1),
('FC Famalic�o', 'Est�dio Municipal de Famalic�o', 1),
('SL Benfica', 'Est�dio da Luz', 1),
('SC Braga', 'Est�dio Municipal de Braga', 1),
('Estrela Amadora', 'Est�dio Jos� Gomes', 1),
('FC Arouca', 'Est�dio Municipal de Arouca', 1),
('Vit�ria SC', 'Est�dio D. Afonso Henriques', 1);

-- 3. Insert into Jornadas table
INSERT INTO Jornadas (IdLiga, Nome) VALUES
(1, 'Jornada 1'), (1, 'Jornada 2'), (1, 'Jornada 3'), (1, 'Jornada 4'),
(1, 'Jornada 5'), (1, 'Jornada 6'), (1, 'Jornada 7'), (1, 'Jornada 8'),
(1, 'Jornada 9'), (1, 'Jornada 10'), (1, 'Jornada 11'), (1, 'Jornada 12'),
(1, 'Jornada 13'), (1, 'Jornada 14'), (1, 'Jornada 15'), (1, 'Jornada 16'),
(1, 'Jornada 17'), (1, 'Jornada 18'), (1, 'Jornada 19'), (1, 'Jornada 20'),
(1, 'Jornada 21'), (1, 'Jornada 22'), (1, 'Jornada 23'), (1, 'Jornada 24'),
(1, 'Jornada 25'), (1, 'Jornada 26'), (1, 'Jornada 27'), (1, 'Jornada 28'),
(1, 'Jornada 29'), (1, 'Jornada 30'), (1, 'Jornada 31'), (1, 'Jornada 32'),
(1, 'Jornada 33'), (1, 'Jornada 34');