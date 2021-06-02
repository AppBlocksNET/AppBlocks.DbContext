USE [AppBlocks]
GO

INSERT INTO [dbo].[Items]
           ([Id]
           ,[CreatorId]
           ,[EditorId]
           ,[OwnerId]
           ,[ParentId]
           ,[TypeId]
           ,[Name]
           ,[Path]
           ,[Title]
           ,[Icon]
           ,[Image]
           ,[Link]
           ,[Source]
           ,[Status]
           ,[Created]
           ,[Edited]
           ,[Description]
           ,[Data])
     VALUES
           ('SchoolOfDev'
           ,null
           ,null
           ,'SchoolOfDev'
           ,'F42F7896-D602-EB11-A38D-BC9A78563412'
           ,'Group'
           ,'SchoolOfDev'
           ,'SchoolOfDev'
           ,'SchoolOfDev'
           ,'fas fa-users'
           ,'https://grouplings.blob.core.windows.net/grouplings-groups/JeepersAnonymous/logo.png'
           ,null
           ,null
           ,null
           ,getdate()
           ,getdate()
           ,null
           ,null
		   )
GO


