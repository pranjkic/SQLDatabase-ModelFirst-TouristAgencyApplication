
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2020 22:22:01
-- Generated from EDMX file: C:\Users\Stefan\Downloads\BazePodataka2\BP2\BP2.Repository.DB\ModelBP2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baza];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CenovnikCenovnikKojiTuristickaAgencijaFormira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet] DROP CONSTRAINT [FK_CenovnikCenovnikKojiTuristickaAgencijaFormira];
GO
IF OBJECT_ID(N'[dbo].[FK_CenovnikKojiTuristickaAgencijaFormira_Cenovnik_Putovanje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cenovnik_Putovanje] DROP CONSTRAINT [FK_CenovnikKojiTuristickaAgencijaFormira_Cenovnik_Putovanje];
GO
IF OBJECT_ID(N'[dbo].[FK_FilijalaKlijentKojiPoslujeSaFilijalom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet] DROP CONSTRAINT [FK_FilijalaKlijentKojiPoslujeSaFilijalom];
GO
IF OBJECT_ID(N'[dbo].[FK_FilijalaRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadnikSet] DROP CONSTRAINT [FK_FilijalaRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentKlijentKojiPoslujeSaFilijalom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet] DROP CONSTRAINT [FK_KlijentKlijentKojiPoslujeSaFilijalom];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentKojiPoslujeSaFilijalomUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UgovorSet] DROP CONSTRAINT [FK_KlijentKojiPoslujeSaFilijalomUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_Menadzer_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadnikSet_Menadzer] DROP CONSTRAINT [FK_Menadzer_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_MenadzerFilijala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadnikSet_Menadzer] DROP CONSTRAINT [FK_MenadzerFilijala];
GO
IF OBJECT_ID(N'[dbo].[FK_Putovanje_PutovanjeKojeNudiTuristickaAgencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet] DROP CONSTRAINT [FK_Putovanje_PutovanjeKojeNudiTuristickaAgencija];
GO
IF OBJECT_ID(N'[dbo].[FK_PutovanjeKojeNudiTuristickaAgencija_Cenovnik_Putovanje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cenovnik_Putovanje] DROP CONSTRAINT [FK_PutovanjeKojeNudiTuristickaAgencija_Cenovnik_Putovanje];
GO
IF OBJECT_ID(N'[dbo].[FK_PutovanjeKojeNudiTuristickaAgencijaUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UgovorSet] DROP CONSTRAINT [FK_PutovanjeKojeNudiTuristickaAgencijaUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_Sekretarica_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadnikSet_Sekretarica] DROP CONSTRAINT [FK_Sekretarica_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_SekretaricaUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UgovorSet] DROP CONSTRAINT [FK_SekretaricaUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_TuristickaAgencija_Filijala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilijalaSet] DROP CONSTRAINT [FK_TuristickaAgencija_Filijala];
GO
IF OBJECT_ID(N'[dbo].[FK_TuristickaAgencijaCenovnikKojiTuristickaAgencijaFormira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet] DROP CONSTRAINT [FK_TuristickaAgencijaCenovnikKojiTuristickaAgencijaFormira];
GO
IF OBJECT_ID(N'[dbo].[FK_TuristickaAgencijaPutovanjeKojeNudiTuristickaAgencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet] DROP CONSTRAINT [FK_TuristickaAgencijaPutovanjeKojeNudiTuristickaAgencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Vodic_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadnikSet_Vodic] DROP CONSTRAINT [FK_Vodic_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_VodicPutovanjeKojeNudiTuristickaAgencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet] DROP CONSTRAINT [FK_VodicPutovanjeKojeNudiTuristickaAgencija];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cenovnik_Putovanje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cenovnik_Putovanje];
GO
IF OBJECT_ID(N'[dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet];
GO
IF OBJECT_ID(N'[dbo].[CenovnikSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CenovnikSet];
GO
IF OBJECT_ID(N'[dbo].[FilijalaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilijalaSet];
GO
IF OBJECT_ID(N'[dbo].[KlijentKojiPoslujeSaFilijalomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet];
GO
IF OBJECT_ID(N'[dbo].[KlijentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlijentSet];
GO
IF OBJECT_ID(N'[dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet];
GO
IF OBJECT_ID(N'[dbo].[PutovanjeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PutovanjeSet];
GO
IF OBJECT_ID(N'[dbo].[RadnikSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadnikSet];
GO
IF OBJECT_ID(N'[dbo].[RadnikSet_Menadzer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadnikSet_Menadzer];
GO
IF OBJECT_ID(N'[dbo].[RadnikSet_Sekretarica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadnikSet_Sekretarica];
GO
IF OBJECT_ID(N'[dbo].[RadnikSet_Vodic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadnikSet_Vodic];
GO
IF OBJECT_ID(N'[dbo].[TuristickaAgencijaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TuristickaAgencijaSet];
GO
IF OBJECT_ID(N'[dbo].[UgovorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UgovorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TuristickaAgencijaSet'
CREATE TABLE [dbo].[TuristickaAgencijaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FilijalaSet'
CREATE TABLE [dbo].[FilijalaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Grad] nvarchar(max)  NULL,
    [Adresa] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [TuristickaAgencijaId] int  NOT NULL
);
GO

-- Creating table 'PutovanjeSet'
CREATE TABLE [dbo].[PutovanjeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Destinacija] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KlijentSet'
CREATE TABLE [dbo].[KlijentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [BrojPasosa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CenovnikSet'
CREATE TABLE [dbo].[CenovnikSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PocetakVazenja] datetime  NOT NULL,
    [KrajVazenja] datetime  NOT NULL
);
GO

-- Creating table 'CenovnikKojiTuristickaAgencijaFormiraSet'
CREATE TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet] (
    [KoeficijentNaplate] float  NOT NULL,
    [TuristickaAgencijaId] int  NOT NULL,
    [CenovnikId] int  NOT NULL
);
GO

-- Creating table 'KlijentKojiPoslujeSaFilijalomSet'
CREATE TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet] (
    [KlijentId] int  NOT NULL,
    [FilijalaId] int  NOT NULL,
    [FilijalaTuristickaAgencijaId] int  NOT NULL
);
GO

-- Creating table 'PutovanjeKojeTuristickaAgencijaNudiSet'
CREATE TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet] (
    [DatumDolaska] datetime  NOT NULL,
    [Trajanje] int  NOT NULL,
    [CenaPutovanja] float  NOT NULL,
    [NazivSmestaja] nvarchar(max)  NOT NULL,
    [PutovanjeId] int  NOT NULL,
    [TuristickaAgencijaId] int  NOT NULL,
    [VodicId] int  NOT NULL
);
GO

-- Creating table 'UgovorSet'
CREATE TABLE [dbo].[UgovorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SifraOsiguranja] nvarchar(max)  NOT NULL,
    [PutovanjeKojeNudiTuristickaAgencijaPutovanjeId] int  NOT NULL,
    [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId] int  NOT NULL,
    [PutovanjeKojeNudiTuristickaAgencijaVodicId] int  NOT NULL,
    [KlijentKojiPoslujeSaFilijalomKlijentId] int  NOT NULL,
    [KlijentKojiPoslujeSaFilijalomFilijalaId] int  NOT NULL,
    [KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId] int  NOT NULL,
    [SekretaricaId] int  NOT NULL
);
GO

-- Creating table 'Cenovnik_Putovanje'
CREATE TABLE [dbo].[Cenovnik_Putovanje] (
    [PutovanjeKojeNudiTuristickaAgencijaPutovanjeId] int  NOT NULL,
    [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId] int  NOT NULL,
    [PutovanjeKojeNudiTuristickaAgencijaVodicId] int  NOT NULL,
    [CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId] int  NOT NULL,
    [CenovnikKojiTuristickaAgencijaFormiraCenovnikId] int  NOT NULL
);
GO

-- Creating table 'RadnikSet'
CREATE TABLE [dbo].[RadnikSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL,
    [FilijalaId] int  NOT NULL,
    [FilijalaTuristickaAgencijaId] int  NOT NULL
);
GO

-- Creating table 'RadnikSet_Sekretarica'
CREATE TABLE [dbo].[RadnikSet_Sekretarica] (
    [ProdatiUgovori] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'RadnikSet_Vodic'
CREATE TABLE [dbo].[RadnikSet_Vodic] (
    [IstorijaPutovanja] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'RadnikSet_Menadzer'
CREATE TABLE [dbo].[RadnikSet_Menadzer] (
    [BrojPodredjenihRadnika] int  NOT NULL,
    [Id] int  NOT NULL,
    [Filijala1_Id] int  NOT NULL,
    [Filijala1_TuristickaAgencijaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TuristickaAgencijaSet'
ALTER TABLE [dbo].[TuristickaAgencijaSet]
ADD CONSTRAINT [PK_TuristickaAgencijaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [TuristickaAgencijaId] in table 'FilijalaSet'
ALTER TABLE [dbo].[FilijalaSet]
ADD CONSTRAINT [PK_FilijalaSet]
    PRIMARY KEY CLUSTERED ([Id], [TuristickaAgencijaId] ASC);
GO

-- Creating primary key on [Id] in table 'PutovanjeSet'
ALTER TABLE [dbo].[PutovanjeSet]
ADD CONSTRAINT [PK_PutovanjeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KlijentSet'
ALTER TABLE [dbo].[KlijentSet]
ADD CONSTRAINT [PK_KlijentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CenovnikSet'
ALTER TABLE [dbo].[CenovnikSet]
ADD CONSTRAINT [PK_CenovnikSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TuristickaAgencijaId], [CenovnikId] in table 'CenovnikKojiTuristickaAgencijaFormiraSet'
ALTER TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]
ADD CONSTRAINT [PK_CenovnikKojiTuristickaAgencijaFormiraSet]
    PRIMARY KEY CLUSTERED ([TuristickaAgencijaId], [CenovnikId] ASC);
GO

-- Creating primary key on [KlijentId], [FilijalaId], [FilijalaTuristickaAgencijaId] in table 'KlijentKojiPoslujeSaFilijalomSet'
ALTER TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet]
ADD CONSTRAINT [PK_KlijentKojiPoslujeSaFilijalomSet]
    PRIMARY KEY CLUSTERED ([KlijentId], [FilijalaId], [FilijalaTuristickaAgencijaId] ASC);
GO

-- Creating primary key on [PutovanjeId], [TuristickaAgencijaId] in table 'PutovanjeKojeTuristickaAgencijaNudiSet'
ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
ADD CONSTRAINT [PK_PutovanjeKojeTuristickaAgencijaNudiSet]
    PRIMARY KEY CLUSTERED ([PutovanjeId], [TuristickaAgencijaId] ASC);
GO

-- Creating primary key on [Id] in table 'UgovorSet'
ALTER TABLE [dbo].[UgovorSet]
ADD CONSTRAINT [PK_UgovorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId], [PutovanjeKojeNudiTuristickaAgencijaVodicId], [CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId], [CenovnikKojiTuristickaAgencijaFormiraCenovnikId] in table 'Cenovnik_Putovanje'
ALTER TABLE [dbo].[Cenovnik_Putovanje]
ADD CONSTRAINT [PK_Cenovnik_Putovanje]
    PRIMARY KEY CLUSTERED ([PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId], [PutovanjeKojeNudiTuristickaAgencijaVodicId], [CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId], [CenovnikKojiTuristickaAgencijaFormiraCenovnikId] ASC);
GO

-- Creating primary key on [Id] in table 'RadnikSet'
ALTER TABLE [dbo].[RadnikSet]
ADD CONSTRAINT [PK_RadnikSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RadnikSet_Sekretarica'
ALTER TABLE [dbo].[RadnikSet_Sekretarica]
ADD CONSTRAINT [PK_RadnikSet_Sekretarica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RadnikSet_Vodic'
ALTER TABLE [dbo].[RadnikSet_Vodic]
ADD CONSTRAINT [PK_RadnikSet_Vodic]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RadnikSet_Menadzer'
ALTER TABLE [dbo].[RadnikSet_Menadzer]
ADD CONSTRAINT [PK_RadnikSet_Menadzer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TuristickaAgencijaId] in table 'FilijalaSet'
ALTER TABLE [dbo].[FilijalaSet]
ADD CONSTRAINT [FK_TuristickaAgencija_Filijala]
    FOREIGN KEY ([TuristickaAgencijaId])
    REFERENCES [dbo].[TuristickaAgencijaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TuristickaAgencija_Filijala'
CREATE INDEX [IX_FK_TuristickaAgencija_Filijala]
ON [dbo].[FilijalaSet]
    ([TuristickaAgencijaId]);
GO

-- Creating foreign key on [TuristickaAgencijaId] in table 'CenovnikKojiTuristickaAgencijaFormiraSet'
ALTER TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]
ADD CONSTRAINT [FK_TuristickaAgencijaCenovnikKojiTuristickaAgencijaFormira]
    FOREIGN KEY ([TuristickaAgencijaId])
    REFERENCES [dbo].[TuristickaAgencijaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CenovnikId] in table 'CenovnikKojiTuristickaAgencijaFormiraSet'
ALTER TABLE [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]
ADD CONSTRAINT [FK_CenovnikCenovnikKojiTuristickaAgencijaFormira]
    FOREIGN KEY ([CenovnikId])
    REFERENCES [dbo].[CenovnikSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CenovnikCenovnikKojiTuristickaAgencijaFormira'
CREATE INDEX [IX_FK_CenovnikCenovnikKojiTuristickaAgencijaFormira]
ON [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]
    ([CenovnikId]);
GO

-- Creating foreign key on [KlijentId] in table 'KlijentKojiPoslujeSaFilijalomSet'
ALTER TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet]
ADD CONSTRAINT [FK_KlijentKlijentKojiPoslujeSaFilijalom]
    FOREIGN KEY ([KlijentId])
    REFERENCES [dbo].[KlijentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FilijalaId], [FilijalaTuristickaAgencijaId] in table 'KlijentKojiPoslujeSaFilijalomSet'
ALTER TABLE [dbo].[KlijentKojiPoslujeSaFilijalomSet]
ADD CONSTRAINT [FK_FilijalaKlijentKojiPoslujeSaFilijalom]
    FOREIGN KEY ([FilijalaId], [FilijalaTuristickaAgencijaId])
    REFERENCES [dbo].[FilijalaSet]
        ([Id], [TuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilijalaKlijentKojiPoslujeSaFilijalom'
CREATE INDEX [IX_FK_FilijalaKlijentKojiPoslujeSaFilijalom]
ON [dbo].[KlijentKojiPoslujeSaFilijalomSet]
    ([FilijalaId], [FilijalaTuristickaAgencijaId]);
GO

-- Creating foreign key on [PutovanjeId] in table 'PutovanjeKojeTuristickaAgencijaNudiSet'
ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
ADD CONSTRAINT [FK_Putovanje_PutovanjeKojeNudiTuristickaAgencija]
    FOREIGN KEY ([PutovanjeId])
    REFERENCES [dbo].[PutovanjeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TuristickaAgencijaId] in table 'PutovanjeKojeTuristickaAgencijaNudiSet'
ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
ADD CONSTRAINT [FK_TuristickaAgencijaPutovanjeKojeNudiTuristickaAgencija]
    FOREIGN KEY ([TuristickaAgencijaId])
    REFERENCES [dbo].[TuristickaAgencijaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TuristickaAgencijaPutovanjeKojeNudiTuristickaAgencija'
CREATE INDEX [IX_FK_TuristickaAgencijaPutovanjeKojeNudiTuristickaAgencija]
ON [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
    ([TuristickaAgencijaId]);
GO

-- Creating foreign key on [PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId] in table 'UgovorSet'
ALTER TABLE [dbo].[UgovorSet]
ADD CONSTRAINT [FK_PutovanjeKojeNudiTuristickaAgencijaUgovor]
    FOREIGN KEY ([PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId])
    REFERENCES [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
        ([PutovanjeId], [TuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PutovanjeKojeNudiTuristickaAgencijaUgovor'
CREATE INDEX [IX_FK_PutovanjeKojeNudiTuristickaAgencijaUgovor]
ON [dbo].[UgovorSet]
    ([PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId]);
GO

-- Creating foreign key on [KlijentKojiPoslujeSaFilijalomKlijentId], [KlijentKojiPoslujeSaFilijalomFilijalaId], [KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId] in table 'UgovorSet'
ALTER TABLE [dbo].[UgovorSet]
ADD CONSTRAINT [FK_KlijentKojiPoslujeSaFilijalomUgovor]
    FOREIGN KEY ([KlijentKojiPoslujeSaFilijalomKlijentId], [KlijentKojiPoslujeSaFilijalomFilijalaId], [KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId])
    REFERENCES [dbo].[KlijentKojiPoslujeSaFilijalomSet]
        ([KlijentId], [FilijalaId], [FilijalaTuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentKojiPoslujeSaFilijalomUgovor'
CREATE INDEX [IX_FK_KlijentKojiPoslujeSaFilijalomUgovor]
ON [dbo].[UgovorSet]
    ([KlijentKojiPoslujeSaFilijalomKlijentId], [KlijentKojiPoslujeSaFilijalomFilijalaId], [KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId]);
GO

-- Creating foreign key on [PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId] in table 'Cenovnik_Putovanje'
ALTER TABLE [dbo].[Cenovnik_Putovanje]
ADD CONSTRAINT [FK_PutovanjeKojeNudiTuristickaAgencija_Cenovnik_Putovanje]
    FOREIGN KEY ([PutovanjeKojeNudiTuristickaAgencijaPutovanjeId], [PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId])
    REFERENCES [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
        ([PutovanjeId], [TuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId], [CenovnikKojiTuristickaAgencijaFormiraCenovnikId] in table 'Cenovnik_Putovanje'
ALTER TABLE [dbo].[Cenovnik_Putovanje]
ADD CONSTRAINT [FK_CenovnikKojiTuristickaAgencijaFormira_Cenovnik_Putovanje]
    FOREIGN KEY ([CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId], [CenovnikKojiTuristickaAgencijaFormiraCenovnikId])
    REFERENCES [dbo].[CenovnikKojiTuristickaAgencijaFormiraSet]
        ([TuristickaAgencijaId], [CenovnikId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CenovnikKojiTuristickaAgencijaFormira_Cenovnik_Putovanje'
CREATE INDEX [IX_FK_CenovnikKojiTuristickaAgencijaFormira_Cenovnik_Putovanje]
ON [dbo].[Cenovnik_Putovanje]
    ([CenovnikKojiTuristickaAgencijaFormiraTuristickaAgencijaId], [CenovnikKojiTuristickaAgencijaFormiraCenovnikId]);
GO

-- Creating foreign key on [FilijalaId], [FilijalaTuristickaAgencijaId] in table 'RadnikSet'
ALTER TABLE [dbo].[RadnikSet]
ADD CONSTRAINT [FK_FilijalaRadnik]
    FOREIGN KEY ([FilijalaId], [FilijalaTuristickaAgencijaId])
    REFERENCES [dbo].[FilijalaSet]
        ([Id], [TuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilijalaRadnik'
CREATE INDEX [IX_FK_FilijalaRadnik]
ON [dbo].[RadnikSet]
    ([FilijalaId], [FilijalaTuristickaAgencijaId]);
GO

-- Creating foreign key on [SekretaricaId] in table 'UgovorSet'
ALTER TABLE [dbo].[UgovorSet]
ADD CONSTRAINT [FK_SekretaricaUgovor]
    FOREIGN KEY ([SekretaricaId])
    REFERENCES [dbo].[RadnikSet_Sekretarica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SekretaricaUgovor'
CREATE INDEX [IX_FK_SekretaricaUgovor]
ON [dbo].[UgovorSet]
    ([SekretaricaId]);
GO

-- Creating foreign key on [VodicId] in table 'PutovanjeKojeTuristickaAgencijaNudiSet'
ALTER TABLE [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
ADD CONSTRAINT [FK_VodicPutovanjeKojeNudiTuristickaAgencija]
    FOREIGN KEY ([VodicId])
    REFERENCES [dbo].[RadnikSet_Vodic]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VodicPutovanjeKojeNudiTuristickaAgencija'
CREATE INDEX [IX_FK_VodicPutovanjeKojeNudiTuristickaAgencija]
ON [dbo].[PutovanjeKojeTuristickaAgencijaNudiSet]
    ([VodicId]);
GO

-- Creating foreign key on [Filijala1_Id], [Filijala1_TuristickaAgencijaId] in table 'RadnikSet_Menadzer'
ALTER TABLE [dbo].[RadnikSet_Menadzer]
ADD CONSTRAINT [FK_MenadzerFilijala]
    FOREIGN KEY ([Filijala1_Id], [Filijala1_TuristickaAgencijaId])
    REFERENCES [dbo].[FilijalaSet]
        ([Id], [TuristickaAgencijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenadzerFilijala'
CREATE INDEX [IX_FK_MenadzerFilijala]
ON [dbo].[RadnikSet_Menadzer]
    ([Filijala1_Id], [Filijala1_TuristickaAgencijaId]);
GO

-- Creating foreign key on [Id] in table 'RadnikSet_Sekretarica'
ALTER TABLE [dbo].[RadnikSet_Sekretarica]
ADD CONSTRAINT [FK_Sekretarica_inherits_Radnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RadnikSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RadnikSet_Vodic'
ALTER TABLE [dbo].[RadnikSet_Vodic]
ADD CONSTRAINT [FK_Vodic_inherits_Radnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RadnikSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RadnikSet_Menadzer'
ALTER TABLE [dbo].[RadnikSet_Menadzer]
ADD CONSTRAINT [FK_Menadzer_inherits_Radnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RadnikSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------