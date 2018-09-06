
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/06/2018 22:28:24
-- Generated from EDMX file: C:\Users\Varathan SP\Documents\Visual Studio 2015\Projects\ScoreBoardApp\ScoreBoardApp\Models\ScoreBoardDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ScoreBoardDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Player__team__29572725]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK__Player__team__29572725];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Fixtures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fixtures];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team];
GO
IF OBJECT_ID(N'[dbo].[UserIdentity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserIdentity];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[plyerBadmintonRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[plyerBadmintonRankView];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[plyerCarromRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[plyerCarromRankView];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[plyerChessRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[plyerChessRankView];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[plyerRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[plyerRankView];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[plyerTTRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[plyerTTRankView];
GO
IF OBJECT_ID(N'[ScoreBoardDBModelStoreContainer].[TeamRankView]', 'U') IS NOT NULL
    DROP TABLE [ScoreBoardDBModelStoreContainer].[TeamRankView];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [teamName] varchar(20)  NOT NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL
);
GO

-- Creating table 'UserIdentities'
CREATE TABLE [dbo].[UserIdentities] (
    [userName] varchar(20)  NOT NULL,
    [password] varchar(20)  NULL
);
GO

-- Creating table 'Fixtures'
CREATE TABLE [dbo].[Fixtures] (
    [gameID] int IDENTITY(1,1) NOT NULL,
    [gameType] varchar(20)  NULL,
    [team1] varchar(20)  NULL,
    [team2] varchar(20)  NULL,
    [tm1pl1] varchar(20)  NULL,
    [tm1pl2] varchar(20)  NULL,
    [tm2pl1] varchar(20)  NULL,
    [tm2pl2] varchar(20)  NULL,
    [venue] varchar(40)  NULL,
    [date] datetime  NULL,
    [time] varchar(20)  NULL,
    [team1Score] varchar(20)  NULL,
    [team2Score] varchar(20)  NULL,
    [winner] varchar(20)  NULL,
    [gameName] varchar(20)  NULL
);
GO

-- Creating table 'plyerRankViews'
CREATE TABLE [dbo].[plyerRankViews] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [playerRank] bigint  NULL
);
GO

-- Creating table 'plyerBadmintonRankViews'
CREATE TABLE [dbo].[plyerBadmintonRankViews] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [playerRank] bigint  NULL
);
GO

-- Creating table 'plyerCarromRankViews'
CREATE TABLE [dbo].[plyerCarromRankViews] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [playerRank] bigint  NULL
);
GO

-- Creating table 'plyerChessRankViews'
CREATE TABLE [dbo].[plyerChessRankViews] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [playerRank] bigint  NULL
);
GO

-- Creating table 'plyerTTRankViews'
CREATE TABLE [dbo].[plyerTTRankViews] (
    [playerName] varchar(20)  NOT NULL,
    [employeeID] int  NULL,
    [team] varchar(20)  NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [playerRank] bigint  NULL
);
GO

-- Creating table 'TeamRankViews'
CREATE TABLE [dbo].[TeamRankViews] (
    [teamName] varchar(20)  NOT NULL,
    [badmintonPoints] int  NULL,
    [caromPoints] int  NULL,
    [chessPoints] int  NULL,
    [ttPoints] int  NULL,
    [totalPoints] int  NULL,
    [Rank] bigint  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [playerName] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [teamName] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([teamName] ASC);
GO

-- Creating primary key on [userName] in table 'UserIdentities'
ALTER TABLE [dbo].[UserIdentities]
ADD CONSTRAINT [PK_UserIdentities]
    PRIMARY KEY CLUSTERED ([userName] ASC);
GO

-- Creating primary key on [gameID] in table 'Fixtures'
ALTER TABLE [dbo].[Fixtures]
ADD CONSTRAINT [PK_Fixtures]
    PRIMARY KEY CLUSTERED ([gameID] ASC);
GO

-- Creating primary key on [playerName] in table 'plyerRankViews'
ALTER TABLE [dbo].[plyerRankViews]
ADD CONSTRAINT [PK_plyerRankViews]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [playerName] in table 'plyerBadmintonRankViews'
ALTER TABLE [dbo].[plyerBadmintonRankViews]
ADD CONSTRAINT [PK_plyerBadmintonRankViews]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [playerName] in table 'plyerCarromRankViews'
ALTER TABLE [dbo].[plyerCarromRankViews]
ADD CONSTRAINT [PK_plyerCarromRankViews]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [playerName] in table 'plyerChessRankViews'
ALTER TABLE [dbo].[plyerChessRankViews]
ADD CONSTRAINT [PK_plyerChessRankViews]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [playerName] in table 'plyerTTRankViews'
ALTER TABLE [dbo].[plyerTTRankViews]
ADD CONSTRAINT [PK_plyerTTRankViews]
    PRIMARY KEY CLUSTERED ([playerName] ASC);
GO

-- Creating primary key on [teamName] in table 'TeamRankViews'
ALTER TABLE [dbo].[TeamRankViews]
ADD CONSTRAINT [PK_TeamRankViews]
    PRIMARY KEY CLUSTERED ([teamName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [team] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK__Player__team__29572725]
    FOREIGN KEY ([team])
    REFERENCES [dbo].[Teams]
        ([teamName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Player__team__29572725'
CREATE INDEX [IX_FK__Player__team__29572725]
ON [dbo].[Players]
    ([team]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------