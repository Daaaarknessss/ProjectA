CREATE TABLE [dbo].[Routee] (
    [RouteId]   INT            IDENTITY (100, 1) NOT NULL,
    [VehicleID] INT            NOT NULL,
    [Stops]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Routee] PRIMARY KEY CLUSTERED ([RouteId] ASC),
    CONSTRAINT [FK_Routee_Vehicle_VehicleID] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Routee_VehicleID]
    ON [dbo].[Routee]([VehicleID] ASC);

