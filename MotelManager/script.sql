USE [MotelDbDemo]
GO
/****** Object:  Table [dbo].[About]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[web_settings_id] [int] IDENTITY(1,1) NOT NULL,
	[about] [nvarchar](max) NULL,
	[phone] [varchar](11) NULL,
	[email] [varchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[start_time] [varchar](10) NULL,
	[finish_time] [varchar](10) NULL,
	[iframe] [varchar](max) NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[web_settings_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[role] [varchar](10) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](11) NULL,
	[sex] [nvarchar](10) NULL,
	[fullname] [nvarchar](50) NULL,
	[status] [bit] NULL,
	[identityID] [varchar](12) NULL,
	[authority] [int] NULL,
	[avatar] [varchar](max) NULL,
	[avatarImage] [bigint] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[slug] [varchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[code_id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](200) NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[code_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[content_post] [nvarchar](max) NULL,
	[created_date] [date] NULL,
	[account_id] [int] NULL,
	[post_id] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[district_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[city_id] [int] NULL,
	[slug] [varchar](50) NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite](
	[favorite_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NULL,
	[post_id] [int] NULL,
	[date_save] [date] NULL,
 CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED 
(
	[favorite_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[url] [varchar](max) NULL,
	[motel_id] [int] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motel]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motel](
	[motel_id] [int] IDENTITY(1,1) NOT NULL,
	[acreage] [int] NULL,
	[floor] [int] NULL,
	[bedroom] [int] NULL,
	[bathroom] [int] NULL,
	[price] [int] NULL,
	[address] [nvarchar](255) NULL,
	[iframe] [varchar](max) NULL,
	[district_id] [int] NULL,
	[sub_district_id] [int] NULL,
	[type_real_estate_id] [int] NULL,
	[city_id] [int] NULL,
	[code_motel] [varchar](200) NULL,
 CONSTRAINT [PK_Motel] PRIMARY KEY CLUSTERED 
(
	[motel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[notification_id] [int] IDENTITY(1,1) NOT NULL,
	[notification_title] [nvarchar](100) NULL,
	[notification_content] [nvarchar](200) NULL,
	[created_date] [date] NULL,
	[account_id] [int] NULL,
	[post_id] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[notification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[idOrder] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [datetime] NULL,
	[Status] [nvarchar](100) NULL,
	[account_id] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[idOrder] [int] NOT NULL,
	[motel_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetails_1] PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC,
	[motel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[sub_title] [nvarchar](255) NULL,
	[description] [nvarchar](max) NULL,
	[account_id] [int] NULL,
	[motel_id] [int] NULL,
	[status] [int] NULL,
	[created_date] [date] NULL,
	[updated_date] [date] NULL,
	[slug] [nvarchar](255) NULL,
	[image_post] [varchar](max) NULL,
	[code_post] [varchar](200) NULL,
	[image_post_byte] [bigint] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[report_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[content_report] [nvarchar](200) NULL,
	[created_date] [date] NULL,
	[status] [bit] NULL,
	[post_id] [int] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[setting_id] [int] IDENTITY(1,1) NOT NULL,
	[min] [int] NULL,
	[max] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[setting_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubDistrict]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubDistrict](
	[sub_district_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[slug] [varchar](50) NULL,
	[district_id] [int] NULL,
 CONSTRAINT [PK_SubDistrict] PRIMARY KEY CLUSTERED 
(
	[sub_district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeRE]    Script Date: 5/9/2022 8:52:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeRE](
	[type_real_estate_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[slug] [varchar](50) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_TypeRE] PRIMARY KEY CLUSTERED 
(
	[type_real_estate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([web_settings_id], [about], [phone], [email], [address], [start_time], [finish_time], [iframe]) VALUES (1, N'<p>Chào mừng đến với Booking.</p>', N'123456789', N'linhdo@gmail.com', N'475A Điện Biên Phủ', N'8:00', N'5:00', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.125120810274!2d106.7123030148853!3d10.801727892304356!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317528a459cb43ab%3A0x6c3d29d370b52a7e!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBDw7RuZyBuZ2jhu4cgVFAuSENN!5e0!3m2!1svi!2s!4v1625157779145!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>')
SET IDENTITY_INSERT [dbo].[About] OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar], [avatarImage]) VALUES (1, N'admin', N'admin123', N'202cb962ac59075b964b07152d234b70', N'linhdo@gmail.com', N'0123456789', N'nam', N'Linh', 1, NULL, 1, N'/Public/images/avatar/avatar1.png', NULL)
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar], [avatarImage]) VALUES (2005, N'user', N'user123', N'202cb962ac59075b964b07152d234b70', N'user@gmail.com', N'0123123123', NULL, N'User Linh', 1, NULL, 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1, N'Hồ Chí Minh', N'ho-chi-minh')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (2, N'Hà Nội', N'ha-noi')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (3, N'Đà Nẵng', N'da-nang')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1002, N'Hải Phòng', N'hai-phong')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1003, N'Đồng Nai', N'dong-nai')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1004, N'Bình Dương', N'binh-duong')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1005, N'Cần Thơ', N'can-tho')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1006, N'Long An', N'long-an')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1007, N'An Giang', N'an-giang')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1008, N'Bà Rịa - Vũng Tàu', N'ba-ria-vung-tau')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1009, N'Bắc Giang', N'bac-giang')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1010, N'Bắc Kạn', N'bac-khan')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1011, N'Bạc Liêu', N'bac-lieu')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1012, N'Bắc Ninh', N'bac-ninh')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1013, N'Bình Định', N'binh-dinh')
INSERT [dbo].[City] ([city_id], [name], [slug]) VALUES (1014, N'Bình Phước', N'binh-phuoc')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Code] ON 

INSERT [dbo].[Code] ([code_id], [code]) VALUES (1, N'qC81nh6vH0ABjGdLp3DSA')
SET IDENTITY_INSERT [dbo].[Code] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([district_id], [name], [city_id], [slug]) VALUES (1, N'Quận 1', 1, N'quan-1')
INSERT [dbo].[District] ([district_id], [name], [city_id], [slug]) VALUES (2, N'Quận 2', 1, N'quan-2')
INSERT [dbo].[District] ([district_id], [name], [city_id], [slug]) VALUES (3, N'Ba Đình', 2, N'ba-dinh')
INSERT [dbo].[District] ([district_id], [name], [city_id], [slug]) VALUES (4, N'Quận 10', 1, N'quan-10-0')
INSERT [dbo].[District] ([district_id], [name], [city_id], [slug]) VALUES (5, N'Quận Bình Thạnh', 1, N'quan-binh-thanh')
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorite] ON 

INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (2016, 4, 1, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (2017, 4, 2, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (3017, 2, 1, CAST(N'2021-07-04' AS Date))
SET IDENTITY_INSERT [dbo].[Favorite] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1008, N'/Public/images/motel/motel10.jpg', 2019)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1009, N'/Public/images/motel/motel11.jpg', 2019)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2035, N'/Public/images/motel/213076494.jpg', 2018)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2036, N'/Public/images/motel/218625234.jpg', 2019)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2037, N'/Public/images/motel/193408435.jpg', 2020)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2038, NULL, 2021)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Motel] ON 

INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2018, 15, 0, 1, 1, 292000, NULL, N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4419297652935!2d106.67622541411646!3d10.777425162123933!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f27af906adb%3A0xe24d24a584852627!2zS2jDoWNoIFPhuqFuIE5o4bqtdCBNaW5oICggSG90ZWwgKQ!5e0!3m2!1svi!2s!4v1651940736388!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>', 4, 3, 3, 0, N'UJxRAA871kGR4QjFeoMrQadmin123')
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2019, 18, 1, 1, 1, 442000, N'190 Lê Thánh Tôn', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.498276255584!2d106.69484151379973!3d10.773097092323779!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f38d513561f%3A0x52056c2321b82148!2zMTkwIEzDqiBUaMOhbmggVMO0biwgUGjGsOG7nW5nIELhur9uIFRow6BuaCwgUXXhuq1uIDEsIFRow6BuaCBwaOG7kSBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1651941441805!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>', 1, 1, 5, NULL, N'5C5drfycIkulWGjzr7oGwadmin123')
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2020, 18, 0, 1, 1, 792000, N'15 Bui Thi Xuan', N'<iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d3919.5122413709137!2d106.69193576379969!3d10.77202414232451!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s15%20Bui%20Thi%20Xuan%20Street%2C%20Ben%20Thanh%20Ward%2C%20District%201%2C%20Qu%E1%BA%ADn%201%2C%20TP.%20H%C3%B4%CC%80%20Chi%CC%81%20Minh%2C!5e0!3m2!1svi!2s!4v1651941844288!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>', 1, 1, 5, NULL, N'mpMJWbxX80K/bLiJHmmljAadmin123')
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2021, 24, 0, 1, 1, 402500, N'27-29 Bui Vien', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.573455203572!2d106.69169611379965!3d10.767319792327724!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f1607388827%3A0x526fb4ecbb2fc53c!2zMjcsIDI5IELDuWkgVmnhu4duLCBQaMaw4budbmcgUGjhuqFtIE5nxakgTMOjbywgUXXhuq1uIDEsIFRow6BuaCBwaOG7kSBI4buTIENow60gTWluaCA3MDAwMDAsIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1651942009068!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>', 1, 4, 5, NULL, N'ov35bsQaaUKZ3XafygDgadmin123')
SET IDENTITY_INSERT [dbo].[Motel] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (2, N'bai viet vi pham', N'bai viet vi pham', CAST(N'2021-07-04' AS Date), 1, 2021, 1)
INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (3, N'bai viet vi pham', N'bai viet vi pham', CAST(N'2021-07-04' AS Date), 0, NULL, 0)
INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (6, N'123', N'<p><strong>adafasdf</strong></p>', CAST(N'2021-07-04' AS Date), 2005, NULL, 1)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (11, CAST(N'2022-05-07T16:11:05.983' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (12, CAST(N'2022-05-07T16:16:14.503' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (13, CAST(N'2022-05-07T16:19:49.203' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (14, CAST(N'2022-05-07T16:48:06.607' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (15, CAST(N'2022-05-07T16:48:06.757' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (16, CAST(N'2022-05-07T16:49:44.880' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (17, CAST(N'2022-05-07T16:50:22.397' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (18, CAST(N'2022-05-07T16:50:22.453' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (19, CAST(N'2022-05-07T16:52:15.437' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (20, CAST(N'2022-05-07T16:52:31.807' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (21, CAST(N'2022-05-07T16:54:52.087' AS DateTime), N'Kiểm tra hàng', 2005)
INSERT [dbo].[Order] ([idOrder], [BookingDate], [Status], [account_id]) VALUES (22, CAST(N'2022-05-07T23:51:06.203' AS DateTime), N'Đang kiểm tra phòng', 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (12, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (13, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (14, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (16, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (17, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (19, 1, 1, CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (21, 2015, 1, CAST(4500000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([idOrder], [motel_id], [quantity], [price]) VALUES (22, 2018, 1, CAST(292000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post], [image_post_byte]) VALUES (2016, N'Phòng Tiêu Chuẩn Giường Đôi', N'1 giường đôi lớn', N'<ul><li>Đồ vệ sinh cá nhân miễn phí</li><li>Vòi sen</li><li>Nhà vệ sinh</li><li>Khăn tắm</li><li>Bàn làm việc</li><li>TV</li><li>Dép</li><li>Tủ lạnh</li><li>Điện thoại</li><li>Máy sấy tóc</li><li>Quạt máy</li><li>Dịch vụ báo thức</li><li>Ấm đun nước điện</li><li>Dịch vụ báo thức</li><li>Đồng hồ báo thức</li><li>Giấy vệ sinh</li><li>Nước rửa tay</li><li>Máy điều hòa độc lập cho từng phòng</li><li>Máy lọc không khí</li><li>Thiết bị báo carbon monoxide</li></ul>', 1, 2018, 1, CAST(N'2022-05-07' AS Date), CAST(N'2022-05-07' AS Date), N'phong-tieu-chuan-giuong-doi4Jp313w19EJSKpUzpF9Q', N'/Public/images/motel/room_3.jpg', N'UJxRAA871kGR4QjFeoMrQadmin123', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post], [image_post_byte]) VALUES (2017, N'Ngay trung tâm TP. Hồ Chí Minh', N'2 Giường Đơn', N'<ul><li>Đồ vệ sinh cá nhân miễn phí</li><li>Chậu rửa vệ sinh (bidet)</li><li>Nhà vệ sinh</li><li>Bồn tắm hoặc Vòi sen</li><li>Sàn lát gỗ</li><li>Khăn tắm</li><li>Ra trải giường</li><li>Ổ điện gần giường</li><li>Sản phẩm lau rửa</li><li>Không gây dị ứng</li><li>Bàn làm việc</li><li>Lối vào riêng</li><li>TV</li><li>Dép</li><li>Tủ lạnh</li><li>Điện thoại</li><li>Máy sấy tóc</li><li>Phòng thay quần áo</li><li>Dịch vụ báo thức</li><li>Ấm đun nước điện</li><li>Bàn ghế ngoài trời</li><li>Truyền hình cáp</li><li>Dịch vụ báo thức</li><li>Tủ hoặc phòng để quần áo</li><li>Bàn ăn</li><li>Các tầng trên đi lên bằng thang máy</li><li>Giá treo quần áo</li><li>Giấy vệ sinh</li><li>Nắp che ổ cắm điện an toàn</li><li>Cửa an toàn cho trẻ nhỏ</li><li>Xe lăn có thể đi đến mọi nơi trong toàn bộ khuôn viên</li></ul>', 1, 2019, 1, CAST(N'2022-05-07' AS Date), NULL, N'ngay-trung-tam-tp-ho-chi-minh', N'/Public/images/motel/room.jpg', N'5C5drfycIkulWGjzr7oGwadmin123', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post], [image_post_byte]) VALUES (2018, N'Ngay trung tâm TP. Hồ Chí Minh', N'1 Giường Đôi Lớn', N'<ul><li>Đồ vệ sinh cá nhân miễn phí</li><li>Két an toàn</li><li>Nhà vệ sinh</li><li>Bồn tắm hoặc Vòi sen</li><li>Sàn lát gỗ</li><li>Khăn tắm</li><li>Ra trải giường</li><li>Ổ điện gần giường</li><li>Bàn làm việc</li><li>Khu vực tiếp khách</li><li>TV</li><li>Dép</li><li>Điện thoại</li><li>Máy sấy tóc</li><li>Quạt máy</li><li>Truyền hình cáp</li><li>Dịch vụ báo thức</li><li>Tủ hoặc phòng để quần áo</li><li>Các tầng trên đi lên bằng thang máy</li><li>Các tầng trên chỉ lên được bằng cầu thang</li><li>Giá treo quần áo</li><li>Giấy vệ sinh</li></ul>', 1, 2020, 1, CAST(N'2022-05-07' AS Date), NULL, N'ngay-trung-tam-tp-ho-chi-minhI28V7RENkehVHw/afpzAg', N'/Public/images/motel/room_2.jpg', N'mpMJWbxX80K/bLiJHmmljAadmin123', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post], [image_post_byte]) VALUES (2019, N'Ngay trung tâm TP. Hồ Chí Minh', N'1 Giường Đôi Lớn', N'<ul><li>Đồ vệ sinh cá nhân miễn phí</li><li>Áo choàng tắm</li><li>Nhà vệ sinh</li><li>Bồn tắm hoặc Vòi sen</li><li>Khăn tắm</li><li>Ổ điện gần giường</li><li>Sàn lát gạch/đá cẩm thạch</li><li>Bàn làm việc</li><li>Khu vực tiếp khách</li><li>TV</li><li>Dép</li><li>Tủ lạnh</li><li>Màn chống muỗi</li><li>Điện thoại</li><li>Máy sấy tóc</li><li>Quạt máy</li><li>Phòng thay quần áo</li><li>Khăn tắm/Bộ khăn trải giường (có thu phí)</li><li>Ấm đun nước điện</li><li>Truyền hình cáp</li><li>Tủ hoặc phòng để quần áo</li><li>Khu vực phòng ăn</li><li>Bàn ăn</li><li>Giá treo quần áo</li><li>Giấy vệ sinh</li><li>Nắp che ổ cắm điện an toàn</li><li>Cửa an toàn cho trẻ nhỏ</li><li>Nước rửa tay</li></ul>', 1, 2021, 1, CAST(N'2022-05-07' AS Date), NULL, N'ngay-trung-tam-tp-ho-chi-minhTftq6IQT/UyN8ulQsSy6nQ', N'/Public/images/motel/98439364.jpg', N'ov35bsQaaUKZ3XafygDgadmin123', NULL)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([report_id], [title], [content_report], [created_date], [status], [post_id]) VALUES (1, N'tieu đe', N'bao cao', CAST(N'2021-07-03' AS Date), 0, 2016)
INSERT [dbo].[Report] ([report_id], [title], [content_report], [created_date], [status], [post_id]) VALUES (2, N'Tiêu đề a', N'Nội dung a
', CAST(N'2022-04-28' AS Date), 0, 2017)
SET IDENTITY_INSERT [dbo].[Report] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([setting_id], [min], [max], [status]) VALUES (1, 0, 1, 1)
INSERT [dbo].[Setting] ([setting_id], [min], [max], [status]) VALUES (2, 1, 3, 1)
INSERT [dbo].[Setting] ([setting_id], [min], [max], [status]) VALUES (3, 3, 5, 1)
INSERT [dbo].[Setting] ([setting_id], [min], [max], [status]) VALUES (4, 5, 10, 1)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[SubDistrict] ON 

INSERT [dbo].[SubDistrict] ([sub_district_id], [name], [slug], [district_id]) VALUES (1, N'Bến Thành', N'ben-thanh', 1)
INSERT [dbo].[SubDistrict] ([sub_district_id], [name], [slug], [district_id]) VALUES (2, N'Nguyễn Cư Trinh', N'nguyen-cu-trinh', 1)
INSERT [dbo].[SubDistrict] ([sub_district_id], [name], [slug], [district_id]) VALUES (3, N'Phường 12', N'phuong-12', 4)
INSERT [dbo].[SubDistrict] ([sub_district_id], [name], [slug], [district_id]) VALUES (4, N'Phường Phạm Ngũ Lão', N'phuong-pham-ngu-lao', 1)
SET IDENTITY_INSERT [dbo].[SubDistrict] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeRE] ON 

INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (1, N'Nhà', N'nha', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (2, N'Phòng trọ', N'phong-tro', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (4, N'Căn hộ', N'can-ho', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (5, N'Khách sạn', N'khach-san', 1)
SET IDENTITY_INSERT [dbo].[TypeRE] OFF
GO
