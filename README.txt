# Project Title

Design and implement a production ready application for maintaining user
contact information.

### Prerequisites

SQL Server, .NET, .NET Framework,C# Language, CRUD,
Bootstrap, Model View Controller (MVC), ASP.NET MVC, Entity Framework


1.Create new Databse and two tables Person and PersonContact
  
  Database Name is EVO_PersonDB
  Table Person and PersonContact 
 

  USE [EVO_PersonDB]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 7/10/2018 8:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Person](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [varchar](1) NULL,
	[CreatedBy] [bigint] NOT NULL CONSTRAINT [DF_Person_CreatedBy]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Person_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__Person__IsActive__0425A276]  DEFAULT ((1)),
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Person_ID] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

----

USE [EVO_PersonDB]
GO

/****** Object:  Table [dbo].[PersonContact]    Script Date: 7/10/2018 8:04:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PersonContact](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonID] [bigint] NOT NULL,
	[EmailAddress] [varchar](250) NULL,
	[AlternateEmailAddress] [varchar](250) NULL,
	[PrimaryContactNo] [varchar](10) NULL,
	[AlternateContactNo] [varchar](15) NULL,
	[CreatedBy] [bigint] NOT NULL CONSTRAINT [DF__PersonCon__Creat__71D1E811]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__PersonCon__Creat__72C60C4A]  DEFAULT (getdate()),
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_PersonContact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_PersonContact_ID] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PersonContact]  WITH CHECK ADD  CONSTRAINT [FK_PersonContact_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO

ALTER TABLE [dbo].[PersonContact] CHECK CONSTRAINT [FK_PersonContact_Person]
GO


2.Create new project in VS. Select ASP.Net WebApplication
3.Select MVC template
4.Create the BAL and DAL folder
5.Add ADO.Net Entity Data Model in DAL folder
  Select Model Content EF Designer From Database. You can choose another model depending on requirment. 
  Choose Data Connection
  Choose Databse Object in model
  Select Table
 It will create edmx file
6.Add Person.cs, PersonContact.cs and PersonReport.cs class in Model folder which is autogenerated
7.Add PersonManager.cs and PersonProvider.cs classes in BAL and DAL folder respectively.
8.Create ListPerson method in PersonProvider.cs, PersonManager.cs and in Home Controller respectively
9.Create AddPerson, UpdatePerson and UpdatePersonStatus method in PersonProvider.cs, PersonManager.cs and in HomeController
10.Create the View for adding person details => Add.cshtml
   Create the required field like FirstName, LastName etc.
   Add validation for same field.
   Call AddPerson method
11.Create the View for updating person details => Edit.cshtml
   Create the required field like FirstName, LastName etc.
   Get the Person Details and  Bind that details to field 
   Add validation for same field.
   Call UpdatePerson method
12.Create the LogFilter.cs in Model filter
   Add the logs in that filter 
13.Use that LogFilter in HomeController at controller level
14.Use Error.cshtml View for displaying Error



