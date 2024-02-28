CREATE SCHEMA WorkersSchema

ALTER SCHEMA WorkersSchema TRANSFER dbo.Worker
ALTER SCHEMA WorkersSchema TRANSFER dbo.Speciality
ALTER SCHEMA WorkersSchema TRANSFER dbo.WorkersSpecialitiesView

CREATE SCHEMA ViewSchema
ALTER SCHEMA ViewSchema TRANSFER dbo.FullNameView
ALTER SCHEMA ViewSchema TRANSFER dbo.AllInformationWorkerView
--------------------------------------------
--------------------------------------------
CREATE ROLE Worker
CREATE ROLE Boss
CREATE ROLE Admin

CREATE LOGIN LeshaLogin WITH PASSWORD = '123'
CREATE USER WorkerLesha FOR LOGIN LeshaLogin
ALTER ROLE Worker ADD MEMBER WorkerLesha

CREATE LOGIN DmitriyLogin WITH PASSWORD = '123'
CREATE USER WorkerDmitriy FOR LOGIN DmitriyLogin
ALTER ROLE Worker ADD MEMBER WorkerDmitriy

CREATE LOGIN MishaLogin WITH PASSWORD = '123'
CREATE USER WorkerMisha FOR LOGIN MishaLogin
ALTER ROLE Worker ADD MEMBER WorkerMisha

CREATE LOGIN PetrLogin WITH PASSWORD = '123'
CREATE USER WorkerPetr FOR LOGIN PetrLogin
ALTER ROLE Worker ADD MEMBER WorkerPetr

CREATE LOGIN IvanLogin WITH PASSWORD = '123'
CREATE USER BossIvan FOR LOGIN IvanLogin
ALTER ROLE Boss ADD MEMBER BossIvan

CREATE LOGIN AndreyLogin WITH PASSWORD = '123'
CREATE USER BossAndrey FOR LOGIN AndreyLogin
ALTER ROLE Boss ADD MEMBER BossAndrey

CREATE LOGIN AdminLogin WITH PASSWORD = 'admin'
CREATE USER AdminIgor FOR LOGIN AdminLogin
ALTER ROLE Admin ADD MEMBER AdminIgor



DENY DELETE, INSERT, UPDATE TO Worker
GRANT DELETE, INSERT, UPDATE TO Worker
REVOKE DELETE, INSERT, UPDATE TO Worker

GRANT SELECT, INSERT, UPDATE ON WorkersSchema.Speciality TO Boss
GRANT UPDATE ON WorkersSchema.Speciality TO Worker
DENY SELECT, INSERT, UPDATE, DELETE ON WorkersSchema.Worker TO Worker
DENY SELECT, INSERT, UPDATE, DELETE ON WorkersSchema.Speciality TO Boss
GRANT SELECT, INSERT, UPDATE ON WorkersSchema.Worker TO Boss
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Department TO Boss
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Brigade TO Boss
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.WorkersHistory TO Boss
GRANT SELECT, INSERT, UPDATE, DELETE ON WorkersSchema.Worker TO Boss
GRANT SELECT, INSERT, UPDATE, DELETE, CREATE TABLE TO Admin




BACKUP DATABASE lab_1 TO DISK = 'E:\PSU_lab\6_semester\BD\backUp\lab_1\backUp_lab_1.bak'