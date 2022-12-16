ALTER TABLE [dbo].[Tb_Productos]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Productos_Tb_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Tb_Categoria] ([IdCategoria])
GO

ALTER TABLE [dbo].[Tb_Productos] CHECK CONSTRAINT [FK_Tb_Productos_Tb_Categoria]
GO