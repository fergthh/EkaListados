USE [Eka]
GO
/****** Object:  Table [dbo].[Abogado]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abogado](
	[Codigo] [int] NULL,
	[Nombre] [char](50) NULL,
	[Empresa] [int] NULL,
	[Clave] [char](10) NULL,
	[Tipo] [int] NULL,
	[Descripcion] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asunto]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asunto](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL,
	[DescripcionII] [char](50) NULL,
	[Cliente] [int] NULL,
	[Empresa] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Empresa] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cierre]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cierre](
	[Mes] [int] NULL,
	[Ano] [int] NULL,
	[Estado] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cliente] [int] NULL,
	[Razon] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[Provincia] [nvarchar](2) NULL,
	[Postal] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Fax] [nvarchar](30) NULL,
	[Telefono] [nvarchar](30) NULL,
	[Cuit] [nvarchar](15) NULL,
	[Observaciones] [nvarchar](100) NULL,
	[Iva] [nvarchar](1) NULL,
	[Importe1] [float] NULL,
	[Importe2] [float] NULL,
	[Importe3] [float] NULL,
	[Importe4] [float] NULL,
	[Importe5] [float] NULL,
	[Importe6] [float] NULL,
	[Dias] [int] NULL,
	[Empresa] [int] NULL,
	[Socio] [int] NULL,
	[Descuento] [float] NULL,
	[Marca] [char](10) NULL,
	[Celular] [char](20) NULL,
	[Contacto] [char](20) NULL,
	[SocioII] [int] NULL,
	[Pais] [char](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concepto](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Importe] [float] NULL,
	[Cuenta] [char](10) NULL,
	[Empresa] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Impre1] [char](50) NULL,
	[Impre2] [char](50) NULL,
	[Impre3] [char](50) NULL,
	[Impre4] [char](50) NULL,
	[Impre5] [char](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planilla]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planilla](
	[Clave] [nvarchar](14) NULL,
	[Abogado] [int] NULL,
	[Fecha] [char](10) NULL,
	[OrdFecha] [char](8) NULL,
	[Renglon] [int] NULL,
	[Cliente] [int] NULL,
	[Asunto] [int] NULL,
	[Horas] [float] NULL,
	[HorasII] [float] NULL,
	[Concepto] [int] NULL,
	[Importe] [float] NULL,
	[Neto] [float] NULL,
	[Iva] [float] NULL,
	[Factura] [float] NULL,
	[Tipo] [char](1) NULL,
	[Observaciones] [nvarchar](50) NULL,
	[Precio] [float] NULL,
	[Monto] [float] NULL,
	[Auxiliar1] [float] NULL,
	[Auxiliar2] [float] NULL,
	[Auxiliar3] [float] NULL,
	[Auxiliar4] [float] NULL,
	[Auxiliar5] [float] NULL,
	[Auxiliar6] [float] NULL,
	[Auxiliar7] [float] NULL,
	[Auxiliar8] [float] NULL,
	[Auxiliar9] [float] NULL,
	[Auxiliar10] [float] NULL,
	[Empresa] [int] NULL,
	[WHoras] [float] NULL,
	[WHorasII] [float] NULL,
	[Minutos] [int] NULL,
	[MinutosII] [int] NULL,
	[TipoHora] [char](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precios]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precios](
	[Clave] [char](6) NULL,
	[Abogado] [int] NULL,
	[Renglon] [int] NULL,
	[Cliente] [int] NULL,
	[Importe] [float] NULL,
	[Empresa] [int] NULL,
	[Asunto] [int] NULL,
	[Categoria] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 28/11/2018 06:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socios](
	[Codigo] [int] NULL,
	[Descripcion] [char](50) NULL,
	[Empresa] [int] NULL
) ON [PRIMARY]
GO
