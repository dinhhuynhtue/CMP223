USE [RESTAURANTMANAGEMENT]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill](
	[Bill_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Discount_ID] [varchar](10) NULL,
	[TB_ID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Bill_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK__Bill__CF6E7D435AA2F367] PRIMARY KEY CLUSTERED 
(
	[Bill_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Phone] [varchar](11) NOT NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK__Customer__8CB286B93B878E92] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Discount](
	[Discount_ID] [varchar](10) NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK__Discount__6C137224ADCC8D6B] PRIMARY KEY CLUSTERED 
(
	[Discount_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dish]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[Dish_ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Type_ID] [smallint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL CONSTRAINT [DF_Dish_Price]  DEFAULT ((0)),
	[Detail] [ntext] NULL,
	[Images] [nvarchar](255) NULL,
	[Description] [nvarchar](500) NULL,
	[TopHot] [datetime] NULL,
 CONSTRAINT [PK__Dish__3B04B49FF6088173] PRIMARY KEY CLUSTERED 
(
	[Dish_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodType]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodType](
	[Type_ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [ntext] NULL,
	[Images] [nvarchar](255) NULL,
 CONSTRAINT [PK__FoodType__FE90DDFEA997FEAA] PRIMARY KEY CLUSTERED 
(
	[Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subcribe]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subcribe](
	[Email] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Subcribe] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Table_ID] [smallint] NOT NULL,
	[TB_ID] [bigint] NULL,
	[Seats] [tinyint] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK__Table__BAB7E656C58FEF92] PRIMARY KEY CLUSTERED 
(
	[Table_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_Detail]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Detail](
	[TB_ID] [bigint] NOT NULL,
	[Dish_ID] [smallint] NOT NULL,
	[Quantity] [tinyint] NOT NULL,
 CONSTRAINT [PK__TB_Detai__52CB067CDED289D6] PRIMARY KEY CLUSTERED 
(
	[TB_ID] ASC,
	[Dish_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_Information]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Information](
	[TB_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [bigint] NOT NULL,
	[Tb_Seats] [tinyint] NOT NULL,
	[DateSet] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_TB_Information_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK__TB_Infor__B17B4D35BA0AB581] PRIMARY KEY CLUSTERED 
(
	[TB_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 04/04/2019 11:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](32) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Administrator] [bit] NOT NULL CONSTRAINT [DF_User_Administrator]  DEFAULT ((0)),
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()),
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__User__206D9190635E7744] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ( [Discount_ID], [TB_ID], [CreatedBy], [CreatedDate]) VALUES ( N'WWW10', 2, 20, NULL)
INSERT [dbo].[Bill] ( [Discount_ID], [TB_ID], [CreatedBy], [CreatedDate]) VALUES ( N'WWW10', 3, 1, NULL)
INSERT [dbo].[Bill] ( [Discount_ID], [TB_ID], [CreatedBy], [CreatedDate]) VALUES ( NULL, 1, 2, NULL)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Customer_ID], [Name], [Phone], [Email]) VALUES (1, N'Đặng Thạch Thảo', N'0391254787', N'theotheo@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Phone], [Email]) VALUES (2, N'Trần Gia Bảo', N'0169554872', N'Baobeo@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Phone], [Email]) VALUES (3, N'Huỳnh Minh Đức', N'0761548959', N'ducminh@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Phone], [Email]) VALUES (4, N'Phạm Thị Lu', N'0399649820', N'lulu@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Phone], [Email]) VALUES (5, N'Đinh Văn Thịnh', N'0945872156', N'thinh3d@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[Discount] ([Discount_ID], [Rate]) VALUES (N'WWW10', 0.1)
SET IDENTITY_INSERT [dbo].[Dish] ON 

INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 4, N'Tôm Đất Chiên Xù Giòn Tan', CAST(400000 AS Decimal(18, 0)), N'Tôm chiên xù là món ăn ngon, dễ làm; những miếng tôm giòn rụm, vàng ươm thịt tôm ngọt lừ, kích thích vị giác…', NULL, NULL, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 1, N'Lẩu Bah-Kut-Tek', CAST(250000 AS Decimal(18, 0)), N'Lẩu Bak-Kut-Teh Cái tên bắt nguồn từ ẩm thực trung hoa và lừng danh trên đất singapore với cách nấu nước dùng đặc biệt từ nhiều loại thảo mộc như đinh hương, quế, tỏi, nấm đông cô… món ăn được xem là có vị thuốc, vừa bổ, vừa...', N'\Assets\Client\images\Food\Hotpot\BakKutTeh-1.jpg', NULL, CAST(N'2019-04-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 2, N'Gà Nướng Ớt Cay', CAST(176000 AS Decimal(18, 0)), NULL, N'\Assets\Client\images\Food\Grill\ganuongotcay.png', NULL, CAST(N'2019-04-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 3, N'Cá Nheo Hấp Kì Lân', CAST(350000 AS Decimal(18, 0)), N'Bằng sự tỉ mỉ, kỳ công các đầu bếp tạo nên một món ăn vừa ngon vừa tinh xảo với hình dáng giống những chiếc vảy của kỳ lân. Món ăn không chỉ ngon, chất lượng mà sẽ khiến thực khách mãn nhãn', NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 4, N'Cánh Gà Chiên', CAST(50000 AS Decimal(18, 0)), N'Mùi thơm , vị béo của bơ cùng với độ ngọt tự nhiên của cánh gà tạo nên “Cánh gà chiên bơ ” vô cùng hấp dẫn làm bất cứ ai cũng khó lòng có thể chối từ.', NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 3, N'Heo Rừng Hấp Gừng', CAST(150000 AS Decimal(18, 0)), N'Thịt heo rừng có vị ngọt tự nhiên, do quá trình vận động trong môi trường hoang dã nên phần thịt đặc biệt săn chắc hơn thịt heo thông thường. Gừng vốn là gia vị quen thuộc trong ẩm thực Đông Nam Á bởi tính ấm, trừ phong cảm', NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 5, N'Nước Suối', CAST(150000 AS Decimal(18, 0)), NULL, NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 2, N'Sườn Bò Nướng Mật Ong', CAST(450000 AS Decimal(18, 0)), N'Thịt sườn rất giàu giá trị dinh dưỡng. Đây được xem là loại “thịt lành”, dùng được cho cả những đối tượng người bệnh hoặc người đang có vết thương hở, giúp làm nhanh quá trình phục hồi của tế bào, giúp vết thương mau lành.. Ngoài ra trong thịt lợn, đặc biệt là phần sườn có nhiều axit amin giúp kích thích tiết dịch vị nên rất tốt cho hệ tiêu hóa.', N'\Assets\Client\images\Food\Grill\suon-nuong-mat-ong.jpg', NULL, CAST(N'2019-04-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 5, N'333', CAST(230000 AS Decimal(18, 0)), NULL, NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 3, N'Gà Hấp Lá Chanh', CAST(300000 AS Decimal(18, 0)), N'Hương thơm của lá chanh và vị ngọt tự nhiên từ thịt gà hòa quyện vào nhau đã tạo nên món ăn vô cùng độc đáo và hấp dẫn, đó là “ Gà hấp lá chanh” đậm chất miền Tây.', NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 5, N'Heineken', CAST(320000 AS Decimal(18, 0)), NULL, NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 2, N'Heo Rừng Nướng Sa Tế', CAST(150000 AS Decimal(18, 0)), N'Heo rừng sống trong môi trường tự nhiên, vận động nhiều nên thịt heo rừng dai, ngọt béo, thơm ngon nhưng lại không ngán. Thịt heo rừng ướp cùng sa tế và một số gia vị tạo nên món heo rừng nướng sa tế vừa thơm ngon lại rất bổ dưỡng.', N'\Assets\Client\images\Food\Grill\heorungnuongsate.jpg', NULL, CAST(N'2019-04-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 5, N'Nước Ngọt', CAST(200000 AS Decimal(18, 0)), NULL, NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 5, N'Tiger', CAST(250000 AS Decimal(18, 0)), NULL, NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 2, N'Vịt Nướng Ngũ Vị', CAST(300000 AS Decimal(18, 0)), N'“Vịt nướng ngũ vị” Vạn Phát đã làm thực khách không khỏi trầm trồ trước vẻ vàng ươm, ngoài da giòn giòn, thịt vịt ngọt ngào, đậm đà nhờ vào sự kì công tẩm ướp gia vị của những đầu bếp nhiều năm kinh nghiệm.', NULL, NULL, CAST(N'2019-01-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 1, N'Lẩu Tứ Xuyên
', CAST(250000 AS Decimal(18, 0)), N'Có tới hơn 30 loại nguyên liệu, thực phẩm, gia vị như tương, gừng, ớt khô, tỏi, hoa tiêu, vị chua thơm, vị hải tiên, đều phát triển trên cơ sở vị cay tê ngào ngạt. Nước chấm của lẩu Tứ Xuyên cũng có nhiều kiểu như dầu vừng, dầu hào, dầu cải chín… pha chế thành nhiều loại nước chấm, đủ màu sắc, hương vị, thích hợp cho nhu cầu khẩu vị từng người
', N'\Assets\Client\images\Food\Hotpot\Hotpot_Tuxuyen.jpeg', NULL, CAST(N'2019-04-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ( [Type_ID], [Name], [Price], [Detail], [Images], [Description], [TopHot]) VALUES ( 1, N'Lẩu Bạch Tuộc', CAST(300000 AS Decimal(18, 0)), N'Lẩu Bạch Tuộc với nước lẩu chua cay, bạch tuộc ngọt, giòn kết hợp cùng các loại rau như cải xanh, cải thía, cải thảo, dùng với bún tươi sẽ mang đến bạn cơ hội thưởng thức trọn vẹn hương vị tuyệt vời của món lẩu sa tế đặc biệt. Chắc chắn rằng hương vị khác biệt của món lẩu này sẽ khiến bạn ghi nhớ mãi.', N'\Assets\Client\images\Food\Hotpot\Hotpot_Bachtuot.jpg', NULL, CAST(N'2019-04-30 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Dish] OFF
SET IDENTITY_INSERT [dbo].[FoodType] ON 

INSERT [dbo].[FoodType] ([Type_ID], [Name], [Detail], [Images]) VALUES (1, N'Hot Pot', NULL, NULL)
INSERT [dbo].[FoodType] ([Type_ID], [Name], [Detail], [Images]) VALUES (2, N'Grill', NULL, NULL)
INSERT [dbo].[FoodType] ([Type_ID], [Name], [Detail], [Images]) VALUES (3, N'Steam', NULL, NULL)
INSERT [dbo].[FoodType] ([Type_ID], [Name], [Detail], [Images]) VALUES (4, N'Fry', NULL, NULL)
INSERT [dbo].[FoodType] ([Type_ID], [Name], [Detail], [Images]) VALUES (5, N'Drinks', NULL, NULL)
SET IDENTITY_INSERT [dbo].[FoodType] OFF
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (1, NULL, 4, 0)
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (2, NULL, 10, 1)
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (3, NULL, 4, 1)
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (4, NULL, 6, 1)
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (5, NULL, 10, 1)
INSERT [dbo].[Table] ([Table_ID], [TB_ID], [Seats], [Status]) VALUES (6, NULL, 6, 0)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 3, 6)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 4, 5)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 5, 5)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 6, 3)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 7, 6)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (1, 9, 25)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (2, 3, 2)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (2, 4, 4)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (2, 5, 1)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (2, 8, 2)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (3, 3, 3)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (3, 10, 3)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (3, 11, 15)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (3, 12, 3)
INSERT [dbo].[TB_Detail] ([TB_ID], [Dish_ID], [Quantity]) VALUES (3, 16, 2)
SET IDENTITY_INSERT [dbo].[TB_Information] ON 

INSERT [dbo].[TB_Information] ( [Customer_ID], [Tb_Seats], [DateSet], [CreatedBy], [CreatedDate]) VALUES ( 1, 10, CAST(N'2019-03-25 12:00:00.000' AS DateTime), 2, CAST(N'2015-03-24 10:00:00.000' AS DateTime))
INSERT [dbo].[TB_Information] ( [Customer_ID], [Tb_Seats], [DateSet], [CreatedBy], [CreatedDate]) VALUES ( 2, 4, CAST(N'2019-03-26 19:00:00.000' AS DateTime), 3, CAST(N'2019-03-26 10:00:00.000' AS DateTime))
INSERT [dbo].[TB_Information] ( [Customer_ID], [Tb_Seats], [DateSet], [CreatedBy], [CreatedDate]) VALUES ( 3, 10, CAST(N'2019-03-28 18:00:00.000' AS DateTime), 20, CAST(N'2019-03-27 12:00:00.000' AS DateTime))
INSERT [dbo].[TB_Information] ( [Customer_ID], [Tb_Seats], [DateSet], [CreatedBy], [CreatedDate]) VALUES ( 4, 5, CAST(N'2019-03-28 00:00:00.000' AS DateTime), 3, CAST(N'2019-03-28 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_Information] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ( [Username], [Password], [Name], [Email], [Administrator], [CreatedDate], [ModifiedDate]) VALUES ( N'baonguyen', N'031a9a7f7d5bb2ecdd555d6c4e440170', N'Nguyễn Trần Xuân Bảo', N'xvxiiixixviii@gmail.com', 1, CAST(N'2019-03-30 21:22:37.510' AS DateTime), CAST(N'2019-03-30 21:38:02.450' AS DateTime))
INSERT [dbo].[User] ( [Username], [Password], [Name], [Email], [Administrator], [CreatedDate], [ModifiedDate]) VALUES ( N'tuehuynh', N'202cb962ac59075b964b07152d234b70', N'Đinh Huỳnh Tuệ Tuệ', N'dinhhuynhtue@gmail.com', 0, NULL, CAST(N'2019-03-30 21:39:32.793' AS DateTime))
INSERT [dbo].[User] ( [Username], [Password], [Name], [Email], [Administrator], [CreatedDate], [ModifiedDate]) VALUES ( N'thaothach', N'202cb962ac59075b964b07152d234b70', N'Đặng Thị Thạch Thảo', N'dangthithachthao@gmail.com', 0, NULL, NULL)
INSERT [dbo].[User] ( [Username], [Password], [Name], [Email], [Administrator], [CreatedDate], [ModifiedDate]) VALUES ( N'quynhpham', N'202cb962ac59075b964b07152d234b70', N'Phạm Thị Quỳnh', N'phamthiquynh@gmail.com', 1, CAST(N'2019-03-30 22:49:28.940' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__5C7E359E457F0A48]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UQ__Customer__5C7E359E457F0A48] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Customer__8CB286B88EB86AD7]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UQ__Customer__8CB286B88EB86AD7] UNIQUE NONCLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__A9D1053490521CF1]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UQ__Customer__A9D1053490521CF1] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Discount__6C13722590589211]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [UQ__Discount__6C13722590589211] UNIQUE NONCLUSTERED 
(
	[Discount_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__User__206D9191AEFC55DE]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__User__206D9191AEFC55DE] UNIQUE NONCLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__User__536C85E4AEC40E55]    Script Date: 04/04/2019 11:56:14 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__User__536C85E4AEC40E55] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Subcribe] ADD  CONSTRAINT [DF_Subcribe_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__CreatedBy__5165187F] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__CreatedBy__5165187F]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__Discount_I__5441852A] FOREIGN KEY([Discount_ID])
REFERENCES [dbo].[Discount] ([Discount_ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__Discount_I__5441852A]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__TB_ID__5629CD9C] FOREIGN KEY([TB_ID])
REFERENCES [dbo].[TB_Information] ([TB_ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__TB_ID__5629CD9C]
GO
ALTER TABLE [dbo].[Dish]  WITH CHECK ADD  CONSTRAINT [FK__Dish__Type_ID__534D60F1] FOREIGN KEY([Type_ID])
REFERENCES [dbo].[FoodType] ([Type_ID])
GO
ALTER TABLE [dbo].[Dish] CHECK CONSTRAINT [FK__Dish__Type_ID__534D60F1]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK__Table__TB_ID__571DF1D5] FOREIGN KEY([TB_ID])
REFERENCES [dbo].[TB_Information] ([TB_ID])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK__Table__TB_ID__571DF1D5]
GO
ALTER TABLE [dbo].[TB_Detail]  WITH CHECK ADD  CONSTRAINT [FK__TB_Detail__Dish___4F7CD00D] FOREIGN KEY([Dish_ID])
REFERENCES [dbo].[Dish] ([Dish_ID])
GO
ALTER TABLE [dbo].[TB_Detail] CHECK CONSTRAINT [FK__TB_Detail__Dish___4F7CD00D]
GO
ALTER TABLE [dbo].[TB_Detail]  WITH CHECK ADD  CONSTRAINT [FK__TB_Detail__TB_ID__5535A963] FOREIGN KEY([TB_ID])
REFERENCES [dbo].[TB_Information] ([TB_ID])
GO
ALTER TABLE [dbo].[TB_Detail] CHECK CONSTRAINT [FK__TB_Detail__TB_ID__5535A963]
GO
ALTER TABLE [dbo].[TB_Information]  WITH CHECK ADD  CONSTRAINT [FK__TB_Inform__Creat__52593CB8] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[TB_Information] CHECK CONSTRAINT [FK__TB_Inform__Creat__52593CB8]
GO
ALTER TABLE [dbo].[TB_Information]  WITH CHECK ADD  CONSTRAINT [FK__TB_Inform__Custo__5070F446] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[TB_Information] CHECK CONSTRAINT [FK__TB_Inform__Custo__5070F446]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [ck_phone] CHECK  ((len([phone])>=(8) AND len([phone])<=(11) AND NOT [phone] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [ck_phone]
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [CK_Rate] CHECK  (([rate]>=(0.01) AND [rate]<=(1)))
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [CK_Rate]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [ck_seats] CHECK  (([seats]>=(1) AND [seats]<=(10)))
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [ck_seats]
GO
ALTER TABLE [dbo].[TB_Information]  WITH CHECK ADD  CONSTRAINT [ck_tb_seats] CHECK  (([tb_seats]>=(1) AND [tb_seats]<=(50)))
GO
ALTER TABLE [dbo].[TB_Information] CHECK CONSTRAINT [ck_tb_seats]
GO
