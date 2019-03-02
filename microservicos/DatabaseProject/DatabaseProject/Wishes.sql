CREATE TABLE [dbo].[Wishes](
	[ProductId] [int]  NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [pk_WishesId] PRIMARY KEY CLUSTERED 
(
	[ProductId],[UserId] ASC
),
 CONSTRAINT FK_WishProduct
FOREIGN KEY ([ProductId]) REFERENCES Products(Id),
 CONSTRAINT FK_WishUser
FOREIGN KEY ([UserId]) REFERENCES Users(Id))