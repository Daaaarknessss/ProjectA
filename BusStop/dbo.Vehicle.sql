CREATE TABLE [dbo].[Vehicle] (
    [VehicleId]      INT IDENTITY (1000, 1) NOT NULL,
    [Capacity]       INT NOT NULL,
    [AvailableSeats] INT NOT NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([VehicleId] ASC)
);

