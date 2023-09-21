CREATE DATABASE Chapter

USE Chapter

CREATE TABLE Livros (
	id INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(150) NOT NULL,
	QuantidadePaginas INT,
	Disponivel BIT
)

INSERT INTO Livros (Titulo, QuantidadePaginas, Disponivel)
VALUES ('Titulo 1', 220, 1)

INSERT INTO Livros (Titulo, QuantidadePaginas, Disponivel)
VALUES ('Biblia', 500, 1)

SELECT * FROM Livros

UPDATE Livros SET Titulo = 'Senhor dos Aneis' WHERE id = 1;

DELETE FROM Livros WHERE id = 3;