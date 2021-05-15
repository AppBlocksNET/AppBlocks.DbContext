USE [All]
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
           (newid()
           ,'6C8BABCD-AD25-4CD9-9766-4B84288C24CE'
           ,'6C8BABCD-AD25-4CD9-9766-4B84288C24CE'
           ,'5E11C4A9-D602-EB11-A38D-BC9A78563412'
           ,'390E44AD-8306-47FB-B65D-C30AEEFA75FA'
           ,'E1749BE1-A589-462C-82BE-C5766A662A07'
           ,'4-Wheel-Parts'
           ,'4-Wheel-Parts'
           ,'4WheelParts.com'
           ,'\uf674'
           ,'https://grouplings.blob.core.windows.net/grouplings-groups/JeepersAnonymous/Sponsors/4-Wheel-Parts-Logo-BW.jpg'
           ,'http://www.4wheelparts.com'
           ,null
           ,null
           ,getdate()
           ,getdate()
           ,null
           ,null
		   )
GO


