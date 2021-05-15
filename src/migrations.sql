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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE TABLE [Items] (
        [Id] nvarchar(256) NOT NULL,
        [Status] nvarchar(max) NULL,
        [Icon] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(256) NOT NULL,
        [OwnerId] nvarchar(256) NULL,
        [ParentId] nvarchar(256) NULL,
        [Data] nvarchar(max) NULL,
        [Description] nvarchar(2000) NULL,
        [Link] nvarchar(max) NULL,
        [Source] nvarchar(max) NULL,
        [Title] nvarchar(256) NULL,
        [TypeId] nvarchar(256) NULL,
        [Created] datetime NOT NULL DEFAULT ((getdate())),
        [CreatorId] nvarchar(256) NULL,
        [Edited] datetime NOT NULL DEFAULT ((getdate())),
        [EditorId] nvarchar(256) NULL,
        [Filename] nvarchar(max) NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Items_Items_CreatorId] FOREIGN KEY ([CreatorId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Items_Items_EditorId] FOREIGN KEY ([EditorId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Items_Items_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Items_Items_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Items_Parent] FOREIGN KEY ([ParentId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE TABLE [RoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(max) NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE TABLE [Roles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [NormalizedName] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE TABLE [Users] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(max) NULL,
        [NormalizedUserName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [NormalizedEmail] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE INDEX [IX_Items_CreatorId] ON [Items] ([CreatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE INDEX [IX_Items_EditorId] ON [Items] ([EditorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE INDEX [IX_Items_OwnerId] ON [Items] ([OwnerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE INDEX [IX_Items_ParentId] ON [Items] ([ParentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    CREATE INDEX [IX_Items_TypeId] ON [Items] ([TypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201113000016_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201113000016_update', N'5.0.0');
END;
GO

COMMIT;
GO

