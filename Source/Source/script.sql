USE [MotelDb]
GO
/****** Object:  Table [dbo].[About]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 05/07/2021 1:25:00 PM ******/
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
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motel]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 05/07/2021 1:25:00 PM ******/
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
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubDistrict]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeRE]    Script Date: 05/07/2021 1:25:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([web_settings_id], [about], [phone], [email], [address], [start_time], [finish_time], [iframe]) VALUES (1, N'<p>Chúng tôi biết bạn có rất nhiều lựa chọn, nhưng Green Group tự hào là trang web đứng top google về các từ khóa: cho thuê phòng trọ, nhà trọ, thuê nhà nguyên căn, cho thuê căn hộ, tìm người ở ghép...Vì vậy tin của bạn đăng trên website sẽ tiếp cận được với nhiều khách hàng hơn, do đó giao dịch nhanh hơn, tiết kiệm chi phí hơn</p>', N'123456789', N'greenhouse@gmail.com', N'475A Penthouse Đà Lạt', N'8:00', N'5:00', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.125120810274!2d106.7123030148853!3d10.801727892304356!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317528a459cb43ab%3A0x6c3d29d370b52a7e!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBDw7RuZyBuZ2jhu4cgVFAuSENN!5e0!3m2!1svi!2s!4v1625157779145!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>')
SET IDENTITY_INSERT [dbo].[About] OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (1, N'admin', N'thanhnguyen', N'202cb962ac59075b964b07152d234b70', N'thanh123@gmail.com', N'0123456789', N'nam', N'Nguyễn Trường Thành', 1, NULL, 1, N'/Public/images/avatar/avatar1.png')
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (2, N'user', N'thanhson', N'e10adc3949ba59abbe56e057f20f883e', N'son1234@gmail.com', N'0123456789', N'nam', N'Đỗ Thanh Sơn', 1, NULL, 2, N'/Public/images/avatar/discord-avatar-512-17LIV.png')
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (3, N'user', N'thanhha', N'e10adc3949ba59abbe56e057f20f883e', N'ha123@gmail.com', N'0123456789', N'nu', N'Trần Thanh Hà', 1, NULL, 3, N'/Public/images/avatar/avatar1.png')
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (4, N'user', N'tuannguyen', N'202cb962ac59075b964b07152d234b70', N'tuan1235@gmail.com', N'0337872590', N'nu', N'Tuấn Trần', 1, NULL, 2, N'/Public/images/avatar/avatar1.png')
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (1004, N'user', N'duongnguyen', N'e10adc3949ba59abbe56e057f20f883e', N'ng.tthanh18@gmail.com', N'0337872590', N'nam', N'Nguyen Thanh', 1, NULL, 3, N'/Public/images/avatar/discord-avatar-512-17LIV.png')
INSERT [dbo].[Account] ([account_id], [role], [username], [password], [email], [phone], [sex], [fullname], [status], [identityID], [authority], [avatar]) VALUES (2004, N'admin', N'tuannguyen1', NULL, N'ng.tthanh1811@gmail.com', N'123456789', N'nam', N'tran van tuan', 1, NULL, 1, N'/Public/images/avatar/discord-avatar-512-17LIV.png')
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
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorite] ON 

INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (2016, 4, 1, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (2017, 4, 2, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[Favorite] ([favorite_id], [account_id], [post_id], [date_save]) VALUES (3017, 2, 1, CAST(N'2021-07-04' AS Date))
SET IDENTITY_INSERT [dbo].[Favorite] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1, N'/Public/images/motel/nhatro1.jpg', 1)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2, N'/Public/images/motel/nhatro2.jpg', 1)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (3, N'/Public/images/motel/nhatro3.jpg', 1)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1005, N'/Public/images/motel/motel7.jpg', 2014)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1006, N'/Public/images/motel/motel9.jpg', 2015)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1007, N'/Public/images/motel/motel11.jpg', 2017)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1008, N'/Public/images/motel/motel10.jpg', 2019)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (1009, N'/Public/images/motel/motel11.jpg', 2019)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2032, N'/Public/images/motel/nhatro1.jpg', 2)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2033, N'/Public/images/motel/nhatro2.jpg', 2)
INSERT [dbo].[Image] ([image_id], [url], [motel_id]) VALUES (2034, N'/Public/images/motel/nhatro3.jpg', 2)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Motel] ON 

INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (1, 40, 1, 2, 2, 5000000, N'Quận 1 Phường Bến Thành', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d504.29583998690475!2d106.69818423464295!3d10.771723229377887!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752fb0a700a33b%3A0x80b0fd314c7193b4!2zROG7kkkgU-G7pE4!5e0!3m2!1svi!2s!4v1625047755025!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>', 1, 1, 1, 1, NULL)
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2, 35, 0, 1, 1, 5000000, N'
Đường Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh', NULL, 1, 2, 1, 1, NULL)
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2014, 20, 1, 1, 1, 4500000, N'261 Đường Trần Hưng Đạo, Phường Cô Giang, Quận 1, Hồ Chí Minh', N'<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d31356.967221864503!2d106.69237!3d10.763672!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f16e8c4f735%3A0xf56ef927ba22c680!2zMjYxIMSQLiBUcuG6p24gSMawbmcgxJDhuqFvLCBQaMaw4budbmcgQ8O0IEdpYW5nLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2sus!4v1625051448813!5m2!1svi!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>', 1, NULL, 1, 1, NULL)
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2015, 45, 1, 1, 1, 4500000, N'385/14 Đường Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1, Hồ Chí Minh', N'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.680415957989!2d106.68260181463681!3d10.759094862455795!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f1b1bf543b5%3A0x13a91c11fe1c5f87!2zMzg1LzE0IE5ndXnhu4VuIFRyw6NpLCBQaMaw4budbmcgTmd1eeG7hW4gQ8awIFRyaW5oLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2sus!4v1625051886822!5m2!1svi!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>', 1, NULL, 1, 1, NULL)
INSERT [dbo].[Motel] ([motel_id], [acreage], [floor], [bedroom], [bathroom], [price], [address], [iframe], [district_id], [sub_district_id], [type_real_estate_id], [city_id], [code_motel]) VALUES (2017, 1, 1, 1, 1, 5500000, N'196 Đề Thám, Phường Cầu Ông Lãnh, Quận 1, Hồ Chí Minh', N'<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d31356.685446245294!2d106.694602!3d10.76638!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f15dd7ca199%3A0xca3f348e3d417f1b!2zMTk2IMSQ4buBIFRow6FtLCBQaMaw4budbmcgQ-G6p3Ugw5RuZyBMw6NuaCwgUXXhuq1uIDEsIFRow6BuaCBwaOG7kSBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2sus!4v1625063979097!5m2!1svi!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>', 1, 0, 1, 1, N'S1dHLg0Cu0e8xUSuS7mWmQthanhson')
SET IDENTITY_INSERT [dbo].[Motel] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (2, N'bai viet vi pham', N'bai viet vi pham', CAST(N'2021-07-04' AS Date), 2, 2021, 1)
INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (3, N'bai viet vi pham', N'bai viet vi pham', CAST(N'2021-07-04' AS Date), 0, NULL, 0)
INSERT [dbo].[Notification] ([notification_id], [notification_title], [notification_content], [created_date], [account_id], [post_id], [status]) VALUES (6, N'123', N'<p><strong>adafasdf</strong></p>', CAST(N'2021-07-04' AS Date), 4, NULL, 1)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post]) VALUES (1, N'Phòng đối diện Chợ Bến Thành, có phòng lớn 40m2Phòng đối diện Chợ Bến Thành, có phòng lớn 40m2', N'ưu tiên người có công ăn chuyện làm, ở sạch sẽ', N'- phòng diện tích: 9m2-15m2 (phòng trọ đơn) - 40m2 ( dạng căn hộ 2 phòng ngủ,phòng khách, bếp), giá cả bình dân phù hợp dân văn phòng, sinh viên, lao động. Phòng riêng biệt
- vị trí năm đối diện chợ bến thành, huận tiện vừa ở vừa kinh doanh online
- giờ giấc tự do 24/24, không chung chủ
- không giới hạn người ở
- sạch sẽ, camera an ninh nên tiện ai muốn ở lâu dài
- ưu tiên người có công ăn chuyện làm, ở sạch sẽ', 2, 1, 1, CAST(N'2021-06-20' AS Date), NULL, N'phong-doi-dien-cho-ben-thanh-co-phong-lon-40m2', N'/Public/images/post/nhatro1.jpg', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post]) VALUES (2, N'Cho thuê phòng trọ Quận 1, diên tích 45m2 khu VIP Nguyễn Trãi free dịch vụ', N'phòng còn trống', N'<p><strong>Cho thuê nhiều phòng trọ đầy đủ nội thất diện tích từ 25m2 đến 45m2 , giá từ 5 đến 7 triệu có hỗ trợ mùa dịch, miễn phí tất cả dịch vụ kèm theo như wifi tốc độ cao, tivi, giữ xe, máy giặt, liên hệ trưc tiếp chủ nhà</strong></p>', 2, 2, 2, CAST(N'2021-06-20' AS Date), CAST(N'2021-07-04' AS Date), N'cho-thue-phong-tro-quan-1-dien-tich-45m2-khu-vip-nguyen-trai-free-dich-vuTnPCF20vk2uEklIoDrf2Q', N'/Public/images/motel/nhatro4.jpg', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post]) VALUES (2013, N'Cho thuê phòng mới xây, có nội thất DT 20m2, giá chỉ từ 4,5 -5,5tr/tháng, đường Trần Hưng Đạo, Quận 1', N'Cho thuê phòng đẹp, mới xây, có nội thất, ngay trung tâm, yên tĩnh và tự do về giờ giấc. Diện tích 20m2, giá thuê chỉ 4,5-5,5tr/tháng.', N'ồm các thông tin, tiện ích sau:

+ Địa chỉ: Hẻm 261 Trần Hưng Đạo, đối diện khách sạn Pulman 5*

+ Nhà mới xây đẹp, sạch sẽ và yên tĩnh.

+ Ban công, cửa sổ giúp đón những ánh nắng tự nhiên soi sáng căn phòng, những cơn gió mát sảng khoái.

Tiện ích:

+ Giường, nệm, tủ quần áo.

+ Máy lạnh.

+ Kệ bếp.

+ Thang máy.

+ Nhà được trang bị hệ thống internet cực mạnh.

+ Nhà vệ sinh có lavabo, rộng rãi, có phòng tắm được ngăn bằng kính.

+ Nhà được giám sát bằng hệ thống camera.

+ Giờ giấc tự do.', 2, 2014, 1, CAST(N'2021-06-30' AS Date), NULL, N'cho-thue-phong-moi-xay-co-noi-that-dt-20m2-gia-chi-tu-45-55trthang-duong-tran-hung-dao-quan-1', N'/Public/images/motel/motel6.jpg', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post]) VALUES (2014, N'Phòng trọ Quận 1 45m² khu VIP Nguyễn Trãi', N'Cho thuê nhiều phòng trọ đầy đủ nội thất diện tích từ 25m2 đến 45m2', N'Cho thuê nhiều phòng trọ đầy đủ nội thất diện tích từ 25m2 đến 45m2 , giá từ 5 đến 7 triệu có hỗ trợ mùa dịch, miễn phí tất cả dịch vụ kèm theo như wifi tốc độ cao, tivi, giữ xe, máy giặt, liên hệ trưc tiếp chủ nhà', 2, 2015, 1, CAST(N'2021-06-30' AS Date), NULL, N'phong-tro-quan-1-45m-khu-vip-nguyen-trai', N'/Public/images/motel/motel8.jpg', NULL)
INSERT [dbo].[Post] ([post_id], [title], [sub_title], [description], [account_id], [motel_id], [status], [created_date], [updated_date], [slug], [image_post], [code_post]) VALUES (2015, N'Phòng đẹp chính chủ 30m2 đường Đề Thám Quận 1', N'Mình còn 1 phòng duy nhất 30m2 đường Đề Thám. Quận 1', N'- Giá thuê 5tr

- Giờ giấc tự do ( ko chung chủ )

- Ra vào thẻ từ

- Full nội thất

# Nhà setup sẵn dọn vào ở ngay

Liên hệ xem phòng 0906050006 Hà', 2, 2017, 1, CAST(N'2021-06-30' AS Date), NULL, N'phong-dep-chinh-chu-30m2-duong-de-tham-quan-1', N'/Public/images/motel/motel10.jpg', N'S1dHLg0Cu0e8xUSuS7mWmQthanhson')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([report_id], [title], [content_report], [created_date], [status], [post_id]) VALUES (1, N'tieu đe', N'bao cao', CAST(N'2021-07-03' AS Date), 0, 1)
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
SET IDENTITY_INSERT [dbo].[SubDistrict] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeRE] ON 

INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (1, N'Nhà', N'nha', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (2, N'Phòng trọ', N'phong-tro', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (3, N'Thương mại', N'thuong-mai', 1)
INSERT [dbo].[TypeRE] ([type_real_estate_id], [name], [slug], [status]) VALUES (4, N'Căn hộ', N'can-ho', 1)
SET IDENTITY_INSERT [dbo].[TypeRE] OFF
GO
