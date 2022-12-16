CREATE TABLE [dbo].[Tb_Categoria](
	[IdCategoria] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tb_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
))