CREATE PROCEDURE [dbo].[ImagesDbDelete]
	@Id int
AS
begin
	DELETE FROM dbo.[ImageDescription] where Id = @Id;
	DELETE FROM dbo.[ImageFile] where Id = @Id;
end