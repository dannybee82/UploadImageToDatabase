CREATE PROCEDURE [dbo].[ImagesDbCount]
AS
begin
	SELECT Count(Id) AS count
	FROM dbo.[ImageDescription]
end