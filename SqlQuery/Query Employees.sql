USE [master]
GO
/****** Object:  Database [BANCAS]    Script Date: 17/9/2021 11:16:49 p. m. ******/
CREATE DATABASE [BANCAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BANCAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BANCAS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BANCAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BANCAS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BANCAS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BANCAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BANCAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BANCAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BANCAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BANCAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BANCAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BANCAS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BANCAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BANCAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BANCAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BANCAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BANCAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BANCAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BANCAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BANCAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BANCAS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BANCAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BANCAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BANCAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BANCAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BANCAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BANCAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BANCAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BANCAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BANCAS] SET  MULTI_USER 
GO
ALTER DATABASE [BANCAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BANCAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BANCAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BANCAS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BANCAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BANCAS] SET QUERY_STORE = OFF
GO
USE [BANCAS]
GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO]  AS ('Emp'+right('00'+CONVERT([varchar],[ID]),(3))),
	[NUMERO_BANCA] [int] NULL,
	[NOMBRE] [varchar](30) NOT NULL,
	[APELLIDO] [varchar](30) NOT NULL,
	[CEDULA] [varchar](20) NOT NULL,
	[SALARIO] [money] NULL,
	[TELEFONO] [varchar](14) NULL,
	[SECTOR] [varchar](max) NULL,
	[LOCAL] [varchar](max) NULL,
	[FECHA_ENTRADA] [date] NULL,
	[FECHA_SALIDA] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[IDusuario] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](30) NOT NULL,
	[APELLIDO] [varchar](40) NOT NULL,
	[USUARIO] [varchar](20) NOT NULL,
	[PASSWORD] [varchar](20) NOT NULL,
	[ACCESO] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EMPLEADOS] ON 

INSERT [dbo].[EMPLEADOS] ([ID], [NUMERO_BANCA], [NOMBRE], [APELLIDO], [CEDULA], [SALARIO], [TELEFONO], [SECTOR], [LOCAL], [FECHA_ENTRADA], [FECHA_SALIDA]) VALUES (1, 55, N'DEWRY', N'VALDEZ', N'40225595590', 90000.0000, N'8094734768', N'DDDDDDDDDDDDDDDDDDDDDDDDDDDDDD', N'DDDDDDDDDDDDDDDDDDDDDDDDDDDDDD', CAST(N'2021-07-06' AS Date), N'7/15/2021')
SET IDENTITY_INSERT [dbo].[EMPLEADOS] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([IDusuario], [NOMBRE], [APELLIDO], [USUARIO], [PASSWORD], [ACCESO]) VALUES (1, N'DEWRY', N'PEÑA VALDEZ', N'Dewryp97', N'dewry123', N'ADMINISTRADOR')
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_login]
@usuario varchar(20),
@password varchar(20)
as
select IDusuario, NOMBRE, APELLIDO, ACCESO FROM USUARIOS
WHERE USUARIO=@usuario and PASSWORD=@password
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_empleado]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_empleado]
@textobuscar varchar(50)
as
select * from empleados
where nombre like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[speditar_empleado]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_empleado]
@idempleado int,
@codigo varchar(30) output,
@numerobanca int,
@nombre varchar(30),
@apellido varchar(30),
@cedula varchar(20),
@salario money,
@telefono varchar(14),
@sector varchar(MAX),
@local varchar(MAX),
@fecha_e date,
@fecha_s varchar(20)
as
update EMPLEADOS set NUMERO_BANCA=@numerobanca, nombre=@nombre, apellido=@apellido,
CEDULA=@cedula, SALARIO=@salario, TELEFONO=@telefono, SECTOR=@sector,
LOCAL=@local, FECHA_ENTRADA=@fecha_e, FECHA_SALIDA=@fecha_s
where ID=@idempleado
GO
/****** Object:  StoredProcedure [dbo].[speditar_usuarios]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP Editar usuarios

CREATE PROC [dbo].[speditar_usuarios]
@idusuario int,
@nombre varchar(30),
@apellido varchar(40),
@usuario varchar(20),
@password varchar(20),
@acceso varchar(20)
as
update USUARIOS set NOMBRE=@nombre,APELLIDO=@apellido,USUARIO=@usuario,PASSWORD=@password,ACCESO=@acceso
where IDusuario=@idusuario
GO
/****** Object:  StoredProcedure [dbo].[spelimiar_usuarios]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spelimiar_usuarios]
@idusuario int
as
delete from USUARIOS
where IDusuario=@idusuario
GO
/****** Object:  StoredProcedure [dbo].[speliminar_empleado]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_empleado]
@idempleado int
as
delete from EMPLEADOS
where ID=@idempleado
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_empleado]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_empleado]
@idempleado int output,
@codigo varchar(30) output,
@numerobanca int,
@nombre varchar(30),
@apellido varchar(30),
@cedula varchar(20),
@salario money,
@telefono varchar(14),
@sector varchar(MAX),
@local varchar(MAX),
@fecha_e date,
@fecha_s varchar(20)
as
insert into EMPLEADOS (NUMERO_BANCA,NOMBRE,APELLIDO,CEDULA,SALARIO,TELEFONO,SECTOR,LOCAL,FECHA_ENTRADA,FECHA_SALIDA)
values (@numerobanca,@nombre,@apellido,@cedula,@salario,@telefono,@sector,@local,@fecha_e,@fecha_s)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_usuarios]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spinsertar_usuarios]
@idusuario int output,
@nombre varchar(30),
@apellido varchar(40),
@usuario varchar(20),
@password varchar(20),
@acceso varchar(20)
as
insert into USUARIOS VALUES(@nombre,@apellido,@usuario,@password,@acceso)
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_empleado]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_empleado]
as
select top 200 *  from empleados
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_usuarios]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_usuarios]
as
select NOMBRE,APELLIDO,ACCESO From USUARIOS
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_usuarios_administrador]    Script Date: 17/9/2021 11:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Mostrar usuarios desde el acceso de administrador para hacer configuraciones
create proc [dbo].[spmostrar_usuarios_administrador]
as
select * From USUARIOS
GO
USE [master]
GO
ALTER DATABASE [BANCAS] SET  READ_WRITE 
GO
