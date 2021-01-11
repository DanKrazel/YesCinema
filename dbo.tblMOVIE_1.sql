CREATE TABLE [dbo].[tblMOVIE] (
    [ID]       INT          NOT NULL,
    [showtime] DATETIME         NULL,
    [price]    INT          NULL,
    [SALLE]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[tblTickets] (
	[ID]     DECIMAL(18,2)		NOT NULL,
	[UserId] DECIMAL(18,2)		NOT NULL,
	[MovieName]  NVARCHAR(50)   NULL,
	[Showtime] DATETIME         NULL,
	[Seat]     NVARCHAR(100)    NULL,
	[Cost]     INT	NULL,
	PRIMARY KEY CLUSTERED([ID] ASC,[UserId] ASC),
);

