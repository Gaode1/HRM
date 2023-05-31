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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [JobCode] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [IsActive] bit NULL,
    [NumberOfPositions] int NOT NULL,
    [StartDate] datetime2 NULL,
    [ClosedOn] datetime2 NULL,
    [ClosedReason] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511002621_InitialMigration', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Title] nvarchar(100) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Description] nvarchar(3000) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'ClosedReason');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [ClosedReason] nvarchar(1000) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511012306_updatingJobsTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Jobs] ADD [StatusId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Status] (
    [Id] int NOT NULL IDENTITY,
    [StatusCode] nvarchar(max) NOT NULL,
    [StatusDescription] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Jobs_StatusId] ON [Jobs] ([StatusId]);
GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514042350_updatingJobsTable1', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidates] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [NumOfJobsApplied] int NOT NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514043002_CreateCandidateTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514043127_CreateStatusTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Submissions] (
    [Id] int NOT NULL IDENTITY,
    [JobId] int NOT NULL,
    [CandidateId] int NOT NULL,
    [SubmittedOn] datetime2 NULL,
    [ApprovedForInterview] datetime2 NULL,
    [RejectedOn] datetime2 NULL,
    [RejectReason] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Type] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Type] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514043424_CreateEmployeeTableAndSubmissionTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CandidateSubmission] (
    [CandidatesId] int NOT NULL,
    [SubmissionsId] int NOT NULL,
    CONSTRAINT [PK_CandidateSubmission] PRIMARY KEY ([CandidatesId], [SubmissionsId]),
    CONSTRAINT [FK_CandidateSubmission_Candidates_CandidatesId] FOREIGN KEY ([CandidatesId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CandidateSubmission_Submissions_SubmissionsId] FOREIGN KEY ([SubmissionsId]) REFERENCES [Submissions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [JobRequirement] (
    [Id] int NOT NULL IDENTITY,
    [language] nvarchar(max) NOT NULL,
    [yoe] int NOT NULL,
    [location] nvarchar(max) NOT NULL,
    [JobId] int NULL,
    CONSTRAINT [PK_JobRequirement] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobRequirement_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id])
);
GO

CREATE INDEX [IX_CandidateSubmission_SubmissionsId] ON [CandidateSubmission] ([SubmissionsId]);
GO

CREATE UNIQUE INDEX [IX_JobRequirement_JobId] ON [JobRequirement] ([JobId]) WHERE [JobId] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514212254_UpdatingAllTables', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [CandidateSubmission];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'NumOfJobsApplied');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Candidates] DROP COLUMN [NumOfJobsApplied];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Description');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Description] nvarchar(2048) NOT NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'MiddleName');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [MiddleName] nvarchar(50) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'LastName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [LastName] nvarchar(50) NOT NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'FirstName');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'Email');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [Email] nvarchar(512) NOT NULL;
GO

ALTER TABLE [Candidates] ADD [CandidateIdentityId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

ALTER TABLE [Candidates] ADD [CreatedOn] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Candidates] ADD [ResumeURL] nvarchar(2048) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Candidates] ADD [SubmissionId] int NULL;
GO

CREATE INDEX [IX_Candidates_SubmissionId] ON [Candidates] ([SubmissionId]);
GO

ALTER TABLE [Candidates] ADD CONSTRAINT [FK_Candidates_Submissions_SubmissionId] FOREIGN KEY ([SubmissionId]) REFERENCES [Submissions] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517182657_UpdatingAllTablesBasedOnNewRequirment', N'7.0.5');
GO

COMMIT;
GO

