--CREATE TRIGGER Speciality_INSERT_UPDATE ----
--ON Speciality
--AFTER INSERT, UPDATE
--AS 
--UPDATE Speciality
--SET SalaryOneRate = SalaryOneRate + SalaryOneRate * 0.2
--WHERE IdSpeciality = (SELECT IdSpeciality FROM inserted)

--INSERT INTO Speciality VALUES
--(40000, 'someone', 'work in building')

--SELECT * FROM Speciality

--DISABLE TRIGGER Speciality_INSERT_UPDATE ON Speciality
--ENABLE TRIGGER Speciality_INSERT_UPDATE ON Speciality
-----------------------------------------------
CREATE TRIGGER Workers_INSTEAD_OF_DELETE ----
ON Worker
INSTEAD OF DELETE
AS 
SELECT Worker.Name FROM Worker 
WHERE Name = 'noname'

DELETE FROM Worker 
WHERE Worker.IdWorker = 7

DISABLE TRIGGER Workers_INSTEAD_OF_DELETE ON WorkersSchema.Worker

SELECT * FROM Worker
----------------------------------------
--CREATE TRIGGER Speciality_INSTEAD_DELETE
--ON Speciality
--INSTEAD OF DELETE
--AS
--UPDATE Speciality
--SET NameSpeciality = 'delete'
--WHERE IdSpeciality = (SELECT IdSpeciality FROM deleted)

--DELETE FROM Speciality
--WHERE IdSpeciality = 6

--DISABLE TRIGGER Speciality_INSTEAD_DELETE ON Speciality
--ENABLE TRIGGER Speciality_INSTEAD_DELETE ON Speciality

--SELECT * FROM Speciality
--------------------------------------
--ALTER TRIGGER Worker_INSTEAD_OF_INSERT
--ON Worker
--INSTEAD OF INSERT
--AS
--SELECT 'we are '+ CAST(COUNT(IdWorker) AS nvarchar)+' worker. there are no more places' AS Warning
--FROM Worker

--INSERT INTO Worker VALUES
--('Tola', 'svoi', 'to123@mail.ru', 1, 2, 4)

DISABLE TRIGGER Worker_INSTEAD_OF_INSERT ON WorkersSchema.Worker
--ENABLE TRIGGER Worker_INSTEAD_OF_INSERT ON Worker
-----------------------------------------------
--CREATE TRIGGER Worker_AFTER_UPDATE
--ON Worker
--AFTER UPDATE
--AS
--UPDATE Worker
--SET Name = Name + 'update'
--WHERE IdWorker = (SELECT IdWorker FROM inserted)

--UPDATE Worker
--SET Rate = Rate + 0.1
--WHERE IdWorker = 7

DISABLE TRIGGER Worker_AFTER_UPDATE ON WorkersSchema.Worker
--ENABLE TRIGGER Worker_AFTER_UPDATE ON Worker

--SELECT * FROM Worker
-----------------------------------
-----------------------------------








CREATE TABLE WorkersHistory
(
	IdHistory INT NOT NULL,
	Operarion VARCHAR(50),
)

CREATE TRIGGER Worker_Operation
ON Worker
AFTER INSERT, DELETE
AS
INSERT INTO WorkersHistory(IdHistory, Operarion)
SELECT IdWorker, 'was added'
FROM Worker
WHERE IdWorker = (SELECT IdWorker FROM inserted)
SELECT IdWorker, 'was deleted'
FROM Worker
WHERE IdWorker = (SELECT IdWorker FROM deleted)

DISABLE TRIGGER Worker_Operation ON Worker
ENABLE TRIGGER Worker_Operation ON Worker

INSERT INTO Worker VALUES
('Tola', 'svoi', 'to123@mail.ru', 1, 3, 4)

SELECT * FROM WorkersHistory
SELECT * FROM Worker

DELETE FROM Worker
WHERE IdWorker = 10

