CREATE TABLE [dbo].[PagoEmpleado](
	[foliopagar] [int] IDENTITY(3000,1) NOT NULL,
	[foliocaptura] [int] NOT NULL,
	[empleado] [int] NOT NULL,
	[nombres] [varchar](120) NOT NULL,
	[sueldobase] [int] NOT NULL,
	[bonotrabajo] [int] NOT NULL,
	[entregas] [int] NOT NULL,
	[vales] [decimal](18, 2) NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[isr] [decimal](18, 2) NOT NULL,
	[totalpagar] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PagoEmpleado] PRIMARY KEY CLUSTERED 
(
	[foliopagar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
