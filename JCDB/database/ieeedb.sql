USE [IEEEPAPER]
GO
/****** Object:  Table [dbo].[MstUserMaster]    Script Date: 03/04/2018 17:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstUserMaster](
	[UserID] [varchar](10) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](10) NULL,
	[MobileNo] [varchar](10) NULL,
	[EmailID] [varchar](100) NULL,
	[UserType] [varchar](10) NULL,
	[Status] [varchar](10) NULL,
	[updatedBy] [varchar](10) NULL,
	[UpdatedOn] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MstDocument]    Script Date: 03/04/2018 17:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstDocument](
	[Transactinno] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [nvarchar](50) NULL,
	[ArticlelTitle] [nvarchar](50) NULL,
	[JournalTitle] [nvarchar](50) NULL,
	[Author1] [nvarchar](50) NULL,
	[Author2] [nvarchar](50) NULL,
	[Author3] [nvarchar](50) NULL,
	[Faculty] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Affiliation] [nvarchar](50) NULL,
	[Volume] [nvarchar](10) NULL,
	[Issue] [nvarchar](10) NULL,
	[PagenoFrom] [nvarchar](10) NULL,
	[PagenoTo] [nvarchar](10) NULL,
	[YearofPublication] [datetime] NULL,
	[DocPath] [varchar](150) NULL,
	[UpdatedBy] [nchar](10) NULL,
	[UpdatedOn] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MstDepartment]    Script Date: 03/04/2018 17:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstDepartment](
	[DeptCode] [nvarchar](10) NULL,
	[DeptName] [nvarchar](50) NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL
) ON [PRIMARY]
GO
