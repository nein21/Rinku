CREATE TABLE [dbo].[CapturaFolio](
	[folio] [int] IDENTITY(2000,1) NOT NULL,
	[idempleado] [int] NOT NULL,
	[nombre] [varchar](120) NOT NULL,
	[cantidad] [int] NOT NULL,
	[turno] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[idpagoempleado] [int] NOT NULL,
 CONSTRAINT [PK_CapturaFolio] PRIMARY KEY CLUSTERED 
(
	[folio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
