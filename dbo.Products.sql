CREATE TABLE [dbo].[Products] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (60)   NOT NULL,
    [Price] DECIMAL (18, 2) NOT NULL,
    [Image] NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

