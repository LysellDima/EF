USE [lesuser]
GO
/****** Object:  Table [dbo].[Iskop]    Script Date: 10.10.2023 12:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iskop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ID_Sale] [int] NULL,
	[Sale] [int] NULL,
	[ID_Mine] [int] NULL,
 CONSTRAINT [PK_Iskop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mine]    Script Date: 10.10.2023 12:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mine](
	[ID_Mine] [int] NOT NULL,
	[Mine_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mine] PRIMARY KEY CLUSTERED 
(
	[ID_Mine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 10.10.2023 12:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[ID_Sale] [int] NOT NULL,
	[Unit] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[ID_Sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Iskop] ON 

INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (1, N'Известняк', 5, 400, 4)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (2, N'Песок', 4, 650, 2)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (3, N'Глина', 4, 3200, 2)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (4, N'Гранит', 5, 600, 2)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (5, N'Торф', 4, 820, 3)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (6, N'Золото', 3, 2895, 1)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (7, N'Лазурит', 3, 202, 1)
INSERT [dbo].[Iskop] ([ID], [Name], [ID_Sale], [Sale], [ID_Mine]) VALUES (8, N'Железо', 2, 50, 3)
SET IDENTITY_INSERT [dbo].[Iskop] OFF
GO
INSERT [dbo].[Mine] ([ID_Mine], [Mine_name]) VALUES (1, N'Северная')
INSERT [dbo].[Mine] ([ID_Mine], [Mine_name]) VALUES (2, N'Заречная')
INSERT [dbo].[Mine] ([ID_Mine], [Mine_name]) VALUES (3, N'Сибирская')
INSERT [dbo].[Mine] ([ID_Mine], [Mine_name]) VALUES (4, N'Октябрьский')
GO
INSERT [dbo].[Sale] ([ID_Sale], [Unit]) VALUES (1, N'Т')
INSERT [dbo].[Sale] ([ID_Sale], [Unit]) VALUES (2, N'Кг')
INSERT [dbo].[Sale] ([ID_Sale], [Unit]) VALUES (3, N'Гр')
INSERT [dbo].[Sale] ([ID_Sale], [Unit]) VALUES (4, N'М^3')
INSERT [dbo].[Sale] ([ID_Sale], [Unit]) VALUES (5, N'М^2')
GO
ALTER TABLE [dbo].[Iskop]  WITH CHECK ADD  CONSTRAINT [FK_Iskop_Mine] FOREIGN KEY([ID_Mine])
REFERENCES [dbo].[Mine] ([ID_Mine])
GO
ALTER TABLE [dbo].[Iskop] CHECK CONSTRAINT [FK_Iskop_Mine]
GO
ALTER TABLE [dbo].[Iskop]  WITH CHECK ADD  CONSTRAINT [FK_Iskop_Sale] FOREIGN KEY([ID_Sale])
REFERENCES [dbo].[Sale] ([ID_Sale])
GO
ALTER TABLE [dbo].[Iskop] CHECK CONSTRAINT [FK_Iskop_Sale]
GO
