SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ufGetFullPath](@id NVARCHAR(255))
RETURNS NVARCHAR(2000)
AS
BEGIN
	IF @id IS NULL OR @id='' RETURN NULL

	DECLARE @root NVARCHAR(255) = '11111111-1111-1111-1111-111111111111'
	IF @id=@root RETURN '/'

    DECLARE @path     NVARCHAR(255)
    DECLARE @parentId            NVARCHAR(255)
	DECLARE @parentFullPath     NVARCHAR(2000)
    SELECT @path=[Path],@parentId=[ParentId],@parentFullPath=[dbo].[ufGetFullPath]([ParentId]) FROM [dbo].[Items] WHERE [Id]=@id
	IF @path='/' OR @parentId='' OR @parentId=@root SELECT @parentFullPath = ''
	RETURN ISNULL(@parentFullPath + '/', '') + @path
END