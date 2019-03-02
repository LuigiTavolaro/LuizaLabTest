CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [pk_ProductsId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))


