CREATE TABLE [dbo].[USStates] (
    [state]          VARCHAR (50)    NOT NULL,
    [cindex]         NUMERIC (18, 3) NOT NULL,
    [grocery]        NUMERIC (18, 3) NOT NULL,
    [housing]        NUMERIC (18, 3) NOT NULL,
    [utilities]      NUMERIC (18, 3) NOT NULL,
    [transportation] NUMERIC (18, 3) NOT NULL,
    [health]         NUMERIC (18, 3) NOT NULL,
    [misc]           NUMERIC (18, 3) NOT NULL,
    CONSTRAINT [PK_USStates] PRIMARY KEY CLUSTERED ([state] ASC)
);

