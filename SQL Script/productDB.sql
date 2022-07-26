USE [ProductDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/22/2022 1:34:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/22/2022 1:34:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](300) NOT NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 7/22/2022 1:34:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerName] [nvarchar](300) NOT NULL,
	[SaleCount] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProductSales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220721084816_InitialCreate', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220722082955_AddedCreatedAddToProductSale', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Price], [Stock], [CreatedAt], [UpdatedAt]) VALUES (7, N'Galaxy S20', 9200, 20, CAST(N'2022-07-22T11:29:55.6118827' AS DateTime2), CAST(N'2022-07-22T13:23:44.2719559' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [Stock], [CreatedAt], [UpdatedAt]) VALUES (11, N'Galaxy A51', 6200, 32, CAST(N'2022-07-22T11:29:55.6118827' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [Stock], [CreatedAt], [UpdatedAt]) VALUES (12, N'Galaxy A71', 8600, 18, CAST(N'2022-07-22T11:29:55.6118827' AS DateTime2), CAST(N'2022-07-22T13:23:52.3130484' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [Stock], [CreatedAt], [UpdatedAt]) VALUES (13, N'Iphone 12', 21200, 34, CAST(N'2022-07-22T11:29:55.6118827' AS DateTime2), CAST(N'2022-07-22T13:24:13.5006869' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [Price], [Stock], [CreatedAt], [UpdatedAt]) VALUES (14, N'Iphone 13', 32500, 22, CAST(N'2022-07-22T11:29:55.6118827' AS DateTime2), CAST(N'2022-07-22T13:24:08.3555159' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSales] ON 

INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (16, 7, N'mehmet', 5, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (17, 7, N'mehmet', 1, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (18, 12, N'ahmet', 3, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (19, 14, N'ayşe', 2, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (20, 14, N'ezgi', 1, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
INSERT [dbo].[ProductSales] ([Id], [ProductId], [CustomerName], [SaleCount], [CreatedAt]) VALUES (21, 13, N'kenan', 2, CAST(N'2022-07-22T11:29:55.6120312' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductSales] OFF
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('2022-07-22T11:29:55.6118827+03:00') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProductSales] ADD  DEFAULT ('2022-07-22T11:29:55.6120312+03:00') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [FK_ProductSales_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [FK_ProductSales_Products_ProductId]
GO
