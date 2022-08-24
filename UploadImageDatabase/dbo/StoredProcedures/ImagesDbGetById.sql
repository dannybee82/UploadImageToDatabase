CREATE PROCEDURE [dbo].[ImagesDbGetById]
	@Id int
AS
begin
	SELECT dbo.[ImageDescription].Id, dbo.[ImageDescription].Title, dbo.[ImageDescription].Description, dbo.[ImageDescription].Rating, dbo.[ImageFile].Id, dbo.[ImageFile].Image
	FROM dbo.[ImageDescription], dbo.[ImageFile]
	WHERE dbo.[ImageDescription].Id = dbo.[ImageFile].Id AND dbo.[ImageDescription].Id = @Id;
end