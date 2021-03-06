USE [TallerAdminDB]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 26/05/2022 18:17:57 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 26/05/2022 18:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id] [int] NOT NULL,
	[nombre_idioma] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/05/2022 18:17:57 ******/
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
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (5, N'Rodrigo', N'Castagnino', N'1234', 3, N'rod@rod.com')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (6, N'test@test.com', N'test@test.com', N'test', 0, N'test@test.com')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (14, N'Rodrigo', N'Castagnino', N'a????xd	?p???h', 0, N'Yj+Jg9cCjLVHyO9GqFqZaUNJW')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (15, N'ab', N'ba', N'?|???plL4?h??N{', 0, N'jY7B6ISssTBYqgyhg7lKOg==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (16, N'as', N'sa', N'Z:Z??mC?8?,?x?', 0, N'KFpSyVZgCk0/+vEjdTAJ7w==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (17, N'rod', N'cas', N'%?Z???@
?d?mq<?', 0, N'ewCgPdjtssYYcFd8rQCa/w==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (18, N'Rod', N'Cas', N'%?Z???@
?d?mq<?', 0, N'casta@test.com')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (19, N'qwerty', N'qwerty', N'%?Z???@
?d?mq<?', 0, N'Uu4NCFt1635PAsds72i3qA==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (20, N'rod', N'rod', N'%?Z???@
?d?mq<?', 0, N'HPnBtvOKWAxzzeqirnOLBQ==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (21, N'aww', N'bww', N'%?Z???@
?d?mq<?', 0, N'UDPPkluoGTNkZ/ZDLb0C/Q==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (22, N'csacsa', N'cascacs', N'%?Z???@
?d?mq<?', 0, N'ewCgPdjtssYYcFd8rQCa/w==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (23, N'iI2Smmdk2SkpvwKITPbqyQ==', N'rod', N'%?Z???@
?d?mq<?', 0, N'do24ZM+fInb7P9qlbDdgeHEKk')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (27, N'cas', N'cas', N'%?Z???@
?d?mq<?', 0, N'7OfIAX5Piv7DHrRr1GmPeA==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (28, N'cas', N'cas', N'%?Z???@
?d?mq<?', 0, N'kMjWzCU7D92KcBIYNzHQXw==')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (30, N'prueba', N'prueba', N'?e|??x???Yq?rq?C', 0, N'Qi5i0e/eAr2YBjMP2IJcDZgeM')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [password], [contador], [email]) VALUES (31, N'Test', N'Test', N'^?g?9??QE?/???"	', 0, N'IY4PdwXWiYL43iQMAGkVnw==')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[altaUsuario]    Script Date: 26/05/2022 18:17:57 ******/
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
/****** Object:  StoredProcedure [dbo].[getUsuario]    Script Date: 26/05/2022 18:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUsuario]
@email nvarchar(50)
as
select top 1 * from Usuario where email = @email;
GO
/****** Object:  StoredProcedure [dbo].[incrementarContador]    Script Date: 26/05/2022 18:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[incrementarContador]
@email nvarchar(50)
as
update Usuario set contador += 1 where email = @email;
GO
/****** Object:  StoredProcedure [dbo].[restablecerContador]    Script Date: 26/05/2022 18:17:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[restablecerContador]
@email nvarchar(50)
as
update Usuario set contador = 0 where email = @email;
GO
