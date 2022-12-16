CREATE TABLE [dbo].[Tb_Productos](
	[IdProducto] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion_breve] [nvarchar](50) NULL,
	[IdCategoria] [numeric](18, 0) NULL,
	[ImagenProducto] [image] NULL,
 CONSTRAINT [PK_Tb_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
))