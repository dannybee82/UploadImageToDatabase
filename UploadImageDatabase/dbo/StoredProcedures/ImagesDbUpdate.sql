CREATE PROCEDURE [dbo].[ImagesDbUpdate]
	@Id int,
	@Title nvarchar(80),
	@Description nvarchar(255),
	@Rating Decimal(4,2),
	@Image image
AS
begin
	UPDATE dbo.[ImageDescription] SET dbo.[ImageDescription].Title=@Title WHERE dbo.[ImageDescription].Id = @Id;
	UPDATE dbo.[ImageDescription] SET dbo.[ImageDescription].Description = @Description WHERE dbo.[ImageDescription].Id = @Id;
	UPDATE dbo.[ImageDescription] SET dbo.[ImageDescription].Rating = @Rating WHERE dbo.[ImageDescription].Id = @Id;		
	UPDATE dbo.[ImageFile] SET dbo.[ImageFile].Image = @Image WHERE dbo.[ImageFile].Id = @Id;
end