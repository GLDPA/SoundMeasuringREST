SELECT  Date
FROM dbo.Measurments WHERE Date = CONVERT(nvarchar(max), GETDATE(),112)
