USE [aspnet-QA.V3.Web-BB31C2B9-DDFC-463F-B281-A48DA1942B7B]
GO
/****** Object:  Table [dbo].[ActivityAccounts]    Script Date: 6/5/2018 3:04:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ADPId] [int] NOT NULL,
	[SourceType] [int] NOT NULL,
	[SourceAthleteId] [nvarchar](500) NULL,
	[SourceKey] [nvarchar](500) NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_ActivityAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityDataProviders]    Script Date: 6/5/2018 3:04:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityDataProviders](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[GrantAccessUrl] [nvarchar](1000) NOT NULL,
	[ClientId] [nvarchar](500) NULL,
	[RedirectUrl] [nvarchar](500) NULL,
	[ClientSecret] [nvarchar](500) NULL,
 CONSTRAINT [PK_ActivityDataProviders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ActivityDataProviders] ([Id], [Name], [GrantAccessUrl], [ClientId], [RedirectUrl], [ClientSecret]) VALUES (1, N'Strava', N'https://www.strava.com/oauth/authorize', N'17076', N'http://quantathletics.com/strava/stravatokenexchange', N'SecretKey')
ALTER TABLE [dbo].[ActivityAccounts]  WITH CHECK ADD  CONSTRAINT [FK_ActivityAccounts_ActivityDataProviders] FOREIGN KEY([ADPId])
REFERENCES [dbo].[ActivityDataProviders] ([Id])
GO
ALTER TABLE [dbo].[ActivityAccounts] CHECK CONSTRAINT [FK_ActivityAccounts_ActivityDataProviders]
GO
ALTER TABLE [dbo].[ActivityAccounts]  WITH CHECK ADD  CONSTRAINT [FK_ActivityAccounts_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ActivityAccounts] CHECK CONSTRAINT [FK_ActivityAccounts_AspNetUsers]
GO
