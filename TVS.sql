CREATE DATABASE Cloud_TVSWeb
GO
USE Cloud_TVSWeb
GO
CREATE	TABLE dbo.Questions
		( 
			qsId INT PRIMARY KEY NOT NULL,
			qsTitle NVARCHAR(50),
			qsContent NVARCHAR(500) NOT NULL,
		)
GO
INSERT dbo.Questions
        ( qsId, qsTitle, qsContent )
VALUES  ( 1, -- qsID - int
          N'Tổng 2 số', -- qsTitle - nvarchar(50)
          N'Cho 2 số thực x và y. Tính tổng 2 số đó'  -- qsContent - nvarchar(500)
          )
INSERT dbo.Questions
        ( qsId, qsTitle, qsContent )
VALUES  ( 2, -- qsID - int
          N'Hiệu 2 số', -- qsTitle - nvarchar(50)
          N'Cho 2 số thực x và y. Tính hiệu 2 số đó'  -- qsContent - nvarchar(500)
          )
INSERT dbo.Questions
        ( qsId, qsTitle, qsContent )
VALUES  ( 3, -- qsID - int
          N'Tích 2 số', -- qsTitle - nvarchar(50)
          N'Cho 2 số thực x và y. Tính tích 2 số đó'  -- qsContent - nvarchar(500)
          )
INSERT dbo.Questions
        ( qsId, qsTitle, qsContent )
VALUES  ( 4, -- qsID - int
          N'Thương 2 số', -- qsTitle - nvarchar(50)
          N'Cho 2 số thực x và y. Tính thương 2 số đó'  -- qsContent - nvarchar(500)
          )
