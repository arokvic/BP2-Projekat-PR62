
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 20:47:21
-- Generated from EDMX file: C:\Users\Win10\Desktop\InternetSale\DataBase\InternetSaleDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InternetSalesDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FactoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_FactoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_CustomerProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerPaymentCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentCards] DROP CONSTRAINT [FK_CustomerPaymentCard];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOnlineCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductOnlineCart];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderPaymentCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderPaymentCard];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOnlineCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderOnlineCart];
GO
IF OBJECT_ID(N'[dbo].[FK_Ball_inherits_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Ball] DROP CONSTRAINT [FK_Ball_inherits_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Sneakers_inherits_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Sneakers] DROP CONSTRAINT [FK_Sneakers_inherits_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Jersey_inherits_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Jersey] DROP CONSTRAINT [FK_Jersey_inherits_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Mastercard_inherits_PaymentCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentCards_Mastercard] DROP CONSTRAINT [FK_Mastercard_inherits_PaymentCard];
GO
IF OBJECT_ID(N'[dbo].[FK_Visacard_inherits_PaymentCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentCards_Visacard] DROP CONSTRAINT [FK_Visacard_inherits_PaymentCard];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Factories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Factories];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[PaymentCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentCards];
GO
IF OBJECT_ID(N'[dbo].[OnlineCarts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnlineCarts];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Products_Ball]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products_Ball];
GO
IF OBJECT_ID(N'[dbo].[Products_Sneakers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products_Sneakers];
GO
IF OBJECT_ID(N'[dbo].[Products_Jersey]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products_Jersey];
GO
IF OBJECT_ID(N'[dbo].[PaymentCards_Mastercard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentCards_Mastercard];
GO
IF OBJECT_ID(N'[dbo].[PaymentCards_Visacard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentCards_Visacard];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Factories'
CREATE TABLE [dbo].[Factories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FactoryId] int  NOT NULL,
    [CustomerJMBG] bigint  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [OnlineCartId] int  NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [JMBG] bigint  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaymentCards'
CREATE TABLE [dbo].[PaymentCards] (
    [AccountNumber] bigint  NOT NULL,
    [CustomerJMBG] bigint  NOT NULL
);
GO

-- Creating table 'OnlineCarts'
CREATE TABLE [dbo].[OnlineCarts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumberOfArticles] int  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [ArrivalDate] datetime  NOT NULL,
    [PaymentCardAccountNumber] bigint  NOT NULL,
    [CustomerJMBG] bigint  NOT NULL,
    [OnlineCartId] int  NOT NULL
);
GO

-- Creating table 'Products_Ball'
CREATE TABLE [dbo].[Products_Ball] (
    [BallType] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Products_Sneakers'
CREATE TABLE [dbo].[Products_Sneakers] (
    [Size] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Products_Jersey'
CREATE TABLE [dbo].[Products_Jersey] (
    [Size] int  NOT NULL,
    [Club] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PaymentCards_Mastercard'
CREATE TABLE [dbo].[PaymentCards_Mastercard] (
    [AccountNumber] bigint  NOT NULL
);
GO

-- Creating table 'PaymentCards_Visacard'
CREATE TABLE [dbo].[PaymentCards_Visacard] (
    [AccountNumber] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Factories'
ALTER TABLE [dbo].[Factories]
ADD CONSTRAINT [PK_Factories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JMBG] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [AccountNumber] in table 'PaymentCards'
ALTER TABLE [dbo].[PaymentCards]
ADD CONSTRAINT [PK_PaymentCards]
    PRIMARY KEY CLUSTERED ([AccountNumber] ASC);
GO

-- Creating primary key on [Id] in table 'OnlineCarts'
ALTER TABLE [dbo].[OnlineCarts]
ADD CONSTRAINT [PK_OnlineCarts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products_Ball'
ALTER TABLE [dbo].[Products_Ball]
ADD CONSTRAINT [PK_Products_Ball]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products_Sneakers'
ALTER TABLE [dbo].[Products_Sneakers]
ADD CONSTRAINT [PK_Products_Sneakers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products_Jersey'
ALTER TABLE [dbo].[Products_Jersey]
ADD CONSTRAINT [PK_Products_Jersey]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AccountNumber] in table 'PaymentCards_Mastercard'
ALTER TABLE [dbo].[PaymentCards_Mastercard]
ADD CONSTRAINT [PK_PaymentCards_Mastercard]
    PRIMARY KEY CLUSTERED ([AccountNumber] ASC);
GO

-- Creating primary key on [AccountNumber] in table 'PaymentCards_Visacard'
ALTER TABLE [dbo].[PaymentCards_Visacard]
ADD CONSTRAINT [PK_PaymentCards_Visacard]
    PRIMARY KEY CLUSTERED ([AccountNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FactoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_FactoryProduct]
    FOREIGN KEY ([FactoryId])
    REFERENCES [dbo].[Factories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactoryProduct'
CREATE INDEX [IX_FK_FactoryProduct]
ON [dbo].[Products]
    ([FactoryId]);
GO

-- Creating foreign key on [CustomerJMBG] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_CustomerProduct]
    FOREIGN KEY ([CustomerJMBG])
    REFERENCES [dbo].[Customers]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerProduct'
CREATE INDEX [IX_FK_CustomerProduct]
ON [dbo].[Products]
    ([CustomerJMBG]);
GO

-- Creating foreign key on [CustomerJMBG] in table 'PaymentCards'
ALTER TABLE [dbo].[PaymentCards]
ADD CONSTRAINT [FK_CustomerPaymentCard]
    FOREIGN KEY ([CustomerJMBG])
    REFERENCES [dbo].[Customers]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPaymentCard'
CREATE INDEX [IX_FK_CustomerPaymentCard]
ON [dbo].[PaymentCards]
    ([CustomerJMBG]);
GO

-- Creating foreign key on [OnlineCartId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductOnlineCart]
    FOREIGN KEY ([OnlineCartId])
    REFERENCES [dbo].[OnlineCarts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOnlineCart'
CREATE INDEX [IX_FK_ProductOnlineCart]
ON [dbo].[Products]
    ([OnlineCartId]);
GO

-- Creating foreign key on [PaymentCardAccountNumber] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderPaymentCard]
    FOREIGN KEY ([PaymentCardAccountNumber])
    REFERENCES [dbo].[PaymentCards]
        ([AccountNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderPaymentCard'
CREATE INDEX [IX_FK_OrderPaymentCard]
ON [dbo].[Orders]
    ([PaymentCardAccountNumber]);
GO

-- Creating foreign key on [CustomerJMBG] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderCustomer]
    FOREIGN KEY ([CustomerJMBG])
    REFERENCES [dbo].[Customers]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCustomer'
CREATE INDEX [IX_FK_OrderCustomer]
ON [dbo].[Orders]
    ([CustomerJMBG]);
GO

-- Creating foreign key on [OnlineCartId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderOnlineCart]
    FOREIGN KEY ([OnlineCartId])
    REFERENCES [dbo].[OnlineCarts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOnlineCart'
CREATE INDEX [IX_FK_OrderOnlineCart]
ON [dbo].[Orders]
    ([OnlineCartId]);
GO

-- Creating foreign key on [Id] in table 'Products_Ball'
ALTER TABLE [dbo].[Products_Ball]
ADD CONSTRAINT [FK_Ball_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Products_Sneakers'
ALTER TABLE [dbo].[Products_Sneakers]
ADD CONSTRAINT [FK_Sneakers_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Products_Jersey'
ALTER TABLE [dbo].[Products_Jersey]
ADD CONSTRAINT [FK_Jersey_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AccountNumber] in table 'PaymentCards_Mastercard'
ALTER TABLE [dbo].[PaymentCards_Mastercard]
ADD CONSTRAINT [FK_Mastercard_inherits_PaymentCard]
    FOREIGN KEY ([AccountNumber])
    REFERENCES [dbo].[PaymentCards]
        ([AccountNumber])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AccountNumber] in table 'PaymentCards_Visacard'
ALTER TABLE [dbo].[PaymentCards_Visacard]
ADD CONSTRAINT [FK_Visacard_inherits_PaymentCard]
    FOREIGN KEY ([AccountNumber])
    REFERENCES [dbo].[PaymentCards]
        ([AccountNumber])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------