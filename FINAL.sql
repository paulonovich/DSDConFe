USE [BDDOCUMENTUM]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[codigoExpediente] [int] NULL,
	[FechaEmision] [datetime] NULL,
	[Recepcionista] [nvarchar](200) NULL,
	[Solicitante] [nvarchar](200) NULL,
	[Estado] [nvarchar](200) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expediente]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expediente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[codigoSolicitante] [int] NULL,
	[codigoTramite] [int] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Expediente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitante]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Solicitante](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NULL,
	[apellido] [varchar](200) NULL,
	[dni] [varchar](8) NULL,
	[telefono] [varchar](15) NULL,
	[correo] [varchar](200) NULL,
	[direccion] [varchar](200) NULL,
 CONSTRAINT [PK_Solicitante] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tramite]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tramite](
	[codigo] [int] NOT NULL,
	[nombre] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tramite] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tupa]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tupa](
	[codigo] [int] NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[codigoTramite] [int] NULL,
 CONSTRAINT [PK_Tupa] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[DNI] [nvarchar](8) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Tipo] [nvarchar](1) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Evaluacion]    Script Date: 07/08/2015 09:36:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*zzevallos@ayd.com.pe
zaili*/
CREATE VIEW [dbo].[Evaluacion]
AS
SELECT        expe.codigo AS codigoExpediente, expe.codigoTramite AS Tramite, soli.nombre + ' ' + soli.apellido AS Solicitante, '' AS 'Recepcionista', expe.Estado
FROM            dbo.Expediente AS expe INNER JOIN
                         dbo.Solicitante AS soli ON soli.codigo = expe.codigoSolicitante

GO
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Expediente] FOREIGN KEY([codigoExpediente])
REFERENCES [dbo].[Expediente] ([codigo])
GO
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Expediente]
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD  CONSTRAINT [FK_Expediente_Solicitante] FOREIGN KEY([codigoSolicitante])
REFERENCES [dbo].[Solicitante] ([codigo])
GO
ALTER TABLE [dbo].[Expediente] CHECK CONSTRAINT [FK_Expediente_Solicitante]
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD  CONSTRAINT [FK_Expediente_Tramite] FOREIGN KEY([codigoTramite])
REFERENCES [dbo].[Tramite] ([codigo])
GO
ALTER TABLE [dbo].[Expediente] CHECK CONSTRAINT [FK_Expediente_Tramite]
GO
ALTER TABLE [dbo].[Tupa]  WITH CHECK ADD  CONSTRAINT [FK_Tupa_Tramite] FOREIGN KEY([codigoTramite])
REFERENCES [dbo].[Tramite] ([codigo])
GO
ALTER TABLE [dbo].[Tupa] CHECK CONSTRAINT [FK_Tupa_Tramite]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "expe"
            Begin Extent = 
               Top = 11
               Left = 25
               Bottom = 140
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "soli"
            Begin Extent = 
               Top = 28
               Left = 331
               Bottom = 157
               Right = 540
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Evaluacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Evaluacion'
GO
