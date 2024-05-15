-- 1.
--SELECT Worker.Name, Surname, Department.Name, Speciality.Name AS Speciality, Speciality.SalaryOneRate, 
--		(SELECT COUNT(*) FROM Worker w
--        JOIN Brigade b ON w.IdBrigade = b.IdBrigade
--        WHERE b.IdDepartment = Brigade.IdDepartment) AS TotalWorkersInDepartment
--FROM Worker
--JOIN Brigade
--ON Worker.IdBrigade = Brigade.IdBrigade
--JOIN Department
--ON Brigade.IdDepartment = Department.IdDepartment
--JOIN Speciality
--ON Worker.IdSpeciality = Speciality.IdSpeciality
--WHERE Speciality.SalaryOneRate * Worker.Rate > 40000

----------------------------------------------

--2.
--SELECT Worker.Name, Surname, Brigade.NumberInDepartment, Department.Name, Speciality.SalaryOneRate,
--	(SELECT COUNT(*) FROM Brigade b
--	WHERE b.IdDepartment = Brigade.IdDepartment) AS TotalBrigadesInDepartment
--FROM Worker
--JOIN Brigade
--ON Worker.IdBrigade = Brigade.IdBrigade
--JOIN Department
--ON Brigade.IdDepartment = Department.IdDepartment
--JOIN Speciality
--ON Worker.IdSpeciality = Speciality.IdSpeciality
--WHERE Speciality.SalaryOneRate > (SELECT AVG(SalaryoneRate) FROM Speciality)

--------------------------------------------------------

--3.
--SELECT Worker.Name, Surname, DateOfMedicalExamination, Speciality.SalaryOneRate,
--	(SELECT COUNT(*) FROM Driver
--	WHERE DateOfMedicalExamination < '2024-01-01')
--FROM Driver
--JOIN Worker
--ON Driver.IdWorker = Worker.IdWorker
--JOIN Speciality
--ON Worker.IdSpeciality = Speciality.IdSpeciality
--WHERE DateOfMedicalExamination < '2024-01-01'

--------------------------------------------

--4.
--SELECT DISTINCT Train.Name
--FROM Locomative
--JOIN Train
--ON Locomative.IdLocomative = Train.IdLocomative
--JOIN Schedule
--ON Train.IdTrain = Schedule.IdTrain
--JOIN Station_Route
--ON Station_Route.IdRoute = Schedule.IdRoute
--WHERE '2024-03-19 18:00:00' BETWEEN (SELECT ArravalTime FROM Station_Route
--							WHERE Station_Route.IdRoute = Schedule.IdRoute AND DepartureTime IS null) AND 
--							(SELECT DepartureTime FROM Station_Route
--							WHERE Station_Route.IdRoute = Schedule.IdRoute AND ArravalTime IS null)


--5.
--SELECT Locomative.Name, Weight, InspectionDate,
--	(SELECT COUNT(*) FROM Locomative
--	WHERE InspectionDate BETWEEN '2023-01-01' AND '2024-07-05')
--FROM Locomative
--WHERE InspectionDate BETWEEN '2023-01-01' AND '2024-07-05'

----------------------------------------------

--6.
--SELECT DISTINCT Name, (DATEDIFF(minute, 
--						(SELECT ArravalTime FROM Station_Route
--						WHERE Station_Route.IdRoute = Schedule.IdRoute AND DepartureTime IS NULL
--						), 
--						(SELECT DepartureTime FROM Station_Route
--						WHERE Station_Route.IdRoute = Schedule.IdRoute AND ArravalTime IS NULL
--						)))
--FROM Train
--JOIN Schedule
--ON Train.IdTrain = Schedule.IdTrain
--JOIN Station_Route
--ON Station_Route.IdRoute = Schedule.IdRoute
--JOIN Route
--ON Station_Route.IdRoute = Route.IdRoute
--WHERE Route.NameRoute = '605B'

---------------------------------------------

--9.
--SELECT IdTicket, PlaceofNumber, NameRoute, 
--										(SELECT COUNT(*) FROM  Ticket
--										JOIN Route
--										ON Ticket.IdRoute = Route.IdRoute
--										WHERE TimeofPurchase BETWEEN '2024-03-10' AND '2024-03-17' AND Route.NameRoute = '605B'
--										)
--FROM Ticket
--JOIN Route
--ON Route.IdRoute = Ticket.IdRoute
--WHERE TimeofPurchase BETWEEN '2024-03-10' AND '2024-03-17' AND Route.NameRoute = '605B'

--10.
--SELECT Route.NameRoute, 
--					(SELECT COUNT(*)
--					FROM Route
--					JOIN Station_Route
--					ON Route.IdRoute = Station_Route.IdRoute
--					JOIN Station
--					ON Station.IdStation = Station_Route.IdStation
--					WHERE Station.NameStation = 'Polotsk'
--					)
--FROM Route
--JOIN Station_Route
--ON Route.IdRoute = Station_Route.IdRoute
--JOIN Station
--ON Station.IdStation = Station_Route.IdStation
--WHERE Station.NameStation = 'Polotsk'

--11.
--SELECT DISTINCT IdTicket, (SELECT COUNT(DISTINCT IdTicket)
--							FROM Ticket
--							JOIN Route
--							ON Route.IdRoute = Ticket.IdRoute
--							JOIN Station_Route
--							ON Route.IdRoute = Station_Route.IdRoute
--							JOIN Station
--							ON Station.IdStation = Station_Route.IdStation
--							WHERE Route.NameRoute = '605B' AND Ticket.IsTaken = 1 AND (SELECT Station_Route.ArravalTime 
--																FROM Station_Route
--																JOIN Route
--																ON Route.IdRoute = Station_Route.IdRoute
--																WHERE Station_Route.DepartureTime IS NULL AND Route.NameRoute = '605B') BETWEEN '2024-03-19 00:00:00' and '2024-03-20 00:00:00')
--FROM Ticket
--JOIN Route
--ON Route.IdRoute = Ticket.IdRoute
--JOIN Station_Route
--ON Route.IdRoute = Station_Route.IdRoute
--JOIN Station
--ON Station.IdStation = Station_Route.IdStation
--WHERE Route.NameRoute = '605B' AND Ticket.IsTaken = 1 AND (SELECT Station_Route.ArravalTime 
--									FROM Station_Route
--									JOIN Route
--									ON Route.IdRoute = Station_Route.IdRoute
--									WHERE Station_Route.DepartureTime IS NULL AND Route.NameRoute = '605B') BETWEEN '2024-03-19 00:00:00' and '2024-03-20 00:00:00'

--12.

SELECT DISTINCT(IdTicket), 
						(SELECT COUNT(DISTINCT IdTicket)
						FROM Ticket
						JOIN Route
						ON Ticket.IdRoute = Route.IdRoute
						JOIN Station_Route
						ON Route.IdRoute = Station_Route.IdRoute
						WHERE Route.NameRoute = '605B' AND Ticket.IsTaken = 'false' AND (SELECT Station_Route.ArravalTime 
						FROM Station_Route
						JOIN Route
						ON Route.IdRoute = Station_Route.IdRoute
						WHERE Station_Route.DepartureTime IS NULL AND Route.NameRoute = '605B') BETWEEN '2024-03-19 00:00:00' and '2024-03-20 00:00:00'
						)
FROM Ticket
JOIN Route
ON Ticket.IdRoute = Route.IdRoute
JOIN Station_Route
ON Route.IdRoute = Station_Route.IdRoute
WHERE Route.NameRoute = '605B' AND Ticket.IsTaken = 'false' AND (SELECT Station_Route.ArravalTime 
									FROM Station_Route
									JOIN Route
									ON Route.IdRoute = Station_Route.IdRoute
									WHERE Station_Route.DepartureTime IS NULL AND Route.NameRoute = '605B') BETWEEN '2024-03-19 00:00:00' and '2024-03-20 00:00:00'







