IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220625071829_v2')
BEGIN
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Longitude] float NOT NULL,
        [Latitude] float NOT NULL,
        [Category] nvarchar(max) NOT NULL,
        [Image64] nvarchar(max) NOT NULL,
        [ImageURL] nvarchar(max) NOT NULL,
        [Approved] bit NOT NULL,
        [Positive] bit NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220625071829_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220625071829_v2', N'6.0.6');
END;
GO

COMMIT;
GO

