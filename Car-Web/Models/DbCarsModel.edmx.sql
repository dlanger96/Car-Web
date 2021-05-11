
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2021 11:22:49
-- Generated from EDMX file: C:\Users\Legion5\Documents\GitHub\Car-Web\Car-Web\Models\DbCarsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Cars];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cars_Fuel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Fuel];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_Make]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Make];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_Model]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Model];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Fuel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fuel];
GO
IF OBJECT_ID(N'[dbo].[Make]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Make];
GO
IF OBJECT_ID(N'[dbo].[Model]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Model];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id_Car] int IDENTITY(1,1) NOT NULL,
    [Make] int  NOT NULL,
    [Model] int  NOT NULL,
    [Fuel] int  NOT NULL,
    [Power] varchar(50)  NULL,
    [Production_Year] int  NULL,
    [Quantity] nvarchar(max)  NULL
);
GO

-- Creating table 'Fuels'
CREATE TABLE [dbo].[Fuels] (
    [Id_Fuel] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL
);
GO

-- Creating table 'Makes'
CREATE TABLE [dbo].[Makes] (
    [Id_Make] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Country] varchar(50)  NULL
);
GO

-- Creating table 'Models'
CREATE TABLE [dbo].[Models] (
    [Id_Model] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Year_From] int  NULL,
    [Year_To] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_Car] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id_Car] ASC);
GO

-- Creating primary key on [Id_Fuel] in table 'Fuels'
ALTER TABLE [dbo].[Fuels]
ADD CONSTRAINT [PK_Fuels]
    PRIMARY KEY CLUSTERED ([Id_Fuel] ASC);
GO

-- Creating primary key on [Id_Make] in table 'Makes'
ALTER TABLE [dbo].[Makes]
ADD CONSTRAINT [PK_Makes]
    PRIMARY KEY CLUSTERED ([Id_Make] ASC);
GO

-- Creating primary key on [Id_Model] in table 'Models'
ALTER TABLE [dbo].[Models]
ADD CONSTRAINT [PK_Models]
    PRIMARY KEY CLUSTERED ([Id_Model] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Fuel] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_Fuel]
    FOREIGN KEY ([Fuel])
    REFERENCES [dbo].[Fuels]
        ([Id_Fuel])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Fuel'
CREATE INDEX [IX_FK_Cars_Fuel]
ON [dbo].[Cars]
    ([Fuel]);
GO

-- Creating foreign key on [Id_Car] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_Make]
    FOREIGN KEY ([Id_Car])
    REFERENCES [dbo].[Makes]
        ([Id_Make])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Model] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_Model]
    FOREIGN KEY ([Model])
    REFERENCES [dbo].[Models]
        ([Id_Model])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Model'
CREATE INDEX [IX_FK_Cars_Model]
ON [dbo].[Cars]
    ([Model]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------