/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [UserID]
      ,[Name]
      ,[Age]
      ,[Email]
      ,[Pwd]
  FROM [MvcDemo].[dbo].[User]
  
  USE MvcDemo
  
INSERT INTO HeaderMenu( MenuID, MenuName, Url,IconUrl, MenuOrder) VALUES('root','根目录','','',0)
INSERT INTO HeaderMenu( MenuID, MenuName, Url,IconUrl, MenuOrder) VALUES('base','基本设置','','',0)
INSERT INTO HeaderMenu( MenuID, MenuName, Url,IconUrl, MenuOrder) VALUES('order','订单业务','','',0)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('root'
           ,'根目录'
           ,''
           ,''
           ,'root'
           ,''
           ,1)
  
INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('power'
           ,'权限管理'
           ,''
           ,''
           ,'base'
           ,'root'
           ,1)
           
INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('menu'
           ,'菜单管理'
           ,'/admin/menu'
           ,''
           ,'base'
           ,'power'
           ,1)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('role'
           ,'角色管理'
           ,'/admin/role'
           ,''
           ,'base'
           ,'power'
           ,2)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('user'
           ,'用户管理'
           ,'/admin/user'
           ,''
           ,'base'
           ,'power'
           ,3)
           
INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('action'
           ,'操作管理'
           ,'admin/action'
           ,''
           ,'base'
           ,'power'
           ,4)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('system'
           ,'系统管理'
           ,''
           ,''
           ,'base'
           ,'root'
           ,2)
                     
INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('setting'
           ,'网站设置'
           ,''
           ,''
           ,'base'
           ,'system'
           ,1)
           
INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('orderS'
           ,'订单查询'
           ,''
           ,''
           ,'order'
           ,'root'
           ,1)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('test1'
           ,'测试1'
           ,''
           ,''
           ,'order'
           ,'orderS'
           ,1)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('test2'
           ,'测试2'
           ,''
           ,''
           ,'order'
           ,'orderS'
           ,1)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('test22'
           ,'测试2'
           ,''
           ,''
           ,'order'
           ,'orderS'
           ,1)

INSERT INTO [MvcDemo].[dbo].[SideMenu]
           ([MenuID]
           ,[MenuName]
           ,[Url]
           ,[IconUrl]
           ,[HeaderMenuID]
           ,[ParentID]
           ,[MenuOrder])
     VALUES
           ('test3'
           ,'测试3'
           ,''
           ,''
           ,'order'
           ,'orderS'
           ,2)
           
INSERT dbo.[Role](RoleName) VALUES('超级管理员')

DECLARE @RoleID int
SELECT TOP 1 @RoleID=RoleID FROM dbo.[Role]

INSERT RoleUser(RoleID,UserID) VALUES(@RoleID,'admin')

INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'power')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'menu')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'role')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'user')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'action')



INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'system')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'setting')

INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'orderS')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'test1')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'test2')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'test22')
INSERT RoleSideMenu( RoleID, MenuID) VALUES(@RoleID,'test3')

INSERT RoleHeaderMenu(RoleID, MenuID) VALUES(@RoleID,'base')
INSERT RoleHeaderMenu(RoleID, MenuID) VALUES(@RoleID,'order')



GO