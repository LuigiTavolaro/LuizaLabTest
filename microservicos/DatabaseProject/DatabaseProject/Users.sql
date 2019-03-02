CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
 CONSTRAINT [pk_UsersId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))