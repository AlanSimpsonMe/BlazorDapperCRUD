-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.spVideo_Insert
	-- Add the parameters for the stored procedure here
	@Title varchar(128),
	@DatePublished date,
	@IsActive bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO Video
              (Title, DatePublished, IsActive)
VALUES        (@Title, @DatePublished, @IsActive)


END
