USE dbPruebaTecnicaDVP
GO
PRINT '<<< CREATING PROCEDURE dbo.sp_consulta_personas >>>'

IF OBJECT_ID('dbo.sp_consulta_personas') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_consulta_personas
	
    IF OBJECT_ID('dbo.sp_consulta_personas') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_consulta_personas >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_consulta_personas >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.sp_consulta_personas
AS
BEGIN
	SELECT	Identificador,
			Nombres,
			Apellidos,
			Numero_Identificacion,
			Email,
			Tipo_Identificacion,
			Fecha_Creacion,
			Tipo_Numero_Identificacion,
			Nombre_Apellidos
	FROM	dbo.Personas
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.sp_consulta_personas') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_consulta_personas >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_consulta_personas >>>'
GO
GRANT EXECUTE ON dbo.sp_consulta_personas TO PUBLIC
GO

EXEC dbo.sp_consulta_personas
GO