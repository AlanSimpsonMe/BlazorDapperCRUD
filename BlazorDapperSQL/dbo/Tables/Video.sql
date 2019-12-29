CREATE TABLE [dbo].[Video] (
    [VideoID]       INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (128) NULL,
    [DatePublished] DATE          NULL,
    [IsActive]      BIT           CONSTRAINT [DF_Video_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED ([VideoID] ASC)
);

