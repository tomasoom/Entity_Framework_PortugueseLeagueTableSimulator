-- Start the transaction
BEGIN TRANSACTION;

-- 1. Insert into Ligas table
INSERT INTO Ligas (Nome) VALUES ('Primeira Liga');

-- 2. Insert into Equipas table
INSERT INTO Equipas (Nome, Estadio, IdLiga) VALUES
('Sporting CP', 'Estádio José Alvalade', 1),
('Rio Ave FC', 'Estádio do Rio Ave Futebol Clube', 1),
('AVS', 'Estádio do AVS Futebol Clube', 1),
('CD Nacional', 'Estádio da Madeira', 1),
('Casa Pia AC', 'Estádio Pina Manique', 1),
('Boavista FC', 'Estádio do Bessa', 1),
('FC Porto', 'Estádio do Dragão', 1),
('Gil Vicente FC', 'Estádio Cidade de Barcelos', 1),
('Estoril Praia', 'Estádio António Coimbra da Mota', 1),
('Santa Clara', 'Estádio de São Miguel', 1),
('SC Farense', 'Estádio São Luís', 1),
('Moreirense FC', 'Estádio Comendador Joaquim de Almeida Freitas', 1),
('FC Famalicão', 'Estádio Municipal de Famalicão', 1),
('SL Benfica', 'Estádio da Luz', 1),
('SC Braga', 'Estádio Municipal de Braga', 1),
('Estrela Amadora', 'Estádio José Gomes', 1),
('FC Arouca', 'Estádio Municipal de Arouca', 1),
('Vitória SC', 'Estádio D. Afonso Henriques', 1);

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