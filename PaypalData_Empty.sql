USE [master]
GO
/****** Object:  Database [PaypalManager]    Script Date: 11/12/2022 8:42:00 PM ******/
CREATE DATABASE [PaypalManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PaypalManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PaypalManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PaypalManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PaypalManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PaypalManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PaypalManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PaypalManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PaypalManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PaypalManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PaypalManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PaypalManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [PaypalManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PaypalManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PaypalManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PaypalManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PaypalManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PaypalManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PaypalManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PaypalManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PaypalManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PaypalManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PaypalManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PaypalManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PaypalManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PaypalManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PaypalManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PaypalManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PaypalManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PaypalManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PaypalManager] SET  MULTI_USER 
GO
ALTER DATABASE [PaypalManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PaypalManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PaypalManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PaypalManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PaypalManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PaypalManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PaypalManager] SET QUERY_STORE = OFF
GO
USE [PaypalManager]
GO
/****** Object:  User [Chieu311]    Script Date: 11/12/2022 8:42:00 PM ******/
CREATE USER [Chieu311] FOR LOGIN [Chieu311] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/12/2022 8:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Balance] [nvarchar](50) NULL,
	[TransactionTotal] [nvarchar](250) NULL,
	[Profile_Created_Time] [datetime] NULL,
	[Notification] [nvarchar](250) NULL,
	[SessionResult] [nvarchar](250) NULL,
	[UpdatedDateTime] [nvarchar](250) NULL,
	[AccPassword] [varchar](50) NULL,
	[EmailPassword] [varchar](50) NULL,
	[Proxy] [varchar](50) NULL,
	[Profile] [bit] NULL,
	[ProfileId] [varchar](100) NULL,
	[Email_2FA] [varchar](50) NULL,
	[AccName] [nvarchar](50) NULL,
	[AccBirthDay] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[BankCard] [varchar](50) NULL,
	[SeQuestion1] [nvarchar](50) NULL,
	[SeQuestion2] [nvarchar](50) NULL,
	[TwoFA] [nvarchar](50) NULL,
	[AccType] [nvarchar](50) NULL,
	[AccOtherType] [varchar](50) NULL,
	[EmailType] [varchar](50) NULL,
	[AccCategory] [varchar](50) NULL,
	[InputtedDate] [nvarchar](250) NULL,
	[RecoveryEmail] [nvarchar](50) NULL,
	[ForwordToEmail] [nvarchar](50) NULL,
	[SecondEmail] [varchar](50) NULL,
	[ProxyStatus] [nvarchar](250) NULL,
	[Acc_ON_OFF] [bit] NULL,
	[Set_ChangedPassPP] [bit] NULL,
	[Set_ChangedPassEmail] [bit] NULL,
	[Set_Deleted_FwEmail] [bit] NULL,
	[Set_Add_New_FwEmail] [bit] NULL,
	[Set_Add_RecoveryEmail] [bit] NULL,
	[Set_2FA] [bit] NULL,
	[Set_Questions] [bit] NULL,
	[Profile_Save] [bit] NULL,
	[AccPassword_Old] [varchar](500) NULL,
	[EmailPassword_Old] [varchar](500) NULL,
	[Acc_2FA_Old] [varchar](500) NULL,
	[Email_2FA_Old] [varchar](500) NULL,
	[RecoveryEmail_Old] [varchar](500) NULL,
	[Questions_Old] [varchar](1500) NULL,
	[Random_AccPassword] [varchar](500) NULL,
	[Random_EmailPassword] [varchar](500) NULL,
	[Random_Questions] [varchar](1500) NULL,
	[Canvas_profile] [bit] NULL,
 CONSTRAINT [PK_AccountBackUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/12/2022 8:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Name] [varchar](100) NOT NULL,
	[Value] [nvarchar](250) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/12/2022 8:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Name] [nvarchar](250) NOT NULL,
	[AccIDList] [xml] NULL,
 CONSTRAINT [PK_Cateogory] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Del_Account]    Script Date: 11/12/2022 8:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Del_Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Balance] [nvarchar](50) NULL,
	[TransactionTotal] [nvarchar](250) NULL,
	[Profile_Created_Time] [datetime] NULL,
	[Notification] [nvarchar](250) NULL,
	[SessionResult] [nvarchar](250) NULL,
	[UpdatedDateTime] [nvarchar](250) NULL,
	[AccPassword] [varchar](50) NULL,
	[EmailPassword] [varchar](50) NULL,
	[Proxy] [varchar](50) NULL,
	[Profile] [bit] NULL,
	[ProfileId] [varchar](100) NULL,
	[Email_2FA] [varchar](50) NULL,
	[AccName] [nvarchar](50) NULL,
	[AccBirthDay] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[BankCard] [varchar](50) NULL,
	[SeQuestion1] [nvarchar](50) NULL,
	[SeQuestion2] [nvarchar](50) NULL,
	[TwoFA] [nvarchar](50) NULL,
	[AccType] [nvarchar](50) NULL,
	[AccOtherType] [varchar](50) NULL,
	[EmailType] [varchar](50) NULL,
	[AccCategory] [varchar](50) NULL,
	[InputtedDate] [nvarchar](250) NULL,
	[RecoveryEmail] [nvarchar](50) NULL,
	[ForwordToEmail] [nvarchar](50) NULL,
	[SecondEmail] [varchar](50) NULL,
	[ProxyStatus] [nvarchar](250) NULL,
	[Acc_ON_OFF] [bit] NULL,
	[Set_ChangedPassPP] [bit] NULL,
	[Set_ChangedPassEmail] [bit] NULL,
	[Set_Deleted_FwEmail] [bit] NULL,
	[Set_Add_New_FwEmail] [bit] NULL,
	[Set_Add_RecoveryEmail] [bit] NULL,
	[Set_2FA] [bit] NULL,
	[Set_Questions] [bit] NULL,
	[Profile_Save] [bit] NULL,
	[AccPassword_Old] [varchar](500) NULL,
	[EmailPassword_Old] [varchar](500) NULL,
	[Acc_2FA_Old] [varchar](500) NULL,
	[Email_2FA_Old] [varchar](500) NULL,
	[RecoveryEmail_Old] [varchar](500) NULL,
	[Questions_Old] [varchar](1500) NULL,
	[Random_AccPassword] [varchar](500) NULL,
	[Random_EmailPassword] [varchar](500) NULL,
	[Random_Questions] [varchar](1500) NULL,
	[Canvas_profile] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/12/2022 8:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_AccountBackUP_InputtedDate]  DEFAULT (getdate()) FOR [InputtedDate]
GO
ALTER TABLE [dbo].[Del_Account] ADD  CONSTRAINT [DF_Del_Account_InputtedDate]  DEFAULT (getdate()) FOR [InputtedDate]
GO
USE [master]
GO
ALTER DATABASE [PaypalManager] SET  READ_WRITE 
GO
