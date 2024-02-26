--NON UPDATABLE
CREATE VIEW WorkersSpecialitiesView AS 
SELECT 
Worker.Name AS WorkerName,
Speciality.NameSpeciality AS SpecialityName
FROM Worker
JOIN Speciality ON Worker.IdSpeciality = Speciality.IdSpeciality

SELECT * FROM WorkersSpecialitiesView

CREATE VIEW CompanyDirectorsView AS
SELECT
Worker.Name AS WorkerName,
Brigade.TypeBrigade AS BrigadeType
FROM Worker
JOIN Brigade ON Worker.IdBrigade = Brigade.IdBrigade

SELECT * FROM CompanyDirectorsView

CREATE VIEW ShowWorkerInBrigadeAndDepartmentView AS
SELECT Name, Speciality.NameSpeciality, Brigade.TypeBrigade
	FROM Worker
	JOIN Speciality ON Worker.IdSpeciality=Speciality.IdSpeciality
	JOIN Brigade ON Worker.IdBrigade=Brigade.IdBrigade

SELECT * FROM ShowWorkerInBrigadeAndDepartmentView

--UPDATABLE

CREATE VIEW AllInformationWorkerView AS
SELECT Worker.Name, Worker.Surname, Worker.Email, Worker.Rate, Worker.IdSpeciality, Worker.IdBrigade
FROM Worker

INSERT INTO AllInformationWorkerView VALUES
('Katya', 'Surname', 'kat123@mail.ru', 1, 4, 4)

CREATE VIEW FullNameView AS
SELECT Name, Surname
FROM Worker

SELECT * FROM FullNameView


DROP VIEW FullNameView

ALTER VIEW FullNameView AS
SELECT Name, Surname, Email
FROM Worker

INSERT INTO AllInformationWorkerView VALUES
('Katya', 'Surname', 'kat123@mail.ru', 1, 5, 5)

SELECT * FROM Worker

DELETE FROM AllInformationWorkerView
WHERE IdBrigade = 5

DECLARE @myTable TABLE
(IdWorker int, Name varchar(50))

INSERT INTO @myTable VALUES
(1, 'lesha'),
(2, 'pasha')

SELECT * FROM @myTable