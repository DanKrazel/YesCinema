CREATE TABLE [dbo].[tblTickets] (
    [ID]        string NOT NULL,
    [UserId]    string NOT NULL,
    [MovieName] NVARCHAR (50)   NULL,
    [Showtime]  DATETIME        NULL,
    [Seat]      NVARCHAR (100)  NULL,
    [Cost]      INT             NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC, [UserId] ASC)
);

