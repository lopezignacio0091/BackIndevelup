USE [BDIndevelup]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/5/2021 17:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 10/5/2021 17:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[DuracionPlanificada] [int] NOT NULL,
	[UsuarioId] [int] NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/5/2021 17:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210506173259_createModels', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210507210319_updateTarea', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210510200648_usuarioNull', N'5.0.5')
SET IDENTITY_INSERT [dbo].[Tareas] ON 

INSERT [dbo].[Tareas] ([Id], [Codigo], [DuracionPlanificada], [UsuarioId], [Descripcion]) VALUES (1, 123, 12, NULL, N'Nueva')
INSERT [dbo].[Tareas] ([Id], [Codigo], [DuracionPlanificada], [UsuarioId], [Descripcion]) VALUES (2, 231, 12, 6, N'Nueva')
INSERT [dbo].[Tareas] ([Id], [Codigo], [DuracionPlanificada], [UsuarioId], [Descripcion]) VALUES (1013, 205, 12, 6, N'nueva tarea')
INSERT [dbo].[Tareas] ([Id], [Codigo], [DuracionPlanificada], [UsuarioId], [Descripcion]) VALUES (1014, 1234, 14, NULL, N'nueva tarea')
INSERT [dbo].[Tareas] ([Id], [Codigo], [DuracionPlanificada], [UsuarioId], [Descripcion]) VALUES (1017, 205, 14, NULL, N'tarea')
SET IDENTITY_INSERT [dbo].[Tareas] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre]) VALUES (6, N'Francisco')
INSERT [dbo].[Usuarios] ([Id], [Nombre]) VALUES (1009, N'juan fernandez')
INSERT [dbo].[Usuarios] ([Id], [Nombre]) VALUES (1010, N'Franco')
INSERT [dbo].[Usuarios] ([Id], [Nombre]) VALUES (1011, N'Matias')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Usuarios_UsuarioId]
GO
