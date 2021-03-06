USE [RoomRentalTable]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/22/2022 1:18:48 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerModelTable]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerModelTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[NumberOfMambers] [int] NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Colony] [nvarchar](max) NOT NULL,
	[ZipCode] [int] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[OwnerDataStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_OwnerModelTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220224124836_first', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220225101826_changeDataType', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220228062119_change model', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220228065808_addnewModelFields', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220228074159_UpateModelState', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220228132432_updateMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220302135923_ne one', N'3.1.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'24a7c848-b9bf-49e1-9a0b-0396eb64f9bb', N'admin', N'ADMIN', N'ed25b967-0c6a-42eb-b06c-f47039e7fd2f')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bae7da1e-401a-4df1-ad4d-2b9cb6539bab', N'user', N'USER', N'85c1326b-7fb4-4150-8a9e-f5b1902728f7')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f672cabb-3782-4036-be47-15d0b7b0a78e', N'owner', N'OWNER', N'dca5b334-2357-47de-b94f-ad64739bac8f')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e527ead-c1af-48f7-baf2-2cf15d42bd0e', N'bae7da1e-401a-4df1-ad4d-2b9cb6539bab')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1cc7fed6-68af-49c0-b16c-db9968ed568a', N'f672cabb-3782-4036-be47-15d0b7b0a78e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bdc20e28-6658-4fb8-a305-88882648a5b7', N'f672cabb-3782-4036-be47-15d0b7b0a78e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'1cc7fed6-68af-49c0-b16c-db9968ed568a', N'ronak1@gmail.com', N'RONAK1@GMAIL.COM', N'ronak1@gmail.com', N'RONAK1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAaDBXmdUNcjZVtrXE5TqYbbgCJW0BQ3TFBgmns5jTxDg854SrdO4MScDK9+Zwbx3Q==', N'E6VP3ITCUUG7FF7IAPZAGVOOAECZJ3IN', N'1ae48795-971b-4fad-b7be-7ba9cda61982', N'9630638110', 0, 0, NULL, 1, 0, N'Ronaks', N'shuryavansi')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'5e527ead-c1af-48f7-baf2-2cf15d42bd0e', N'deepakchawda1@gmail.com', N'DEEPAKCHAWDA1@GMAIL.COM', N'deepakchawda1@gmail.com', N'DEEPAKCHAWDA1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEC6QUQGOfvBFBCjEfPQ+G1lbOv7a6MUcVAyhRl/uQJMT3stwVq1xbKL/3vp1Vwguw==', N'SL6AJTSSIN5NCXMEQF3DW7ORSYRISZ3M', N'bf289c70-d582-4af7-b417-68b5148c3386', N'85858585', 0, 0, NULL, 1, 0, N'Deepak', N'gurjar')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'bdc20e28-6658-4fb8-a305-88882648a5b7', N'mayur@gmail.com', N'MAYUR@GMAIL.COM', N'mayur@gmail.com', N'MAYUR@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFCSdLCWIFc+Knm1Gwa5boHQK6n6tKkcn0doJ4wqgFwL3v0w9Si8SZryumwBUzRkVw==', N'HV6TPVIPKOYE773VNZXTKKWYGM2GVFP3', N'61683e96-3264-4513-9374-b45b5477cd77', N'6633225566', 0, 0, NULL, 1, 0, N'mayur', N'gupta')
GO
SET IDENTITY_INSERT [dbo].[OwnerModelTable] ON 

INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1, N'22/4 shavid nager', 10000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (2, N'22/4 shavid nager', 20000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (3, N'22/4 shavid nager', 30000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (4, N'22/4 shavid nager', 40000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (5, N'22/4 shavid nager', 10000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'success')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (6, N'22/4 shavid nager', 20000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (7, N'22/4 shavid nager', 30000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (8, N'22/4 shavid nager', 40000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'rejected')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (9, N'22/4 shavid nager', 40000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 0, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (10, N'22/4 shavid nager', 40000, 4, N'MP', N'indore', N'tilak nager', 451225, N'not image yet', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1019, N'savid nager tilak nager indore', 5000, 5, N'mp', N'indore', N'savid nager tilak nager', 455, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1020, N'savid nager tilak nager indore', 5000, 5, N'mp', N'indore', N'savid nager tilak nager', 455, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1021, N'savid nager tilak nager indore', 5000, 5, N'mp', N'indore', N'savid nager tilak nager', 455, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1022, N'savid nager tilak nager indore', 5000, 5, N'mp', N'indore', N'savid nager tilak nager', 45, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1023, N'savid nager tilak nager indore', 54654, 654, N'mp', N'indore', N'savid nager tilak nager', 454, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
INSERT [dbo].[OwnerModelTable] ([Id], [Address], [Price], [NumberOfMambers], [State], [City], [Colony], [ZipCode], [Image], [UserId], [IsActive], [OwnerDataStatus]) VALUES (1024, N'savid nager tilak nager indore', 5454, 5454, N'mp', N'indore', N'savid nager tilak nager', 15, N'jjj', N'1cc7fed6-68af-49c0-b16c-db9968ed568a', 1, N'pending')
SET IDENTITY_INSERT [dbo].[OwnerModelTable] OFF
GO
ALTER TABLE [dbo].[OwnerModelTable] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[spEditOwnerAccount]    Script Date: 7/22/2022 1:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spEditOwnerAccount]
    @EditOwnerid varchar(Max),
    @FirstName varchar(Max),
    @LastName varchar(Max),
    @Email varchar(Max),
    @PhoneNumber varchar(Max)
  
AS 
BEGIN 
 
UPDATE AspNetUsers
SET  FirstName = @FirstName,
     LastName = @LastName, 
     Email = @Email,
     PhoneNumber = @PhoneNumber
WHERE  id = @EditOwnerid


END
GO
