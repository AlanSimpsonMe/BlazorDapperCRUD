-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spVideo_Update]
	-- Add the parameters for the stored procedure here
	@VideoID int,
	@Title varchar(128),
	@DatePublished date,
	@IsActive bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE       Video
SET                Title =@Title, DatePublished =@DatePublished, IsActive = @IsActive
WHERE        (VideoID = @VideoID)

END
