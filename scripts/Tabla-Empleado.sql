CREATE TABLE [dbo].[Empleado](
	[idempleado] [int] IDENTITY(1000,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apaterno] [varchar](40) NOT NULL,
	[amaterno] [varchar](40) NOT NULL,
	[tipo] [int] NOT NULL,
	[rol] [int] NOT NULL,
 CONSTRAINT [PK_Empleado_1] PRIMARY KEY CLUSTERED 
(
	[idempleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]