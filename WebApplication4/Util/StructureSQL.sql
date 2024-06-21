
/*
CREATE TABLE [dbo].[ATEEI_SRTP_ProductTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocEntry] [int] NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Serial] [nvarchar](36) NULL,
	[Status] [varchar](3) NULL,
	[DateRealese] [datetime] NULL,
	[PlanInspCode] [nvarchar](50) NULL,
	[UserRealese] [int] NULL,
	[Quantity] [numeric](19, 6) NULL,
	[TimeRegisterId] [int] NULL,
	[AdmSerialType] [nvarchar](6) NULL,
	[Justify] [nvarchar](50) NULL,
	[Comments] [ntext],
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ATEEI_SRTP_ProductTest]  WITH CHECK ADD FOREIGN KEY([TimeRegisterId])
REFERENCES [dbo].[ATEEI_SRTP_RG_TEMPO] ([ID])
GO



CREATE TABLE [dbo].[ATEEI_SRTP_ProductTestLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTestId] [int] NULL,
	[ParamId] [nvarchar](50) NULL,
	[ParamCode] [nvarchar](50) NULL,	
	[Status] [varchar](3) NULL,
	[Comments] [text] NULL,
	[DateRealese] [datetime] NULL,
	[UserRealese] [int] NULL,
	[BlockQty] [numeric](19, 6) NULL,
	[Justify] [nvarchar](50) NULL,
	[Mandatory] [nvarchar](3) NULL,
	[Description] [nText] NULL,
	[Measurement] [nvarchar](36) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ATEEI_SRTP_ProductTestLines]  WITH CHECK ADD FOREIGN KEY([ProductTestId])

REFERENCES [dbo].[ATEEI_SRTP_ProductTest] ([ID])

*/