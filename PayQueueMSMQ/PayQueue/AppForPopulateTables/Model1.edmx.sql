
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/11/2014 22:02:51
-- Generated from EDMX file: C:\Code_August\3816_Code\PayQueueMSMQ\PayQueue\AppForPopulateTables\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PayQueue];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[auditconfigs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[auditconfigs];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[unicastconfigs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[unicastconfigs];
GO
IF OBJECT_ID(N'[dbo].[MSreplication_options]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSreplication_options];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_db];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_dev]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_dev];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_usg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_usg];
GO
IF OBJECT_ID(N'[dbo].[spt_monitor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_monitor];
GO
IF OBJECT_ID(N'[dbo].[AppForReadinXMLs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppForReadinXMLs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'auditconfigs'
CREATE TABLE [dbo].[auditconfigs] (
    [AppId] int  NOT NULL,
    [AppName] varchar(50)  NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [EventId] uniqueidentifier  NOT NULL,
    [Time] varchar(50)  NULL,
    [Duration] varchar(50)  NULL,
    [billerGroupId] varchar(10)  NULL,
    [billerId] varchar(10)  NULL,
    [bankRoutingNumber] varchar(9)  NULL,
    [bankAccountNumber] varchar(9)  NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [streetAddress1] varchar(50)  NULL,
    [streetAddress2] varchar(50)  NULL,
    [city] varchar(50)  NULL,
    [state] varchar(2)  NULL,
    [zip] varchar(5)  NULL,
    [nameOnAccount] varchar(50)  NULL,
    [phone] varchar(10)  NULL,
    [companyName] varchar(50)  NULL,
    [paymentReferenceId] uniqueidentifier  NULL,
    [paymentChannel] varchar(10)  NULL,
    [paymentAmount] decimal(19,4)  NULL
);
GO

-- Creating table 'unicastconfigs'
CREATE TABLE [dbo].[unicastconfigs] (
    [AppId] int  NOT NULL,
    [AppName] varchar(50)  NULL
);
GO

-- Creating table 'MSreplication_options'
CREATE TABLE [dbo].[MSreplication_options] (
    [optname] nvarchar(128)  NOT NULL,
    [value] bit  NOT NULL,
    [major_version] int  NOT NULL,
    [minor_version] int  NOT NULL,
    [revision] int  NOT NULL,
    [install_failures] int  NOT NULL
);
GO

-- Creating table 'spt_fallback_db'
CREATE TABLE [dbo].[spt_fallback_db] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_dbid] smallint  NULL,
    [name] varchar(30)  NOT NULL,
    [dbid] smallint  NOT NULL,
    [status] smallint  NOT NULL,
    [version] smallint  NOT NULL
);
GO

-- Creating table 'spt_fallback_dev'
CREATE TABLE [dbo].[spt_fallback_dev] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_low] int  NULL,
    [xfallback_drive] char(2)  NULL,
    [low] int  NOT NULL,
    [high] int  NOT NULL,
    [status] smallint  NOT NULL,
    [name] varchar(30)  NOT NULL,
    [phyname] varchar(127)  NOT NULL
);
GO

-- Creating table 'spt_fallback_usg'
CREATE TABLE [dbo].[spt_fallback_usg] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_vstart] int  NULL,
    [dbid] smallint  NOT NULL,
    [segmap] int  NOT NULL,
    [lstart] int  NOT NULL,
    [sizepg] int  NOT NULL,
    [vstart] int  NOT NULL
);
GO

-- Creating table 'spt_monitor'
CREATE TABLE [dbo].[spt_monitor] (
    [lastrun] datetime  NOT NULL,
    [cpu_busy] int  NOT NULL,
    [io_busy] int  NOT NULL,
    [idle] int  NOT NULL,
    [pack_received] int  NOT NULL,
    [pack_sent] int  NOT NULL,
    [connections] int  NOT NULL,
    [pack_errors] int  NOT NULL,
    [total_read] int  NOT NULL,
    [total_write] int  NOT NULL,
    [total_errors] int  NOT NULL
);
GO

-- Creating table 'AppForReadinXML'
CREATE TABLE [dbo].[AppForReadinXML] (
    [Id] uniqueidentifier  NOT NULL,
    [CorrelationId] varchar(255)  NULL,
    [ReplyToAddress] varchar(255)  NULL,
    [Recoverable] bit  NOT NULL,
    [Expires] datetime  NULL,
    [Headers] varchar(max)  NOT NULL,
    [Body] varbinary(max)  NULL,
    [RowVersion] bigint IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AppId] in table 'auditconfigs'
ALTER TABLE [dbo].[auditconfigs]
ADD CONSTRAINT [PK_auditconfigs]
    PRIMARY KEY CLUSTERED ([AppId] ASC);
GO

-- Creating primary key on [EventId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [AppId] in table 'unicastconfigs'
ALTER TABLE [dbo].[unicastconfigs]
ADD CONSTRAINT [PK_unicastconfigs]
    PRIMARY KEY CLUSTERED ([AppId] ASC);
GO

-- Creating primary key on [optname], [value], [major_version], [minor_version], [revision], [install_failures] in table 'MSreplication_options'
ALTER TABLE [dbo].[MSreplication_options]
ADD CONSTRAINT [PK_MSreplication_options]
    PRIMARY KEY CLUSTERED ([optname], [value], [major_version], [minor_version], [revision], [install_failures] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] in table 'spt_fallback_db'
ALTER TABLE [dbo].[spt_fallback_db]
ADD CONSTRAINT [PK_spt_fallback_db]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] in table 'spt_fallback_dev'
ALTER TABLE [dbo].[spt_fallback_dev]
ADD CONSTRAINT [PK_spt_fallback_dev]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] in table 'spt_fallback_usg'
ALTER TABLE [dbo].[spt_fallback_usg]
ADD CONSTRAINT [PK_spt_fallback_usg]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] ASC);
GO

-- Creating primary key on [lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] in table 'spt_monitor'
ALTER TABLE [dbo].[spt_monitor]
ADD CONSTRAINT [PK_spt_monitor]
    PRIMARY KEY CLUSTERED ([lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] ASC);
GO

-- Creating primary key on [Id], [Recoverable], [RowVersion] in table 'AppForReadinXML'
ALTER TABLE [dbo].[AppForReadinXML]
ADD CONSTRAINT [PK_AppForReadinXML]
    PRIMARY KEY CLUSTERED ([Id], [Recoverable], [RowVersion] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------