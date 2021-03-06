USE [master]
GO
/****** Object:  Database [DUAN2DBNhaThuoc]    Script Date: 5/30/2020 10:44:37 PM ******/
CREATE DATABASE [DUAN2DBNhaThuoc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DUAN2DBNhaThuoc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DUAN2DBNhaThuoc.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DUAN2DBNhaThuoc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DUAN2DBNhaThuoc_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DUAN2DBNhaThuoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ARITHABORT OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET  MULTI_USER 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DUAN2DBNhaThuoc]
GO
/****** Object:  UserDefinedFunction [dbo].[fnSplit]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[fnSplit](@text nvarchar(max) , @delimitor nchar(1))

RETURNS
@table TABLE
(
    [Index] int Identity(0,1),
    [SplitText] nvarchar(max)
)
AS
BEGIN
    declare @current nvarchar(max)
    declare @endIndex int
    declare @textlength int
    declare @startIndex int

    set @startIndex = 1 

    if(@text is not null)
    begin
        set @textLength = datalength(@text)

        while(1=1)
        begin
            set @endIndex = charindex(@delimitor, @text, @startIndex)

            if(@endIndex != 0)
            begin
                set @current = substring(@text,@startIndex, @endIndex - @StartIndex)
                Insert Into @table ([SplitText]) values(@current)
                set @startIndex = @endIndex + 1   
            end
            else
            begin
                set @current = substring(@text, @startIndex, datalength(@text)-@startIndex+1)
                Insert Into @table ([SplitText]) values(@current)
                break
            end
        end
    end
    return

END


GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[username] [nvarchar](200) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[groupId] [int] NOT NULL,
 CONSTRAINT [Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountDetail]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountDetail](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[iduser] [int] NOT NULL,
 CONSTRAINT [PK_AccountDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[adId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[adName] [nvarchar](200) NOT NULL,
	[adUrl] [nvarchar](200) NOT NULL,
	[PositionId] [int] NOT NULL,
	[adImgSrc] [nvarchar](200) NOT NULL,
	[adStatus] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[adId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdvertisementPage]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertisementPage](
	[adPageId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[adPageName] [int] NOT NULL,
 CONSTRAINT [PK_AdvertisementPage] PRIMARY KEY CLUSTERED 
(
	[adPageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdvertisementPosition]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertisementPosition](
	[adPosId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[adPageId] [int] NOT NULL,
	[adPosName] [nvarchar](200) NOT NULL,
	[adPosition] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_AdvertisementPosition] PRIMARY KEY CLUSTERED 
(
	[adPosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[cId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cName] [nvarchar](200) NOT NULL,
	[cAddress] [nvarchar](max) NOT NULL,
	[cPhone] [nvarchar](max) NOT NULL,
	[cWebsite] [nvarchar](max) NOT NULL,
	[cEmail] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugCategory]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugCategory](
	[categoryId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[categoryName] [nvarchar](200) NULL,
 CONSTRAINT [PK_DrugCategory] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugDetails]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[drugname] [nvarchar](200) NOT NULL,
	[price] [int] NOT NULL,
	[note] [nvarchar](max) NULL,
	[iddrugstore] [int] NULL,
 CONSTRAINT [PK_DrugDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugInfo]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugInfo](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[drugname] [nvarchar](200) NOT NULL,
	[categoryId] [int] NULL,
	[alias] [nvarchar](max) NULL,
	[company] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[newFlg] [nvarchar](max) NULL,
	[hotFlg] [nvarchar](max) NULL,
 CONSTRAINT [PK_DrugInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugStore]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrugStore](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[district] [int] NULL,
	[phone] [nvarchar](max) NULL,
	[imgSrc] [nvarchar](max) NULL,
	[status] [int] NULL CONSTRAINT [DF_DrugStore_status]  DEFAULT ((0)),
	[categoryId] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[openTime] [char](10) NULL,
	[closedTime] [char](10) NULL,
	[iduser] [int] NULL,
	[lat] [float] NULL,
	[lng] [float] NULL,
	[datecreate] [date] NULL,
 CONSTRAINT [PK_DrugStore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrugStoreInprocess]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugStoreInprocess](
	[tempId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[ward] [nvarchar](max) NULL,
	[district] [nvarchar](max) NULL,
	[openTime] [datetime] NULL,
	[closedTime] [datetime] NULL,
	[description] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[imgSrc] [nvarchar](max) NULL,
 CONSTRAINT [PK_DrugStoreInprocess] PRIMARY KEY CLUSTERED 
(
	[tempId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[fbId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[fbName] [nvarchar](200) NOT NULL,
	[fbContent] [nvarchar](max) NOT NULL,
	[fbEmail] [nvarchar](max) NOT NULL,
	[fbPhone] [nvarchar](max) NOT NULL,
	[fbCreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[fbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[image] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[menuName] [nvarchar](200) NOT NULL,
	[menuUrl] [nvarchar](200) NOT NULL,
	[menuParentId] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Page]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[pageId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[pageName] [nvarchar](200) NOT NULL,
	[pageContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[pageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slide]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[slideId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[slideName] [nvarchar](200) NOT NULL,
	[slideUrl] [nvarchar](200) NOT NULL,
	[slideSort] [int] NOT NULL,
	[slideText] [nvarchar](200) NOT NULL,
	[slideImgSrc] [nvarchar](200) NOT NULL,
	[slideStatus] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[slideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccountDetail]  WITH CHECK ADD FOREIGN KEY([iduser])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_AdvertisementPosition] FOREIGN KEY([PositionId])
REFERENCES [dbo].[AdvertisementPosition] ([adPosId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_AdvertisementPosition]
GO
ALTER TABLE [dbo].[AdvertisementPage]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementPage_Page] FOREIGN KEY([adPageId])
REFERENCES [dbo].[Page] ([pageId])
GO
ALTER TABLE [dbo].[AdvertisementPage] CHECK CONSTRAINT [FK_AdvertisementPage_Page]
GO
ALTER TABLE [dbo].[AdvertisementPosition]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementPosition_AdvertisementPage] FOREIGN KEY([adPageId])
REFERENCES [dbo].[AdvertisementPage] ([adPageId])
GO
ALTER TABLE [dbo].[AdvertisementPosition] CHECK CONSTRAINT [FK_AdvertisementPosition_AdvertisementPage]
GO
ALTER TABLE [dbo].[DrugDetails]  WITH CHECK ADD FOREIGN KEY([iddrugstore])
REFERENCES [dbo].[DrugStore] ([ID])
GO
ALTER TABLE [dbo].[DrugInfo]  WITH CHECK ADD  CONSTRAINT [FK_DrugInfo_DrugCategory] FOREIGN KEY([categoryId])
REFERENCES [dbo].[DrugCategory] ([categoryId])
GO
ALTER TABLE [dbo].[DrugInfo] CHECK CONSTRAINT [FK_DrugInfo_DrugCategory]
GO
ALTER TABLE [dbo].[DrugStore]  WITH CHECK ADD  CONSTRAINT [FK_Iduser] FOREIGN KEY([iduser])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[DrugStore] CHECK CONSTRAINT [FK_Iduser]
GO
/****** Object:  StoredProcedure [dbo].[Account_Delete]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Account_Delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
		if exists (select 1 from DrugDetails where iddrugstore = (select ID from DrugStore where iduser = @id) )
	begin
		delete from DrugDetails where iddrugstore = (select ID from DrugStore where iduser = @id)
	end
	if exists (select 1 from DrugStore where iduser = @id )
	begin
		delete from DrugStore where ID =(select ID from DrugStore where iduser = @id)
	end
	delete from AccountDetail where iduser = @id
	delete from Account where id = @id
END




GO
/****** Object:  StoredProcedure [dbo].[Account_Getall]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Account_Getall]
AS
BEGIN
    select * from Account
END


GO
/****** Object:  StoredProcedure [dbo].[District_Delete]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[District_Delete]
	@ID int
AS
BEGIN
	delete from District where ID = @ID
END



GO
/****** Object:  StoredProcedure [dbo].[District_Getall]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[District_Getall]
AS
BEGIN
    select * from District
END



GO
/****** Object:  StoredProcedure [dbo].[District_Save]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[District_Save]
	@ID int,
	@Name nvarchar(max),
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRANSACTION;
    SAVE TRANSACTION MySavePoint;
    BEGIN TRY
		if exists (select 1 from District where ID = @ID)
		begin
			update District
			set 
				Name = @Name 
			where ID = @ID

		end
		else
		begin
			insert into District(Name)
			values(@Name)
			set @ID= SCOPE_IDENTITY()
		end
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
			set @ErrorMessage  = ERROR_MESSAGE()
            ROLLBACK TRANSACTION MySavePoint; 
        END
    END CATCH
    COMMIT TRANSACTION 
	return @ID
END



GO
/****** Object:  StoredProcedure [dbo].[DrugCategory_Delete]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DrugCategory_Delete]
	@categoryId int
AS
BEGIN
	delete from DrugCategory where categoryId = @categoryId
END


GO
/****** Object:  StoredProcedure [dbo].[DrugCategory_Getall]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DrugCategory_Getall]
AS
BEGIN
    select * from DrugCategory
END


GO
/****** Object:  StoredProcedure [dbo].[DrugCategory_Save]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DrugCategory_Save]
	@categoryId int,
	@categoryName nvarchar(max),
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRANSACTION;
    SAVE TRANSACTION MySavePoint;
    BEGIN TRY
		if exists (select 1 from DrugCategory where categoryId=@categoryId)
		begin
			update DrugCategory
			set 
				categoryName=@categoryName
			where categoryId=@categoryId 

		end
		else
		begin
			insert into DrugCategory(categoryName)
			values(@categoryName)
			set @categoryId= SCOPE_IDENTITY()
		end
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
			set @ErrorMessage  = ERROR_MESSAGE()
            ROLLBACK TRANSACTION MySavePoint; 
        END
    END CATCH
    COMMIT TRANSACTION 
	return @categoryId
END


GO
/****** Object:  StoredProcedure [dbo].[DrugDetails_Delete]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DrugDetails_Delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	delete from DrugDetails where id = @id
END



GO
/****** Object:  StoredProcedure [dbo].[DrugDetails_Getall]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DrugDetails_Getall]
AS
BEGIN
    select * from DrugDetails
END


GO
/****** Object:  StoredProcedure [dbo].[DrugDetails_Save]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DrugDetails_Save]
	@id int,
	@drugname nvarchar(200),
	@price int,
	@note nvarchar(max),
	@iddrugstore int,
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRANSACTION;
    SAVE TRANSACTION MySavePoint;
    BEGIN TRY
		if exists (select 1 from DrugDetails where id=@id)
		begin
			update DrugDetails
			set 
				drugname=@drugname,
				price = @price,
				note=@note
			where id=@id 

		end
		else
		begin
			insert into DrugDetails(drugname,price,note,iddrugstore)
			values(@drugname,@price,@note,@iddrugstore)
			set @id= SCOPE_IDENTITY()
		end
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
			set @ErrorMessage  = ERROR_MESSAGE()
            ROLLBACK TRANSACTION MySavePoint; 
        END
    END CATCH
    COMMIT TRANSACTION 
	return @id
END




GO
/****** Object:  StoredProcedure [dbo].[DrugStore_Delete]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DrugStore_Delete]
	@ID int
AS
BEGIN
	SET NOCOUNT ON;
	if exists (select 1 from DrugDetails where iddrugstore = @ID )
	begin
		delete from DrugDetails where iddrugstore = @ID
	end
	
	delete from DrugStore where ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[DrugStore_Getall]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DrugStore_Getall]
AS
BEGIN
    select * from DrugStore
END

GO
/****** Object:  StoredProcedure [dbo].[DrugStore_GetallSearch]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DrugStore_GetallSearch]
	@Lat float,
	@Long float,
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
    DECLARE @orig geography = geography::Point(@Lat,@Long, 4326);

	SELECT dest.ID,dest.name,dest.address,dest.district,dest.phone,dest.imgSrc,
	dest.status,dest.categoryId,dest.openTime,dest.closedTime,
	(@orig.STDistance(geography::Point(dest.lat, dest.lng, 4326))/1609.344) distance
	FROM DrugStore dest
	where   dest.status = 1
	ORDER BY (@orig.STDistance(geography::Point(dest.lat, dest.lng, 4326))/1609.344)
END


GO
/****** Object:  StoredProcedure [dbo].[DrugStore_Insert]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DrugStore_Insert]
	@name nvarchar(max),
	@address nvarchar(max),
	@phone nvarchar(max),
	@district nvarchar(max),
	@imgSrc nvarchar(max),
	@categoryId int,
	@description nvarchar(max),
	@openTime char(10),
	@closedTime char(10),
	@ciduser int,
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
    BEGIN TRY
		Insert into DrugStore(name,address,district,phone,imgSrc,categoryId) 
		values(@name,@address,@district,@phone,@imgSrc,@categoryId)           
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
			SET @ErrorMessage  = ERROR_MESSAGE()
        END
    END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[DrugStore_Save]    Script Date: 5/30/2020 10:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DrugStore_Save]
	@ID int,
	@name nvarchar(max),
	@address nvarchar(max),
	@phone nvarchar(max),
	@district nvarchar(max),
	@imgSrc nvarchar(max),
	@status int,
	@categoryId int,
	@description nvarchar(max),
	@openTime char(10),
	@closedTime char(10),
	@lat float,
	@lng float,
	@ErrorMessage nvarchar(max)='' output
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRANSACTION;
    SAVE TRANSACTION MySavePoint;
    BEGIN TRY
		if exists (select 1 from DrugStore where ID=@ID)
		begin
			update DrugStore
			set name= @name,
				address=@address,
				phone=@phone,
				district=@district,
				imgSrc=@imgSrc,
				status=@status,
				categoryId=@categoryId,
				description= @description,
				openTime = @openTime,
				closedTime= @closedTime,
				lat = @lat,
				lng = @lng
			where ID=@ID 

		end
		else
		begin
			insert into DrugStore(name, address, phone, district,imgSrc,categoryId,description,openTime,closedTime,lat,lng,datecreate)
			values(@name, @address, @phone, @district,@imgSrc,@categoryId,@description,@openTime,@closedTime,@lat,@lng,GETDATE())

		end
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
			set @ErrorMessage  = ERROR_MESSAGE()
            ROLLBACK TRANSACTION MySavePoint; 
        END
    END CATCH
    COMMIT TRANSACTION 
	return @ID
END


GO
USE [master]
GO
ALTER DATABASE [DUAN2DBNhaThuoc] SET  READ_WRITE 
GO
