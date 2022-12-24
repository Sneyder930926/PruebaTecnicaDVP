USE master
GO
IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'dbPruebaTecnicaDVP')
BEGIN
	DROP DATABASE dbPruebaTecnicaDVP
	
    IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'dbPruebaTecnicaDVP')
        PRINT '<<< FAILED DROPPING DATABASE dbPruebaTecnicaDVP >>>'
    ELSE
        PRINT '<<< DROPPED DATABASE dbPruebaTecnicaDVP >>>'
END
GO
CREATE DATABASE dbPruebaTecnicaDVP
GO
IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'dbPruebaTecnicaDVP')
	PRINT '<<< CREATED DATABASE dbPruebaTecnicaDVP >>>'
ELSE
	PRINT '<<< FAILED CREATING DATABASE dbPruebaTecnicaDVP >>>'
GO

USE dbPruebaTecnicaDVP
GO
IF OBJECT_ID('dbo.Personas') IS NOT NULL
BEGIN
	DROP TABLE dbo.Personas
	
	IF OBJECT_ID('dbo.Personas') IS NOT NULL
		PRINT '<<< FAILED DROPPING TABLE dbo.Personas >>>'
	ELSE
		PRINT '<<< DROPPED TABLE dbo.Personas >>>'
END
GO
CREATE TABLE dbo.Personas
(
	Identificador				INTEGER IDENTITY(1,1),
	Nombres						VARCHAR(30),
	Apellidos					VARCHAR(40),
	Numero_Identificacion		INT,
	Email						VARCHAR(100),
	Tipo_Identificacion			VARCHAR(2),
	Fecha_Creacion				DATETIME,
	Tipo_Numero_Identificacion	AS Tipo_Identificacion + CONVERT(VARCHAR, Numero_Identificacion),
	Nombre_Apellidos			AS Nombres + ' ' + Apellidos,
	CONSTRAINT PK_Personas PRIMARY KEY ( Identificador )
)
GO
IF OBJECT_ID('dbo.Personas') IS NOT NULL
	PRINT '<<< CREATED TABLE dbo.Personas >>>'
ELSE
	PRINT '<<< FAILED CREATING TABLE dbo.Personas >>>'
GO
GRANT INSERT, UPDATE, DELETE ON dbo.Personas TO PUBLIC
GO

IF OBJECT_ID('dbo.Usuarios') IS NOT NULL
BEGIN
	DROP TABLE dbo.Usuarios
	
	IF OBJECT_ID('dbo.Usuarios') IS NOT NULL
		PRINT '<<< FAILED DROPPING TABLE dbo.Usuarios >>>'
	ELSE
		PRINT '<<< DROPPED TABLE dbo.Usuarios >>>'
END
GO
CREATE TABLE dbo.Usuarios
(
	Identificador				INTEGER IDENTITY(1,1),
	Usuario						VARCHAR(30),
	Pass						VARCHAR(40),
	Fecha_Creacion				DATETIME,
	CONSTRAINT PK_Usuarios PRIMARY KEY ( Identificador )
)
GO
IF OBJECT_ID('dbo.Usuarios') IS NOT NULL
	PRINT '<<< CREATED TABLE dbo.Usuarios >>>'
ELSE
	PRINT '<<< FAILED CREATING TABLE dbo.Usuarios >>>'
GO
GRANT INSERT, UPDATE, DELETE ON dbo.Usuarios TO PUBLIC