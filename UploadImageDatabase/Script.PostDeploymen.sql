if not exists (select 1 from dbo.[ImageDescription])
begin
	SET IDENTITY_INSERT dbo.ImageDescription ON;
	INSERT INTO dbo.ImageDescription(Id, Title, Description, Rating) VALUES(1, 'Test image 1', 'This is image 2', 4.0);
	INSERT INTO dbo.ImageDescription(Id, Title, Description, Rating) VALUES(2, 'Test image 2', 'This is image 2', 3.5);
	SET IDENTITY_INSERT dbo.ImageDescription OFF;
end
if not exists (select 1 from dbo.[ImageFile])
begin
	SET IDENTITY_INSERT dbo.[ImageFile] ON;
	INSERT INTO dbo.[ImageFile](Id, Image) VALUES(1, null);
	INSERT INTO dbo.[ImageFile](Id, Image) VALUES(2, null);
	SET IDENTITY_INSERT dbo.[ImageFile] OFF;
end