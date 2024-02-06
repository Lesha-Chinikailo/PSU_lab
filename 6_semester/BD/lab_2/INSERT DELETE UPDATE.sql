UPDATE Brigade
SET CountWorker=CountWorker+1
WHERE IdDepartment=(SELECT IdDepartment FROM Department WHERE DescriptionDepartment = 'description1')

DELETE FROM Worker
WHERE IdBrigade=(SELECT IdBrigade FROM Brigade WHERE IdDepartment=3)
AND IdSpeciality=(SELECT IdSpeciality FROM Speciality WHERE Speciality.NameSpeciality = 'cashier')

INSERT INTO Worker VALUES
(
	'Maria',
	'Tutor',
	'ma123@mail.ru',
	1,
	(SELECT IdSpeciality FROM Speciality WHERE NameSpeciality='cashier'),
	(SELECT IdBrigade FROM Brigade WHERE IdDepartment=3)
)
