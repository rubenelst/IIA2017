/****** Script for SelectTopNRows command from SSMS  ******/
--EXEC LogData @TagName='PV', @TagValue=37
SELECT TOP (100) *
  FROM [SCADA].[dbo].[HISTORY] 
  WHERE TagId = 1
  ORDER BY HistoryId DESC 

  SELECT TOP (100) *
  FROM [SCADA].[dbo].[TAG]

  SELECT TOP (100) *
  FROM [SCADA].[dbo].[ALARM]
  ORDER BY AlarmId DESC