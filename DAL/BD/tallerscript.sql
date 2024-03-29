USE [master]
GO
/****** Object:  Database [TallerAdminDB]    Script Date: 08/09/2022 11:41:02 ******/
CREATE DATABASE [TallerAdminDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TallerAdminDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TallerAdminDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TallerAdminDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TallerAdminDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TallerAdminDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TallerAdminDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TallerAdminDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TallerAdminDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TallerAdminDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TallerAdminDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TallerAdminDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TallerAdminDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TallerAdminDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TallerAdminDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TallerAdminDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TallerAdminDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TallerAdminDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TallerAdminDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TallerAdminDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TallerAdminDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TallerAdminDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TallerAdminDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TallerAdminDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TallerAdminDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TallerAdminDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TallerAdminDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TallerAdminDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TallerAdminDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TallerAdminDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TallerAdminDB] SET  MULTI_USER 
GO
ALTER DATABASE [TallerAdminDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TallerAdminDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TallerAdminDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TallerAdminDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TallerAdminDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TallerAdminDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TallerAdminDB] SET QUERY_STORE = OFF
GO
USE [TallerAdminDB]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id] [int] NOT NULL,
	[fk_usuario] [int] NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[criticidad] [int] NOT NULL,
	[fecha_movimiento] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiqueta](
	[id] [int] NOT NULL,
	[clave] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Etiqueta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[idPermisoPadre] [int] NOT NULL,
	[idPermisoHijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[default] [bit] NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[permiso] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traducciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_idioma] [int] NOT NULL,
	[fk_etiqueta] [int] NOT NULL,
	[valor] [nvarchar](50) NULL,
 CONSTRAINT [PK_Traducciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[contador] [int] NULL,
	[email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Permiso]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Permiso](
	[idUsuario] [int] NOT NULL,
	[idPermiso] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (1, N'LGI_btnLogin')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (2, N'LGI_lblEmail')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (3, N'LGI_lblPass')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (4, N'LGI_lbllogin')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (5, N'LGI_gbInicio')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (6, N'LGI_btnNuevoUsr')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (7, N'LGI_msIdioma')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (8, N'NU_gb')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (9, N'NU_lblNombre')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (10, N'NU_Apellido')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (11, N'NU_lblEmail')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (12, N'NU_btnAltaUsuario')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (13, N'NU_lblTitulo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (14, N'P_MenuEmpleado')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (15, N'P_MenuOmnibus')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (16, N'P_MenuReparacion')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (17, N'P_MenuRepuesto')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (18, N'P_MenuReportes')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (19, N'P_MenuStock')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (20, N'P_MenuSolicitudes')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (21, N'P_MenuSession')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (22, N'P_menuItemCerrarSession')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (23, N'P_miRepoCostoxO')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (24, N'P_menuIdioma')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (25, N'P_miSolicitudes')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (26, N'P_miIngresos')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (27, N'P_miConsultar')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (28, N'P_miInventario')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (29, N'P_miConsultarRespuesto')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (30, N'P_miRegistrarRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (31, N'P_miAltaRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (32, N'P_miBajaRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (33, N'P_miModiRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (34, N'P_miConsultarRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (35, N'P_miAsignarRepa')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (36, N'P_miSolicitarRepu')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (37, N'P_miSupervisar')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (38, N'P_miRegistrarOmnibus')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (39, N'P_miAltaOmni')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (40, N'P_miBajaOmni')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (41, N'P_miModiOmni')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (42, N'P_miConsultarOmni')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (43, N'P_miEstatus')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (44, N'P_miEvaluarOmni')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (45, N'P_miRegistrarEmple')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (46, N'P_miAltaEmple')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (47, N'P_miBajaEmple')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (48, N'P_miModiEmple')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (49, N'P_miConsultarEmple')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (50, N'P_imIdiomaNuevo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (51, N'P_miNuevoIdioma')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (52, N'P_miTraduccion')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (53, N'NI_lblNombre')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (54, N'NI_lblTitulo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (55, N'NI_btnIngresar')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (56, N'NI_lblDisponibles')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (57, N'NT_lblTitulo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (58, N'NT_lblRef')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (59, N'NT_lblRefIdioma')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (60, N'NT_lblIdioma')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (61, N'NT_lblEtiqueta')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (62, N'NT_lblValor')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (63, N'NT_btnTraducir')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (64, N'P_menuPermisos')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (65, N'P_miGestionPatentesFamilias')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (66, N'P_miGestionPermisosUsuario')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (67, N'PU_lblTitulo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (68, N'PU_lblUsr')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (69, N'PU_lblFamilia')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (70, N'PU_lblPatente')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (71, N'PU_btnUsr')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (72, N'PU_btnFamilia')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (73, N'PU_btnPatente')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (74, N'PU_btnGuardar')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (75, N'FP_lblTitulo')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (76, N'FP_lblNuevaFamilia')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (77, N'FP_lblNombreNuevaFamilia')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (78, N'FP_btnGuardarFamilia')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (79, N'FP_lblNuevoPermiso')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (80, N'FP_lblNombreNuevoPermiso')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (81, N'FP_btnGuardaPermiso')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (82, N'FP_lblFamilias')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (83, N'FP_btnConfFam')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (84, N'FP_lblPatentes')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (85, N'FP_btnAgregarPatente')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (86, N'FP_btnGuardar')
INSERT [dbo].[Etiqueta] ([id], [clave]) VALUES (87, N'FP_btnAgregarFamilia')
GO
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 2)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 3)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 4)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 5)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 6)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 7)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 8)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 9)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 10)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 11)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 12)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 13)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 14)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 15)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 16)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 17)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 18)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 19)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 20)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1, 21)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (24, 2)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (24, 3)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (24, 4)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (24, 5)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 20)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 21)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 18)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 16)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 2)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1029, 1030)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1030, 1029)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (1030, 3)
GO
INSERT [dbo].[Idioma] ([id], [nombre], [default]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([id], [nombre], [default]) VALUES (2, N'Ingles', 0)
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (1, N'Administrador', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (2, N'Empleado ABM', N'EmpleadoABM')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (3, N'Empleado Consultar', N'EmpleadoConsultar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (4, N'Omnibus ABM', N'OmnibusABM')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (5, N'Omnibus Consultar', N'OmnibusConsultar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (6, N'Omnibus Status', N'OmnibusStatus')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (7, N'Omnibus Evaluar', N'OmnibusEvaluar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (8, N'Reparacion ABM', N'ReparacionABM')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (9, N'Reparacion Consultar', N'ReparacionConsultar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (10, N'Reparacion Asignar', N'ReparacionAsignar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (11, N'Reparacion SoliRepu', N'ReparacionSoliRepu')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (12, N'Reparacion Supervisar', N'ReparacionSupervisar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (13, N'Repuesto ABM', N'RepuestoABM')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (14, N'Repuesto Consultar', N'RepuestoConsultar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (15, N'Stock Ingresos', N'StockIngresos')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (16, N'Stock Inventario', N'StockInventario')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (17, N'Stock Consultar', N'StockConsultar')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (18, N'Solicitudes', N'Solicitudes')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (19, N'Costos Omnibus', N'CostosOmnibus')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (20, N'AsignarFamiliaPatente', N'AsignarFamiliaPatente')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (21, N'ManagerIdioma', N'ManagerIdioma')
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (22, N'JefeArea', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (23, N'Tecnico', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (24, N'Administrativo', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (25, N'JefeAlmacenes', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (1029, N'Nueva', NULL)
INSERT [dbo].[Permiso] ([id], [nombre], [permiso]) VALUES (1030, N'Nueva2', NULL)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Traducciones] ON 

INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (1, 1, 1, N'Ingresar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (2, 2, 1, N'Login')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (3, 1, 2, N'Email:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (4, 2, 2, N'Email:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (5, 1, 3, N'Contraseña:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (6, 2, 3, N'Password:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (7, 1, 4, N'Login')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (8, 2, 4, N'Login')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (9, 1, 5, N'Ingreso al Sistema')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (10, 2, 5, N'Login to the System')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (11, 1, 6, N'No tenes cuenta? Registrate')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (12, 2, 6, N'You don´t have an account? Sign up')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (13, 1, 7, N'Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (14, 2, 7, N'Languaje')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (15, 1, 8, N'Ingrese Usuario')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (16, 2, 8, N'Enter User')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (17, 1, 9, N'Nombre:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (18, 2, 9, N'Name:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (19, 1, 10, N'Apellido:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (20, 2, 10, N'Surname:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (21, 1, 11, N'Email:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (22, 2, 11, N'Email:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (23, 1, 12, N'Registrar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (24, 2, 12, N'Register')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (25, 1, 13, N'Nuevo Usuario')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (26, 2, 13, N'New User')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (27, 1, 14, N'Empleados')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (28, 2, 14, N'Employees')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (29, 1, 15, N'Omnibus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (30, 2, 15, N'Bus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (31, 1, 16, N'Reparacion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (32, 2, 16, N'Repair')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (33, 1, 17, N'Repuesto')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (34, 2, 17, N'Spare Part')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (35, 1, 18, N'Reportes')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (36, 2, 18, N'Reports')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (37, 1, 19, N'Stock')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (38, 2, 19, N'Stock')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (39, 1, 20, N'Solicitudes Repuestos')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (40, 2, 20, N'Spare Parts Requests')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (41, 1, 21, N'Sesion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (42, 2, 21, N'Session')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (43, 1, 22, N'Cerrar Sesion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (44, 2, 22, N'Sign off')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (45, 1, 23, N'Costo por Omnibus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (46, 2, 23, N'Cost per bus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (47, 1, 24, N'Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (48, 2, 24, N'Languaje')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (57, 1, 25, N'Solicitudes')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (58, 2, 25, N'Requisition')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (59, 1, 26, N'Ingresos')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (60, 2, 26, N'Income')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (61, 1, 27, N'Consultar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (62, 2, 27, N'Consult')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (63, 1, 28, N'Inventario')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (64, 2, 28, N'Inventory')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (65, 1, 29, N'Consultar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (66, 2, 29, N'Consult')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (67, 1, 30, N'Registrar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (68, 2, 30, N'Register')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (69, 1, 31, N'Nueva Reparacion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (70, 2, 31, N'New Repair')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (71, 1, 32, N'Eliminar Repair')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (72, 2, 32, N'Delete Repair')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (73, 1, 33, N'Modificar Reparacion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (74, 2, 33, N'Modify Repair')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (75, 1, 34, N'Consultar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (76, 2, 34, N'Consult')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (77, 1, 35, N'Asignar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (78, 2, 35, N'Assign')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (79, 1, 36, N'Solicitar Repuesto')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (80, 2, 36, N'Request Replacement')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (81, 1, 37, N'Supervisar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (82, 2, 37, N'Supervise')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (83, 1, 38, N'Registrar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (84, 2, 38, N'Register')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (85, 1, 39, N'Nuevo Omnibus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (86, 2, 39, N'New Bus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (87, 1, 40, N'Eliminar Omnibus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (88, 2, 40, N'Delete Bus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (89, 1, 41, N'Modificar Omnibus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (90, 2, 41, N'Modify Bus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (91, 1, 42, N'Consultar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (92, 2, 42, N'Consult')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (93, 1, 43, N'Estatus')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (94, 2, 43, N'Status')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (95, 1, 44, N'Evaluar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (96, 2, 44, N'Evaluate')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (97, 1, 45, N'Registrar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (98, 2, 45, N'Register')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (99, 1, 46, N'Nuevo Empleado')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (100, 2, 46, N'New Employee')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (101, 1, 47, N'Eliminar Empleado')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (102, 2, 47, N'Delete employee')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (103, 1, 48, N'Modificar Empleado')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (104, 2, 48, N'Modify employee')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (105, 1, 49, N'Consultar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (106, 2, 49, N'Consult')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (107, 1, 50, N'Agregar')
GO
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (108, 2, 50, N'Add')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (109, 1, 51, N'Nuevo Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (110, 2, 51, N'New Languaje')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (111, 1, 52, N'Traduccion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (112, 2, 52, N'Translation')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (113, 1, 53, N'Idioma a ingresar:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (114, 2, 53, N'Language to enter:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (115, 1, 54, N'Nuevo Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (116, 2, 54, N'New Language')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (117, 1, 55, N'Ingresar Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (118, 2, 55, N'Enter Language')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (119, 1, 56, N'Disponibles')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (120, 2, 56, N'Available')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (121, 1, 57, N'Nuevas Traducciones')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (122, 2, 57, N'New Translations')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (123, 1, 58, N'Refencias de idioma default')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (124, 2, 58, N'Default language references')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (125, 1, 59, N'Traducciones del nuevo idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (126, 2, 59, N'New language translations')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (127, 1, 60, N'Idioma')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (128, 2, 60, N'Languaje')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (129, 1, 61, N'Etiquetas')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (130, 2, 61, N'Tags')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (131, 1, 62, N'Valor')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (132, 2, 62, N'Value')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (133, 1, 63, N'Agregar Traduccion')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (134, 2, 63, N'Add Translation')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (149, 1, 64, N'Permisos')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (150, 2, 64, N'Permissions')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (151, 1, 65, N'Gestion Patentes-Familias')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (152, 2, 65, N'Patent-Family Management')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (153, 1, 66, N'Gestion Permisos-Usuario')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (154, 2, 66, N'Permissions-User Management')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (155, 1, 67, N'Gestion Permisos-Usuario')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (156, 2, 67, N'Permissions-User Management')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (157, 1, 68, N'Usuario:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (158, 2, 68, N'User:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (159, 1, 69, N'Familia:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (160, 2, 69, N'Family:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (161, 1, 70, N'Patente:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (162, 2, 70, N'Patent:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (163, 1, 71, N'Configurar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (164, 2, 71, N'Set up')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (165, 1, 72, N'Agregar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (166, 2, 72, N'Add')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (167, 1, 73, N'Agregar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (168, 2, 73, N'Add')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (169, 1, 74, N'Guardar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (170, 2, 74, N'Save')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (171, 1, 75, N'Gestion Familias-Patentes')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (172, 2, 75, N'Patent-Family Management')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (173, 1, 76, N'Nueva Familia')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (174, 2, 76, N'New Family')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (175, 1, 77, N'Nombre:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (176, 2, 77, N'Name:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (177, 1, 78, N'Guardar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (178, 2, 78, N'Save')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (179, 1, 79, N'Nuevo Permiso')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (180, 2, 79, N'New Permission')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (181, 1, 80, N'Nombre:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (182, 2, 80, N'Name:')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (183, 1, 81, N'Guardar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (184, 2, 81, N'Save')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (185, 1, 82, N'Familias en sistema')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (186, 2, 82, N'Systems Familys')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (187, 1, 83, N'Configurar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (188, 2, 83, N'Set up')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (189, 1, 84, N'Patentes')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (190, 2, 84, N'Patents')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (191, 1, 85, N'Agregar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (192, 2, 85, N'Add')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (193, 1, 86, N'Guardar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (194, 2, 86, N'Save')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (1149, 1, 87, N'Agregar')
INSERT [dbo].[Traducciones] ([id], [fk_idioma], [fk_etiqueta], [valor]) VALUES (1150, 2, 87, N'Add')
SET IDENTITY_INSERT [dbo].[Traducciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (1, N'Rodrigo', N'Castagnino', N'??f?.??>{_????!1', 0, N'BJv5vVBgrGOArf3pY3JXjw==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (2, N'Test', N'Test', N'?Ri&??????<v?A', 0, N'0n5mCK4M8IiM08LgjmyeXw==')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (1, 1)
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_Familia_Permiso] FOREIGN KEY([idPermisoPadre])
REFERENCES [dbo].[Permiso] ([id])
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK_Patente_Familia_Permiso]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_Familia_Permiso1] FOREIGN KEY([idPermisoHijo])
REFERENCES [dbo].[Permiso] ([id])
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK_Patente_Familia_Permiso1]
GO
ALTER TABLE [dbo].[Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Traducciones_Etiqueta] FOREIGN KEY([fk_etiqueta])
REFERENCES [dbo].[Etiqueta] ([id])
GO
ALTER TABLE [dbo].[Traducciones] CHECK CONSTRAINT [FK_Traducciones_Etiqueta]
GO
ALTER TABLE [dbo].[Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Traducciones_Idioma] FOREIGN KEY([fk_idioma])
REFERENCES [dbo].[Idioma] ([id])
GO
ALTER TABLE [dbo].[Traducciones] CHECK CONSTRAINT [FK_Traducciones_Idioma]
GO
ALTER TABLE [dbo].[Usuario_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Permiso_Permiso] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permiso] ([id])
GO
ALTER TABLE [dbo].[Usuario_Permiso] CHECK CONSTRAINT [FK_Usuario_Permiso_Permiso]
GO
ALTER TABLE [dbo].[Usuario_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Permiso_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Usuario_Permiso] CHECK CONSTRAINT [FK_Usuario_Permiso_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[altaIdioma]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[altaIdioma] 
@nombre nvarchar(50)
as
insert into Idioma (id,nombre,[default]) values ((select max(id)+1 from Idioma),@nombre,'0');
GO
/****** Object:  StoredProcedure [dbo].[altaTraduccion]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[altaTraduccion]
@idIdioma int,
@claveEtiqueta nvarchar(50),
@valor nvarchar(50)
as
insert into Traducciones values (@idIdioma,(select id from Etiqueta where clave = @claveEtiqueta),@valor)
GO
/****** Object:  StoredProcedure [dbo].[altaUsuario]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[altaUsuario]
@nombre nvarchar(50),
@apellido nvarchar(50),
@email nvarchar(50),
@pass nvarchar(50)
as
insert into Usuario (nombre, apellido, password, contador, email)
values (@nombre, @apellido, @pass, 0, @email);
GO
/****** Object:  StoredProcedure [dbo].[getUsuario]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUsuario]
@email nvarchar(50)
as
select top 1 * from Usuario where email = @email;
GO
/****** Object:  StoredProcedure [dbo].[GuardarPatente]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarPatente]
@nombre nvarchar(50),
@permiso nvarchar(50)
as
begin
insert into Permiso values (@nombre,@permiso)
end
GO
/****** Object:  StoredProcedure [dbo].[incrementarContador]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[incrementarContador]
@email nvarchar(50)
as
update Usuario set contador += 1 where email = @email;
GO
/****** Object:  StoredProcedure [dbo].[LlenarFamiliaComponente]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[LlenarFamiliaComponente]
@idUsuario int
as
begin
SELECT p.* FROM Usuario_Permiso up
INNER JOIN Permiso p on p.id = up.idPermiso
WHERE idUsuario = @idUsuario;
end
GO
/****** Object:  StoredProcedure [dbo].[restablecerContador]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[restablecerContador]
@email nvarchar(50)
as
update Usuario set contador = 0 where email = @email;
GO
/****** Object:  StoredProcedure [dbo].[TraerFamilias]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[TraerFamilias]
as
select * from Permiso p where p.permiso is null;
GO
/****** Object:  StoredProcedure [dbo].[TraerPatentes]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[TraerPatentes]
as
begin
select * from Permiso where permiso is not null;
end
GO
/****** Object:  StoredProcedure [dbo].[TraerTodo]    Script Date: 08/09/2022 11:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TraerTodo]
@idPermisoP int
as
BEGIN
WITH RECURSIVO AS (SELECT fp.idPermisoPadre, fp.idPermisoHijo FROM Familia_Patente fp WHERE fp.idPermisoPadre = @idPermisoP
UNION ALL SELECT fp2.idPermisoPadre, fp2.idPermisoHijo FROM Familia_Patente fp2 INNER JOIN RECURSIVO r on r.idPermisoHijo = fp2.idPermisoPadre)
SELECT r.idPermisoPadre, r.idPermisoHijo, p.id, p.Nombre, p.Permiso FROM RECURSIVO r INNER JOIN Permiso p on r.idPermisoHijo = p.id
END
GO
USE [master]
GO
ALTER DATABASE [TallerAdminDB] SET  READ_WRITE 
GO
