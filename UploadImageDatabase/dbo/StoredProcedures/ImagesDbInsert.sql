CREATE PROCEDURE [dbo].[ImagesDbInsert]
	@Id int,
	@Title nvarchar(80),
	@Description nvarchar(255),
	@Rating Decimal(4,2),
	@Image image,
	@Id2 int
AS
begin
	SET IDENTITY_INSERT dbo.[ImageDescription] ON;
	INSERT INTO dbo.[ImageDescription](Id, Title, Description, Rating) VALUES(@Id, @Title, @Description, @Rating);
	SET IDENTITY_INSERT dbo.[ImageDescription] OFF;
	SET IDENTITY_INSERT dbo.[ImageFile] ON;
	INSERT INTO dbo.[ImageFile](Id, Image) VALUES(@Id2, @Image);
	SET IDENTITY_INSERT dbo.[ImageFile] OFF;
end