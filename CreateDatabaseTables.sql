USE LigaPortuguesa;

-- Create Ligas table
CREATE TABLE Ligas (
    IdLiga INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL
);

-- Create Equipas table
CREATE TABLE Equipas (
    IdEquipa INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Estadio NVARCHAR(100) NOT NULL,
    IdLiga INT NOT NULL,
    FOREIGN KEY (IdLiga) REFERENCES Ligas(IdLiga)
);

-- Create Jornadas table
CREATE TABLE Jornadas (
    IdJornada INT PRIMARY KEY IDENTITY(1,1),
    IdLiga INT NOT NULL,
    Nome NVARCHAR(100) NOT NULL, -- Optional: name or description of the jornada
    FOREIGN KEY (IdLiga) REFERENCES Ligas(IdLiga)
);

-- Create Jogos table
CREATE TABLE Jogos (
    IdJogo INT PRIMARY KEY IDENTITY(1,1),
    IdJornada INT NOT NULL,
    IdEquipaCasa INT NOT NULL,
    IdEquipaFora INT NOT NULL,
	GolosCasa INT NOT NULL DEFAULT 0,
    GolosFora INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IdJornada) REFERENCES Jornadas(IdJornada),
    FOREIGN KEY (IdEquipaCasa) REFERENCES Equipas(IdEquipa),
    FOREIGN KEY (IdEquipaFora) REFERENCES Equipas(IdEquipa),
    CHECK (IdEquipaCasa <> IdEquipaFora) -- Ensure a team does not play against itself
);