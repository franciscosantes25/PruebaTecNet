USE [BdGeneric]
GO
/****** Object:  Schema [Employees]    Script Date: 10/09/2024 06:27:01 p. m. ******/
CREATE SCHEMA [Employees]
GO
/****** Object:  Schema [Positions]    Script Date: 10/09/2024 06:27:01 p. m. ******/
CREATE SCHEMA [Positions]
GO
/****** Object:  Schema [States]    Script Date: 10/09/2024 06:27:01 p. m. ******/
CREATE SCHEMA [States]
GO
/****** Object:  Table [Employees].[Employees]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Employees].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photograph] [varbinary](max) NULL,
	[Name] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[PositionId] [int] NOT NULL,
	[BirthDate] [date] NOT NULL,
	[HiringDate] [date] NOT NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[StateId] [tinyint] NULL,
	[IsVisible] [bit] NOT NULL,
	[IsBySystem] [bit] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUserId] [bigint] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [bigint] NULL,
 CONSTRAINT [PK_Employees_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Positions].[Positions]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Positions].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsBySystem] [bit] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUserId] [bigint] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [bigint] NULL,
 CONSTRAINT [PK_Position_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [States].[States]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [States].[States](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsBySystem] [bit] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUserId] [bigint] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [bigint] NULL,
 CONSTRAINT [PK_States_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Employees].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([PositionId])
REFERENCES [Positions].[Positions] ([Id])
GO
ALTER TABLE [Employees].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
GO
ALTER TABLE [Employees].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_States] FOREIGN KEY([StateId])
REFERENCES [States].[States] ([Id])
GO
ALTER TABLE [Employees].[Employees] CHECK CONSTRAINT [FK_Employees_States]
GO
/****** Object:  StoredProcedure [Employees].[SP_EMPLOYEEDELETE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [Employees].[SP_EMPLOYEEDELETE] 3, 1

CREATE PROCEDURE [Employees].[SP_EMPLOYEEDELETE]
@PA_Id bigint = 0 
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[Employees].[Employees]
	set  [IsVisible] = 0
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 
	, [Photograph]
	, [Name]
	, [LastName]
	, [PositionId]
	, [BirthDate]
	, [HiringDate]
	, [Address]
	, [Phone]
	, [Email]
	, [StateId]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[Employees].[Employees]
	where id = @PA_Id

END
GO
/****** Object:  StoredProcedure [Employees].[SP_EMPLOYEEINSERT]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [Employees].[SP_EMPLOYEEINSERT] null, 

CREATE PROCEDURE [Employees].[SP_EMPLOYEEINSERT]
@PA_Photograph VARBINARY = null 
, @PA_Name VARCHAR(100) = null 
, @PA_LastName VARCHAR(100) = null 
, @PA_PositionId INT = 0
, @PA_BirthDate DATE = null 
, @PA_HiringDate DATE = null 
, @PA_Address VARCHAR(1000) = null 
, @PA_Phone VARCHAR(15) = null 
, @PA_Email VARCHAR(100) = null 
, @PA_StateId TINYINT = 0
, @PA_InsertUserId BIGINT = 0
AS
BEGIN
	
	declare @newId int = 0

	INSERT INTO [Employees].[Employees] (
	[Photograph]
	, [Name]
	, [LastName]
	, [PositionId]
	, [BirthDate]
	, [HiringDate]
	, [Address]
	, [Phone]
	, [Email]
	, [StateId]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId])
	VALUES(
	  @PA_Photograph
	, @PA_Name 
	, @PA_LastName 
	, @PA_PositionId 
	, @PA_BirthDate 
	, @PA_HiringDate 
	, @PA_Address 
	, @PA_Phone 
	, @PA_Email 
	, @PA_StateId 
	, 1
	, 1
	, GETDATE()
	, @PA_InsertUserId
	)
	
	set @newId = SCOPE_IDENTITY()

	select [Id] 
	, [Photograph]
	, [Name]
	, [LastName]
	, [PositionId]
	, [BirthDate]
	, [HiringDate]
	, [Address]
	, [Phone]
	, [Email]
	, [StateId]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	from [BdGeneric].[Employees].[Employees]
	where id = @newId

END
GO
/****** Object:  StoredProcedure [Employees].[SP_EMPLOYEELIST]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Employees].[SP_EMPLOYEELIST]
@PA_ACTIVO BIT = 1
AS
BEGIN
	SELECT Id	
	, Photograph	
	, [Name]
	, LastName
	, [PositionId]
	, [BirthDate]
	, [HiringDate]
	, [Address]
	, [Phone]
	, [Email]
	, [StateId]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]	
	, [UpdateUserId]
	FROM [BdGeneric].[Employees].[Employees]
	WHERE [IsVisible] = @PA_ACTIVO
END
GO
/****** Object:  StoredProcedure [Employees].[SP_EMPLOYEEUPDATE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [Employees].[SP_EMPLOYEEUPDATE] 2, null, 'Francisco', 'Santess', 1, '1988-09-25', '2024-09-10', 'Actualización de dirección', '5512345678', 'ing.francisco.santes@gmail.com', 1, 1

CREATE PROCEDURE [Employees].[SP_EMPLOYEEUPDATE]
@PA_Id bigint = 0 
, @PA_Photograph VARBINARY = null 
, @PA_Name VARCHAR(100) = null 
, @PA_LastName VARCHAR(100) = null 
, @PA_PositionId INT = 0
, @PA_BirthDate DATE = null 
, @PA_HiringDate DATE = null 
, @PA_Address VARCHAR(1000) = null 
, @PA_Phone VARCHAR(15) = null 
, @PA_Email VARCHAR(100) = null 
, @PA_StateId TINYINT = 0
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[Employees].[Employees]
	set  [Photograph] =  @PA_Photograph
	, [Name] = @PA_Name
	, [LastName] = @PA_LastName
	, [PositionId] = @PA_PositionId
	, [BirthDate] = @PA_BirthDate
	, [HiringDate] = @PA_HiringDate
	, [Address] = @PA_Address
	, [Phone] = @PA_Phone
	, [Email] = @PA_Email
	, [StateId] = @PA_StateId
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 
	, [Photograph]
	, [Name]
	, [LastName]
	, [PositionId]
	, [BirthDate]
	, [HiringDate]
	, [Address]
	, [Phone]
	, [Email]
	, [StateId]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[Employees].[Employees]
	where id = @PA_Id

END
GO
/****** Object:  StoredProcedure [Positions].[SP_POSITIONDELETE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Positions].[SP_POSITIONDELETE]
@PA_Id bigint = 0 
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[Positions].[Positions]
	set  [IsVisible] = 0
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 
	, [Name]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[Positions].[Positions]
	where id = @PA_Id

END
GO
/****** Object:  StoredProcedure [Positions].[SP_POSITIONINSERT]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [Positions].[SP_POSITIONINSERT]
  @PA_Name VARCHAR(100) = null 
, @PA_InsertUserId BIGINT = 0
AS
BEGIN
	
	declare @newId int = 0

	INSERT INTO [BdGeneric].[Positions].[Positions] (
	  [Name]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId])
	VALUES(
	  @PA_Name 	
	, 1
	, 1
	, GETDATE()
	, @PA_InsertUserId
	)
	
	set @newId = SCOPE_IDENTITY()

	select [Id] 	
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	from [BdGeneric].[Positions].[Positions]
	where id = @newId

END
GO
/****** Object:  StoredProcedure [Positions].[SP_POSITIONLIST]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Positions].[SP_POSITIONLIST]
@PA_ACTIVO BIT = 1
AS
BEGIN
	SELECT Id		
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]	
	, [UpdateUserId]
	FROM [BdGeneric].[Positions].[Positions]
	WHERE [IsVisible] = @PA_ACTIVO
END
GO
/****** Object:  StoredProcedure [Positions].[SP_POSITIONUPDATE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [Positions].[SP_POSITIONUPDATE]
@PA_Id bigint = 0 
, @PA_Name VARCHAR(100) = null 
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[Positions].[Positions]
	set  [Name] = @PA_Name
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 	
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[Positions].[Positions]
	where id = @PA_Id

END
GO
/****** Object:  StoredProcedure [States].[SP_STATEDELETE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [States].[SP_STATEDELETE]
@PA_Id bigint = 0 
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[States].[States]
	set  [IsVisible] = 0
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 
	, [Name]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[States].[States]
	where id = @PA_Id

END
GO
/****** Object:  StoredProcedure [States].[SP_STATEINSERT]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [States].[SP_STATEINSERT]
  @PA_Name VARCHAR(100) = null 
, @PA_InsertUserId BIGINT = 0
AS
BEGIN
	
	declare @newId int = 0

	INSERT INTO [BdGeneric].[States].[States] (
	  [Name]
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId])
	VALUES(
	  @PA_Name 	
	, 1
	, 1
	, GETDATE()
	, @PA_InsertUserId
	)
	
	set @newId = SCOPE_IDENTITY()

	select [Id] 	
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	from [BdGeneric].[States].[States]
	where id = @newId

END
GO
/****** Object:  StoredProcedure [States].[SP_STATELIST]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [States].[SP_STATELIST]
@PA_ACTIVO BIT = 1
AS
BEGIN
	SELECT Id		
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]	
	, [UpdateUserId]
	FROM [BdGeneric].[States].[States]
	WHERE [IsVisible] = @PA_ACTIVO
END
GO
/****** Object:  StoredProcedure [States].[SP_STATEUPDATE]    Script Date: 10/09/2024 06:27:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [States].[SP_STATEUPDATE]
@PA_Id bigint = 0 
, @PA_Name VARCHAR(100) = null 
, @PA_UpdateUserId BIGINT = 0
AS
BEGIN
	
	UPDATE [BdGeneric].[States].[States]
	set  [Name] = @PA_Name
	, [UpdateDate] = getdate()
	, [UpdateUserId] = @PA_UpdateUserId
	where id = @PA_Id

	select [Id] 	
	, [Name]	
	, [IsVisible]
	, [IsBySystem]
	, [InsertDate]
	, [InsertUserId]
	, [UpdateDate]
	, [UpdateUserId]
	from [BdGeneric].[States].[States]
	where id = @PA_Id

END
GO
