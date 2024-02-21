CREATE TABLE [dbo].[Countries] (
    [country]    VARCHAR (50)    NOT NULL,
    [cindex]     NUMERIC (18, 3) NOT NULL,
    [rent]       NUMERIC (18, 3) NOT NULL,
    [groceries]  NUMERIC (18, 3) NOT NULL,
    [restaurant] NUMERIC (18, 3) NOT NULL,
    [pp]         NUMERIC (18, 3) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([country] ASC)
);

