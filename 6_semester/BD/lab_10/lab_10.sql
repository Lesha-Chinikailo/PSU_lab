BEGIN TRANSACTION;

INSERT INTO WorkersSchema.Worker VALUES
('Pashka', 'pashkent', 'pa123@mail.ru', 1, 4, 1)

UPDATE Brigade
SET CountWorker = CountWorker + 1
WHERE IdBrigade = 1

IF EXISTS(SELECT * FROM WorkersSchema.Worker WHERE Worker.Name = 'Pashka')
BEGIN 
	COMMIT TRANSACTION 
	PRINT 'Worker seccessfull added';
END
ELSE
BEGIN
	ROLLBACK TRANSACTION 
	PRINT 'ERROR: Worker do not add ';
END
------------------------------------------------
BEGIN TRANSACTION;

DELETE FROM WorkersSchema.Worker
WHERE Worker.Name = 'Pashka'

UPDATE Brigade
SET CountWorker = CountWorker - 1
WHERE IdBrigade = 1

IF EXISTS(SELECT * FROM WorkersSchema.Worker WHERE Worker.Name = 'Pashka')
BEGIN 
	PRINT 'ERROR: Worker do not delete';
	ROLLBACK TRANSACTION 
END
ELSE
BEGIN
	COMMIT TRANSACTION 
	PRINT 'Worker seccessfull delete';
END
---------------------------------------------------

---------------------------------------------------
BEGIN TRANSACTION;

INSERT INTO Brigade VALUES
(20, 'for Department 3', 3)

UPDATE Department
SET CountBrigade = CountBrigade + 1
WHERE IdDepartment = 3

IF EXISTS(SELECT * FROM Brigade WHERE TypeBrigade = 'for Department 3')
BEGIN 
	COMMIT TRANSACTION 
	PRINT 'Brigade seccessfull added';
END
ELSE
BEGIN
	ROLLBACK TRANSACTION 
	PRINT 'ERROR: Brigade do not add';
END

SELECT * FROM Brigade
SELECT * FROM Department
------------------------------------------------
BEGIN TRANSACTION;

DELETE FROM Brigade
WHERE TypeBrigade = 'for Department 3'

UPDATE Department
SET CountBrigade = CountBrigade - 1
WHERE IdDepartment = 3

IF NOT EXISTS(SELECT * FROM Brigade WHERE TypeBrigade = 'for Department 3')
BEGIN 
	COMMIT TRANSACTION 
	PRINT 'Brigade seccessfull delete';
END
ELSE
BEGIN
	ROLLBACK TRANSACTION 
	PRINT 'ERROR: Brigade do not delete';
END

SELECT * FROM Brigade
SELECT * FROM Department
---------------------------------------------------

---------------------------------------------------
BEGIN TRANSACTION

INSERT INTO WorkersSchema.Worker VALUES
('Pasha', 'pashkent', 'pa123@mail.ru', 1, 4, 2)

UPDATE WorkersSchema.Speciality
SET SalaryOneRate = SalaryOneRate + SalaryOneRate * 0.1
WHERE IdSpeciality = (SELECT IdSpeciality FROM WorkersSchema.Worker WHERE WorkersSchema.Worker.Name = 'Pasha')

IF EXISTS(SELECT * FROM WorkersSchema.Worker WHERE Worker.Name = 'Pasha')
BEGIN 
	COMMIT TRANSACTION 
	PRINT 'Brigade seccessfull added';
END
ELSE
BEGIN
	ROLLBACK TRANSACTION 
	PRINT 'ERROR: Brigade do not add';
END

--UPDATE WorkersSchema.Worker
--SET Name = 'temp'
--WHERE Name = 'Pasha'

SELECT * FROM WorkersSchema.Worker
SELECT * FROM WorkersSchema.Speciality

-------------------------------------------------

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ 
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE 


-------------------------------------------------
sqlcmd -S DESKTOP-501ABTG
SELECT * FROM lab_1.WorkersSchema.Worker
go

sqlcmd -S DESKTOP-501ABTG -Q "SELECT * FROM lab_1.WorkersSchema.Worker" -o E:\PSU_lab\6_semester\BD\lab_10\data.txt









IF EXISTS(SELECT * FROM WorkersSchema.Worker WHERE IdWorker = 11)
PRINT 'yes'
ELSE
PRINT 'no';

DELETE FROM WorkersSchema.Worker
WHERE IdWorker = 13

SELECT * FROM WorkersSchema.Worker WHERE Worker.IdWorker = 11
SELECT * FROM WorkersSchema.Worker

SELECT * FROM Brigade