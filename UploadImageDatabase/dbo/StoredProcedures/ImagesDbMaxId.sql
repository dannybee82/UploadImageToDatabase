CREATE PROCEDURE [dbo].[ImagesDbMaxId]
AS
begin
	SELECT MAX(Id) AS MaxId
	FROM dbo.[ImageDescription]
end
